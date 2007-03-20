using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;

namespace DansposéInitialLaunch {

	[RunInstaller(true)]
	public partial class DansposéInstallerLaunch : Installer {

		public DansposéInstallerLaunch() {
			InitializeComponent();
		}

		public override void Commit(System.Collections.IDictionary savedState) {
			base.Commit(savedState);

			Process.Start(Environment.SystemDirectory.Substring(0, 3) + "Program Files\\Dansposé\\DansposéLauncher.exe");
		}
	}
}