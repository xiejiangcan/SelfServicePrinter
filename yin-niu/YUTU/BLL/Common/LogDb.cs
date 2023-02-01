using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YUTU.BLL.Golobal;
using YUTU.BLL.Log;
using YUTU.DAL.Log.Entity;
using YUTU.BLL.Global;
using System.Collections;

namespace YUTU.BLL.Common
{
    public class LogDb
    {
        private string BizId;
        private string WdsId;
        private string CarNumber;
        private string Module;
        private string DectionaryCode;
        private string DectionaryName;
        private SysLogBiz logBiz;
        private SysLog sysLog;

        public LogDb(string bizId, string wdsId, string carNumber, string module, string dectionaryCode, string dectionaryName)
        {
            BizId = bizId;
            WdsId = wdsId;
            CarNumber = carNumber;
            Module = module;
            DectionaryCode = dectionaryCode;
            DectionaryName = dectionaryName;
            try
            {
                Init();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public LogDb(string carNumber, string module, string dectionaryCode, string dectionaryName)
        {
            CarNumber = carNumber;
            Module = module;
            DectionaryCode = dectionaryCode;
            DectionaryName = dectionaryName;
            try
            {
                Init();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private void Init()
        {
            try
            {
                logBiz = new SysLogBiz();
                sysLog = new SysLog();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void HandleLog(string logContent)
        {
            try
            {
                //if (logContent.Length > 400) logContent = logContent.Substring(0, 400);

                ArrayList list = SplitLength(logContent, 400);
                foreach (var item in list)
                {
                    Save(item.ToString());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void Save(string logContent)
        {
            sysLog = new SysLog();
            sysLog.BizID = BizId;
            sysLog.WdsID = WdsId;
            sysLog.CarNumber = CarNumber;
            sysLog.Content = logContent;
            sysLog.Module = Module;
            sysLog.DectionaryCode = DectionaryCode;
            sysLog.DectionaryName = DectionaryName;
            sysLog.OrganCode = GlobalParameter.OrganCode;
            sysLog.SaveTime = Tools.Now;
            sysLog.IsUpload = 0;
            sysLog.Code = logBiz.GetMaxCode(GlobalParameter.OrganCode + Tools.YearMonthDay);
            sysLog.UserCode = Login.UserCode;
            sysLog.UserName = Login.UserName;
            logBiz.Save(sysLog);
        }


        public ArrayList SplitLength(string SourceString, int Length)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < SourceString.Trim().Length; i += Length)
            {
                if ((SourceString.Trim().Length - i) >= Length)
                    list.Add(SourceString.Trim().Substring(i, Length));
                else
                    list.Add(SourceString.Trim().Substring(i, SourceString.Trim().Length - i));
            }
            return list;
        }
    }
}
