namespace NameMaze
{
    internal class Robot
    {
        public Point Location = new Point();
        public Point Direction = new Point(0, 1);
        //    |
        //    |
        //------->y
        //    |
        //    Vx
        public void rotateDown()
        {
            Direction.X = 1;
            Direction.Y = 0;
        }
        public void rotateLeft()
        {
            Direction.X = 0;
            Direction.Y = -1;
        }
        public void rotateUp()
        {
            Direction.X = -1;
            Direction.Y = 0;
        }
        public void rotateRight()
        {
            Direction.X = 0;
            Direction.Y = 1;
        }
        public void GoForward()
        {
            Location.X += Direction.X;
            Location.Y += Direction.Y;
        }
        public void GoBack()
        {
            Location.X -= Direction.X;
            Location.Y -= Direction.Y;
        }
        public int GetNextX()
        {
            int a = Direction.X;
            return a + Location.X;
        }
        public int GetNextY()
        {
            int a = Direction.Y;
            return a + Location.Y;
        }
        public bool IsDown()
        {
            if(Direction.X == 1)
            {
                return true;
            }
            return false;
        }
        public bool IsRight()
        {
            if (Direction.Y == 1)
            {
                return true;
            }
            return false;
        }
    }
}