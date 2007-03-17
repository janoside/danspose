using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Triggers {

	public interface IMouseListener {

		void OnMouseActivity(MouseEventArgs mea);
	}
}
