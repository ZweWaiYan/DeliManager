using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliManager
{
    public static class EncryptDecrypt
    {
        public static string Encrypt(string encrptyValue)
        {
            string value = "";
            return value = encrptyValue != "" ? AcutusSecurityCore.EncDec.Encrypt(encrptyValue) : "";
        }

        public static string Decrypt(string decryptValue)
        {
            string value = "";
            return value = decryptValue != "" ? AcutusSecurityCore.EncDec.Decrypt(decryptValue) : "";
        }

    }
}