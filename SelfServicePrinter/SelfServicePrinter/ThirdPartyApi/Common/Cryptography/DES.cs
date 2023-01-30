using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ThirdPartyApi.Common.Cryptography
{
    /// <summary>
    /// DES对称加密算法
    /// 密钥长度（UTF8编码后）8（64bit=8byte）
    /// 向量长度（UTF8编码后）8（64bit=8byte）
    /// </summary>
    internal class DES : SymmetricAlgorithm
    {
        public DES(string key, string iv) : base(new DESCryptoServiceProvider(), key, iv) { }

        protected override byte[] MakeKey(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            byte[] keytmp = Encoding.UTF8.GetBytes(key);
            if (keytmp.Length != 8)
            {
                throw new ArgumentException("DES对称加密算法密钥在经过UTF8编码后的位数必须为8", "key");
            }
            return keytmp;
        }

        protected override byte[] MakeIV(string iv)
        {
            if (iv == null)
            {
                throw new ArgumentNullException("iv");
            }
            byte[] ivtmp = Encoding.UTF8.GetBytes(iv);
            if (ivtmp.Length != 8)
            {
                throw new ArgumentException("DES对称加密算法向量在经过UTF8编码后的位数必须为8", "iv");
            }
            return ivtmp;
        }
    }
}
