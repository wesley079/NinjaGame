using Game5.Behaviour.Jumping;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Game5.GameObjects
{
	class NinjaGirl: GameObject, Ijump
	{
		#region Fields
		#region Lists
		private List<Assets> _IdleSprites;
		private List<Assets> _RunningSprites;
		private List<Assets> _AttackSprites;
		private List<Assets> _JumpingSprites;
		private List<Assets> _ThrowSprites;
		private List<Kunai>	 _Kunais;
		#endregion

		#region variables
		private Game1 _Game;
		private int				_Speed;
		private Ijump			_jumpBehaviour;
		private DateTime		_kunaiThrown;
		private int				_CurrentFrame;
		private DateTime		_jumpTime;
		private List<Background> _backGrounds;
		#endregion

		#region Health
		private int health;

		#endregion // end of Health 
		private SpriteFont _spriteFont;
		private List<Assets> _GetHitSprites;
		#endregion
		
		/// <summary>
		/// Player logics, movement, new kunai's
		/// </summary>
		/// <param name="Game"></param>
		public NinjaGirl(Game1 Game, List<Background> backGrounds)
		{
			#region Basic initialize
			Texture		= AssetsManager.Textures[Assets.NinjaResting0];
			Position	= new Vector2(550,850);
			Color		= Color.White;
			Scale		= .4f;
			_spriteFont = Game.Content.Load<SpriteFont>("verdana");
			health		= 100;
			#endregion

			#region effects
			_Speed = 5;
			CurrentState = State.Normal;
			SpriteEffect = SpriteEffects.None;
			_CurrentFrame = 0;
			Direction = 0;
			#endregion

			#region behaviours
			_Game = Game;
			_jumpBehaviour = new NinjaJumpBehaviour();
			_kunaiThrown = DateTime.Now;
			#endregion
			
			#region Lists initialization
			_IdleSprites = new List<Assets>(){
				Assets.NinjaResting0, Assets.NinjaResting1, Assets.NinjaResting2,
				Assets.NinjaResting3, Assets.NinjaResting4, Assets.NinjaResting5,
				Assets.NinjaResting6, Assets.NinjaResting7, Assets.NinjaResting8, 
				Assets.NinjaResting9
			};
			_RunningSprites = new List<Assets>(){
				Assets.NinjaRunning0, Assets.NinjaRunning1, Assets.NinjaRunning2,
				Assets.NinjaRunning3, Assets.NinjaRunning4, Assets.NinjaRunning5,
				Assets.NinjaRunning6, Assets.NinjaRunning7, Assets.NinjaRunning8,
				Assets.NinjaRunning9
			};
			_AttackSprites = new List<Assets>(){
				Assets.NinjaAttack0, Assets.NinjaAttack1, Assets.NinjaAttack2,
				Assets.NinjaAttack3, Assets.NinjaAttack4, Assets.NinjaAttack5,
				Assets.NinjaAttack6, Assets.NinjaAttack7, Assets.NinjaAttack8,
				Assets.NinjaAttack9
			};
			_JumpingSprites = new List<Assets>(){
				Assets.NinjaJumping0, Assets.NinjaJumping1, Assets.NinjaJumping2,
				Assets.NinjaJumping3, Assets.NinjaJumping4, Assets.NinjaJumping5,
				Assets.NinjaJumping6, Assets.NinjaJumping7, Assets.NinjaJumping8,
				Assets.NinjaJumping9
			};
			_ThrowSprites = new List<Assets>(){
				Assets.NinjaThrow0, Assets.NinjaThrow1, Assets.NinjaThrow2,
				Assets.NinjaThrow3, Assets.NinjaThrow4, Assets.NinjaThrow5,
				Assets.NinjaThrow6, Assets.NinjaThrow7, Assets.NinjaThrow8,
				Assets.NinjaThrow9
			};

			_GetHitSprites = new List <Assets>(){
				Assets.NinjaThrow9, Assets.NinjaThrow8, Assets.NinjaThrow7, Assets.NinjaThrow6, Assets.NinjaThrow5
			};
			_Kunais = new List<Kunai>();

			_backGrounds = backGrounds;
			#endregion
		}


		/// <summary>
		/// Update logics, moving, changing textures
		/// </summary>
		public override void Update()
		{
			
			Move();
			ChangeTexture();
	
			#region Kunai logic
			try{
			foreach (Kunai k in _Kunais)
			{
				k.Update();
			}
			}
			catch
			{

			}
			#endregion 
			base.Update();	

		}

		/// <summary>
		/// All movement and attacks handled in here
		/// </summary>
		private void Move()
		{
			#region RunningRight
			if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				if (CurrentState != State.Running)
					_CurrentFrame = 0;

					CurrentState = State.Running;
					if (Position.X < _Game.GraphicsDevice.Viewport.Width - 200)
					{
						Position = new Vector2(Position.X+5, Position.Y);
					}


					if (Direction == 1)
					{
						SpriteEffect = SpriteEffects.None;
						Direction = 0;
					}

			}
			#endregion
			
			#region RunningLeft
			else if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				if (CurrentState != State.Running)
				{
					_CurrentFrame = 0;

				}
					CurrentState = State.Running;

					if (Position.X > 200)
					{
						Position = new Vector2(Position.X - 5, Position.Y);
					}
				
					if (Direction == 0)
					{
						SpriteEffect = SpriteEffects.FlipHorizontally;
						Direction = 1;
						
					}
			}
			#endregion
			
			#region BladeAttack
			else if (Keyboard.GetState().IsKeyDown(Keys.Space))
			{
				if (CurrentState != State.Attacking)
					_CurrentFrame = 0;
				CurrentState = State.Attacking;
			}
			#endregion
			
			#region DoNothing
			else if(CurrentState == State.Normal)
			{
				if (CurrentState != State.Normal)
					_CurrentFrame = 0;

				CurrentState = State.Normal;
			}
			else if (CurrentState == State.Hit)
			{
				if (CurrentState != State.Hit)
					_CurrentFrame = 0;

				CurrentState = State.Hit;
			}
			#endregion

			#region Jumping
			if (Jumping == true || Keyboard.GetState().IsKeyDown(Keys.Up) && DateTime.Now.Subtract(_jumpTime).Milliseconds >80)
			{
				Jumping = true;
				CurrentState = State.Jumping;
				_jumpBehaviour.Jump(this);
			}
			#endregion

			#region Throw
			if (Keyboard.GetState().IsKeyDown(Keys.X) && DateTime.Now.Subtract(_kunaiThrown).Seconds >= 2)
			{
				if (CurrentState != State.Throw)
					_CurrentFrame = 0;

				CurrentState = State.Throw;
			}
			#endregion
			
		}

		/// <summary>
		/// Changing texture based on current state
		/// </summary>
		public void ChangeTexture()
		{
			#region NormalFrames
			if (CurrentState == State.Normal) {
				Texture = AssetsManager.Textures[_IdleSprites[_CurrentFrame]];
			}
			#endregion

			#region RunningFrames
			if (CurrentState == State.Running)
			{
				Texture = AssetsManager.Textures[_RunningSprites[_CurrentFrame]];
			}
			#endregion

			#region AttackingFrames
			if (CurrentState == State.Attacking)
			{
				Texture = AssetsManager.Textures[_AttackSprites[_CurrentFrame]];
			}
			#endregion

			#region JumpingFrames
			if (CurrentState == State.Jumping)
			{
				Texture = AssetsManager.Textures[_JumpingSprites[_CurrentFrame]];
			}
			#endregion

			#region ThrowingFrames
			if (CurrentState == State.Throw)
			{
				Texture = AssetsManager.Textures[_ThrowSprites[_CurrentFrame]];


				if (DateTime.Now.Subtract(_kunaiThrown).Seconds >= 2) { 
						_Kunais.Add(new Kunai(_Game, this));
						_kunaiThrown = DateTime.Now;
					}
			}
			#endregion

			#region GetHit
			if (CurrentState == State.Hit)
			{
				
				Texture = AssetsManager.Textures[_GetHitSprites[_CurrentFrame]];

				if (_CurrentFrame == _GetHitSprites.Count -1)
				{
					_CurrentFrame = 9;

				}
			}

			#endregion // end of GetHit

			#region BasicFrameLogic
			if (_CurrentFrame == 9)
			{
				CurrentState = State.Normal;
				_CurrentFrame = -1;
			}
			_CurrentFrame++;
			#endregion


			
    
			
		}

		/// <summary>
		/// Drawing NinjaGirl & Kunai's
		/// </summary>
		/// <param name="spriteBatch"></param>
		public override void Draw(SpriteBatch spriteBatch)
		{
			foreach (Kunai k in _Kunais)
			{
				k.Draw(spriteBatch);
			}
			spriteBatch.Draw(Texture, Position, null, Color, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), Scale, SpriteEffect, 1);
			spriteBatch.DrawString(_spriteFont, ""+(health)+"HP" ,new Vector2(Position.X-20, Position.Y-(Texture.Height*Scale)+90), Color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
		}

		/// <summary>
		/// Removing Kunai from lists
		///	- No more drawing
		///	- No more updating
		/// </summary>
		/// <param name="k">Send item of type Kunai</param>
		public void RemoveKunai(Kunai k){
			_Kunais.Remove(k);
		}

		public void GetHit(int d)
		{
			if(d == 1)
			Position = new Vector2(Position.X - 50, Position.Y);

			if (d == 0)
				Position = new Vector2(Position.X + 50, Position.Y);
			
			//Change frame 
			_CurrentFrame = 0;
			CurrentState = State.Hit;
			health--;
		}
		public void JumpDone()
		{
			Jumping = false;
			_jumpTime = DateTime.Now;
		}
	}

}