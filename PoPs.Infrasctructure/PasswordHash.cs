using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PoPs.Infrasctructure
{
    public static class PasswordHash
    {
        public static string GetMD5Hash(string input)
        {
            var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GenerateNewPassword(DateTime dateTime)
        {
            return GetMD5Hash(dateTime.ToLongTimeString());
        }
    }
}
