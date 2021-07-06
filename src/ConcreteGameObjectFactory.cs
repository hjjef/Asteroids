using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public class ConcreteGameObjectFactory: GameObjectFactory
    {
        private Random _rand = new Random ();
        private ushort _originalCount, _total;
        private Player _player;

        public ConcreteGameObjectFactory(Player p)
        {
            _player = p;
        }

        public override IFactory GetGameObject (FactoryType type)
        {
            
            return new Asteroid (35, , ypos, angle);
        }

        public override IFactory GetGameObject (Point2D point, FactoryType type)
        {   
            _originalCount++;
            _total++;
            int xpos = _rand.Next (50, 750);
            int ypos = _rand.Next (50, 550);
            float angle = (float)_rand.NextDouble () * (float)Math.PI;

            switch (type) 
            {
            case (FactoryType.SmallAsteroid):
                return new Asteroid (20, xpos, ypos, angle);

            case (FactoryType.MediumAsteroid):
                return new Asteroid (35, xpos, ypos, angle);

            case (FactoryType.Bullet):
                return new Bullet (xpos, ypos, angle);
            }
        }

        private Point2D GetRandPos()
        {
            Point2D temp = new Point2D();
            temp.X = _rand.Next (50, 750);
            temp.Y = _rand.Next (50, 550);
            while(RestrictedSpawn(temp.X))
            {
                temp.X = _rand.Next (50, 750);
            }
            return temp;
        }

  //      public MovingGameObject Create(FactoryType type)
		//{
  //          _originalCount++;
  //          _total++;
  //          int xpos = _rand.Next (50, 750);
  //          int ypos = _rand.Next (50, 550);
  //          float angle = (float)_rand.NextDouble()*(float)Math.PI;

  //          while(RestrictedSpawn(xpos))
  //          {
  //              xpos = _rand.Next (50, 750);
  //              ypos = _rand.Next (50, 550);
  //          }

  //          if (type == FactoryType.SmallAsteroid)
  //              return new Asteroid (20, xpos, ypos, angle, "smallasteroid" + _total.ToString());

  //          else if (type == FactoryType.MediumAsteroid)
  //              return new Asteroid (35, xpos, ypos, angle, "mediumasteroid" + _total.ToString());
            
  //          else if (type == FactoryType.LargeAsteroid)
  //              return new Asteroid (50, xpos, ypos, angle, "largeasteroid" + _total.ToString());
  //          else if (type == FactoryType.Bullet)
  //              return new 
		//}

        public Asteroid CreateAsteroid()
        {
            _originalCount++;
            _total++;
            return new Asteroid (50, _rand.Next (50, 750), _rand.Next (50, 550), (float)_rand.NextDouble()*(float)Math.PI);
        }

        public Asteroid CreateAsteroidAtLocation (FactoryType type, int x, int y, float angle)
        {
            _total++;
            if(type == FactoryType.MediumAsteroid)
            {
                return new Asteroid (35, x, y, angle + (-1*(float)_rand.NextDouble()+1));
            } 
            else
            {
                return new Asteroid (20, x, y, angle + (-1*(float)_rand.NextDouble()+1));
			}
        }

        public bool RestrictedSpawn(float xpos)
        {
            return ((Math.Abs(_player.X - xpos) <= (800*3 / 16)));
        }

        public bool AtAsteroidCapactiy()
        {
            return (_originalCount >= 2);
        }

        public void Reset()
        {
            _originalCount = 0;
        }
    }
}
