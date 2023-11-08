using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace DonkeyKong1
{
    public class Tile
    {
        public Vector2 pos;
        public Texture2D tex;
        public bool walkable;

        public Tile(Vector2 pos, Texture2D tex, bool walkable)
        {
            this.pos = pos;
            this.tex = tex;
            this.walkable = walkable;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
        }
    }
}
