using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using VistaDwmApi;

namespace Forefront {
	
	public class ThumbnailGrid {

		private static int[] columns = new int[]{
			1,//0
			1,//1
			2,//2
			3,//3
			2,//4
			3,//5
			3,
			3,//7
			3,
			3,//9
			4,
			4,//11
			4,
			4,//13
			4,
			4,//15
			4,
			4,
			4,
			4,
			4,
			5,
			5,
			5,
			5
		};

		private static int[] rows = new int[]{
			1,//0
			1,//1
			1,//2
			1,//3
			2,//4
			2,//5
			2,
			3,//7
			3,
			3,//9
			3,
			3,//11
			3,
			4,//13
			4,
			4,//15
			4,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5
		};

		private Rectangle[,] fRectangles;

		private Dictionary<object, Rectangle> fObjectRectangles;

		private int fVisibleObjects;

		private int fBorderWidth;

		private int fBorderHeight;

		public ThumbnailGrid() {
			this.fRectangles = new Rectangle[10, 10];
			this.fObjectRectangles = new Dictionary<object, Rectangle>();
			this.fBorderWidth = 25;
			this.fBorderHeight = 25;
		}

		public int Columns {
			get {
				return columns[this.fVisibleObjects];
			}
		}

		public int Rows {
			get {
				return rows[this.fVisibleObjects];
			}
		}

		public int BorderWidth {
			get {
				return this.fBorderWidth;
			}
			set {
				this.fBorderWidth = value;
			}
		}

		public int BorderHeight {
			get {
				return this.fBorderHeight;
			}
			set {
				this.fBorderHeight = value;
			}
		}

		public void RefreshGrid(VistaWindowManager windowManager, IntPtr hwnd, int w, int h) {
			this.fVisibleObjects = windowManager.ObjectCount;
			this.fObjectRectangles.Clear();

			int width = (int)((w - this.fBorderWidth * (this.Columns + 1)) / this.Columns);
			int height = (int)((h - this.fBorderHeight * (this.Rows + 1)) / this.Rows);

			int xIndex = 0;
			int yIndex = 0;

			int objIndex = 0;
			for ( int x = 0; x < this.Columns; x++ ) {
				for ( int y = 0; y < this.Rows; y++ ) {

					this.fRectangles[x, y] = new Rectangle(
						x * width + this.fBorderWidth * (x + 1),
						y * height + this.fBorderHeight * (y + 1),
						width,
						height);

					object obj = windowManager.GetNextObject();//					windowManager[objIndex++];

					if ( obj is VistaWindow ) {
						VistaWindow window = (VistaWindow)obj;

						window.Rectangle = new VistaDwmApi.Rect(
							x * width + this.fBorderWidth * (x + 1),
							y * height + this.fBorderHeight * (y + 1),
							x * width + this.fBorderWidth * (x + 1) + width,
							y * height + this.fBorderHeight * (y + 1) + height);

						//if ( !this.fObjectRectangles.ContainsKey(window) ) {
							this.fObjectRectangles.Add(window, this.fRectangles[xIndex, yIndex]);
						//}

						if ( window.RegisterTo(hwnd) ) {
							window.UpdateThumbnail();
							window.BringToFront(hwnd);
						}
					} else if ( obj is VistaWindowGroup ) {
						VistaWindowGroup group = (VistaWindowGroup)obj;
						int overlap = 50 / group.WindowCount;
						int index = 0;
						Rectangle rect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);
						
						foreach ( VistaWindow window in group.Windows ) {
							window.Rectangle = new Rect(
								x * width + this.fBorderWidth * (x + 1) + index * overlap,
								y * height + this.fBorderHeight * (y + 1) + index * overlap,
								x * width + this.fBorderWidth * (x + 1) + width - (overlap * (group.WindowCount - 1 - index)),
								y * height + this.fBorderHeight * (y + 1) + height - (overlap * (group.WindowCount - 1 - index)));

							if ( window.RegisterTo(hwnd) ) {
								window.UpdateThumbnail();
								window.BringToFront(hwnd);
							}

							Rectangle vwRect = Utility.RectangleFromRect(window.VisibleRectangle);
							rect.X = Math.Min(rect.X, vwRect.Left);
							rect.Y = Math.Min(rect.Y, vwRect.Top);
							rect.Width = Math.Max(rect.X + rect.Width, vwRect.Right) - rect.X;
							rect.Height = Math.Max(rect.Y + rect.Height, vwRect.Bottom) - rect.Y;

							index++;
						}

						this.fObjectRectangles.Add(group, rect);
					}
				}
			}
		}

		public Rectangle GetRectangle(object obj) {
			return this.fObjectRectangles[obj];
		}
	}
}
