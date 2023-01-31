using SelfServicePrinter.ThirdPartyApi.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ThirdPartyApi.Global
{
    public static class LocalConfig
    {
        private static string guardCode = "";
        private static string guardName = "";

        public static string GuardCode
        {
            get { return LocalConfig.guardCode; }
            set
            {
                LocalConfig.guardCode = value;
                LocalConfig.SetLocalConfig("GuardCode", value);
            }
        }

        public static string GuardName
        {
            get { return LocalConfig.guardName; }
            set
            {
                LocalConfig.guardName = value;
                LocalConfig.SetLocalConfig("GuardName", value);
            }
        }

        private static string poundCode = "";

        public static string PoundCode
        {
            get { return LocalConfig.poundCode ?? ""; }
            set
            {
                LocalConfig.poundCode = value;
                LocalConfig.SetLocalConfig("PoundCode", value);
            }
        }
        private static string poundName = "";

        public static string PoundName
        {
            get { return LocalConfig.poundName; }
            set
            {
                LocalConfig.poundName = value;
                LocalConfig.SetLocalConfig("PoundName", value);
            }
        }

        private static string inBulkCode = "";

        public static string InBulkCode
        {
            get { return LocalConfig.inBulkCode; }
            set
            {
                LocalConfig.inBulkCode = value;
                LocalConfig.SetLocalConfig("InBulkCode", value);
            }
        }
        private static string inBulkName = "";

        public static string InBulkName
        {
            get { return LocalConfig.inBulkName; }
            set
            {
                LocalConfig.inBulkName = value;
                LocalConfig.SetLocalConfig("InBulkName", value);
            }
        }

        private static string bagsCode = "";

        public static string BagsCode
        {
            get { return LocalConfig.bagsCode; }
            set
            {
                LocalConfig.bagsCode = value;
                LocalConfig.SetLocalConfig("BagsCode", value);
            }
        }
        private static string bagsName = "";

        public static string BagsName
        {
            get { return LocalConfig.bagsName; }
            set
            {
                LocalConfig.bagsName = value;
                LocalConfig.SetLocalConfig("BagsNmae", value);
            }
        }

        private static string queueCode = "";

        public static string QueueCode
        {
            get { return LocalConfig.queueCode; }
            set
            {
                LocalConfig.queueCode = value;
                LocalConfig.SetLocalConfig("QueueCode", value);
            }
        }
        private static string queueName = "";

        public static string QueueName
        {
            get { return LocalConfig.queueName; }
            set
            {
                LocalConfig.queueName = value;
                LocalConfig.SetLocalConfig("QueueName", value);
            }
        }

        private static string receptionCode = "";

        public static string ReceptionCode
        {
            get { return LocalConfig.receptionCode; }
            set
            {
                LocalConfig.receptionCode = value;
                LocalConfig.SetLocalConfig("ReceptionCode", value);
            }
        }
        private static string receptionName = "";

        public static string ReceptionName
        {
            get { return LocalConfig.receptionName; }
            set
            {
                LocalConfig.receptionName = value;
                LocalConfig.SetLocalConfig("ReceptionName", value);
            }
        }
        private static string autoCode = "";

        public static string AutoCode
        {
            get { return LocalConfig.autoCode; }
            set
            {
                LocalConfig.autoCode = value;
                LocalConfig.SetLocalConfig("AutoCode", value);
            }
        }

        private static string autoName = "";

        public static string AutoName
        {
            get { return LocalConfig.autoName; }
            set
            {
                LocalConfig.autoName = value;
                LocalConfig.SetLocalConfig("AutoName", value);
            }
        }
        private static string recipientCode = "";
        private static string recipientName = "";
        /// <summary>
        /// 收卡点
        /// </summary>
        public static string RecipientCode
        {
            get { return LocalConfig.recipientCode; }
            set
            {
                LocalConfig.recipientCode = value;
                LocalConfig.SetLocalConfig("RecipientCode", value);
            }
        }
        /// <summary>
        /// 收卡点
        /// </summary>
        public static string RecipientName
        {
            get { return LocalConfig.recipientName; }
            set
            {
                LocalConfig.recipientName = value;
                LocalConfig.SetLocalConfig("RecipientName", value);
            }
        }

        private static string icDictionaryCode = "";

        public static string IcDictionaryCode
        {
            get { return LocalConfig.icDictionaryCode; }
            set
            {
                LocalConfig.icDictionaryCode = value;
                LocalConfig.SetLocalConfig("IcDictionaryCode", value);
            }
        }
        private static string icDictionaryName = "";

        public static string IcDictionaryName
        {
            get { return LocalConfig.icDictionaryName; }
            set
            {
                LocalConfig.icDictionaryName = value;
                LocalConfig.SetLocalConfig("IcDictionaryName", value);
            }
        }

        /// <summary>
        ///志信袋装参数文件，含全路径
        /// </summary>
        private static string bagsInterfaceConfigFile = "";

        /// <summary>
        ///志信袋装参数文件，含全路径
        /// </summary>
        public static string BagsInterfaceConfigFile
        {
            get { return LocalConfig.bagsInterfaceConfigFile; }
            set
            {
                LocalConfig.bagsInterfaceConfigFile = value;
                LocalConfig.SetLocalConfig("BagsInterfaceConfigFile", value);
            }
        }

        private static string mineCode = "";

        public static string MineCode
        {
            get { return LocalConfig.mineCode; }
            set
            {
                LocalConfig.mineCode = value;
                LocalConfig.SetLocalConfig("MineCode", value);
            }
        }
        private static string mineName = "";

        public static string MineName
        {
            get { return LocalConfig.mineName; }
            set
            {
                LocalConfig.mineName = value;
                LocalConfig.SetLocalConfig("MineName", value);
            }
        }

        private static string passageCode = "";

        public static string PassageCode
        {
            get { return LocalConfig.passageCode; }
            set
            {
                LocalConfig.passageCode = value;
                LocalConfig.SetLocalConfig("PassageCode", value);
            }
        }
        private static string passageName = "";

        public static string PassageName
        {
            get { return LocalConfig.passageName; }
            set
            {
                LocalConfig.passageName = value;
                LocalConfig.SetLocalConfig("PassageName", value);
            }
        }

        private static string clinkerCode = "";

        public static string ClinkerCode
        {
            get { return LocalConfig.clinkerCode; }
            set
            {
                LocalConfig.clinkerCode = value;
                LocalConfig.SetLocalConfig("ClinkerCode", value);
            }
        }
        private static string clinkerName = "";

        public static string ClinkerName
        {
            get { return LocalConfig.clinkerName; }
            set
            {
                LocalConfig.clinkerName = value;
                LocalConfig.SetLocalConfig("ClinkerName", value);
            }
        }

        private static string printCode = "";

        public static string PrintCode
        {
            get { return LocalConfig.printCode; }
            set
            {
                LocalConfig.printCode = value;
                LocalConfig.SetLocalConfig("PrintCode", value);
            }
        }
        private static string printName = "";

        public static string PrintName
        {
            get { return LocalConfig.printName; }
            set
            {
                LocalConfig.printName = value;
                LocalConfig.SetLocalConfig("PrintName", value);
            }
        }

        /// <summary>
        /// 基础数据同步间隔，默认5分钟
        /// </summary>
        private static string basicDataSyncInterval = "5";

        public static string BasicDataSyncInterval
        {
            get { return LocalConfig.basicDataSyncInterval; }
            set
            {
                LocalConfig.basicDataSyncInterval = value;
                LocalConfig.SetLocalConfig("BasicDataSyncInterval", value);
            }
        }

        /// <summary>
        /// 基础数据同步是否开机自动开始启动
        /// </summary>
        private static string basicDataSyncIsAutoStart = "0";

        public static string BasicDataSyncIsAutoStart
        {
            get { return LocalConfig.basicDataSyncIsAutoStart; }
            set
            {
                LocalConfig.basicDataSyncIsAutoStart = value;
                LocalConfig.SetLocalConfig("BasicDataSyncIsAutoStart", value);
            }
        }


        private static string localPlaceCode = "";

        public static string LocalPlaceCode
        {
            get { return LocalConfig.localPlaceCode; }
            set
            {
                LocalConfig.localPlaceCode = value;
                LocalConfig.SetLocalConfig("LocalPlaceCode", value);
            }
        }

        private static string localPlaceName = "";

        public static string LocalPlaceName
        {
            get { return LocalConfig.localPlaceName; }
            set
            {
                LocalConfig.localPlaceName = value;
                LocalConfig.SetLocalConfig("LocalPlaceName", value);
            }
        }

        private static string receptionUISplitterDistance = "";

        public static string ReceptionUISplitterDistance
        {
            get { return LocalConfig.receptionUISplitterDistance; }
            set
            {
                LocalConfig.receptionUISplitterDistance = value;
                LocalConfig.SetLocalConfig("ReceptionUISplitterDistance", value);
            }
        }

        private static string collarBagCode = "";

        public static string CollarBagCode
        {
            get { return LocalConfig.collarBagCode; }
            set
            {
                LocalConfig.collarBagCode = value;
                LocalConfig.SetLocalConfig("CollarBagCode", value);
            }
        }
        private static string collarBagName = "";

        public static string CollarBagName
        {
            get { return LocalConfig.collarBagName; }
            set
            {
                LocalConfig.collarBagName = value;
                LocalConfig.SetLocalConfig("CollarBagName", value);
            }
        }

        private static string accessToken = "";

        public static string AccessToken
        {
            get { return LocalConfig.accessToken; }
            set
            {
                LocalConfig.accessToken = value;
                LocalConfig.SetLocalConfig("AccessToken", value);
            }
        }

        private static string tokenExpired = "";

        public static string TokenExpired
        {
            get { return LocalConfig.tokenExpired; }
            set
            {
                LocalConfig.tokenExpired = value;
                LocalConfig.SetLocalConfig("TokenExpired", value);
            }
        }

        private static string file = "LocalConfig.ini";

        /// <summary>
        /// 从LocalConfig.ini中获取默认参数
        /// </summary>
        public static void GetLocalConfig()
        {
            GuardCode = IniFile.IniReadValue("LocalConfig", "GuardCode", file);
            GuardName = IniFile.IniReadValue("LocalConfig", "GuardName", file);

            PoundCode = IniFile.IniReadValue("LocalConfig", "PoundCode", file);
            PoundName = IniFile.IniReadValue("LocalConfig", "PoundName", file);

            InBulkCode = IniFile.IniReadValue("LocalConfig", "InBulkCode", file);
            InBulkName = IniFile.IniReadValue("LocalConfig", "InBulkName", file);

            BagsCode = IniFile.IniReadValue("LocalConfig", "BagsCode", file);
            BagsName = IniFile.IniReadValue("LocalConfig", "BagsNmae", file);

            MineCode = IniFile.IniReadValue("LocalConfig", "MineCode", file);
            MineName = IniFile.IniReadValue("LocalConfig", "MineName", file);

            PassageCode = IniFile.IniReadValue("LocalConfig", "PassageCode", file);
            PassageName = IniFile.IniReadValue("LocalConfig", "PassageName", file);

            ClinkerCode = IniFile.IniReadValue("LocalConfig", "ClinkerCode", file);
            ClinkerName = IniFile.IniReadValue("LocalConfig", "ClinkerName", file);

            PrintCode = IniFile.IniReadValue("LocalConfig", "PrintCode", file);
            PrintName = IniFile.IniReadValue("LocalConfig", "PrintName", file);

            BasicDataSyncInterval = IniFile.IniReadValue("LocalConfig", "BasicDataSyncInterval", file);
            BasicDataSyncIsAutoStart = IniFile.IniReadValue("LocalConfig", "BasicDataSyncIsAutoStart", file);

            BagsInterfaceConfigFile = IniFile.IniReadValue("LocalConfig", "BagsInterfaceConfigFile", file);

            LocalPlaceCode = IniFile.IniReadValue("LocalConfig", "LocalPlaceCode", file);
            LocalPlaceName = IniFile.IniReadValue("LocalConfig", "LocalPlaceName", file);

            QueueCode = IniFile.IniReadValue("LocalConfig", "QueueCode", file);
            QueueName = IniFile.IniReadValue("LocalConfig", "QueueName", file);

            ReceptionCode = IniFile.IniReadValue("LocalConfig", "ReceptionCode", file);
            ReceptionName = IniFile.IniReadValue("LocalConfig", "ReceptionName", file);

            ReceptionUISplitterDistance = IniFile.IniReadValue("LocalConfig", "ReceptionUISplitterDistance", file);

            AutoCode = IniFile.IniReadValue("LocalConfig", "AutoCode", file);
            AutoName = IniFile.IniReadValue("LocalConfig", "AutoName", file);

            RecipientCode = IniFile.IniReadValue("LocalConfig", "RecipientCode", file);
            RecipientName = IniFile.IniReadValue("LocalConfig", "RecipientName", file);

            IcDictionaryCode = IniFile.IniReadValue("LocalConfig", "IcDictionaryCode", file);
            IcDictionaryName = IniFile.IniReadValue("LocalConfig", "IcDictionaryName", file);

            CollarBagCode = IniFile.IniReadValue("LocalConfig", "CollarBagCode", file);
            CollarBagName = IniFile.IniReadValue("LocalConfig", "CollarBagName", file);

            IcDictionaryCode = IniFile.IniReadValue("LocalConfig", "IcDictionaryCode", file);
            IcDictionaryName = IniFile.IniReadValue("LocalConfig", "IcDictionaryName", file);

            AccessToken = IniFile.IniReadValue("LocalConfig", "AccessToken", file);
            TokenExpired = IniFile.IniReadValue("LocalConfig", "TokenExpired", file);
        }

        /// <summary>
        /// 把变量值保存到LocalConfig.ini
        /// </summary>
        public static void SetLocalConfig()
        {
            IniFile.IniWriteValue("LocalConfig", "GuardCode", guardCode, file);
            IniFile.IniWriteValue("LocalConfig", "GuardName", guardName, file);

            IniFile.IniWriteValue("LocalConfig", "PoundCode", poundCode, file);
            IniFile.IniWriteValue("LocalConfig", "PoundName", poundName, file);

            IniFile.IniWriteValue("LocalConfig", "InBulkCode", inBulkCode, file);
            IniFile.IniWriteValue("LocalConfig", "InBulkName", inBulkName, file);

            IniFile.IniWriteValue("LocalConfig", "BagsCode", bagsCode, file);
            IniFile.IniWriteValue("LocalConfig", "BagsNmae", bagsName, file);

            IniFile.IniWriteValue("LocalConfig", "MineCode", mineCode, file);
            IniFile.IniWriteValue("LocalConfig", "MineName", mineName, file);

            IniFile.IniWriteValue("LocalConfig", "PassageCode", passageCode, file);
            IniFile.IniWriteValue("LocalConfig", "PassageName", passageName, file);

            IniFile.IniWriteValue("LocalConfig", "ClinkerCode", clinkerCode, file);
            IniFile.IniWriteValue("LocalConfig", "ClinkerName", clinkerName, file);

            IniFile.IniWriteValue("LocalConfig", "PrintCode", printCode, file);
            IniFile.IniWriteValue("LocalConfig", "PrintName", printName, file);

            IniFile.IniWriteValue("LocalConfig", "BasicDataSyncInterval", basicDataSyncInterval, file);
            IniFile.IniWriteValue("LocalConfig", "BasicDataSyncIsAutoStart", basicDataSyncIsAutoStart, file);

            IniFile.IniWriteValue("LocalConfig", "LocalPlaceCode", localPlaceCode, file);
            IniFile.IniWriteValue("LocalConfig", "LocalPlaceName", localPlaceName, file);

            IniFile.IniWriteValue("LocalConfig", "QueueCode", queueCode, file);
            IniFile.IniWriteValue("LocalConfig", "QueueName", queueName, file);

            IniFile.IniWriteValue("LocalConfig", "ReceptionCode", receptionCode, file);
            IniFile.IniWriteValue("LocalConfig", "ReceptionName", receptionName, file);

            IniFile.IniWriteValue("LocalConfig", "ReceptionUISplitterDistance", receptionUISplitterDistance, file);

            IniFile.IniWriteValue("LocalConfig", "AutoCode", autoCode, file);
            IniFile.IniWriteValue("LocalConfig", "AutoName", autoName, file);

            IniFile.IniWriteValue("LocalConfig", "RecipientCode", recipientCode, file);
            IniFile.IniWriteValue("LocalConfig", "RecipientName", recipientName, file);

            IniFile.IniWriteValue("LocalConfig", "IcDictionaryCode", icDictionaryCode, file);
            IniFile.IniWriteValue("LocalConfig", "IcDictionaryName", icDictionaryName, file);

            IniFile.IniWriteValue("LocalConfig", "CollarBagCode", collarBagCode, file);
            IniFile.IniWriteValue("LocalConfig", "CollarBagName", collarBagName, file);

            IniFile.IniWriteValue("LocalConfig", "IcDictionaryCode", icDictionaryCode, file);
            IniFile.IniWriteValue("LocalConfig", "IcDictionaryName", icDictionaryName, file);

            IniFile.IniWriteValue("LocalConfig", "AccessToken", accessToken, file);
            IniFile.IniWriteValue("LocalConfig", "TokenExpired", tokenExpired, file);

        }


        public static string GetLocalConfig(string key)
        {
            return IniFile.IniReadValue("LocalConfig", key, file);
        }

        public static void SetLocalConfig(string key, string value)
        {
            try { IniFile.IniWriteValue("LocalConfig", key, value, file); }
            catch { }
        }

        public static void Init()
        {
            try
            {
                file = Tools.GetCurrentPath() + file;
                if (!File.Exists(file))
                {
                    SetLocalConfig();
                }
                GetLocalConfig();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 模块
        /// </summary>
        public enum SystemModule
        {
            /// <summary>
            /// 门禁
            /// </summary>
            Guard,
            /// <summary>
            /// 称重
            /// </summary>
            Weight,
            /// <summary>
            /// 散装
            /// </summary>
            InBulk,
            /// <summary>
            /// 散装中心
            /// </summary>
            InBulkCenter,
            /// <summary>
            /// 袋装
            /// </summary>
            Bags,
            /// <summary>
            /// 袋装中心
            /// </summary>
            BagsCenter,
            /// <summary>
            /// 矿山
            /// </summary>
            Mine,
            /// <summary>
            /// 非磅通道
            /// </summary>
            Passage,
            /// <summary>
            /// 熟料
            /// </summary>
            Clinker,
            /// <summary>
            /// 熟料
            /// </summary>
            ClinkerCenter,
            /// <summary>
            /// 业务类型
            /// </summary>
            BusinessType,
            /// <summary>
            /// 组织机构
            /// </summary>
            Organization,
            /// <summary>
            /// 仓库
            /// </summary>
            Warehourse,
            /// <summary>
            /// 单位地区
            /// </summary>
            CustomArea,
            /// <summary>
            /// 排队
            /// </summary>
            Queue,
            /// <summary>
            /// 登记
            /// </summary>
            Reception,
            /// <summary>
            /// 审核打印
            /// </summary>
            Print,
            /// <summary>
            /// 转运地点
            /// </summary>
            TransPortPlace,
            /// <summary>
            /// 库存入库业务类型
            /// </summary>
            StockBizType,
            /// <summary>
            /// 部门
            /// </summary>
            Department,
            /// <summary>
            /// 采购员
            /// </summary>
            Buyer,
            /// <summary>
            /// 自助
            /// </summary>
            Auto,
            /// <summary>
            /// 固定卡
            /// </summary>
            IcDictionary,
            /// <summary>
            /// 自助收卡
            /// </summary>
            Recipient,
            /// <summary>
            /// 车辆
            /// </summary>
            Vehicle,
            /// <summary>
            /// 领包
            /// </summary>
            CollarBag
        }
    }
}
