namespace lab4pontus
{
    internal abstract class GameObject
    {
        private Position position;
        

        public GameObject(Position position, char symbol)
        {
            this.Position = position;
            Symbol = symbol;
        }

        public char Symbol { get; internal set; }
        internal Position Position { get => position; set => position = value; }
    }
}