using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forefront {
	
	public static class Program {

		[STAThread]
		public static void Main() {
			ForefrontForm form = new ForefrontForm(
				new string[] { "Mozilla Firefox/Mozilla Firefox", "Microsoft Visual/Visual Studio" }
			);

			try {

				Application.Run(form);
			} catch ( Exception e ) {
				form.Hide();

				int x = 5;
				int y = x + x;
			}
		}
	}
}
