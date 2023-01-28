using System;
using System.Security.Cryptography;
using System.Text;

namespace YUTU.BLL.Common.Cryptography
{
    /// <summary>
    /// AES对称加密算法（其实现为Rijndael算法）
    /// 密钥长度（UTF8编码后）16、24或32（128bit、192bit、256bit=16byte、24byte、32byte）
    /// 向量长度（UTF8编码后）16（128bit=16byte）
    /// </summary>
    internal class AES : SymmetricAlgorithm
    {
        public AES(string key, string iv) : base(new AesManaged(), key, iv) { }

        protected override byte[] MakeKey(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            byte[] keytmp = Encoding.UTF8.GetBytes(key);
            if (keytmp.Length != 16 && keytmp.Length != 24 && keytmp.Length != 32)
            {
                throw new ArgumentException("AES对称加密算法密钥在经过UTF8编码后的位数必须为16、24或32", "key");
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
            if (ivtmp.Length != 16)
            {
                throw new ArgumentException("AES对称加密算法向量在经过UTF8编码后的位数必须为16", "key");
            }
            return ivtmp;
        }
    }
}