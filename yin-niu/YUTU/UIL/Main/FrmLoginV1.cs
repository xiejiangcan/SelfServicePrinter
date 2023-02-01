using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using YUTU.BLL.Common;
using YUTU.UIL.Common.Win32;
using YUTU.ThirdPartyApi;
using YUTU.BLL.Global;

namespace YUTU.UIL.Main
{
    public partial class FrmLoginV1 : Form
    {
        private XmlAnalyze analyze;
        public FrmLoginV1()
        {
            InitializeComponent();
        }




        #region 事件
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {

                BtnStatus(true);
                //验证
                if (!CheckConfigure()) return;

                bool result = ApiYnHelper.LogOn(tbCode.Text, tbPwd.Text);
                if (result)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("登录失败，请输入正确的账号密码！");
                }
            }
            catch (Exception ex)
            {
                BtnStatus(false);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                BtnStatus(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(Environment.ExitCode);//退出全部线程
            this.Dispose();
        }

        protected void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("+{Tab}");
            }
        }
        private void tbEnter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.SelectAll();
        }

        private void BtnStatus(bool isClick)
        {
            Invoke(new Action(() =>
            {
                if (isClick)
                {
                    btnEnter.Enabled = false;
                }
                else
                {
                    btnEnter.Enabled = true;
                }
            }));
        }

        /// <summary>
        /// 窗体拖动变量
        /// </summary>
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            WindowOperate.ReleaseCapture();
            WindowOperate.SendMessage1(this.Handle);
        }

        #endregion

        /// <summary>
        /// 检查验证
        /// </summary>
        /// <returns></returns>
        private bool CheckConfigure()
        {
            if (string.IsNullOrEmpty(tbCode.Text))
            {
                MessageBox.Show("用户编号不能为空，请输入！");
                return false;
            }
            if (string.IsNullOrEmpty(tbPwd.Text))
            {
                MessageBox.Show("密码不能为空，请输入！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 写本地文件
        /// </summary>
        /// <param name="user"></param>
        //private void WriteLocalFile(UserVO user)
        //{
        //    var pwd = GlobalParameter.IsAutoLogin ? user.Password : "";
        //    if (!analyze.FileExist())
        //    {
        //        analyze.CreateXml(user.Code, user.Name, user.OrganCode, Login.RoleCode, pwd);
        //    }
        //    else
        //    {
        //        analyze.DeleteXmlNode();
        //        analyze.InsertXml(user.Code, user.Name, user.OrganCode, Login.RoleCode, pwd);
        //    }
        //}


        private void tbPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnter_Click(sender, e);
            }
        }

        private void FrmLoginV3_Activated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCode.Text))
                tbCode.Focus();
            else
                tbPwd.Focus();
        }

        private void FrmLoginV3_Shown(object sender, EventArgs e)
        {
            //RuntimeMonitor.StopMonit();
            //MessageBox.Show("从启动到登录界面显示总时长：" + RuntimeMonitor.GetTimeLen());
        }
    }
}
