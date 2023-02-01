using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace YUTU.BLL.Common.Cryptography
{
    /// <summary>
    /// 所有对称加密算法的基类
    /// </summary>
    internal abstract class SymmetricAlgorithm
    {
        private System.Security.Cryptography.SymmetricAlgorithm sa;
        private byte[] key;
        private byte[] iv;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sa">加密服务对象</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        public SymmetricAlgorithm(System.Security.Cryptography.SymmetricAlgorithm sa, string key, string iv)
        {
            this.sa = sa;
            Key = key;
            IV = iv;
            sa.Key = this.key;
            sa.IV = this.iv;
        }

        /// <summary>
        /// 验证并创建密钥
        /// </summary>
        /// <param name="key">密钥（string形式）</param>
        /// <returns>密钥（byte数组形式）</returns>
        protected abstract byte[] MakeKey(string key);

        /// <summary>
        /// 验证并创建向量
        /// </summary>
        /// <param name="iv">向量（string形式）</param>
        /// <returns>向量（byte数组形式）</returns>
        protected abstract byte[] MakeIV(string iv);

        /// <summary>
        /// 设置密钥
        /// </summary>
        public string Key { set { key = MakeKey(value); } }

        /// <summary>
        /// 设置向量
        /// </summary>
        public string IV { set { iv = MakeIV(value); } }

        /// <summary>
        /// 加密一个字符串
        /// </summary>
        /// <param name="source">明文</param>
        /// <returns>密文</returns>
        public string Encrypt(string source)
        {
            byte[] result;
            ICryptoTransform encryptor = sa.CreateEncryptor();
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    // StreamWriter的Write方法可以直接写入string（默认UTF8Encoding，可由构造函数更改）
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(source);
                    }
                }
                result = msEncrypt.ToArray();
            }
            return BytesToHexString(result);
        }

        /// <summary>
        /// 解密一个字符串
        /// </summary>
        /// <param name="result">密文</param>
        /// <returns>明文</returns>
        public string Decrypt(string result)
        {
            byte[] resultBytes = HexStringToBytes(result);
            string source;
            ICryptoTransform decryptor = sa.CreateDecryptor();
            using (MemoryStream msDecrypt = new MemoryStream(resultBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    // StreamReader的ReadToEnd方法可以直接读取string（默认UTF8Encoding，可由构造函数更改）
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        source = srDecrypt.ReadToEnd();
                    }
                }
            }
            return source;
        }

        /// <summary>
        /// byte数组转换为十六进制字符串
        /// </summary>
        /// <param name="source">byte数组</param>
        /// <returns>十六进制字符串</returns>
        public static string BytesToHexString(byte[] source)
        {
            return BitConverter.ToString(source).Replace("-", "");
        }

        /// <summary>
        /// 十六进制字符串转换为byte数组
        /// </summary>
        /// <param name="source">十六进制字符串</param>
        /// <returns>byte数组</returns>
        public static byte[] HexStringToBytes(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (!IsHexString(source))
            {
                throw new ArgumentException("参数字符串必须是十六进制字符串", "source");
            }
            if (source.Length % 2 != 0)
            {
                // 每两个字符转化为一个byte，比如"FF"转化为255
                throw new ArgumentException("参数字符串长度必须是2的倍数", "source");
            }
            int length = source.Length / 2;
            byte[] result = new byte[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = byte.Parse(source.Substring(i * 2, 2), NumberStyles.HexNumber);
            }
            return result;
        }

        private static Regex hexRegex = new Regex(@"^[0-9A-F]+$");

        /// <summary>
        /// 判断一个字符串是否是十六进制字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>是否是十六进制字符串</returns>
        public static bool IsHexString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            return hexRegex.IsMatch(str.ToUpper());
        }
    }
}
