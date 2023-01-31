using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ThirdPartyApi.Common.Cryptography
{
    /// <summary>
    /// 加密解密
    /// </summary>
    public static class Cryptographer
    {
        private static Dictionary<string, HashAlgorithm> hash = new Dictionary<string, HashAlgorithm>();
        private static Dictionary<string, SymmetricAlgorithm> symmetric = new Dictionary<string, SymmetricAlgorithm>();

        private static HashAlgorithm GetOneHash(HashAlgorithmsEnum algorithm)
        {
            HashAlgorithm onehash = null;
            switch (algorithm)
            {
                case HashAlgorithmsEnum.MD5:
                    if (hash.ContainsKey("MD5"))
                    {
                        onehash = hash["MD5"];
                    }
                    else
                    {
                        onehash = new MD5();
                        hash.Add("MD5", onehash);
                    }
                    break;
                case HashAlgorithmsEnum.SHA1:
                    if (hash.ContainsKey("SHA1"))
                    {
                        onehash = hash["SHA1"];
                    }
                    else
                    {
                        onehash = new SHA1();
                        hash.Add("SHA1", onehash);
                    }
                    break;
                default: break;
            }
            return onehash;
        }

        private static SymmetricAlgorithm GetOneSymmetric(SymmetricAlgorithmsEnum algorithm, string name, string key, string iv)
        {
            SymmetricAlgorithm onesymmetric = null;
            if (symmetric.ContainsKey(name))
            {
                onesymmetric = symmetric[name];
            }
            else
            {
                switch (algorithm)
                {
                    case SymmetricAlgorithmsEnum.AES:
                        onesymmetric = new AES(key, iv);
                        symmetric.Add(name, onesymmetric);
                        break;
                    case SymmetricAlgorithmsEnum.DES:
                        onesymmetric = new DES(key, iv);
                        symmetric.Add(name, onesymmetric);
                        break;
                    default: break;
                }
            }
            return onesymmetric;
        }

        /// <summary>
        /// 获得一个字符串的摘要
        /// </summary>
        /// <param name="algorithm">摘要算法枚举</param>
        /// <param name="source">待摘要的字符串</param>
        /// <returns>摘要字符串</returns>
        public static string CreateHash(HashAlgorithmsEnum algorithm, string source)
        {
            return GetOneHash(algorithm).Hash(source);
        }

        /// <summary>
        /// 比较一个字符串和一个目标摘要，判断字符串是否可以通过摘要算法获得和目标摘要相同的摘要
        /// </summary>
        /// <param name="algorithm">摘要算法枚举</param>
        /// <param name="source">待摘要的字符串</param>
        /// <param name="result">目标摘要</param>
        /// <returns>比较结果</returns>
        public static bool CompareHash(HashAlgorithmsEnum algorithm, string source, string result)
        {
            return GetOneHash(algorithm).Compare(source, result);
        }

        /// <summary>
        /// 使用已经初始化过的对称加密算法实例加密一个字符串
        /// </summary>
        /// <param name="algorithm">对称加密算法枚举</param>
        /// <param name="name">该算法实例名称</param>
        /// <param name="source">明文</param>
        /// <returns>密文</returns>
        public static string EncryptSymmetric(SymmetricAlgorithmsEnum algorithm, string name, string source)
        {
            return EncryptSymmetric(algorithm, name, null, null, source);
        }

        /// <summary>
        /// 初始化一个对称加密算法实例并加密一个字符串
        /// </summary>
        /// <param name="algorithm">对称加密算法枚举</param>
        /// <param name="name">算法实例名称</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="source">明文</param>
        /// <returns>密文</returns>
        public static string EncryptSymmetric(SymmetricAlgorithmsEnum algorithm, string name, string key, string iv, string source)
        {
            return GetOneSymmetric(algorithm, name, key, iv).Encrypt(source);
        }

        /// <summary>
        /// 使用已经初始化过的对称加密算法实例解密一个字符串
        /// </summary>
        /// <param name="algorithm">对称加密算法枚举</param>
        /// <param name="name">该算法实例名称</param>
        /// <param name="result">密文</param>
        /// <returns>明文</returns>
        public static string DecryptSymmetric(SymmetricAlgorithmsEnum algorithm, string name, string result)
        {
            return DecryptSymmetric(algorithm, name, null, null, result);
        }

        /// <summary>
        /// 初始化一个对称加密算法实例并解密一个字符串
        /// </summary>
        /// <param name="algorithm">对称加密算法枚举</param>
        /// <param name="name">算法实例名称</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="result">密文</param>
        /// <returns>明文</returns>
        public static string DecryptSymmetric(SymmetricAlgorithmsEnum algorithm, string name, string key, string iv, string result)
        {
            return GetOneSymmetric(algorithm, name, key, iv).Decrypt(result);
        }
    }
}
