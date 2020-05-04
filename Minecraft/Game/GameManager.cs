using Minecraft.Blocks;
using Minecraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minecraft.Game
{
    public class GameManager : IGameManager<Dictionary<int, Dictionary<int, Dictionary<int, Block>>>>
    {
        private Dictionary<int, Dictionary<int, Dictionary<int, Block>>> GameState = new Dictionary<int, Dictionary<int, Dictionary<int, Block>>>();

        public GameManager()
        {
             InitGameState();
        }
        private void InitGameState()
        {

            for (int y = 0; y < 100; y++)
            {
                Dictionary<int, Dictionary<int, Block>> verticalSlice = new Dictionary<int, Dictionary<int, Block>>();
                for (int z = 0; z < 100; z++)
                {
                    Dictionary<int, Block> row = new Dictionary<int, Block>();
                    for (int x = 0; x < 100; x++)
                    {
                        if(y <= 40)
                        {
                            row[x] = new DirtBlock() { XPOS = x, ZPOS = z, YPOS = y };
                        }
                        else
                        {
                            row[x] = new AirBlock() { XPOS = x, ZPOS = z, YPOS = y };
                        }
                        
                    }
                    verticalSlice[z] = row;
                }
                GameState[y] = verticalSlice;
            }

        }
        public Dictionary<int, Dictionary<int, Dictionary<int, Block>>> GetGameState()
        {
            return GameState;
        }

        
    }
}
