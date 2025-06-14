﻿using System.Security.Cryptography;
using System.Text;

namespace MyProject.Services.Helpers
{
    // deff pass is - pass123
    public static class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToUpper();
            }
        }
    }
}
