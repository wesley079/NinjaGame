using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game5.GameObjects;


namespace Game5.Behaviour.Jumping
{
	class NormalJumpBehaviour:Ijump
	{
		private bool _goingDown;
		private bool heightReached;

		public bool Jumping { get; set; }


		public void Jump(GameObject o)
		{

			//Go up
			if (o.Position.Y <= 850 && heightReached == false)
			{
				heightReached = false;
				o.Position = new Vector2(o.Position.X, o.Position.Y - 10);
			}
			//Go down
			if (o.Position.Y < 650 || _goingDown == true)
			{
				heightReached = true;
				_goingDown = true;
				o.Position = new Vector2(o.Position.X, o.Position.Y + 15);
			}

			//Check if jump in done
			if (_goingDown == true)
			{
				if (o.Position.Y == 850)
				{
					//reset
					((Ijump)(o)).JumpDone();
					_goingDown = false;
					heightReached = false;
					o.Rotation = 0;
				}
			}
			
		}


		public void JumpDone()
		{
			throw new NotImplementedException();
		}
	}
}

