namespace lab4pontus
{
    internal class Key : GameObject, ILootable
    {

        public Key(int x, int y) : base(new Position(x,y),'K')
        {
        }
    }
}