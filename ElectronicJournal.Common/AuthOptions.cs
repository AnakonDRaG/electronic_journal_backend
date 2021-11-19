using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ElectronicJournal.Common
{
    public class AuthOptions
    {
        public  string Issuer { get; set; } // издатель токена
        public  string Audience { get; set; } // потребитель токена
        public  string Secret { get; set; } // ключ для шифрации
        public  int LifeTime { get; set; } // время жизни токена - 1 минута
        public  SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
