using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameObject
    {
        private Point2D _point;

        public GameObject(int x, int y)
        {
            _point = new Point2D();
            X = x;
            Y = y;
        }


        public float X
        {
            get
            {
                return _point.X;
            }
            set
            {
                _point.X = value;
            }
        }

        public float Y
        {
            get
            {
                return _point.Y;
            }
            set
            {
                _point.Y = value;
            }
        }

        public Point2D Point
        {
            get
            {
                return _point;
            }
            set
            {
                _point = value;
            }
        }

        //public virtual void Move(float x, float y)
        //{
        //    X = x;
        //    Y = y;
        //}

        //public virtual void Move() { }

        public virtual void Draw () { }
    }
}
