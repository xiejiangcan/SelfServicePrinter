using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ThirdPartyApi.Common.Cryptography
{
    /// <summary>
    /// 所有摘要算法的基类
    /// </summary>
    internal abstract class HashAlgorithm
    {
        private System.Security.Cryptography.HashAlgorithm h;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="h">摘要服务对象</param>
        public HashAlgorithm(System.Security.Cryptography.HashAlgorithm h)
        {
            this.h = h;
        }

        /// <summary>
        /// 获取一个字符串的摘要
        /// </summary>
        /// <param name="source">待摘要的字符串</param>
        /// <returns>摘要字符串</returns>
        public string Hash(string source)
        {
            byte[] sourceTmp = Encoding.UTF8.GetBytes(source);
            byte[] result = h.ComputeHash(sourceTmp);
            return SymmetricAlgorithm.BytesToHexString(result);
        }

        /// <summary>
        /// 比较一个字符串和一个目标摘要，判断字符串是否可以通过摘要算法获得和目标摘要相同的摘要
        /// </summary>
        /// <param name="source">待摘要的字符串</param>
        /// <param name="result">目标摘要</param>
        /// <returns>比较结果</returns>
        public bool Compare(string source, string result)
        {
            return Hash(source) == result;
        }
    }
}
