using Game5.Behaviour.Jumping;
using Game5.GameObjects.BadGuys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game5.GameObjects.Badguys
{
	class Ninja:Enemy, Ijump
	{
		private int _CurrentFrame;
		private static Random randomX = new Random();
		private List<Assets> _RunningSprites;
		private List<Assets> _AttackSprites;
		private Ijump _jumpBehaviour;
		private DateTime _Jumped;
		private bool _jumping;

		public Ninja(Game1 Game, NinjaGirl N) 
		{
			#region Basic initialize
			Texture = AssetsManager.Textures[Assets.Enemy_NinjaRun0];
			Position = new Vector2(((float)(randomX.Next(Game.GraphicsDevice.Viewport.Width - Texture.Width, Game.GraphicsDevice.Viewport.Width - Texture.Width + 500))), 850);
			Color = Color.White;
			Scale = .4f;
			CurrentState = State.Running;
			Direction = 1;
			SpriteEffect = SpriteEffects.FlipHorizontally;
			_CurrentFrame = 0;
			
			#endregion
			_ninjaGirl = N;

			//Behaviour
			_jumpBehaviour = new NinjaJumpBehaviour();
			_Jumped = DateTime.Now;
			_jumping = false;

			_RunningSprites = new List<Assets>(){
				Assets.Enemy_NinjaRun0, Assets.Enemy_NinjaRun1, Assets.Enemy_NinjaRun2,
				Assets.Enemy_NinjaRun3, Assets.Enemy_NinjaRun4, Assets.Enemy_NinjaRun5,
				Assets.Enemy_NinjaRun6, Assets.Enemy_NinjaRun7, Assets.Enemy_NinjaRun8,
				Assets.Enemy_NinjaRun9
			
			};
			_AttackSprites = new List<Assets>(){
				Assets.Enemy_NinjaAttack0, Assets.Enemy_NinjaAttack1, Assets.Enemy_NinjaAttack2,
				Assets.Enemy_NinjaAttack3, Assets.Enemy_NinjaAttack4, Assets.Enemy_NinjaAttack5,
				Assets.Enemy_NinjaAttack6, Assets.Enemy_NinjaAttack7, Assets.Enemy_NinjaAttack8,
				Assets.Enemy_NinjaAttack9
			};
		}

		public override void Update()
		{
			
			changeTexture();
			base.Update();

			//Jump every 10 seconds
			if (DateTime.Now.Subtract(_Jumped).Seconds >= 2 && CurrentState != State.Attacking || Jumping == true || Rotation != 0)
			{
				_jumping = true;
				_jumpBehaviour.Jump(this);
			}

			

		}
		public void changeTexture()
		{
			if (CurrentState == State.Running && Jumping == false)
			{
				Texture = AssetsManager.Textures[_RunningSprites[_CurrentFrame]];
			}
			if (CurrentState == State.Attacking && Jumping == false)
			{
				Texture = AssetsManager.Textures[_AttackSprites[_CurrentFrame]];

				if (_CurrentFrame == 9) {
					_ninjaGirl.GetHit(Direction);

										}
			}

			if (_CurrentFrame == 9)
			{
				_CurrentFrame = -1;
			}

			_CurrentFrame++;
		}

		bool Ijump.Jumping
		{
			get
			{
				return Jumping;
			}
			set
			{

			}
		}

		void Ijump.Jump(GameObject o)
		{
		}

		void Ijump.JumpDone()
		{
				_Jumped = DateTime.Now;
				_jumping = false;
		}
	}
}
