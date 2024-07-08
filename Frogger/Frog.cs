using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class Frog : IGameObject
    {
        public Frog()
        {

        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool IsDead { get; private set; }
        public bool HasWon { get; private set; }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("@");
        }

        public void Update(int elapsedMilliseconds, ConsoleKeyInfo? pressedKey)
        {
            if (pressedKey?.Key == ConsoleKey.UpArrow)
            {
                Y -= 1;
            }

            if (pressedKey?.Key == ConsoleKey.DownArrow)
            {
                Y += 1;
            }

            if (pressedKey?.Key == ConsoleKey.LeftArrow)
            {
                X -= 1;
            }

            if (pressedKey?.Key == ConsoleKey.RightArrow)
            {
                X += 1;
            }


        }

        public void Die()
        {
            this.IsDead = true;
        }

        
        public void BroWon()
        {
            this.HasWon = true;
        }
    }
}
