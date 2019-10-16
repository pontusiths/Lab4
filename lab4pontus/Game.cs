using System;
using System.Collections.Generic;

namespace lab4pontus
{
    internal class Game
    {
        private GameState currentState;
        private Renderer renderer;

        public Game()
        {
        }

        internal void Run()
        {
            //Init
            currentState = new GameState();
            renderer = new Renderer();
            currentState.GenerateState();
            renderer.DrawGraphics(currentState);
            //Gameplay 
            while (currentState.state == GameState.State.Running)
            {
                ExecuteGameTurn();
                renderer.DrawGraphics(currentState);
            }
            //GameOver
            Console.Clear();
            if (currentState.state == GameState.State.YouLost)
            {
                Console.WriteLine("You Lost");
            } 
            if (currentState.state == GameState.State.YouWon)
            {
                Console.WriteLine("You won");
            }
            Console.ReadKey(false);
        }

        void ExecuteGameTurn()
        {
            var direction = GetDirection(Console.ReadKey(true).Key);
            if (direction.Equals(default(Position)))
                return;

            var player = currentState.GetPlayer();
            var newPosition = player.Position + direction;
            var gameObject = currentState.GetGameObject(newPosition);
            if (gameObject is Wall)
                return;
            
            if (gameObject is IDamageGiver damageGiver)
            {
                player.TakeDamage(damageGiver.GetDamage());
            }

            if (gameObject is ILootable lootable)
            {
                player.PickUp(lootable);
            }

            if (gameObject is Door)
            {
                if (player.HasKey())
                {
                    player.UseOneKey();
                }
                else
                {
                    return;
                }
            }

            if (gameObject is Exit)
            {
                currentState.state = GameState.State.YouWon;
                return;
            }

            if (player.HealthPoints <= 0)
            {
                currentState.state = GameState.State.YouLost;
            }

            currentState.RemoveGameObject(gameObject);
            currentState.Add(new Floor(player.Position));
            player.SetPosition(newPosition);
        }
        private Position GetDirection(ConsoleKey key)
        {
            if (key == ConsoleKey.W) return new Position(0, -1);
            if (key == ConsoleKey.S) return new Position(0, 1);
            if (key == ConsoleKey.A) return new Position(-1, 0);
            if (key == ConsoleKey.D) return new Position(1, 0);
            return default;
        }
    }
}