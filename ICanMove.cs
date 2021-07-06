using System;
namespace MyGame
{
    public interface ICanMove
    {
        void Move ();

        void CheckBoundary ();
    }
}
