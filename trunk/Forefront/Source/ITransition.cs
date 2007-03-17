using System;
using System.Collections.Generic;
using System.Text;

namespace Forefront {
	
	public interface ITransition {

		float Progress {
			set;
		}

		void End();
	}
}
