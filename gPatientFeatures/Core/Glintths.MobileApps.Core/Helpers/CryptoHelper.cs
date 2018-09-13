
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Glintths.MobileApps.Core.Helpers
{

    public class CryptoHelper
    {

        public static string Encrypt(string str, string key32b)
        {
            var strB = Encoding.UTF8.GetBytes(str);
            var keyB = Encoding.UTF8.GetBytes(key32b);
            var ret = AESGCM.SimpleEncrypt(str, keyB);

            //var ret = Encoding.UTF8.GetString(retB, 0, retB.Length);
            return ret;
        }

        public static string Decrypt(string str, string key32b) 
        {
            var keyB = Encoding.UTF8.GetBytes(key32b);
            var ret = AESGCM.SimpleDecrypt(str, keyB);
            
            return ret;
        }

    }
}
