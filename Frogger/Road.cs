namespace Frogger
{
    public class Road : Area, ICollidable
    {
        public Vehicle[] Vehicles { get; set; } = [];

        public void CheckCollision(Frog frog)
        {
            foreach (Vehicle vehicle in Vehicles)
            {
                vehicle.CheckCollision(frog);
            }
        }

        public override void Draw()
        {
            base.Draw();

            Console.WriteLine("rrrrrrrrrrr");
            Console.WriteLine("rrrrrrrrrrr");

            foreach (var vehicle in Vehicles)
            {
                vehicle.Draw();
            }
        }

        public override void Update(int elapsedMilliseconds, ConsoleKeyInfo? pressedKey)
        {
            foreach (var vehicle in Vehicles)
            {
                vehicle.Update(elapsedMilliseconds, pressedKey);
            }
        }
    }
}
