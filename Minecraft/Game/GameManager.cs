using Minecraft.Blocks;
using Minecraft.Interfaces;
using Minecraft.ProceduralGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minecraft.Game
{
    public class GameManager : IGameManager<Block[,]>
    {
        private Block[,] GameState = new Block[350, 350];
        private readonly Generator generator = new Generator();

        public GameManager()
        {
             InitGameState();
        }
        private void InitGameState()
        {
            GameState = generator.GenerateSurface(350, 350);
        }
        public Block[,] GetGameState()
        {
            return GameState;
        }

        
    }
}
