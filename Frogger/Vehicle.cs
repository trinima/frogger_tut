namespace Frogger
{
    public class Vehicle : IGameObject, ICollidable
    {
        public const int LAP_DURATION = 5000;
        public const int MAX_X = 10;

        public int X { get; set; }
        public int StartPosition { get; set; }
        public int Y { get; set; }
        private int _runTime;

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("V");
        }

        public void Update(int elapsedMilliseconds, ConsoleKeyInfo? pressedKey)
        {
            _runTime += elapsedMilliseconds;
            _runTime = _runTime % LAP_DURATION;

            var timeRatio = (double)_runTime / LAP_DURATION;
            var currentlyAtX = (int)(timeRatio * MAX_X);
            currentlyAtX = (currentlyAtX + StartPosition) % MAX_X;

            X = currentlyAtX;
        }

        public void CheckCollision(Frog frog)
        {
            if (this.X == frog.X && this.Y == frog.Y)
            {
                frog.Die();
            }
        }
    }
}