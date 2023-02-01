using System.Security.Cryptography;

namespace YUTU.BLL.Common.Cryptography
{
    /// <summary>
    /// SHA1摘要算法，摘要结果为长度40的十六进制字符串（160bit=20byte=(hexstring)40）
    /// </summary>
    internal class SHA1 : HashAlgorithm
    {
        private static SHA1Managed sha1 = new SHA1Managed();

        public SHA1() : base(sha1) { }
    }
}