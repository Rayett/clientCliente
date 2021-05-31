using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace clientCliente
{
    static class Misc
    {
        public static int id;

        public static string MD5Hash(string _password)
        {
            byte[] cryString = new SHA512Managed().ComputeHash(Encoding.Default.GetBytes(_password));
            string hashedPwd = string.Empty;
            for (int i = 0; i < cryString.Length; i++)
                hashedPwd += cryString[i].ToString("X3");
            return hashedPwd;
        }
    }


    
}
