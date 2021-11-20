using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicJournal.Services.JwtService.Interfaces
{
    public interface IJwtService
    {
        string GenerateJWT(string userName, string id, string role);
    }
}
