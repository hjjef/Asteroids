using System;
using SwinGameSDK;

namespace MyGame
{
    public class Turret : GameObject
    {
        private float _angle;
        private int _length;
        private int _bulletCount;

        public Turret (int x, int y): base(x,y,"turret")
        {
            _angle = 90;
            _length = 20;
            _bulletCount = 0;
        }

        public float Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
            }
        }

        public void RotateCW()
        {
            Angle -= 10;
        }

        public void RotateACW()
        {
            Angle += 10;
        }

        public float TurretPointX()
        {
            return _length * ((float)Math.Cos ((Math.PI * Angle) / 180)) + X;
        }

        public float TurretPointY()
        {
            return _length * ((float)Math.Sin ((Math.PI * Angle) / 180)) + Y;
        }

        public override void Draw()
        {
            SwinGame.DrawLine (Color.Black, X, Y, TurretPointX(), TurretPointY());
        }

        public GameObject Shoot()
        {
            _bulletCount++;
            return new Bullet ((int)TurretPointX(), (int)TurretPointY(), Angle, "bullet");
        }

        public int BulletCount
        {
            get
            {
                return _bulletCount;
            }
        }
    }
}
