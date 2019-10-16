namespace lab4pontus
{
    internal class Monster : GameObject, IDamageGiver
    {

        public Monster(int x, int y) : base(new Position(x,y),'M')
        {
        }

        public int GetDamage()
        {
            return 10;
        }
    }
}