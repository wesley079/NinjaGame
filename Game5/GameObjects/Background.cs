using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game5.GameObjects
{
	class Background:GameObject
	{
			public Background(Game1 Game){
			Texture		= AssetsManager.Textures[Assets.BACKGROUND];
			Position	= new Vector2(0,0);
			Color		= Color.White;
			Scale		= 1f;
			}

			public override void Update()
			{
				if (Keyboard.GetState().IsKeyDown(Keys.Right))
				{
					Position = new Vector2(Position.X - 5, Position.Y);
					
					if (Position.X + Texture.Width < 0)
					{
						Position = new Vector2(Texture.Width -5 , Position.Y);
					}
				}
				if (Keyboard.GetState().IsKeyDown(Keys.Left))
				{
					Position = new Vector2(Position.X + 5, Position.Y);

					if (Position.X + Texture.Width > Texture.Width*2)
					{
						Position = new Vector2(-Texture.Width + 5, Position.Y);
					}
				}
			

				base.Update();
			}
	}
}
