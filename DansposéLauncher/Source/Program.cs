using System;
using System.Collections.Generic;
using System.Text;

namespace DansposéLauncher {
	
	public static class Program {

		[STAThread]
		public static void Main() {
			Launcher launcher = new Launcher();
			try {
				System.Windows.Forms.Application.EnableVisualStyles();
				launcher.Run();
			} catch ( Exception e ) {
				launcher.DansposéForm.Hide();
				System.Windows.Forms.MessageBox.Show(e.Message + "\n\n" + e.StackTrace);
			}
		}
	}
}
