using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Diagnostics;
using System.IO;

using VistaDwmApi;

using Triggers;

namespace Forefront {

	public class ForefrontForm : Form {

		private VistaWindowManager fWindowManager;

		private VistaWindowManager fSecondaryWindowManager;

		private ThumbnailGrid fThumbnailGrid;

		private List<ITransition> fWindowTransitions;

		private TriggerManager fTriggerManager;

		private Animation fAnimation;

		private object fSelectedObject;

		private float fBackgroundOpacity;

		private float fThumbnailOpacity;

		private bool fFocusedOnGroup;

		private bool fAnimating;

		private bool fEnding;

		private bool fSkipShow;

		public ForefrontForm(IEnumerable<string> groups) {
			this.fWindowManager = new VistaWindowManager(
				new IntPtr[] { this.Handle },
				groups);

			this.fSecondaryWindowManager = new VistaWindowManager(
				new IntPtr[] { this.Handle },
				groups);

			this.fThumbnailGrid = new ThumbnailGrid();

			this.fWindowTransitions = new List<ITransition>();
			this.fTriggerManager = new TriggerManager(true, true);
			this.fTriggerManager.Triggered += delegate {
				if ( !this.Visible || this.fFocusedOnGroup ) {
					this.fFocusedOnGroup = false;
					this.fEnding = false;

					this.OnLoad(EventArgs.Empty);
					this.Show();
					this.Focus();
				}
			};

			this.BackColor = Color.Black;
			this.FormBorderStyle = FormBorderStyle.None;
			this.TopMost = true;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Font = new Font("Segoe UI", 10, FontStyle.Bold);
			this.fFocusedOnGroup = false;
			this.Left = Screen.PrimaryScreen.Bounds.Left;
			this.Top = Screen.PrimaryScreen.Bounds.Top;
			this.Width = Screen.PrimaryScreen.Bounds.Width;
			this.Height = Screen.PrimaryScreen.Bounds.Height;
			this.fEnding = false;
			this.fAnimating = false;
			this.fSkipShow = false;
			this.fThumbnailOpacity = 0.5f;
			this.fBackgroundOpacity = 0;//			0.2f;

			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);

			this.fAnimation = new Animation(0.2f);
			this.fAnimation.Completed += delegate {
				foreach ( ITransition transition in this.fWindowTransitions ) {
					transition.End();
				}
				this.fAnimating = false;
				this.fWindowTransitions.Clear();

				if ( this.fEnding ) {
					this.Hide();
				}
			};
		}

		public float AnimationLength {
			set {
				this.fAnimation.Length = value;
			}
		}

		public float BackgroundOpacity {
			set {
				this.fBackgroundOpacity = value;
			}
		}

		public float ThumbnailOpacity {
			set {
				this.fThumbnailOpacity = value;
			}
		}

		public int BorderWidth {
			set {
				this.fThumbnailGrid.BorderWidth = value;
			}
		}

		public int BorderHeight {
			set {
				this.fThumbnailGrid.BorderHeight = value;
			}
		}

		private string[] LoadGroups() {
			List<string> groups = new List<string>();
			string[] lines = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "\\Configuration.txt");
			foreach ( string line in lines ) {
				if ( line.StartsWith("Group") ) {
					groups.Add(line.Substring(line.IndexOf(" ") + 1));
				}
			}

