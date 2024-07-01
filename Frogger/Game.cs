using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class Game
    {
        private bool _isRunning = false;
        private DateTime _lastRun = DateTime.Now;
        private Frog _frog;
        private List<IGameObject> _gameObjects;

        public void Start()
        {
            _isRunning = true;

            Initialize();

            RunLoop();
        }

        private void Initialize()
        {
            _frog = new Frog() { X = 5, Y = 4 };

            _gameObjects = new List<IGameObject>()
            {
                new Goal() { Y = 0 },
                new Road() { Y = 1, Vehicles = [new Vehicle() { StartPosition = 5, Y = 1 }, new Vehicle() { StartPosition = 7, Y = 2 }] },
                new Grass() { Y = 3 },
                _frog
            };
        }

        private void RunLoop()
        {
            do
            {
                ConsoleKeyInfo? pressedKey = GetUserInput();
                int elapsedMilliseconds = GetElapsedMilliseconds();
                this.Update(elapsedMilliseconds, pressedKey);
                this.CheckCollision();
                this.Draw();

                Thread.Sleep(40);
                ValidateFrogIsAlive();
                CheckIfFrogIsChillin();
            } while (_isRunning);
        }

        private void CheckIfFrogIsChillin()
        {
            if (_frog.HasWon)
            {
                Console.Clear();
                Console.WriteLine("You Win! Press enter to exit.");
                Console.ReadLine();

                _isRunning = false;
            }
        }

        private void ValidateFrogIsAlive()
        {
            if (_frog.IsDead)
            {
                Console.Clear();
                Console.WriteLine("You died! Press enter to exit.");
                Console.ReadLine();

                _isRunning = false;
            }
        }

        private void CheckCollision()
        {
            _gameObjects
                .OfType<ICollidable>()
                .ToList()
                .ForEach(x => x.CheckCollision(_frog));
        }

        private ConsoleKeyInfo? GetUserInput()
        {
            ConsoleKeyInfo? key = null;

            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
            }

            return key;
        }


        private void Draw()
        {
            _gameObjects.ForEach(x => x.Draw());
        }

        private void Update(int elapsedMilliseconds, ConsoleKeyInfo? pressedKey)
        {
            _gameObjects.ForEach(x => x.Update(elapsedMilliseconds, pressedKey));
        }

        private int GetElapsedMilliseconds()
        {
            DateTime now = DateTime.Now;
            TimeSpan elapsed = now.Subtract(_lastRun);

            _lastRun = now;

            return (int)elapsed.TotalMilliseconds;
        }
    }
}
