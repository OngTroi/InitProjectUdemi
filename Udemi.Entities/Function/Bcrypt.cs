using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Udemi.Entities.Function
{
    public class Hashing
    {
        const int workFactor = 13;

        public static string GenerateHash(string passowrd)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(passowrd, workFactor);
            return hashed;
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
