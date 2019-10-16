namespace lab4pontus
{
    internal class Potion : GameObject, ILootable
    {
        public int GetHealthPoints() => 10;
        public Potion(int x, int y) : base(new Position(x,y),'P')
        {
        }
    }
}