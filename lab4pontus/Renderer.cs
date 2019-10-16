using System;

namespace lab4pontus
{
    internal class Renderer
    {
        private char[,] lastFrame;

        public Renderer()
        {
            Console.CursorVisible = false;
        }
        public void DrawGraphics(GameState gameState)
        {
            var currentFrame = CreateFrame(gameState);
            if (lastFrame == null)
            {
                FullRender(currentFrame);
                PrintHud(gameState);
                lastFrame = currentFrame;
                return;
            }

            for (int y = 0; y < gameState.Height; y++)
            {
                for (int x = 0; x < gameState.Width; x++)
                {
                    if (currentFrame[y,x] != lastFrame[y,x])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(gameState.GetGameObject(x, y).Symbol);
                    }
                }
            }
            PrintHud(gameState);
            lastFrame = currentFrame;
        }

        private void PrintHud(GameState gameState)
        {
            Console.SetCursorPosition(gameState.Height + 1, 0);
            var hud = string.Format
            (
                "HP: {0}, Keys: {1}",
                gameState.GetPlayer().HealthPoints,
                gameState.GetPlayer().KeyCount
            );
            foreach (var item in hud)
            {
                Console.Write(item);
            }
        }

        private char[,] CreateFrame(GameState gameState)
        {
            var array = new char[gameState.Height, gameState.Width];
            for (int y = 0; y < gameState.Height; y++)
            {
                for (int x = 0; x < gameState.Width; x++)
                {
                    array[y, x] = gameState.GetGameObject(x, y).Symbol;
                }
            }
            return array;
        }

        private void FullRender(char[,] array)
        {
            Console.Clear();
            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    Console.Write(array[y,x]);
                }
                Console.WriteLine();
            }
            
        }
    }
}