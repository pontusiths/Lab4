namespace lab4pontus
{
    internal struct Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        
        public static Position operator+ (Position first, Position second)
        {
            return new Position(first.x+second.x,first.y+second.y);
        }
    }
}