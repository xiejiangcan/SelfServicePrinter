using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using NHibernate;
using YUTU.BLL.Common;
//using YUTU.BLL.Golobal;
using NHConfiguration = NHibernate.Cfg.Configuration;
using YUTU.UIL.Main;
namespace YUTU
{
    static class Program
    {
        internal static NHConfiguration NHConfig { get; private set; }
        internal static string ApplicationPath { get; set; } // 不带最后的斜线

        /// <summary>
        /// NHibernate ISessionFactory
        /// </summary>
        public static ISessionFactory SessionFactory { get; private set; }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                RuntimeMonitor.StartMonit();
                ProgramException.ExceptionControl();
                ApplicationPath = Application.StartupPath;
                YUTU.BLL.Global.LocalConfig.Init();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                bool firstApplicationInstance;
                string mutexname = Assembly.GetEntryAssembly().FullName;
                using (new Mutex(false, mutexname, out firstApplicationInstance))
                    if (firstApplicationInstance)
                    {
                        //if (args.Length > 0 && args[0] == "device")
                        //{
                        //    Application.Run(new YUTU.UIL.DeviceTest.FrmDeviceTest());
                        //}
                        //else
                        //{

                        //}

                        //Form4 form4 = new Form4();
                        //form4.ShowDialog();
                        FrmLoginV1 login = new FrmLoginV1();
                        if (login.ShowDialog() == DialogResult.OK)
                        {
                            //GetSession();
                            Application.Run(new FrmMain1());
                        }
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //public static void ConnectDB()
        //{
        //    try
        //    {
        //        NHConfig = new NHConfiguration().Configure().AddAssembly(typeof(Program).Assembly);
        //        if (string.IsNullOrEmpty(GlobalParameter.ConnectionString))
        //        {
        //            return;
        //        }
        //        string connectionString;
        //        string connStr = GlobalParameter.ConnectionString;
        //        if (string.IsNullOrEmpty(connStr))
        //        {
        //            connectionString = connStr;
        //        }
        //        else
        //        {
        //            connectionString = Transform(connStr);
        //        }

        //        NHConfig.SetProperty("connection.connection_string", connectionString);

        //        BuildSessionFacetory();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public static void ConnectDB(string conStr)
        {
            try
            {
                NHConfig = new NHConfiguration().Configure().AddAssembly(typeof(Program).Assembly);
                if (string.IsNullOrEmpty(conStr))
                {
                    return;
                }
                string connectionString = Transform(conStr);
                NHConfig.SetProperty("connection.connection_string", connectionString);

                Program.SessionFactory = NHConfig.BuildSessionFactory();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 创建SessionFactory
        /// </summary>
        public static void BuildSessionFacetory()
        {
            //创建 SessionFactory
            try
            {
                Program.SessionFactory = NHConfig.BuildSessionFactory();
                //if (GlobalParameter.UserDataSource == YUTU.BLL.Global.GlobalEnum.ReceptionDataSource.Database)
                //{

                //CHANGE.HibernateManager.BuildSessionFacetory();

                //CHANGE.HibernateManager.NHConfig = NHConfig;
                //CHANGE.HibernateManager.SessionFactory = SessionFactory;

                //NHConfig.SetProperty("connection.connection_string", GlobalParameter.ConnectionString);
                //CHANGE.HibernateManager.BuildSessionFacetory("YUTU.exe.Config");
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("创建SessionFactory异常，原因是：" + ex.Message + ex.InnerException);
            }
        }

        private static string Transform(string connStr)
        {
            string[] conns = connStr.Split(';');
            if (conns.Length == 5)
            {
                string[] pwds = conns[3].Split('=');
                string encryptPwd;
                if (pwds.Length == 2)
                {
                    encryptPwd = pwds[1];
                    if (string.IsNullOrEmpty(encryptPwd))
                    {
                        encryptPwd = "";
                    }
                    else
                    {
                        encryptPwd = Tools.GetDecryptStr(encryptPwd);
                    }
                }
                else
                {
                    encryptPwd = "";
                }
                return string.Format("{0};{1};{2};Password={3};", conns[0], conns[1], conns[2], encryptPwd);
            }
            return connStr;
        }

        public static ISession Session
        {
            get; set;
        }
        public static ISession GetSession()
        {
            try
            {
                if (Session == null || Session.IsOpen == false)
                {
                    Session = SessionFactory.OpenSession();
                }
                return Session;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static ISession newSession;
        public static ISession NewSession
        {
            get
            {
                try { newSession = SessionFactory.OpenSession(); } catch (Exception) { }
                return newSession;
            }
            set
            {
                newSession = value;
            }
        }

    }
}
