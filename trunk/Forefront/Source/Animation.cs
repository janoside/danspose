using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Dansposé {
	
	public class Animation {

		public event EventHandler Completed;

		private Stopwatch fStopwatch;

		private float fLength;

		private float fTime;

		public Animation(float length) {
			this.fStopwatch = new Stopwatch();
			this.fLength = length;
			this.fTime = 0;
		}

		public float Length {
			get {
				return this.fLength;
			}
			set {
				this.fLength = value;
			}
		}

		public float Progress {
			get {
				return this.fTime / this.fLength;
			}
		}

		public void Start() {
			this.fTime = 0;
			this.fStopwatch.Reset();
			this.fStopwatch.Start();
		}

		public void Update() {
			this.fTime = this.fStopwatch.ElapsedMilliseconds / 1000.0f;
			if ( this.fTime >= this.fLength ) {
				if ( this.Completed != null ) {
					this.Completed(this, EventArgs.Empty);
				}
			}
		}
	}
}
