using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YUTU.BLL.Global;
using YUTU.ThirdPartyApi;

namespace YUTU.UIL.Main
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool reg = ApiYnHelper.LogOut(Login.UserCode.ToString(), textBox1.Text.Trim());
            if (reg)
            {
                System.Environment.Exit(Environment.ExitCode);//退出全部线程
                this.Dispose();
            }
            else
                MessageBox.Show("退出失败，请输入正确的账号密码！");
        }
    }
}
