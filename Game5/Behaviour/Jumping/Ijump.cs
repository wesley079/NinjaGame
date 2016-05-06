using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game5.GameObjects;


namespace Game5.Behaviour.Jumping
{
		public interface Ijump
	{
			//fields

			//Properties
			bool Jumping { get; set; }

			//methods
			void Jump(GameObject o);
			void JumpDone();
	}
}
