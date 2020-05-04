using Minecraft.Blocks;
using System;
using System.Text.Json.Serialization;

namespace Minecraft
{
    public class Block
    {
        public BlockType Type { get; protected set; }
        public int XPOS { get; set; }
        public int YPOS { get; set; }
        public int ZPOS { get; set; }

    }
}