			return groups.ToArray();
		}

		public TriggerManager TriggerManager {
			get {
				return this.fTriggerManager;
			}
		}

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);

			if ( this.fSkipShow ) {
				this.Hide();
			}
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			this.fSkipShow = false;

			this.fWindowManager.UnregisterAll();
			this.fSecondaryWindowManager.UnregisterAll();

			if ( !this.fFocusedOnGroup ) {
				this.fWindowManager.RefreshWindows();
				if ( this.fWindowManager.ObjectCount == 1 ) {
					this.Hide();
					this.fSkipShow = true;
					return;
				}
			}

			this.fAnimation.Start();
			this.fAnimating = true;

			this.fWindowManager.DesktopWindow.Opacity = this.fBackgroundOpacity;
			this.fWindowManager.DesktopWindow.Rectangle = new Rect(
				0,
				0,
				this.Width,
				this.Height);

			if ( this.fWindowManager.DesktopWindow.RegisterTo(this.Handle) ) {
				this.fWindowManager.DesktopWindow.UpdateThumbnail();
			}

			VistaWindowManager windowManager = (this.fFocusedOnGroup ? this.fSecondaryWindowManager : this.fWindowManager);

			this.fThumbnailGrid.RefreshGrid(
				windowManager,
				this.Handle,
				this.Width,
				this.Height);

			for ( int i = 0; i < windowManager.ObjectCount; i++ ) {
				if ( windowManager[i] is VistaWindow ) {
					VistaWindow vw = (VistaWindow)windowManager[i];
					this.fWindowTransitions.Add(new WindowPositionTransition(
						vw,
						vw.InitialRectangle,
						vw.Rectangle));
				} else if ( windowManager[i] is VistaWindowGroup ) {
					foreach ( VistaWindow vw in ((VistaWindowGroup)windowManager[i]).Windows ) {
						this.fWindowTransitions.Add(new WindowPositionTransition(
						vw,
						vw.InitialRectangle,
						vw.Rectangle));
					}	
				}
			}
		}

		private void DrawHighlightRectangle(Graphics g, RectangleF rect) {
			GraphicsPath gp = new GraphicsPath();
			int y = -2;

			// corner size
			int cs = 5;

			int x = 15;
			gp.AddLine(rect.X - x, rect.Y - y, rect.X + rect.Width + x, rect.Y - y);
			gp.AddArc(rect.X + rect.Width + x, rect.Y - y, cs, cs, 270, 90);
			gp.AddLine(rect.X + rect.Width + x + cs, rect.Y - y + cs, rect.X + rect.Width + x + cs, rect.Y + rect.Height + y - cs);
			gp.AddArc(rect.X + rect.Width + x, rect.Y + rect.Height + y - cs, cs, cs, 0, 90);
			gp.AddLine(rect.X + rect.Width + x, rect.Y + rect.Height + y, rect.X - x, rect.Y + rect.Height + y);
			gp.AddArc(rect.X - x - cs, rect.Y + rect.Height + y - cs, cs, cs, 90, 90);
			gp.AddLine(rect.X - x - cs, rect.Y + rect.Height + y - cs, rect.X - x - cs, rect.Y - y + cs);
			gp.AddArc(rect.X - x - cs, rect.Y - y, cs, cs, 180, 90);

			g.FillPath(Brushes.White, gp);
		}

		private void DrawLabels(Graphics g) {
			if ( !this.fFocusedOnGroup ) {
				foreach ( VistaWindowGroup group in this.fWindowManager.ActiveGroups ) {
					Rectangle rect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);//					this.fThumbnailGrid.GetRectangle(group);

					foreach ( VistaWindow vw in group.Windows ) {
						Rectangle vwRect = Utility.RectangleFromRect(vw.VisibleRectangle);

						rect.X = Math.Min(rect.X, vwRect.Left);
						rect.Y = Math.Min(rect.Y, vwRect.Top);
						rect.Width = Math.Max(rect.X + rect.Width, vwRect.Right) - rect.X;
						rect.Height = Math.Max(rect.Y + rect.Height, vwRect.Bottom) - rect.Y;
					}

					SizeF size = g.MeasureString(group.Name, this.Font);

					if ( size.Width > rect.Width - 25 ) {
						size.Width = rect.Width - 25;
					}

					RectangleF textRect = new RectangleF(
						rect.X + (rect.Width - size.Width) / 2,
						rect.Y + rect.Height,
						size.Width,
						size.Height);

					this.DrawHighlightRectangle(g, textRect);

					g.DrawString(
						group.Name,
						this.Font,
						Brushes.Black,
						textRect);
				}
				foreach ( VistaWindow vw in this.fWindowManager.Windows ) {
					SizeF size = g.MeasureString(vw.Title, this.Font);

					int width = vw.Rectangle.Right - vw.Rectangle.Left;
					int height = vw.Rectangle.Bottom - vw.Rectangle.Top;
					if ( size.Width > width - 25 ) {
						size.Width = width - 25;
					}

					RectangleF textRect = new RectangleF(
						vw.Rectangle.Left + (width - size.Width) / 2,
						vw.Rectangle.Bottom - (height - vw.ScaledSize.Y) / 2,
						size.Width,
						size.Height);

					this.DrawHighlightRectangle(g, textRect);

					g.DrawString(
						vw.Title,
						this.Font,
						Brushes.Black,
						textRect);
				}
			} else {
				foreach ( VistaWindow vw in this.fSecondaryWindowManager.Windows ) {
					SizeF size = g.MeasureString(vw.Title, this.Font);

					int width = vw.Rectangle.Right - vw.Rectangle.Left;
					int height = vw.Rectangle.Bottom - vw.Rectangle.Top;
					if ( size.Width > width - 25 ) {
						size.Width = width - 25;
					}

					RectangleF textRect = new RectangleF(
						vw.Rectangle.Left + (width - size.Width) / 2,
						vw.Rectangle.Bottom - (height - vw.ScaledSize.Y) / 2,
						size.Width,
						size.Height);

					this.DrawHighlightRectangle(g, textRect);

					g.DrawString(
						vw.Title,
						this.Font,
						Brushes.Black,
						textRect);
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			//e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

			this.DrawLabels(e.Graphics);

			this.fAnimation.Update();
			foreach ( ITransition transition in this.fWindowTransitions ) {
				transition.Progress = this.fAnimation.Progress;
			}

			// must simulate mouse movement during animation to properly update opacities
			if ( this.fWindowTransitions.Count > 0 ) {
				this.OnMouseMove(new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
			}

			this.Invalidate();
			/*
			if ( this.fSelectedWindow != null ) {
				Rectangle rect = this.fWindowRectangles[this.fSelectedWindow];
				e.Graphics.FillRectangle(
					new LinearGradientBrush(new Point(rect.Left, rect.Top), new Point(rect.Left+rect.Width, rect.Top+rect.Height), Color.White, Color.Black),
					rect);
			}

			this.Invalidate();*/
		}

		protected override void OnMouseClick(MouseEventArgs e) {
			base.OnMouseClick(e);

			if ( e.Button == MouseButtons.Left ) {
				if ( this.fSelectedObject != null ) {
					if ( this.fSelectedObject is VistaWindowGroup ) {
						VistaWindowGroup group = (VistaWindowGroup)this.fSelectedObject;
						if ( group.WindowCount == 1 ) {
							this.SelectWindow(group[0]);
						} else {
							for ( int i = 0; i < this.fWindowManager.ObjectCount; i++ ) {
								if ( this.fWindowManager[i] is VistaWindow ) {
									this.fWindowTransitions.Add(new WindowOpacityTransition(
										(VistaWindow)this.fWindowManager[i],
										((VistaWindow)this.fWindowManager[i]).Opacity,
										0));
								} else if ( this.fWindowManager[i] is VistaWindowGroup ) {
									if ( this.fWindowManager[i] != group ) {
										foreach ( VistaWindow vw in ((VistaWindowGroup)this.fWindowManager[i]).Windows ) {
											this.fWindowTransitions.Add(new WindowOpacityTransition(
												vw,
												vw.Opacity,
												0));
										}
									}
								}
							}

							foreach ( VistaWindow vw in group.Windows ) {
								vw.InitialRectangle = vw.Rectangle;
							}
							this.fSecondaryWindowManager.RefreshWindows(
								group.Windows,
								false,
								false);

							this.fWindowManager.UnregisterAll();

							this.fFocusedOnGroup = true;
							this.OnLoad(EventArgs.Empty);
						}
					} else if ( this.fSelectedObject is VistaWindow ) {
						this.SelectWindow((VistaWindow)this.fSelectedObject);
					}
				} else {
					this.EndExpose();
				}
			} else if ( e.Button == MouseButtons.Right ) {
				
			}
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			base.OnMouseMove(e);

			if ( !this.fEnding ) {
				if ( !this.fFocusedOnGroup ) {
					this.fSelectedObject = null;
					foreach ( VistaWindow vw in this.fWindowManager.Windows ) {
						if ( vw.IsCovering(e.X, e.Y, true) ) {
							this.fSelectedObject = vw;
							vw.Opacity = 1;
						} else {
							vw.Opacity = this.fThumbnailOpacity;
						}
					}

					foreach ( VistaWindowGroup group in this.fWindowManager.Groups ) {
						bool hit = false;
						foreach ( VistaWindow vw in group.Windows ) {
							if ( vw.IsCovering(e.X, e.Y, true) ) {
								this.fSelectedObject = group;
								hit = true;
								break;
							}
						}
						foreach ( VistaWindow vw in group.Windows ) {
							vw.Opacity = (hit ? 1 : this.fThumbnailOpacity);
						}
					}
				} else {
					this.fSelectedObject = null;
					foreach ( VistaWindow vw in this.fSecondaryWindowManager.Windows ) {
						if ( vw.IsCovering(e.X, e.Y, true) ) {
							this.fSelectedObject = vw;
							vw.Opacity = 1;
						} else {
							vw.Opacity = this.fThumbnailOpacity;
						}
					}
				}
			}
		}

		private void EndExpose() {
			VistaWindowManager windowManager = (this.fFocusedOnGroup ? this.fSecondaryWindowManager : this.fWindowManager);
			//this.Hide();
			for ( int i = 0; i < windowManager.ObjectCount; i++ ) {
				if ( windowManager[i] is VistaWindow ) {
					VistaWindow vw = (VistaWindow)windowManager[i];
					this.fWindowTransitions.Add(new WindowPositionTransition(
						vw,
						vw.Rectangle,
						this.fWindowManager.GetOriginalLocation(vw)));
				} else if ( windowManager[i] is VistaWindowGroup ) {
					foreach ( VistaWindow vw in ((VistaWindowGroup)windowManager[i]).Windows ) {
						this.fWindowTransitions.Add(new WindowPositionTransition(
							vw,
							vw.Rectangle,
							this.fWindowManager.GetOriginalLocation(vw)));
					}
				}
			}
			this.fAnimation.Start();
			this.fAnimating = true;
			this.fEnding = true;
		}

		private void SelectWindow(VistaWindow vw) {
			vw.Opacity = 1;
			vw.BringToFront(this.Handle);

			this.EndExpose();

			if ( vw.IsMinimized ) {
				User32.ShowWindow(vw.Handle, VistaDwm.SW_RESTORE);
			} else {
				if ( vw.Title == "Desktop" ) {
					VistaDwm.MinimizeAllWindows();
				} else {
					User32.SetForegroundWindow(vw.Handle);
					User32.SetFocus(vw.Handle);
				}
			}
		}

		public void SetGroups(IEnumerable<string> groups) {
			this.fWindowManager.UnregisterAll();
			this.fSecondaryWindowManager.UnregisterAll();

			this.fWindowManager = new VistaWindowManager(
				new IntPtr[] { this.Handle },
				groups);

			this.fSecondaryWindowManager = new VistaWindowManager(
				new IntPtr[] { this.Handle },
				groups);
		}
	}
}
