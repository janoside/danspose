using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Dansposé {
	
	public static class Program {

		[STAThread]
		public static void Main() {
			DansposéForm form = new DansposéForm();

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
