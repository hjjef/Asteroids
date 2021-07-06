using System;
using SwinGameSDK;

namespace MyGame
{
    public class Bullet: MovingGameObject, IFactory
    {
        private float _angle;

        public Bullet (int x, int y, float angle): base(x,y)
        {
            _angle = angle;
            Radius = 3;
        }

        public void Move()
        {
            Move (X + 15 * (float)Math.Cos ((Math.PI *_angle)/180), Y + 15 * (float)Math.Sin ((Math.PI * _angle)/180));
        }

        public override void Draw()
        {
            SwinGame.FillCircle (Color.Black, X, Y, Radius);
        }

        public void CheckBoundary()
        {
            if (X >= 800 + Radius) {
                X = 1 - Radius;
            }
            if (X <= 0 - Radius) {
                Move (800 + Radius, Y);
            }
            if (Y >= 600 + Radius) {
                Move (X, 1 - Radius);
            }
            if (Y <= 0 - Radius) {
                Move (X, 600 + Radius);
            }
        }
    }
}
