using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace EMS.API.Ulities
{
    
   public class Hash
   {
        public string HashPassword(string value)
        {
            return Create(value, "creativesoftware");
        }
       public static string Create(string value, string salt)
       {
            var valueBytes = KeyDerivation.Pbkdf2(
                             password: value,
                             salt: Encoding.UTF8.GetBytes(salt),
                             prf: KeyDerivationPrf.HMACSHA512,
                             iterationCount: 10000,
                             numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
       }

       public static bool Validate(string value, string salt, string hash)
                => Create(value, salt) == hash;
   }
    
}
