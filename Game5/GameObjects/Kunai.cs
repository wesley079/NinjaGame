using Game5.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game5
{
	class Kunai:GameObject
	{
		private Game1 _game;
		private NinjaGirl _ninjaGirl;
		private int _direction;
		public Kunai(Game1 Game, NinjaGirl N)
		{
			Texture = AssetsManager.Textures[Assets.KunaiAsset];
			Position = new Vector2(N.Position.X, N.Position.Y);
			Color = Color.White;
			Scale = .4f;
			_ninjaGirl = N;
			_game = Game;
			_direction = N.Direction;
		}

		public override void Update()
		{
			if (_direction == 0) { 
			Position = new Vector2(Position.X +10, Position.Y);
								}
			if (_direction == 1)
			{
				SpriteEffect = SpriteEffects.FlipHorizontally;
				Position = new Vector2(Position.X - 10, Position.Y);
			}    
			CheckBounds();
			base.Update();
		}

		public void CheckBounds()
		{
			if (!this.BoundingBox().Intersects(_game.GraphicsDevice.Viewport.Bounds))
			{
				_ninjaGirl.RemoveKunai(this);
			}

			if (this.BoundingBox().Intersects(World._enemies.First().BoundingBox()))
			{
				World._enemies.First().SetColor();
				if(this.Intersects(World._enemies.First()))
					_ninjaGirl.RemoveKunai(this);
			}	

		}
	}
}
