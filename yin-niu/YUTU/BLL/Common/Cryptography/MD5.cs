using System.Security.Cryptography;

namespace YUTU.BLL.Common.Cryptography
{
    /// <summary>
    /// MD5摘要算法，摘要结果为长度32的十六进制字符串（128bit=16byte=(hexstring)32）
    /// </summary>
    internal class MD5 : HashAlgorithm
    {
        private static MD5CryptoServiceProvider  md5 = new MD5CryptoServiceProvider ();

        public MD5() : base(md5) { }
    }
}