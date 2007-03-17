using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Triggers {
	
	public class KeyUpTrigger : Trigger, IKeyboardListener {

		private Keys fKey;

		public KeyUpTrigger(Keys k) {
			this.fKey = k;
		}

		#region IKeyboardListener Members

		public void OnKeyUp(System.Windows.Forms.KeyEventArgs kea) {
			if ( kea.KeyCode == this.fKey ) {
				this.OnTriggered();
			}
		}

		#endregion
	}
}
