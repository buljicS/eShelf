using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eShelf.Shared.Utils
{
    public static class StringUtils
    {
        /// <summary>
        /// Get MD5 hash of given string
        /// </summary>
        /// <returns><c>MD5 Hash</c></returns>
        public static string MD5Hash_Str(string rawString)
        {
            if (string.IsNullOrEmpty(rawString))
                throw new ArgumentNullException(nameof(rawString));

            StringBuilder stringBuilder = new StringBuilder();
            byte[] byteString = Encoding.UTF8.GetBytes(rawString);

            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(byteString);

                for (int i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("x2"));
                }
            }

            return stringBuilder.ToString();
        }
    }
}
