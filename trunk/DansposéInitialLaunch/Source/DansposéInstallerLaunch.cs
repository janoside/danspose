using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;

namespace Danspos�InitialLaunch {

	[RunInstaller(true)]
	public partial class Danspos�InstallerLaunch : Installer {

		public Danspos�InstallerLaunch() {
			InitializeComponent();
		}

		public override void Commit(System.Collections.IDictionary savedState) {
			base.Commit(savedState);

			Process.Start(Environment.SystemDirectory.Substring(0, 3) + "Program Files\\Danspos�\\Danspos�Launcher.exe");
		}
	}
}