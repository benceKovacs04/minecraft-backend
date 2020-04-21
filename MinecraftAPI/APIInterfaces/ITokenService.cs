using MinecraftAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinecraftAPI.APIInterfaces
{
    public interface ITokenService
    {
        string GetJWToken(User user, string issuer, string secretKey);
    }
}
