using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public static class Globals
    {
        public static bool GAME_OVER = false; // Modifiable
    }

    public class GameModel
    {
        public GameModel ()
        {
            
        }

        public void StartGame()
        {
            SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);

            GameView gameView = GameView.GetInstance ();

            Random rnd = new Random ();

            CollisionObserver collisionObserver = new CollisionObserver (gameView);
            gameView.Asteroids.Add(gameView.AsteroidFactory.CreateAsteroid (FactoryType.LargeAsteroid));



            //Run the game loop
            while (false == SwinGame.WindowCloseRequested ()) {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents ();



                //Clear the screen and draw the framerate
                SwinGame.ClearScreen (Color.White);
                SwinGame.DrawFramerate (0, 0);

                //Draw onto the screen

                if (SwinGame.KeyDown (KeyCode.AKey)) 
                {
                    gameView.Player.Turret.RotateCW ();
                }
                if (SwinGame.KeyDown(KeyCode.DKey))
                {
                    gameView.Player.Turret.RotateACW ();
                }

                if(SwinGame.KeyDown(KeyCode.WKey))
                {
                    gameView.Player.MoveForward();
                }

                if(SwinGame.KeyTyped(KeyCode.SpaceKey))
                {
                    gameView.Add(gameView.Player.Turret.Shoot());
                }

                if (!gameView.AsteroidFactory.AtAsteroidCapactiy ()) 
                {
                    if (rnd.Next (1, 70) == 3) 
                    {
                        gameView.Add (gameView.AsteroidFactory.CreateAsteroid (FactoryType.LargeAsteroid));
                    }
                }

                if(Globals.GAME_OVER == true && gameView.Asteroids.Count != 0)
                { 
                    SwinGame.DrawText ("GameOver! Press esc to exit or space to play again", Color.Blue, 200, 300);
                }

                if (Globals.GAME_OVER == true && gameView.Asteroids.Count == 0) 
                {
                    SwinGame.DrawText ("You Won! Press esc to exit or space to play again", Color.Blue, 200, 300);
                }

                if(Globals.GAME_OVER == true && SwinGame.KeyTyped(KeyCode.SpaceKey))
                {
                    Globals.GAME_OVER = false;
                    gameView.AsteroidFactory.Reset ();
                    gameView.Asteroids.Add (gameView.AsteroidFactory.CreateAsteroid (FactoryType.LargeAsteroid));
                }

                if(Globals.GAME_OVER == true && SwinGame.KeyTyped(KeyCode.EscapeKey))
                {
                    Environment.Exit (0);
                }

                if (Globals.GAME_OVER == false) 
                {
                    gameView.Draw ();
                    if (collisionObserver.CollisionCheck (gameView.Asteroids, gameView.Bullets, gameView.Player)) 
                    {
                        gameView.Asteroids.Clear ();
                        gameView.Bullets.Clear ();
                        Globals.GAME_OVER = true;
                    }
                    if(gameView.Asteroids.Count == 0)
                    {
                        Globals.GAME_OVER = true;
                    }
                }

                SwinGame.RefreshScreen (60);

            }
        }
    }
}

