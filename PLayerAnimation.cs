using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;

namespace DonkeyKong1
{
    public class PLayerAnimation
    {
        enum PlayMode { Play, Pause};
        Rectangle[] srcRects;
        PlayMode playMode = PlayMode.Play;
        float animTime = 0.0f;
        float speed;

        public PLayerAnimation(Rectangle[] srcRects, float speed)
        {
            this.srcRects = srcRects;
            this.speed = speed;
        }
        
        public void SetPlay() { playMode = PlayMode.Play; }
        public void SetPause() {  playMode = PlayMode.Pause; }
        public void SetSpeed(float speed) { this.speed = speed; }
        public void Update(float time)
        {
            if (playMode == PlayMode.Pause) return;
            animTime += time * speed;
        }
        public Rectangle GetCurrentSourceRectangle()
        {
            int rect_index = (int)animTime % srcRects.Length;
            return srcRects[rect_index];
        }
    }

}
