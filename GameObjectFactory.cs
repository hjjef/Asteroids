using System;
using SwinGameSDK;

namespace MyGame
{
    public abstract class GameObjectFactory
    {
        public GameObjectFactory ()
        {}

        public abstract IFactory GetGameObject (FactoryType type);

        public abstract IFactory GetGameObject (Point2D point, FactoryType type);

        public abstract bool AtAsteroidCapacity ();
    }
}
