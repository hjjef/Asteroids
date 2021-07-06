using System;
using SwinGameSDK;

namespace MyGame
{
    public class Player : MovingGameObject, IFactory
    {
        //private LifeBar _lifebar;
        private Turret _turret;

        public Player () : base (400, 300)
        {
            Radius = 15;
            _turret = new Turret (400, 300);
            //_lifebar = new LifeBar (400, 280);
        }

        public Turret Turret
        {
            get
            {
                return _turret;
            }
        }

        public override void Draw()
        {
            Turret.Draw ();
            CheckBoundary ();
            SwinGame.FillCircle (Color.Green, X, Y, Radius);
        }

        public void Move()
        {
            base.X = (2 * base.X + Turret.TurretPointX ()) / 3;
            base.Y = (2 * base.Y + Turret.TurretPointY()) / 3 ;

            Turret.X = X;
            Turret.Y = Y;
        }

        public virtual void CheckBoundary ()
        {
            if (X >= 800 + Radius) {
                X = 1 - Radius;
                Turret.X = X;
            }
            if (X <= 0 - Radius) {
                Move (800 + Radius, Y);
                Turret.X = X;
            }
            if (Y >= 600 + Radius) {
                Move (X, 1 - Radius);
                Turret.Y = Y;
            }
            if (Y <= 0 - Radius) {
                Move (X, 600 + Radius);
                Turret.Y = Y;
            }
        }
    }
}