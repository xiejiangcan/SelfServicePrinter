using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ThirdPartyApi.Common.Cryptography
{
    /// <summary>
    /// 对称加密算法枚举
    /// </summary>
    public enum SymmetricAlgorithmsEnum
    {
        AES, DES
    }

    /// <summary>
    /// 摘要算法枚举
    /// </summary>
    public enum HashAlgorithmsEnum
    {
        SHA1, MD5
    }
}
