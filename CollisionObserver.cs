using System;
using System.Collections.Generic;

namespace MyGame
{
    public class CollisionObserver
    {
        
        private IFoundCollision _collisionHandler;

        public CollisionObserver(GameView gameView)
        {
            _collisionHandler = gameView;
        }

        public bool CollisionCheck (List<GameObject> asteroids, List<GameObject> bullets, Player player)
        {
            GameObject asteroidToDelete = null;
            GameObject bulletToDelete = null;
            var asteroidsToCreate = new Tuple<GameObject, GameObject> (null, null);

            foreach (GameObject asteroid in asteroids) {
                if (CheckAsteroidPlayer (asteroid as Asteroid, player)) {
                    return true;
                }

                foreach (GameObject bullet in bullets) {
                    if (CheckAsteroidBullet (asteroid as Asteroid, bullet as Bullet)) {
                        asteroidToDelete = asteroid;
                        bulletToDelete = bullet;
                        asteroidsToCreate = _collisionHandler.BulletCollision ((asteroid as Asteroid).Angle, (int)asteroid.X, (int)asteroid.Y, asteroid.Name);
                    }
                }
            }
            asteroids.Remove (asteroidToDelete);
            bullets.Remove (bulletToDelete);

            if (asteroidsToCreate.Item1 != null && asteroidsToCreate.Item2 != null && asteroidsToCreate != null) 
            {
                asteroids.Add (asteroidsToCreate.Item1);
                asteroids.Add (asteroidsToCreate.Item2);
            }
            return false;
        }

        private bool CheckAsteroidBullet(Asteroid asteroid, Bullet bullet)
        {
            return (Math.Abs (bullet.X - asteroid.X) <= (3 + asteroid.Radius)/2 && Math.Abs (bullet.Y - asteroid.Y) <= (3 + asteroid.Radius)/2);
        }

        private bool CheckAsteroidPlayer(Asteroid asteroid, Player player)
        {
            return ((Math.Abs(player.X - asteroid.X)) <= (asteroid.Radius + player.Radius)/2 && (Math.Abs (player.Y - asteroid.Y)) <= (asteroid.Radius + player.Radius)/2);
        }


    }
}
