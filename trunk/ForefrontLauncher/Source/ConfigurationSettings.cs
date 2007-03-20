using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DansposéLauncher {
	
	[XmlRoot("ConfigurationSettings")]
	public class ConfigurationSettings {

		private List<string> fGroups;

		private List<string> fTriggers;

		private float fAnimationLength;

		private float fBackgroundOpacity;

		private float fThumbnailOpacity;

		private int fBorderWidth;

		private int fBorderHeight;

		public ConfigurationSettings() {
			this.fGroups = new List<string>();
			this.fTriggers = new List<string>();

			this.fAnimationLength = 0.2f;
			this.fBackgroundOpacity = 0.2f;
			this.fBorderWidth = 25;
			this.fBorderHeight = 25;
			this.fThumbnailOpacity = 0.5f;
		}

		public List<string> Groups {
			get {
				return this.fGroups;
			}
		}

		public List<string> Triggers {
			get {
				return this.fTriggers;
			}
		}

		public float AnimationLength {
			get {
				return this.fAnimationLength;
			}
			set {
				this.fAnimationLength = value;
			}
		}

		public float BackgroundOpacity {
			get {
				return this.fBackgroundOpacity;
			}
			set {
				this.fBackgroundOpacity = value;
			}
		}

		public float ThumbnailOpacity {
			get {
				return this.fThumbnailOpacity;
			}
			set {
				this.fThumbnailOpacity = value;
			}
		}

		public int BorderWidth {
			get {
				return this.fBorderWidth;
			}
			set {
				this.fBorderWidth = value;
			}
		}

		public int BorderHeight {
			get {
				return this.fBorderHeight;
			}
			set {
				this.fBorderHeight = value;
			}
		}
	}
}
