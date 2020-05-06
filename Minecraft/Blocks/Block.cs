using Minecraft.Blocks;
using System;
using System.Text.Json.Serialization;

namespace Minecraft
{
    public class Block
    {
        public BlockType Type { get; protected set; }
        public float XPOS { get; set; }
        public float YPOS { get; set; }
        public float ZPOS { get; set; }

    }
}
