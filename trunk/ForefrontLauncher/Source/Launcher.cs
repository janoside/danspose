using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using DansposéLauncher.Properties;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

using Triggers;

using VistaDwmApi;

using Dansposé;

namespace DansposéLauncher {

	public partial class Launcher : System.Windows.Application {

		private DansposéForm fForm;

		private NotifyIcon fTrayIcon;

		public Launcher() {
			this.fForm = new DansposéForm();

			this.fTrayIcon = new NotifyIcon();
			this.fTrayIcon.Text = "Dansposé: Running";
			this.fTrayIcon.Icon = DansposéLauncher.Properties.Resources.DansposéIconSmall;
			this.fTrayIcon.BalloonTipText = "To exit Dansposé, right click on this icon and click exit";
			this.fTrayIcon.BalloonTipIcon = ToolTipIcon.Info;
			this.fTrayIcon.BalloonTipTitle = "Dansposé is running";

			ContextMenu menu = new ContextMenu();

			MenuItem settingsItem = menu.MenuItems.Add("Settings");
			menu.MenuItems.Add("-");
			MenuItem activeItem = menu.MenuItems.Add("Disable");
			menu.MenuItems.Add("-");
			MenuItem exitItem = menu.MenuItems.Add("Exit");

			settingsItem.Click += delegate {
				SettingsForm configForm = new SettingsForm(this);
				configForm.ShowDialog();
			};
			activeItem.Click += delegate {
				this.fForm.TriggerManager.IsActive = !this.fForm.TriggerManager.IsActive;
				activeItem.Text = (this.fForm.TriggerManager.IsActive ? "Disable" : "Enable");
				this.fTrayIcon.Text = (this.fForm.TriggerManager.IsActive ? "Dansposé: Running" : "Dansposé: Disabled");
			};
			exitItem.Click += delegate {
				this.fTrayIcon.Visible = false;
				this.Shutdown();
			};

			this.fTrayIcon.ContextMenu = menu;
		}

		public DansposéForm DansposéForm {
			get {
				return this.fForm;
			}
		}

		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);

			this.LoadSettings();

			this.fTrayIcon.Visible = true;
			this.fTrayIcon.ShowBalloonTip(2000);
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
	}
}