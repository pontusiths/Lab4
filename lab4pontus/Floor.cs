namespace lab4pontus
{
    internal class Floor : GameObject
    {
        private Position position;

        public Floor(Position position) : base(position, '.')
        {
            
        }

        public Floor(int x, int y) : base(new Position(x,y),'.')
        {
        }
    }
}