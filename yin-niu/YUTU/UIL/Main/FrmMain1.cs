using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using YUTU.UIL.Common.Win32;
using YUTU.ThirdPartyApi;
using System.Threading;
using YUTU.BLL.Global;

namespace YUTU.UIL.Main
{
    public partial class FrmMain1 : Form
    {
        public FrmMain1()
        {
            InitializeComponent();
        }

        private void FrmMain1_MouseDown(object sender, MouseEventArgs e)
        {
            WindowOperate.ReleaseCapture();
            WindowOperate.SendMessage1(this.Handle);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(Environment.ExitCode);//退出全部线程
            //this.Dispose();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            //this.Dispose();
        }

        private int id;
        private int Id
        {
            get { return id; }
            set { id = value; }
        }

        private void FrmMain1_Load(object sender, EventArgs e)
        {
            try
            {
                label4.Text = Login.UserName;
                string noteTitle = string.Empty;
                ApiYnHelper.GetNoticeList(1, 1,out noteTitle,out id);
                lbNote.Text = noteTitle;


                string imgUrl = string.Empty;
                ApiYnHelper.GetShopQrcode(out imgUrl);
                pbImgUrl.LoadAsync(imgUrl);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pbUpload_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            //openFileDialog1.Filter = "文本文件|*.*|所有文件|*.*";
            //openFileDialog1.RestoreDirectory = true;
            //openFileDialog1.FilterIndex = 1;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    string[] fName = openFileDialog1.FileNames;


            //    if (fName.Length == 0) return;

            //    FrmMain2 frmMain2 = new FrmMain2(fName);
            //    frmMain2.ShowDialog();
            //}

            //Application.Run(new FrmMain2());

            

            FrmMain2 frmMain2 = new FrmMain2();
            
            frmMain2.ShowDialog();

            //this.Dispose();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            WindowOperate.ReleaseCapture();
            WindowOperate.SendMessage1(this.Handle);
        }

        private void FrmMain1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 frm1 = new Form2();
            frm1.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.sfoa.com.cn/admin/login.html");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbNote_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(id);
            form1.ShowDialog();
        }
    }
}
