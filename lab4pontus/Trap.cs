namespace lab4pontus
{
    internal class Trap : GameObject, IDamageGiver
    {

        public Trap(int x, int y) : base(new Position(x,y),'T')
        {
        }

        public int GetDamage()
        {
            return 10;
        }
    }
}