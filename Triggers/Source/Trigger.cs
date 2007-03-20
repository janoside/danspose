using System;
using System.Collections.Generic;
using System.Text;

namespace Triggers {
	
	public class Trigger {

		private TriggerManager fTriggerManager;

		public Trigger() {
		}

		internal TriggerManager TriggerManager {
			set {
				this.fTriggerManager = value;
			}
		}

		protected void OnTriggered() {
			this.fTriggerManager.OnTriggered();
		}
	}
}
