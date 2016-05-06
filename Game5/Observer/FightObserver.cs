using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game5.Observer
{
	interface FightObserver
	{
		void Notify(string State);
	}
}
