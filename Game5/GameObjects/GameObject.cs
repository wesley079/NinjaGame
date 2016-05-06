using Game5.Behaviour.Jumping;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game5
{
	/**
	 * All objects are drawn here
	 * Standard logic for all classes taking part of the game
	 * Abstract class
	 * **/
	public abstract class GameObject:Ijump
	{
		private bool JumpState;
		//fields
		public enum State
		{
			Normal,
			Jumping,
			Attacking,
			Running,
			Throw,
			Hit
		}
		public State CurrentState { get; set;}        
		private Color[] _colors;


		//properties
		private Texture2D _Texture;
		public Texture2D	Texture			{ get{return _Texture;} set{if(_colors == null){ }
																			_Texture = value;}}
		public Vector2		Position		{ get; set; }
		public float		Scale			{ get; set; }
		public float		Rotation		{ get; set; }
		public Color		Color			{ get; set; }
		public SpriteEffects SpriteEffect	{ get; set;}
		public bool			Jumping			{ get; set;}
		public int			Direction		{ get; set;}
		public Color[] Colors
		{
			get { return _colors; }
 
        }
		public void SetColor()
		{

			_colors = new Color[_Texture.Width * _Texture.Height];
			_Texture.GetData(_colors);
		}
			
			public GameObject()
			{
				//initialize
			}

			public virtual void Update()
			{

			}

			public virtual void  Draw(SpriteBatch spriteBatch)
			{
				spriteBatch.Draw(Texture, Position, null, Color, Rotation, Vector2.Zero, Scale, SpriteEffect, 1);
			}

			public virtual Rectangle BoundingBox()
			{
				float width = Texture.Width * Scale;
				float height = Texture.Height * Scale;


				Rectangle rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)width, (int)height);
				return rectangle;
			}
			public virtual Rectangle CustomBoundingBox()
			{
				float width = Texture.Width * Scale;
				float height = Texture.Height * Scale;


				Rectangle rectangle = new Rectangle((int)Position.X + 50, (int)Position.Y, (int)(width/2), (int)(height/2));
				return rectangle;
			}
			public virtual Rectangle PositionRectangle
			{
				get
				{
					return new Rectangle(
						(int)Position.X, (int)Position.Y,
						Texture.Width,
						Texture.Height);
				}
			}

			 public bool Intersects(GameObject bulletObject)
        {
			int top = Math.Max(PositionRectangle.Top, bulletObject.PositionRectangle.Top);
			int bottom = Math.Min(PositionRectangle.Bottom, bulletObject.PositionRectangle.Bottom);
			int left = 0;
			int right = 0;


			if (bulletObject.Direction == 0) { 
				left = Math.Max(PositionRectangle.Left, bulletObject.PositionRectangle.Left);
				right = Math.Min(PositionRectangle.Right, bulletObject.PositionRectangle.Right);
			}
			if (bulletObject.Direction == 1)
			{
				left = Math.Min(PositionRectangle.Left, bulletObject.PositionRectangle.Left);
				right = Math.Max(PositionRectangle.Right, bulletObject.PositionRectangle.Right);
			}

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    
                    var color1Index = (x - PositionRectangle.Left) + (y - PositionRectangle.Top) * PositionRectangle.Width;
                    var color2Index = (x - bulletObject.PositionRectangle.Left) + (y - bulletObject.PositionRectangle.Top) * bulletObject.PositionRectangle.Width;
					if(this.Colors.Length >= color1Index && bulletObject.Colors.Length >= color2Index)
					{
						Color color1 = _colors[(x - PositionRectangle.Left) + (y - PositionRectangle.Top) * PositionRectangle.Width];
						Color color2 = bulletObject.Colors[(x - bulletObject.PositionRectangle.Left) + (y - bulletObject.PositionRectangle.Top) * bulletObject.PositionRectangle.Width];
						if (color1.A != 0 && color2.A != 0)
							return true;
					}
                }
            }

            return false;
        }



			void Ijump.Jump(GameObject o)
			{
				
			}




			public void JumpDone()
			{
				throw new NotImplementedException();
			}
	}
}
