using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game5.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game5.GameObjects.BadGuys
{
	abstract class Enemy:GameObject
	{
		public NinjaGirl _ninjaGirl {get; set;}
		public float Speed { get; set; }


		public Enemy()
		{
			Speed = 5;
		}
		public override void Update()
		{
			EnemyLogic();
			
 			base.Update();
			Console.WriteLine(Direction);
		}

		public void Move()
		{
			//Direction logic can be found at: EnemyLogic() - Change direction
			#region Running based on direction

			if (CurrentState == State.Running)
			{
				if (Direction == 0)
				{
					Position = new Vector2(Position.X + Speed, Position.Y);
				}
				if (Direction == 1)
				{
					Position = new Vector2(Position.X - Speed, Position.Y);
				}
			}
			#endregion // end of Running based on direction 

			#region Movement based on player

			//Movement
			if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				Position = new Vector2(Position.X - Speed, Position.Y);

			}
			if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				Position = new Vector2(Position.X + Speed, Position.Y);
			}
			#endregion // end of Movement based on player 
    
		}
		

		public void EnemyLogic()
		{

			#region Change direction
			if (Direction == 0)
			{
				if (_ninjaGirl.Position.X - _ninjaGirl.Texture.Width *Scale < Position.X + Texture.Width*Scale)
				{
					//Face left
					Direction = 1;
					SpriteEffect = SpriteEffects.FlipHorizontally;
				}
			}

			if (Direction == 1)
			{
				if (_ninjaGirl.Position.X > Position.X)
				{
					//Face right
					Direction = 0;
					SpriteEffect = SpriteEffects.None;
				}
			}
			#endregion // end of Change direction 
    
			#region Attack logic

			if (((this.BoundingBox().Intersects((_ninjaGirl.BoundingBox()))) && (_ninjaGirl.Position.Y >= Position.Y) )&& this.Intersects(_ninjaGirl))
			{
				
				CurrentState = State.Attacking;
			}
			else
			{
				CurrentState = State.Running;
			}
			#endregion // end of Attack logic 
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, Position, null, Color, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), Scale, SpriteEffect, 1);
		}
	}
}
