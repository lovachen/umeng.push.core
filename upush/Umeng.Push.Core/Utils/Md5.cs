using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Umeng.Push.Core.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class Md5
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String GetMD5Hash(string str)
        { 

            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(str);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            { 
                sb.Append(b.ToString("x2"));
            } 
            return sb.ToString(); 
        }
    }
}
