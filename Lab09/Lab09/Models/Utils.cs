﻿using System.Security.Cryptography;
using System.Text;

namespace Lab09.Utilities
{
    public static class Utils
    {
        public static string GetSHA26Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
