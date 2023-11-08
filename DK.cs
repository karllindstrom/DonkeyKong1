using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DonkeyKong1
{
    public class DK
    {
        public Texture2D texDK;
        public Vector2 pos, size;
        public Rectangle DKRec;
        public DK(Vector2 pos)
        {
            this.pos = pos;
            texDK = TextureHandler.texDK;
            size = new Vector2(Game1.tileSize * 3, Game1.tileSize * 2);
            DKRec = new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texDK, DKRec, Color.White);
        }
    }
}
