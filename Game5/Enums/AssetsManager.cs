using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game5
{
	public static class AssetsManager
	{
		public static Dictionary<Assets, Texture2D>		Textures	= new Dictionary<Assets, Texture2D>();
        public static Dictionary<Assets, SpriteFont>	Fonts		= new Dictionary<Assets, SpriteFont>();
        public static void LoadGameContent(Game game)
        {
			Textures.Add(Assets.BACKGROUND, game.Content.Load<Texture2D>("Background"));
			Textures.Add(Assets.KunaiAsset, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Kunai"));

			#region NinjaGirl-Attack

			Textures.Add(Assets.NinjaAttack0, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__000"));
			Textures.Add(Assets.NinjaAttack1, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__001"));
			Textures.Add(Assets.NinjaAttack2, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__002"));
			Textures.Add(Assets.NinjaAttack3, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__003"));
			Textures.Add(Assets.NinjaAttack4, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__004"));
			Textures.Add(Assets.NinjaAttack5, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__005"));
			Textures.Add(Assets.NinjaAttack6, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__006"));
			Textures.Add(Assets.NinjaAttack7, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__007"));
			Textures.Add(Assets.NinjaAttack8, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__008"));
			Textures.Add(Assets.NinjaAttack9, game.Content.Load<Texture2D>("NinjaGirl\\Attack\\Attack__009"));

			#endregion // end of NinjaGirl-Attack 
			
			#region NinjaGirl-Jumping
			Textures.Add(Assets.NinjaJumping0, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__000"));
			Textures.Add(Assets.NinjaJumping1, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__001"));
			Textures.Add(Assets.NinjaJumping2, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__002"));
			Textures.Add(Assets.NinjaJumping3, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__003"));
			Textures.Add(Assets.NinjaJumping4, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__004"));
			Textures.Add(Assets.NinjaJumping5, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__005"));
			Textures.Add(Assets.NinjaJumping6, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__006"));
			Textures.Add(Assets.NinjaJumping7, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__007"));
			Textures.Add(Assets.NinjaJumping8, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__008"));
			Textures.Add(Assets.NinjaJumping9, game.Content.Load<Texture2D>("NinjaGirl\\Jumping\\Jump__009"));

			#endregion // end of NinjaGirl-Jumping 
	
			#region NinjaGirl-Rest
			Textures.Add(Assets.NinjaResting0, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__000"));
			Textures.Add(Assets.NinjaResting1, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__001"));
			Textures.Add(Assets.NinjaResting2, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__002"));
			Textures.Add(Assets.NinjaResting3, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__003"));
			Textures.Add(Assets.NinjaResting4, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__004"));
			Textures.Add(Assets.NinjaResting5, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__005"));
			Textures.Add(Assets.NinjaResting6, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__006"));
			Textures.Add(Assets.NinjaResting7, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__007"));
			Textures.Add(Assets.NinjaResting8, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__008"));
			Textures.Add(Assets.NinjaResting9, game.Content.Load<Texture2D>("NinjaGirl\\Rest\\Idle__009"));

			#endregion // end of Rest 
      
			#region NinjaGirl-Running
			Textures.Add(Assets.NinjaRunning0, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__000"));
			Textures.Add(Assets.NinjaRunning1, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__001"));
			Textures.Add(Assets.NinjaRunning2, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__002"));
			Textures.Add(Assets.NinjaRunning3, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__003"));
			Textures.Add(Assets.NinjaRunning4, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__004"));
			Textures.Add(Assets.NinjaRunning5, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__005"));
			Textures.Add(Assets.NinjaRunning6, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__006"));
			Textures.Add(Assets.NinjaRunning7, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__007"));
			Textures.Add(Assets.NinjaRunning8, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__008"));
			Textures.Add(Assets.NinjaRunning9, game.Content.Load<Texture2D>("NinjaGirl\\Running\\Run__009"));


			#endregion // end of NinjaGirl-Running 
    	
			#region NinjaGirl-Throw
			Textures.Add(Assets.NinjaThrow0, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__000"));
			Textures.Add(Assets.NinjaThrow1, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__001"));
			Textures.Add(Assets.NinjaThrow2, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__002"));
			Textures.Add(Assets.NinjaThrow3, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__003"));
			Textures.Add(Assets.NinjaThrow4, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__004"));
			Textures.Add(Assets.NinjaThrow5, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__005"));
			Textures.Add(Assets.NinjaThrow6, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__006"));
			Textures.Add(Assets.NinjaThrow7, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__007"));
			Textures.Add(Assets.NinjaThrow8, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__008"));
			Textures.Add(Assets.NinjaThrow9, game.Content.Load<Texture2D>("NinjaGirl\\Throw\\Throw__009"));


			#endregion // end of NinjaGirl-Throw 

			#region Enemies

				#region Ninja-Normal
				Textures.Add(Assets.Enemy_NinjaRun0, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__000"));
				Textures.Add(Assets.Enemy_NinjaRun1, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__001"));
				Textures.Add(Assets.Enemy_NinjaRun2, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__002"));
				Textures.Add(Assets.Enemy_NinjaRun3, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__003"));
				Textures.Add(Assets.Enemy_NinjaRun4, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__004"));
				Textures.Add(Assets.Enemy_NinjaRun5, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__005"));
				Textures.Add(Assets.Enemy_NinjaRun6, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__006"));
				Textures.Add(Assets.Enemy_NinjaRun7, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__007"));
				Textures.Add(Assets.Enemy_NinjaRun8, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__008"));
				Textures.Add(Assets.Enemy_NinjaRun9, game.Content.Load<Texture2D>("NinjaEnemy\\Running\\Run__009"));

				#endregion // end of Ninja


			#region Ninja-Attack
			Textures.Add(Assets.Enemy_NinjaAttack0, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__000"));
			Textures.Add(Assets.Enemy_NinjaAttack1, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__001"));
			Textures.Add(Assets.Enemy_NinjaAttack2, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__002"));
			Textures.Add(Assets.Enemy_NinjaAttack3, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__003"));
			Textures.Add(Assets.Enemy_NinjaAttack4, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__004"));
			Textures.Add(Assets.Enemy_NinjaAttack5, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__005"));
			Textures.Add(Assets.Enemy_NinjaAttack6, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__006"));
			Textures.Add(Assets.Enemy_NinjaAttack7, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__007"));
			Textures.Add(Assets.Enemy_NinjaAttack8, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__008"));
			Textures.Add(Assets.Enemy_NinjaAttack9, game.Content.Load<Texture2D>("NinjaEnemy\\Attack\\Attack__009"));
			#endregion // end of Ninja-Attack 
    

			#endregion // end of Enemies 
    
    
		}
	}
}
