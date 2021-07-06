using System;
namespace MyGame
{
    public class MovingGameObject: GameObject
    {
        private int _radius;

        public MovingGameObject (int x, int y): base(x,y)
        {
            
        }

        public int Radius 
        {
            get 
            {
                return _radius;
            }
            set 
            {
                _radius = value;
            }
        }

        public virtual void Move(float x, float y)
        {
            X = X;
            Y = y;
        }
    }
}
