using System;
using YUTU.BLL.Common.Cryptography;


namespace YUTU.BLL.Common.ET99
{
    public class SetSeed
    {
        Seed seed = new Seed();
        public string GetSeedD()
        {
            return seed.PID = EncryptCommon.DecryptStr("71B2607400083A6C4E9C64F4DB185A80");
            
        }
        public string GetSeedN()
        {
            return seed.PIN = EncryptCommon.DecryptStr("F066F56F24BC517EC6C179032E416F4B589551D6211F10819D5DD3C43D402C90");
        }
        public string GetDayNumber()
        {
            return seed.DayNumber = "588C84AB25AB40787CE9FE6950917E3F";
        }
        public string GetPowerCount()
        {
            return seed.PowerCount = "B0C9CE0F57C877BA4BABFD5929CA0C9E";
        }
        public string GetPowerDate()
        {
            try
            {
                //WeightBiz weightBiz = new WeightBiz();
                //取磅房第一张单据日期
                //return seed.PowerDate = EncryptCommon.EncryptStr(weightBiz.GetFirstTime());
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + " SetSeed.GetPowerDate");
            }
        }
    }
}
