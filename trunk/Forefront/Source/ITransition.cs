using System;
using System.Collections.Generic;
using System.Text;

namespace Dansposé {
	
	public interface ITransition {

		float Progress {
			set;
		}

		void End();
	}
}
