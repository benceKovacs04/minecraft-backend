using System;
using System.Collections.Generic;
using System.Text;

namespace Minecraft.Interfaces
{
    public interface IStateSupplier<T>
    {
        List<T> GetGameState();
    }
}
