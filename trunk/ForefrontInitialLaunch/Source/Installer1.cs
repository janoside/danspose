using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;

namespace ForefrontInitialLaunch {

	[RunInstaller(true)]
	public partial class Installer1 : Installer {

		public Installer1() {
			InitializeComponent();
		}

		public override void Commit(System.Collections.IDictionary savedState) {
			base.Commit(savedState);

			Process.Start("V:\\Program Files\\Forefront\\ForefrontLauncher.exe");
		}
	}
}