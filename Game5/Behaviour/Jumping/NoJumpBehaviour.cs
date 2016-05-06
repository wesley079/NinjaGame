
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game5.GameObjects;


namespace Game5.Behaviour.Jumping
{
	class NoJumpBehaviour:Ijump
	{

		public bool Jumping { get; set; }

		public void Jump(GameObject o)
		{
			//Do nothing
		}


		public void JumpDone()
		{
			throw new NotImplementedException();
		}
	}
}
