using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using ForefrontLauncher.Properties;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

using Triggers;

using VistaDwmApi;

using Forefront;

namespace ForefrontLauncher {

	public partial class App : System.Windows.Application {

	//	private CLimitSingleInstance m_csi;
		private ForefrontForm fForm;
		private NotifyIcon m_oNotifyIcon;

		public ForefrontForm ForefrontForm {
			get {
				return this.fForm;
			}
		}

		protected override void OnStartup(StartupEventArgs e) {
	//		m_csi = new CLimitSingleInstance("Global\\{719967FE-DAC6-43b5-9C61-DE911125C3187}");
	//		if ( m_csi.IsAnotherInstanceRunning() ) {
	//			this.Shutdown();
	//			return;
	//		}

			base.OnStartup(e);

			System.AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
			this.fForm = new ForefrontForm(
				new string[] { "Mozilla Firefox/Mozilla Firefox", "Microsoft Visual/Visual Studio", "Internet Explorer/Internet Explorer" }
			);

			this.LoadSettings();

			ContextMenu menu = new ContextMenu();

			MenuItem configItem = menu.MenuItems.Add("Settings");
			menu.MenuItems.Add("-");
			MenuItem aboutItem = menu.MenuItems.Add("About");
			menu.MenuItems.Add("-");
			MenuItem exitItem = menu.MenuItems.Add("Exit");

			configItem.Click += delegate {
				SettingsForm configForm = new SettingsForm(this);
				configForm.ShowDialog();
			};
			aboutItem.Click += delegate {
				AboutForm af = new AboutForm();
				af.ShowDialog();
			};
			exitItem.Click += delegate {
				this.Shutdown();
			};

			m_oNotifyIcon = new NotifyIcon();
			m_oNotifyIcon.DoubleClick += delegate {
				SettingsForm configForm = new SettingsForm(this);
				configForm.ShowDialog();
			};

			m_oNotifyIcon.Text = "Forefront";
			m_oNotifyIcon.ContextMenu = menu;
			m_oNotifyIcon.Visible = true;

			this.ShowInfoBalloon();
		}

		internal void LoadSettings() {
			string file = System.Windows.Forms.Application.StartupPath + "\\Settings.xml";

			ConfigurationSettings settings;
			if ( File.Exists(file) ) {
				settings = SerializationUtility.DeserializeXmlObject<ConfigurationSettings>(file);
			} else {
				settings = new ConfigurationSettings();
				settings.AnimationLength = 0.2f;
				settings.Groups.Add("Mozilla Firefox/Mozilla Firefox");
				settings.Groups.Add("Microsoft Visual/Visual Studio");
				settings.Groups.Add("Internet Explorer/Internet Explorer");
				settings.Triggers.Add("Key F9");
				settings.Triggers.Add("Corner TopLeft");

				SerializationUtility.SaveObjectToFile(settings, "Settings.xml");
			}

			this.LoadTriggers(settings.Triggers);
			this.fForm.SetGroups(settings.Groups);

			this.fForm.AnimationLength = settings.AnimationLength;
			this.fForm.BorderWidth = settings.BorderWidth;
			this.fForm.BorderHeight = settings.BorderHeight;
			this.fForm.BackgroundOpacity = settings.BackgroundOpacity;
			this.fForm.ThumbnailOpacity = settings.ThumbnailOpacity;
		}

		private void LoadTriggers(IEnumerable<string> triggers) {
			this.fForm.TriggerManager.ClearListeners();

			foreach ( string li in triggers ) {
				if ( li.StartsWith("Key") ) {
					KeyUpTrigger keyTrigger = new KeyUpTrigger((System.Windows.Forms.Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), li.Substring(li.IndexOf(" ") + 1)));
					this.fForm.TriggerManager.AddTrigger(keyTrigger);
				} else if ( li.StartsWith("MouseInCorner") ) {
					MouseInCornerTrigger micTrigger = new MouseInCornerTrigger((MouseCorner)Enum.Parse(typeof(MouseCorner), li.Substring(li.IndexOf(" ") + 1)));
					this.fForm.TriggerManager.AddTrigger(micTrigger);
				}
			}
		}

		private void ShowInfoBalloon() {
			if ( true ) {
				m_oNotifyIcon.Icon = ForefrontLauncher.Properties.Resources.ForefrontIconSmall;
				m_oNotifyIcon.BalloonTipText = "To exit Forefront, right click on this icon and click exit";
				m_oNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
				m_oNotifyIcon.BalloonTipTitle = "Forefront is running";
			} else {
				m_oNotifyIcon.Icon = ForefrontLauncher.Properties.Resources.ForefrontIconSmall;
				m_oNotifyIcon.BalloonTipText = "Forefront needs Aero to run";
				m_oNotifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
				m_oNotifyIcon.BalloonTipTitle = "Forefront is not running";
			}

			m_oNotifyIcon.ShowBalloonTip(2000);
		}

		Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
			string assemblySimpleName = args.Name.Substring(0, args.Name.IndexOf(','));

			string path;

			if ( File.Exists((path = Path.Combine(Path.Combine(Environment.CurrentDirectory, "plugins"), assemblySimpleName + ".dll"))) ) {
				return Assembly.LoadFile(path);

			} else if ( File.Exists((path = Path.Combine(Path.Combine(Environment.CurrentDirectory, "plugins"), assemblySimpleName + ".exe"))) ) {
				return Assembly.LoadFile(path);

			} else {
				throw new InvalidOperationException(string.Format("The referenced assembly \"{0}\" is not in the same directory as the tested assembly", args.Name));
			}
		}

		[STAThread]
		public static void Main() {
			App app = new App();
			try {
				System.Windows.Forms.Application.EnableVisualStyles();
				app.Run();
			} catch ( Exception e ) {
				app.ForefrontForm.Hide();
				System.Windows.Forms.MessageBox.Show(e.Message + "\n\n" + e.StackTrace);
			}
		}
	}
}