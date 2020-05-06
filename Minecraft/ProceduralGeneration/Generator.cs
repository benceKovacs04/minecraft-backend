using Minecraft.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minecraft.ProceduralGeneration
{
    public class Generator
    {
        private readonly FastNoise _noise = new FastNoise();
        private readonly Random rnd = new Random();

        public Generator()
        {
            _noise.SetNoiseType(FastNoise.NoiseType.Perlin);
        }

        public void SetRandomSeed()
        {
            _noise.SetSeed(rnd.Next());
        }

        public Block[,] GenerateSurface(int width, int height)
        {

            Block[,] map = new Block[350, 350];

            for(int x = 0; x < width; x++)
            {
                for(int z = 0; z < height; z++)
                {
                    map[x, z] = new DirtBlock()
                    {
                        XPOS = x,
                        ZPOS = z,
                        YPOS = (float)Math.Round(_noise.GetNoise(x, z), 1) * 10
                    };
                }
            }

            return map;
        }
    }
}
