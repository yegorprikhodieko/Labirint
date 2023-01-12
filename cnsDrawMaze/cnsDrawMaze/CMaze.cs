namespace NameMaze
{
    internal class Maze
    {
        private Cell[,] Items;
        
        public static Maze Create(Point a)
        {
            Robot robotyaga = new Robot { Location = new Point { X = 1, Y = 1 } };
            var res = new Maze();
            res.Items = new Cell[a.X, a.Y];
            for (int row = 0; row < a.X; row++)
                for (int col = 0; col < a.Y; col++)
                {
                    if (row == 1 && col == 0)
                    {
                        res.Items[row, col] = Cell.Inner;
                    }
                    else if (row == a.X - 1 && col == a.Y - 2)
                    {
                        //exit
                        res.Items[row, col] = Cell.Exit;
                    }                    
                    else if (row == 0 || row == a.Y - 1 || col == 0 || col == a.X - 1)
                    {
                        //border
                        res.Items[row, col] = Cell.Wall;
                    }

                }
            var rand = new Random();
            while (res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y - 1] != Cell.Inner ||
                    res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y] != Cell.Inner ||
                    res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y + 1] != Cell.Inner ||
                    res.Items[robotyaga.Location.X, robotyaga.Location.Y - 1] != Cell.Inner ||
                    res.Items[robotyaga.Location.X, robotyaga.Location.Y + 1] != Cell.Inner ||
                    res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y - 1] != Cell.Inner ||
                    res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y] != Cell.Inner ||
                    res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y + 1] != Cell.Inner)
            {
                //   3
                // |---|
                //2|   |0
                // |---|
                //   1
                var randNumber = rand.Next(4);
                if (randNumber == 0)
                {
                    robotyaga.rotateRight();
                    if (res.Items[robotyaga.GetNextX(), robotyaga.GetNextY()] == Cell.Empty)
                    {
                        res.Items[robotyaga.Location.X, robotyaga.Location.Y] = Cell.Way;

                        if (res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y] == Cell.Empty)
                        {
                            res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y] = Cell.Wall;
                        }
                        if (res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y] == Cell.Empty)
                        {
                            res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y] = Cell.Wall;
                        }
                        robotyaga.GoForward();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (randNumber == 1)
                {
                    robotyaga.rotateDown();
                    if (res.Items[robotyaga.GetNextX(), robotyaga.GetNextY()] == Cell.Empty)
                    {
                        res.Items[robotyaga.Location.X, robotyaga.Location.Y] = Cell.Way;
                        if (res.Items[robotyaga.Location.X, robotyaga.Location.Y - 1] == Cell.Empty)
                        {
                            res.Items[robotyaga.Location.X, robotyaga.Location.Y - 1] = Cell.Wall;
                        }
                        if (res.Items[robotyaga.Location.X, robotyaga.Location.Y + 1] == Cell.Empty)
                        {
                            res.Items[robotyaga.Location.X, robotyaga.Location.Y + 1] = Cell.Wall;
                        }
                        robotyaga.GoForward();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (randNumber == 2)
                {
                    robotyaga.rotateLeft();
                    if (res.Items[robotyaga.GetNextX(), robotyaga.GetNextY()] == Cell.Empty)
                    {
                        res.Items[robotyaga.Location.X, robotyaga.Location.Y] = Cell.Way;
                        if (res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y] == Cell.Empty)
                        {
                            res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y] = Cell.Wall;
                        }
                        if (res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y] == Cell.Empty)
                        {
                            res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y] = Cell.Wall;
                        }
                        robotyaga.GoForward();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (randNumber == 3)
                {
                    robotyaga.rotateUp();
                    if (res.Items[robotyaga.GetNextX(), robotyaga.GetNextY()] == Cell.Empty)
                    {
                        res.Items[robotyaga.Location.X, robotyaga.Location.Y] = Cell.Way;
                        if (res.Items[robotyaga.Location.X, robotyaga.Location.Y - 1] == Cell.Empty)
                        {
                            res.Items[robotyaga.Location.X, robotyaga.Location.Y - 1] = Cell.Wall;
                        }
                        if (res.Items[robotyaga.Location.X, robotyaga.Location.Y + 1] == Cell.Empty)
                        {
                            res.Items[robotyaga.Location.X, robotyaga.Location.Y + 1] = Cell.Wall;
                        }
                        robotyaga.GoForward();

                    }
                    else
                    {
                        continue;
                    }
                }
                int test = 0;
                if (
                    res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y] != Cell.Empty &&                    
                    res.Items[robotyaga.Location.X, robotyaga.Location.Y - 1] != Cell.Empty &&
                    res.Items[robotyaga.Location.X, robotyaga.Location.Y + 1] != Cell.Empty &&                    
                    res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y] != Cell.Empty)                   
                {
                    res.Items[robotyaga.Location.X, robotyaga.Location.Y] = Cell.WayPassed;
                    robotyaga.GoBack();
                   
                    while (
                        res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y] != Cell.Empty &&
                        res.Items[robotyaga.Location.X, robotyaga.Location.Y - 1] != Cell.Empty &&
                        res.Items[robotyaga.Location.X, robotyaga.Location.Y + 1] != Cell.Empty &&
                        res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y] != Cell.Empty
                    )
                    {
                        if (test == 10)
                        {
                            for( int i=0; i<res.Width;i++)
                            {
                                for(int j = 0; j < res.Height; j++)
                                {
                                    if (res.Items[i, j] == Cell.Empty)
                                    {
                                        robotyaga.Location.X = i;
                                        robotyaga.Location.Y = j;
                                        break;
                                    }
                                }
                            }
                            test = 0;
                            break;
                        }
                            if (res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y] == Cell.Way)
                            {
                                res.Items[robotyaga.Location.X, robotyaga.Location.Y] = Cell.WayPassed;
                                robotyaga.rotateUp();
                                robotyaga.GoForward();
                                Console.Write("Вверх\n");
                                //robotyaga.GoBack();
                            }
                            else if (res.Items[robotyaga.Location.X, robotyaga.Location.Y + 1] == Cell.Way)
                            {
                                res.Items[robotyaga.Location.X, robotyaga.Location.Y] = Cell.WayPassed;
                                robotyaga.rotateRight();
                                robotyaga.GoForward();
                                Console.Write("Вправо\n");
                                //robotyaga.GoBack();
                            }
                            else if (res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y] == Cell.Way)
                            {
                                res.Items[robotyaga.Location.X, robotyaga.Location.Y] = Cell.WayPassed;
                                robotyaga.rotateDown();
                                robotyaga.GoForward();
                                Console.Write("Вниз\n");

                                //robotyaga.GoBack();
                            }
                            else if (res.Items[robotyaga.Location.X, robotyaga.Location.Y - 1] == Cell.Way)
                            {
                                res.Items[robotyaga.Location.X, robotyaga.Location.Y] = Cell.WayPassed;
                                robotyaga.rotateLeft();
                                robotyaga.GoForward();
                                Console.Write("Влево\n");

                                //robotyaga.GoBack();
                            }
                        test++;
                    }
                }
                if (res.Items[robotyaga.Location.X, robotyaga.Location.Y - 1] == Cell.Exit)
                {
                    continue;
                }
                else if (res.Items[robotyaga.Location.X, robotyaga.Location.Y + 1] == Cell.Exit)
                {
                    continue;
                } else if (res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y + 1] == Cell.Exit)
                {
                    continue;
                } else if (res.Items[robotyaga.Location.X + 1, robotyaga.Location.Y + 1] == Cell.Exit)
                {
                    continue;
                } else if (res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y + 1] == Cell.Exit)
                {
                    continue;
                } else if (res.Items[robotyaga.Location.X - 1, robotyaga.Location.Y + 1] == Cell.Exit)
                {
                    continue;
                } else if (res.Items[robotyaga.Location.X, robotyaga.Location.Y] == Cell.Exit)
                {
                    continue;
                } else if (res.Items[robotyaga.Location.X, robotyaga.Location.Y] == Cell.Exit)
                {
                    continue;
                }
                int count = 0;
                for (int row = 0; row < res.Width; row++)
                {
                    for (int col = 0; col < res.Height; col++)
                    {
                        switch (res[row, col])
                        {
                            case Cell.Wall: Console.Write("██"); break;
                            case Cell.Exit: Console.Write("ex"); break;
                            case Cell.Way: Console.Write("░░"); break;
                            case Cell.WayPassed: Console.Write("++"); break;
                            case Cell.Inner: Console.Write("oo"); break;
                            default:
                                Console.Write("  "); break;
                                count++;
                        }
                        count++;
                        if (count % 20 == 0)
                        {
                            Console.Write('\n');
                        }
                    }
                }
            }
           
            return res;
        }

        public Cell this[Point p, Point c]
        {
            get { return Items[p.X, p.Y]; }
        }
        public Cell this[int col, int row]
        {
            get { return Items[col, row]; }
        }



        public int Height { get { return Items.GetLength(1); } }
        public int Width { get { return Items.GetLength(0); } }
    }
    enum Cell : byte
    {
        Empty = 0,
        Wall = 1,
        Exit = 2,
        Way = 3,
        Inner = 4,
        WayPassed = 5
    }
}