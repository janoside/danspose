using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Forefront {
	
	public static class GdiUtil {

		public static Image ImageFromText(string strText, Font fnt, Color clrFore, Color clrBack, int blurAmount) {
			Bitmap bmpOut = null; // bitmap we are creating and will return from this function.

			using ( Graphics g = Graphics.FromHwnd(IntPtr.Zero) ) {
				SizeF sz = g.MeasureString(strText, fnt);
				using ( Bitmap bmp = new Bitmap((int)sz.Width, (int)sz.Height) )
				using ( Graphics gBmp = Graphics.FromImage(bmp) )
				using ( SolidBrush brBack = new SolidBrush(Color.FromArgb(16, clrBack.R, clrBack.G, clrBack.B)) )
				using ( SolidBrush brFore = new SolidBrush(clrFore) ) {
					gBmp.SmoothingMode = SmoothingMode.HighQuality;
					gBmp.InterpolationMode = InterpolationMode.HighQualityBilinear;
					gBmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

					gBmp.DrawString(strText, fnt, brBack, 0, 0);

					// make bitmap we will return.
					bmpOut = new Bitmap(bmp.Width + blurAmount, bmp.Height + blurAmount);
					using ( Graphics gBmpOut = Graphics.FromImage(bmpOut) ) {
						gBmpOut.SmoothingMode = SmoothingMode.HighQuality;
						gBmpOut.InterpolationMode = InterpolationMode.HighQualityBilinear;
						gBmpOut.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

						// smear image of background of text about to make blurred background "halo"
						for ( int x = 0; x <= blurAmount; x++ )
							for ( int y = 0; y <= blurAmount; y++ )
								gBmpOut.DrawImageUnscaled(bmp, x, y);

						// draw actual text
						gBmpOut.DrawString(strText, fnt, brFore, blurAmount / 2, blurAmount / 2);
					}
				}
			}

			return bmpOut;
		}

		public static Bitmap BitmapFromText(string text, Font f, Color col, Color glowCol, Rectangle rect, float glowScale) {
			Bitmap bm = new Bitmap((int)(rect.Width / glowScale), (int)(rect.Height / glowScale));
			GraphicsPath pth = new GraphicsPath();
			pth.AddString(text, f.FontFamily, (int)f.Style, f.Size, new Point(rect.Left, rect.Top), StringFormat.GenericTypographic);
			Graphics g = Graphics.FromImage(bm);
			Matrix mx = new Matrix(1.0f / glowScale, 0, 0, 1.0f / glowScale, -(1.0f / glowScale), -(1.0f / glowScale));
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.Transform = mx;
			Pen p = new Pen(glowCol, 3);
			g.DrawPath(p, pth);
			g.FillPath(new SolidBrush(glowCol), pth);
			g.Dispose();

			Bitmap bmp = new Bitmap(rect.Width, rect.Height);
			Graphics g2 = Graphics.FromImage(bmp);
			g2.Transform = new Matrix(1, 0, 0, 1, 50, 50);
			g2.SmoothingMode = SmoothingMode.AntiAlias;
			g2.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g2.DrawImage(bm, rect, 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel);
			g2.FillPath(new SolidBrush(col), pth);
			pth.Dispose();

			return bmp;
		}
	}
}
