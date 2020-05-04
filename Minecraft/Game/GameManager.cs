using Minecraft.Blocks;
using Minecraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minecraft.Game
{
    public class GameManager : IStateSupplier<Block>
    {
        private List<Block> GameState;

        public void InitGameState()
        {
            GameState = new List<Block>() { new DirtBlock(), new DirtBlock() };
        }
        public List<Block> GetGameState()
        {
            return GameState;
        }
    }
}
