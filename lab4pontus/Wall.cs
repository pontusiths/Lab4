namespace lab4pontus
{
    internal class Wall : GameObject
    {
        public Wall(int x, int y) : base(new Position(x,y),'#')
        {
        }
    }
}