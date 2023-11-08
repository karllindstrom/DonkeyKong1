using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DonkeyKong1
{
    public class Pauline
    {
        public Rectangle paulineRec;
        public Texture2D pauTex;
        public Vector2 pos, size;


        public Pauline(Vector2 pos)
        {
            this.pos = pos;
            pauTex = TextureHandler.texPauline;
            size = new Vector2(Game1.tileSize, Game1.tileSize);
            paulineRec = new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pauTex, paulineRec, Color.White);
        }
    }
    
}
