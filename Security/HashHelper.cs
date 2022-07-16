using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BootCamp.Adm.Security
{
    /// <summary>
    /// HashHelper
    /// </summary>
    public class HashHelper
    {
        /// <summary>
        /// Generates the salt.
        /// </summary>
        /// <returns></returns>
        public static string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string saltString = Convert.ToBase64String(salt);

            return saltString;
        }

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <param name="saltString">The salt string.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string GetHash(string saltString, string password)
        {
            byte[] salt = new byte[128 / 8];
            salt = System.Text.Encoding.UTF8.GetBytes(saltString);

            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)
                );

            return hashed;
        }
    }
}
