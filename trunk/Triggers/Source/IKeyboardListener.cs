using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Triggers {
	
	public interface IKeyboardListener {

		void OnKeyUp(KeyEventArgs kea);
	}
}
