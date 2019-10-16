using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4pontus
{
    internal class Player : GameObject
    {
        private int healthPoints;
        private List<GameObject> inventory;

        public int HealthPoints { get => healthPoints; }
        public int KeyCount { get => inventory.Where(item => item is Key).Count(); }

        public Player(int x, int y) : base(new Position(x,y),'@')
        {
            healthPoints = 100;
            inventory = new List<GameObject>();
        }

        internal void SetPosition(Position position)
        {
            Position = position;
        }

        internal void TakeDamage(int damage)
        {
            healthPoints -= damage;
        }

        internal void PickUp(ILootable lootable)
        {
            if (lootable is Potion potion)
            {
                healthPoints += potion.GetHealthPoints();
                return;
            }

            inventory.Add(lootable as GameObject);
        }

        internal bool HasKey()
        {
            return inventory.Where(item => item is Key).Take(1).Count() > 0;
        }

        internal void UseOneKey()
        {
            inventory.Remove(inventory.Where(item => item is Key).First());
        }
    }
}