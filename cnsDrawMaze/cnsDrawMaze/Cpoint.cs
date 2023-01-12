namespace NameMaze
{
    internal class Point
    {
        public int X;
        public int Y;


        //Конфигуратор по умолчанию
        public Point()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Point(int Px, int Py)
        {
            this.X = Px;
            this.Y = Py;
        }
        public Point Rotate(int angle)
        {
            if (angle > 0)
                return new Point(Y, -X);
            else
                return new Point(-Y, X);
        }
        public int GetX()
        {
            return this.X;
        }
        public int GetY()
        {
            return this.Y;
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X), (p1.Y + p2.Y));
        }
        public void Print()
        {
            Console.WriteLine($"X {this.X}, Y {this.Y}");
        }
    }
}
