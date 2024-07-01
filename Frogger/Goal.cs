using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class Goal : Area, ICollidable
    {
        public int X { get; private set; }

        public void CheckCollision(Frog frog)
        {
            bool hasCollided;

            // HW: Replace line below with logic for detecting if the frog has collided with the goal
            hasCollided = false;

            if (this.Y == frog.Y)
            {
                frog.BroWon();

                
            }
        }

        public override void Draw()
        {
            base.Draw();

            Console.WriteLine("GGGGGGGGGGG");

        }

    

        // HW: Oh no! I forgot to add the drawing logic for the goal!
        // Draw the goal by overriding the base class' Draw() method
        // (See Grass or Road for an example)
    }
}
