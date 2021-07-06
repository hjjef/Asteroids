using System;
using System.Collections.Generic;
using System.Linq;
using SwinGameSDK;

namespace MyGame
{
    public class GameView: IFoundCollision
    {
        private Color _background;

        private List<GameObject> _asteroids;
        private List<GameObject> _bullets;
        private Player _player;
        private static GameView _instance;
        private IFactoryController _factoryController;

        private GameView ()
        {
            _player = new Player ();
            _asteroids = new List<GameObject> ();
            _bullets = new List<GameObject> ();
            _background = Color.White;
            _factoryController = new Factory (Player.X);
        }

        public static GameView GetInstance()
        {
            if (_instance == null)
                _instance = new GameView ();
            return _instance;
        }

        public Player Player
        {
            get
            {
                return _player;
            }
        }

        public List<GameObject> Asteroids
        {
            get
            {
                return _asteroids;
            }
        }


        public List<GameObject> Bullets
        {
            get
            {
                return _bullets;
            }
        }

        public Color Background
        {
            get 
            {
                return _background;
            }
            set 
            {
                _background = value;
            }
        }

        public IFactoryController AsteroidFactory
        {
            get
            {
                return _factoryController;
            }
        }

        public void Add(GameObject obj)
        {
            if(obj.Name.Contains("asteroid"))
            {
                Asteroids.Add (obj);
            }

            if(obj.Name.Contains("bullet"))
            {
                _bullets.Add (obj);
            }
        }

        public void Remove(GameObject obj)
        {
            if (obj.Name.Contains ("asteroid")) 
            {
                Asteroids.Remove (obj);
            }

            if (obj.Name.Contains ("bullet")) {
                _bullets.Remove (obj);
            }

        }

        public void Draw()
        {
            SwinGame.ClearScreen (_background);

            foreach(GameObject a in Asteroids)
            {
                a.Draw ();
                a.Move ();
            }

            foreach(GameObject b in Bullets)
            {
                b.Draw ();
                b.Move ();
            }
            Player.Draw ();
            Player.Move ();
        }

        public Tuple<GameObject, GameObject> BulletCollision (float angle, int asteroidX, int asteroidY, string name)
        {
            if (name.Contains ("large")) 
            {
                return Tuple.Create((AsteroidFactory.CreateAsteroidAtLocation (FactoryType.MediumAsteroid, asteroidX, asteroidY, angle) as GameObject),(AsteroidFactory.CreateAsteroidAtLocation (FactoryType.MediumAsteroid, asteroidX, asteroidY, angle) as GameObject));
            }
            if (name.Contains ("medium")) {
                return Tuple.Create ((AsteroidFactory.CreateAsteroidAtLocation (FactoryType.SmallAsteroid, asteroidX, asteroidY, angle) as GameObject), (AsteroidFactory.CreateAsteroidAtLocation (FactoryType.SmallAsteroid, asteroidX, asteroidY, angle) as GameObject));
            } 
            else
                return new Tuple<GameObject, GameObject> (null, null);
        }
    }
}
