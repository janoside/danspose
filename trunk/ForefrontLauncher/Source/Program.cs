using System;
using System.Collections.Generic;
using System.Text;

namespace ForefrontLauncher {
	
	public static class Program {

		[STAThread]
		public static void Main() {
			Launcher launcher = new Launcher();
			try {
				System.Windows.Forms.Application.EnableVisualStyles();
				launcher.Run();
			} catch ( Exception e ) {
				launcher.ForefrontForm.Hide();
				System.Windows.Forms.MessageBox.Show(e.Message + "\n\n" + e.StackTrace);
			}
		}
	}
}
