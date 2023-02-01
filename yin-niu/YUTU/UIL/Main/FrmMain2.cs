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
using HZH_Controls;
using HZH_Controls.Controls;
using System.IO;
using System.Diagnostics;
using YUTU.ThirdPartyApi;
using YUTU.BLL.Global;

namespace YUTU.UIL.Main
{
    public partial class FrmMain2 : Form
    {
        List<TestGridModel> lstSourceTemp = new List<TestGridModel>();
        string[] uploadFName;

        public FrmMain2()
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
            this.Dispose();
        }
        private int id;
        private int Id
        {
            get { return id; }
            set { id = value; }
        }

        private void FrmMain2_Load(object sender, EventArgs e)
        {
            label4.Text = Login.UserName;
            string noteTitle = string.Empty;
            ApiYnHelper.GetNoticeList(1, 1, out noteTitle,out id);
            lbNote.Text = noteTitle;

            string imgUrl = string.Empty;
            ApiYnHelper.GetShopQrcode(out imgUrl);
            pbImgUrl.LoadAsync(imgUrl);


            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "选择文件名", Width = 220, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "上传进度", Width = 220, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { HeadText = "操作", Width = 220, WidthType = SizeType.Absolute, CustomCellType = typeof(UCTestGridTable_CustomCell) });

            this.ucDataGridView1.Columns = lstCulumns;
            this.ucDataGridView1.IsShowCheckBox = true;




            List<DataGridViewColumnEntity> lstCulumns2 = new List<DataGridViewColumnEntity>();
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "id", HeadText = "序号", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "文件", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "打印价格", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "颜色", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "类型", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "单双面", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "份数", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns2.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "状态", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns2.Add(new DataGridViewColumnEntity() { HeadText = "操作", Width = 220, WidthType = SizeType.Absolute, CustomCellType = typeof(UCTestGridTable_CustomCell) });

            this.ucDataGridView2.Columns = lstCulumns2;
            this.ucDataGridView2.IsShowCheckBox = true;


            List<DataGridViewColumnEntity> lstCulumns3 = new List<DataGridViewColumnEntity>();
            lstCulumns3.Add(new DataGridViewColumnEntity() { DataField = "id", HeadText = "序号", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns3.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "文件", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns3.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "打印价格", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns3.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "颜色", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns3.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "类型", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns3.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "单双面", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns3.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "份数", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns3.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "状态", Width = 50, WidthType = SizeType.Absolute });
            lstCulumns3.Add(new DataGridViewColumnEntity() { HeadText = "操作", Width = 220, WidthType = SizeType.Absolute, CustomCellType = typeof(UCTestGridTable_CustomCell) });

