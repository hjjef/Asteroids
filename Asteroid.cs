using System;
using SwinGameSDK;

namespace MyGame
{
    public class Asteroid: MovingGameObject, IFactory
    {
        private float _angle, _velocityModifier;

        public Asteroid (int radius, int x, int y, float angle): base(x, y)
        {
            Radius = radius;
            _angle = angle;
            _velocityModifier = (float)((1.0 / Radius) * 75.0);
        }

        public float Angle
        {
            get
            {
                return _angle;
            }
        }

        public float VelocityModifier
        {
            get
            {
                return _velocityModifier;
            }
        }

        public override void Draw ()
        {
            SwinGame.FillCircle (Color.Grey, X, Y, Radius);
        }

        public void Move ()
        {
            Move (X + VelocityModifier * (float)Math.Cos (Angle), Y + VelocityModifier * (float)Math.Sin (Angle));
            CheckBoundary ();
        }

        public virtual void CheckBoundary ()
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
