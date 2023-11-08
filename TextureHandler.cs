using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DonkeyKong1
{
    public class TextureHandler
    {
        public static Texture2D texBridge;
        public static Texture2D texBridgeLadder;
        public static Texture2D texLadder;
        public static Texture2D texEmpty;
        public static Texture2D texDK;
        public static Texture2D texMarioFront;
        public static Texture2D texMarioBack;
        public static Texture2D texDKMod;
        public static Texture2D texEnemy;
        public static Texture2D texMarioPauline;
        public static Texture2D texPauline;
        public static Texture2D texScore;
        public static Texture2D texStart;
        public static Texture2D texWin;
        public static Texture2D texLoose;
        public static Texture2D marioPaulineSheet, donkeyKongSheet, enemySheet;
        public static Texture2D texHit;

        public static void LoadTextures(ContentManager content)
        {
            texBridge = content.Load<Texture2D>("bridge");
            texBridgeLadder = content.Load<Texture2D>("bridgeLadder");
            texLadder = content.Load<Texture2D>("ladder");
            texEmpty = content.Load<Texture2D>("empty");
            texDK = content.Load<Texture2D>("DonkeyKong");
            texMarioFront = content.Load<Texture2D>("SuperMarioFront");
            texMarioBack = content.Load<Texture2D>("SuperMarioBack");
            texDKMod = content.Load<Texture2D>("DK_mod_mario");
            texEnemy = content.Load<Texture2D>("enemy");
            texMarioPauline = content.Load<Texture2D>("mario-pauline");
            texPauline = content.Load<Texture2D>("pauline");
            texScore = content.Load<Texture2D>("score-numbers");
            texHit = content.Load<Texture2D>("hitsprite");

            texStart = content.Load<Texture2D>("start");
            texWin = content.Load<Texture2D>("win");
            texLoose = content.Load<Texture2D>("loose");

            marioPaulineSheet = content.Load<Texture2D>("mario-pauline");
            donkeyKongSheet = content.Load<Texture2D>("DK_mod_mario");
            enemySheet = content.Load<Texture2D>("stuff_mod");


        }
    }
}