            this.ucDataGridView3.Columns = lstCulumns3;
            this.ucDataGridView3.IsShowCheckBox = true;

        }

        /// <summary>
        /// 将文件转换为二进制流进行读取
        /// </summary>
        /// <param name="fileName">文件完整名</param>
        /// <returns>二进制流</returns>
        private byte[] FileToBinary(string fileName)
        {
            try
            {
                FileStream fsRead = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                if (fsRead.CanRead)
                {
                    int fsSize = Convert.ToInt32(fsRead.Length);

                    byte[] btRead = new byte[fsSize];

                    fsRead.Read(btRead, 0, fsSize);

                    return btRead;
                }
                else
                {
                    MessageBox.Show("文件读取错误！");
                    return null;
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message);

                return null;
            }
        }

        /// <summary>
        /// 将二进制流转换为对应的文件进行存储
        /// </summary>
        /// <param name="filePath">接收的文件</param>
        /// <param name="btBinary">二进制流</param>
        /// <returns>转换结果</returns>
        private bool BinaryToFile(string fileName, byte[] btBinary)
        {
            bool result = false;

            try
            {
                FileStream fsWrite = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                if (fsWrite.CanWrite)
                {
                    fsWrite.Write(btBinary, 0, btBinary.Length);

                    //MessageBox.Show("文件写入成功！");
                    fsWrite.Close();
                    result = true;
                }
                else
                {
                    //MessageBox.Show("文件些入错误！");
                    result = false;
                }
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message);
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fileName">文件完整的路径名</param>
        /// <param name="nodeTipText">文件名</param>
        /// <returns>判断结果</returns>
        private bool JudgeFileExists(string fileName, string nodeTipText)
        {

            if (File.Exists(fileName))
            {
                StringBuilder sbError = new StringBuilder();
                sbError.Append(nodeTipText + "已存在于：/n");

                sbError.Append(fileName.Substring(0, fileName.LastIndexOf("//")) + "/n");

                sbError.Append("中，是否覆盖原文件？");

                string strSearch = MessageBox.Show(sbError.ToString(), "提示", MessageBoxButtons.YesNo).ToString();

                if (strSearch == "Yes")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }


        private void btDel_Click(object sender, EventArgs e)
        {
            if (this.ucDataGridView1.SelectRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的文件！"); 
                return;
            }

            List<TestGridModel> lstSource = new List<TestGridModel>();
            lstSource = this.ucDataGridView1.DataSource as List<TestGridModel>;

            foreach (IDataGridViewRow row in ucDataGridView1.SelectRows)
            {
                File.Delete("upload\\" + ((TestGridModel)((HZH_Controls.Controls.UCDataGridViewRow)row).DataSource).ID);
                

                TestGridModel tempModel = new TestGridModel()
                {
                    ID = ((TestGridModel)((HZH_Controls.Controls.UCDataGridViewRow)row).DataSource).ID,
                    Name = ((TestGridModel)((HZH_Controls.Controls.UCDataGridViewRow)row).DataSource).Name,
                    Age = ((TestGridModel)((HZH_Controls.Controls.UCDataGridViewRow)row).DataSource).Age
                };


                this.ucDataGridView1.Rows.Remove(row);
                lstSource.RemoveAll(a => a.ID == tempModel.ID);
            }

            this.ucDataGridView1.DataSource = lstSource;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {


            List<TestGridModel> lstSource = new List<TestGridModel>();
            lstSource = this.ucDataGridView1.DataSource as List<TestGridModel>;

            if (lstSource == null) return;

            foreach (var item in lstSource)
            {
                Process pr = new Process();

                pr.StartInfo.FileName = "upload\\"+ item.ID;//文件全称-包括文件后缀

                pr.StartInfo.CreateNoWindow = true;

                pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                pr.StartInfo.Verb = "Print";

                pr.Start();
            }

        }


        public void DelModel(TestGridModel testGridModel)
        {
            File.Delete("upload\\" + testGridModel.ID);

            lstSourceTemp.RemoveAll(a => a.ID == testGridModel.ID);

            this.ucDataGridView1.DataSource = lstSourceTemp;
        }

        private void pbUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog1.Filter = "文本文件|*.*|所有文件|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] fName = openFileDialog1.FileNames;


                if (fName.Length == 0) return;


                uploadFName = fName;
                if (uploadFName == null) return;

                List<TestGridModel> lstSource = new List<TestGridModel>();

                for (int i = 0; i < uploadFName.Length; i++)
                {
                    TestGridModel model = new TestGridModel()
                    {
                        ID = uploadFName[i],
                    };
                    lstSource.Add(model);
                }

                

                NewMethod(lstSource);

            }
        }

        //上传文件
        private void NewMethod(List<TestGridModel> lstSource)
        {

            this.ucDataGridView1.DataSource = lstSource;



            //保存文件的路径
            string loadPath = "upload";


            for (int i = 0; i < uploadFName.Length; i++)
            {
                //上传文件的文件名
                string loadName = uploadFName[i].Substring(uploadFName[i].LastIndexOf("\\") + 1);

                string loadFile = loadPath + "\\" + loadName;


                if (lstSourceTemp.Where(a => a.ID == loadName).ToList().Count > 0)
                {
                    continue;
                }


                byte[] btFile = FileToBinary(uploadFName[i]);

                BinaryToFile(loadFile, btFile);

                TestGridModel model = new TestGridModel()
                {
                    ID = loadName,
                    Name = "上传完成"
                };
                lstSourceTemp.Add(model);
            }
            this.ucDataGridView1.DataSource = lstSourceTemp;
        }



        private void ucDataGridView1_RowCustomEvent(object sender, DataGridViewRowCustomEventArgs e)
        {
            if (e.EventName == "Modify")
            {
                DelModel((TestGridModel)e.Data);
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            List<TestGridModel> lstSource = new List<TestGridModel>();

            string tempStr = string.Empty;
            for (var i = 0; i < ((System.Array)e.Data.GetData(DataFormats.FileDrop)).Length; i++)
            {
                string path1 = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(i).ToString();
                TestGridModel model = new TestGridModel()
                {
                    ID = path1,
                };
                lstSource.Add(model);
                tempStr += path1 + ",";
            }
            uploadFName = tempStr.TrimEnd(',').Split(',');

            NewMethod(lstSource);
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                //需求有一需要从QQ的聊天记录中拖拽图片到WinForm窗体中，用ALL会出现QQ的聊天信息中的图片丢失
                //Link和Move不能从QQ的聊天记录中拖拽图片到WinForm窗体中，Copy和Scroll都可以实现，推荐使用Copy
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            WindowOperate.ReleaseCapture();
            WindowOperate.SendMessage1(this.Handle);
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

        private void lbNote_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(id);
            form1.ShowDialog();
        }

        private void btPrintSet_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.ShowDialog();
        }
    }
}
