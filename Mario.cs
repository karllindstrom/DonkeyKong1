using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace DonkeyKong1
{
    public class Mario
    {
        public Texture2D marioTex;
        public Vector2 pos, size;

        public Vector2 direction;
        public bool moving, climbing, invincible, flip;
        public Vector2 destination;
        public float speed;
        //public PLayerAnimation walkClip, standClip, climbClip, injuredClip, deathClip, currentClip;
        public Rectangle bounds;
        Color color = Color.White;
        //public static int p = 17;
        //public static int m = 1;
        public Texture2D marioBackTex;

       

        public Mario(Vector2 pos)
        {
            this.pos = pos;
            //marioTex = TextureHandler.marioPaulineSheet;
            marioTex = TextureHandler.texMarioFront;
            marioBackTex = TextureHandler.texMarioBack;
            size = new Vector2(Game1.tileSize, Game1.tileSize);
            direction = new Vector2(0, 0);
            speed = 200;
            moving = false;
            destination = Vector2.Zero;
            bounds = new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);

            

        }

        public void Update(GameTime gameTime)
        {
           

                    KeyMouseReader.Update();
            if (!moving)
            {
                if (KeyMouseReader.KeyPressed(Keys.Up))
                {
                    climbing = true;
                    ChangeDirection(new Vector2(0, -1));
                }
                else if (KeyMouseReader.KeyPressed(Keys.Left))
                {
                    climbing = false;
                    ChangeDirection(new Vector2(-1, 0));
                }
                else if (KeyMouseReader.KeyPressed(Keys.Down))
                {
                    climbing = true;
                    ChangeDirection(new Vector2(0, 1));
                }
                else if (KeyMouseReader.KeyPressed(Keys.Right))
                {
                    climbing = false;
                    ChangeDirection(new Vector2(1, 0));
                }
            }
            else
            {
                pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Vector2.Distance(pos, destination) < 1)
                {
                    pos = destination;
                    moving = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (climbing == true)
            {
                spriteBatch.Draw(marioBackTex, pos, Color.White);
            }
            else
            {
                spriteBatch.Draw(marioTex, pos, Color.White);
            }
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
        }

        public void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = pos + direction * Game1.tileSize;

            if (Game1.GetTileAtPosition(newDestination))
            {
                destination = newDestination;
                moving = true;
            }
        }
    }
}
