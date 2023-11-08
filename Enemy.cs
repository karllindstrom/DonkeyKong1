using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace DonkeyKong1
{
    public class Enemy
    {
        public Texture2D texEnemy;
        public Rectangle enemyRec;
        public Vector2 pos, size, destination, direction;
        public bool moving;
        public float speed;
        public Enemy(Vector2 pos, float minSpeed, float maxSpeed)
        {
            this.pos = pos;
            texEnemy = TextureHandler.texEnemy;
            size = new Vector2(Game1.tileSize, Game1.tileSize);
            enemyRec = new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
            Random random = new Random();
            speed = (float)(random.NextDouble() * (maxSpeed - minSpeed) + minSpeed);
            moving = true;
            direction = new Vector2(speed, 0);
        }
        public void Update(GameTime gameTime)
        {
            if (moving)
            {
                Vector2 nextPos = pos + direction;

                if (IsWalkable(nextPos))
                {
                    pos = nextPos;
                    enemyRec.Location = new Point((int)pos.X, ((int)pos.Y));
                }
                else
                {
                    direction.X = -direction.X;
                }
                

            }
            
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
        }
        public bool IsWalkable(Vector2 pos)
        {
            int tileX = (int)(pos.X / Game1.tileSize);
            int tileY = (int)(pos.Y / Game1.tileSize);

            if (tileX >= 0 && tileX < Game1.tileArray.GetLength(0) && tileY >= 0 && tileY < Game1.tileArray.GetLength(1))
            {
                return Game1.tileArray[tileX, tileY].walkable;
            }
            return false;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texEnemy, enemyRec, Color.White);
        }
    }
}
