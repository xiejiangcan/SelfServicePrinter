using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ThirdPartyApi.Common.Cryptography
{
    public static class EncryptCommon
    {
        private static bool cryptographyInited;
        private const string cryptographyName = "password";
        private const string cryptographyKey = "大军软件";
        private const string cryptographyIv = "软件";

        private static void Init()
        {
            if (!cryptographyInited)
            {
                Cryptographer.EncryptSymmetric(SymmetricAlgorithmsEnum.AES, cryptographyName, cryptographyKey, cryptographyIv, "init");
                cryptographyInited = true;
            }
        }
        public static string EncryptStr(string encryptStr)
        {
            Init();
            return Cryptographer.EncryptSymmetric(SymmetricAlgorithmsEnum.AES, cryptographyName, encryptStr);
        }
        public static string DecryptStr(string decryptStr)
        {
            Init();
            return Cryptographer.DecryptSymmetric(SymmetricAlgorithmsEnum.AES, cryptographyName, decryptStr);
        }
    }
}
