using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public abstract class Area : IGameObject
    {
        public int Y { get; set; }

        public virtual void Update(int elapsedMilliseconds, ConsoleKeyInfo? pressedKey)
        {
            // do nothing
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(0, Y);
            // do nothing
        }
    }
}
