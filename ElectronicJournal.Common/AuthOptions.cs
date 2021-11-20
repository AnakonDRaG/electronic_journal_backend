using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ElectronicJournal.Common
{
    public class AuthOptions
    {
        public  string Issuer { get; set; }
        public  string Audience { get; set; } 
        public  string Secret { get; set; } 
        public  int LifeTime { get; set; } 
        public  SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
    }
}
