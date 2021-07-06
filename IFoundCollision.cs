using System;
using System.Collections.Generic;

namespace MyGame
{
    public interface IFoundCollision
    {
        
		Tuple<GameObject,GameObject> BulletCollision(float angle, int asteroidX, int asteroidY, string name);

    }
}
