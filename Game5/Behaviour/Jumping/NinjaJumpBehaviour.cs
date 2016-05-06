using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game5.GameObjects;
using Microsoft.Xna.Framework;


namespace Game5.Behaviour.Jumping
{
	class NinjaJumpBehaviour:Ijump
	{
		private bool _goingDown;
		private bool heightReached;
		private bool _rotation;
		private float _rotationRadius;

		public bool Jumping { get; set; }


		public void Jump(GameObject o)
		{
			if (o.Direction == 0) { 
				if (_rotation == false && o.Rotation != 360)
				{
					o.Rotation += 0.5f;
					_rotationRadius = o.Rotation;
				}
			}
			if (o.Direction == 1)
			{
				if (_rotation == false && o.Rotation != -360)
				{
					o.Rotation -= 0.5f;
					_rotationRadius = o.Rotation;
				}
			}

				//Go up
				if (o.Position.Y <= 850 && heightReached == false)
				{
					heightReached = false;
					o.Position = new Vector2(o.Position.X, o.Position.Y - 10);
				}	
				//Go down
				if (o.Position.Y < 550 || _goingDown == true)
				{
					heightReached = true;
					_goingDown = true;
					o.Position = new Vector2(o.Position.X, o.Position.Y + 15);
				}
				
				//Check if jump in done
				if(_goingDown == true)
				{
					if (o.Position.Y >= 850)
					{
						//reset
						o.Position = new Vector2(o.Position.X, 850);
						((Ijump)(o)).JumpDone();
						_goingDown = false;
						heightReached = false;
						o.Rotation = 0;
						_rotation = false;
					}
				}
			
		}




		public void JumpDone()
		{
			throw new NotImplementedException();
		}
	}
}
