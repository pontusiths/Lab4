using System;
using System.Collections.Generic;

namespace lab4pontus
{
    internal class GameState
    {
        private static readonly char[,] rawData = new char[,]
            {
                {'#','#','#','#','#','#','#','#'},
                {'#','@','.','#','.','.','E','#'},
                {'#','.','.','#','.','.','.','#'},
                {'#','K','.','#','.','.','.','#'},
                {'#','#','D','#','.','P','.','#'},
                {'#','.','.','.','.','.','.','#'},
                {'#','.','.','M','.','T','.','#'},
                {'#','#','#','#','#','#','#','#'},
            };
        private List<GameObject> gameObjects;
        private int height;
        private int width;
        internal State state;

        public enum State
        {
            Running,
            YouWon,
            YouLost
        }

        public GameState()
        {
            gameObjects = new List<GameObject>();
        }

        public int Height { get => height; }
        public int Width { get => width; }

        public Player GetPlayer()
        {
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is Player player)
                    return player;
            }
            return null;
        }

        public GameObject GetGameObject(int x, int y)
        {
            return GetGameObject(new Position(x, y));
        }

        public GameObject GetGameObject(Position position)
        {
            foreach (var gameObject in gameObjects)
            {
                if (gameObject.Position.Equals(position))
                    return gameObject;
            }
            return null;
        }

        public void GenerateState()
        {
            gameObjects = new List<GameObject>();
            height = rawData.GetLength(0);
            width = rawData.GetLength(1);
            for (int y = 0; y < rawData.GetLength(0); y++)
            {
                for (int x = 0; x < rawData.GetLength(1); x++)
                {
                    if (rawData[y, x] == '#') gameObjects.Add(new Wall(x, y));
                    if (rawData[y, x] == '.') gameObjects.Add(new Floor(x, y));
                    if (rawData[y, x] == '@') gameObjects.Add(new Player(x, y));
                    if (rawData[y, x] == 'T') gameObjects.Add(new Trap(x, y));
                    if (rawData[y, x] == 'M') gameObjects.Add(new Monster(x, y));
                    if (rawData[y, x] == 'K') gameObjects.Add(new Key(x, y));
                    if (rawData[y, x] == 'P') gameObjects.Add(new Potion(x, y));
                    if (rawData[y, x] == 'D') gameObjects.Add(new Door(x, y));
                    if (rawData[y, x] == 'E') gameObjects.Add(new Exit(x, y));
                }
            }
        }

        internal void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        internal void RemoveGameObject(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }
    }
}