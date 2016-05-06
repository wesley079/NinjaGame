using Game5.GameObjects;
using Game5.GameObjects.Badguys;
using Game5.GameObjects.BadGuys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Game5
{
	class World
	{
		//Fields
		List<GameObject> _gameObjects;
		private NinjaGirl _NinjaGirl;
		private Background _background;
		private Background _backgroundLeft;
		private List<Background> _backgroundList;
		private Ninja _EnemyNinja;
		private Game1 _game;
		public static List<Enemy> _enemies;
		private Ninja _EnemyNinja2;
		
		public World(Game1 game)
		{
			//Initialize world

				//Load gameContent
				AssetsManager.LoadGameContent(game);
				_game = game;

				//GameObjects
				_gameObjects = new List<GameObject>();
				_gameObjects.Add(_background = new Background(game));
				_gameObjects.Add(_backgroundLeft = new Background(game));
				_enemies = new List<Enemy>();

				//add all backgrounds
				_backgroundList = new List<Background>(){
					_background, _backgroundLeft
				};
				_gameObjects.Add(_NinjaGirl = new NinjaGirl(game, _backgroundList));
				
				//Set custom background position
				_backgroundLeft.SpriteEffect = SpriteEffects.FlipHorizontally;
				_backgroundLeft.Position = new Vector2(_backgroundLeft.Texture.Width, _backgroundLeft.Position.Y);
				

				
				
				
		}

		public void Update()
		{
			if (_enemies.Count < 1)
			{
				_enemies.Add(new Ninja(_game, _NinjaGirl));
			}

			_NinjaGirl.Update();



			foreach (Enemy o in _enemies)
			{
				o.Move();
				o.Update();
			}


				_background.Update();
				_backgroundLeft.Update();

				
			
			
			
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			//TO DO: Add draw


			foreach (GameObject g in _gameObjects)
			{
				g.Draw(spriteBatch);
			}
			foreach (Enemy e in _enemies)
			{
				e.Draw(spriteBatch);
			}

			//Overwrite ninjagirl as main layer
			_NinjaGirl.Draw(spriteBatch);
			
		}
	}
}
