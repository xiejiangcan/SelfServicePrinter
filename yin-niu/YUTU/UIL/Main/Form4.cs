using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;

namespace YUTU.UIL.Main
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


        private string stringToPrint;
        private void button1_Click(object sender, EventArgs e)
        {

            string docName = "工.jpg";
            string docPath = @"c:\";


            //stringToPrint = ReadFile(docPath + docName, Encoding.GetEncoding("GBK"));
            var doc = new Document();
            doc.LoadFromFile(docPath + docName);
            PrintDocument printDoc = doc.PrintDocument;
            printDoc.PrintController = new StandardPrintController();
            printDoc.Print();
            doc.Close();

            //if (this.printDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    this.printDocument1.Print();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }





        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //打印内容 为 整个Form
            //Image myFormImage;
            //myFormImage = new Bitmap(this.Width, this.Height);
            //Graphics g = Graphics.FromImage(myFormImage);
            //g.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //e.Graphics.DrawImage(myFormImage, 0, 0);

            //打印内容 为 局部的 this.groupBox1

            Bitmap _NewBitmap = new Bitmap(panel1.Width - 1, panel1.Height - 1);
            panel1.DrawToBitmap(_NewBitmap, new Rectangle(1, 1, _NewBitmap.Width, _NewBitmap.Height));
            e.Graphics.DrawImage(_NewBitmap, 1, 1, _NewBitmap.Width, _NewBitmap.Height);




            //打印内容 为 自定义文本内容
            //Font font = new Font("宋体", 12);
            //Brush bru = Brushes.Blue;
            //for (int i = 1; i <= 5; i++)
            //{
            //    e.Graphics.DrawString("Hello world ", font, bru, i * 20, i * 20);
            //}




        }




 
        private void button4_Click(object sender, EventArgs e)
        {
            string docName = "新建 DOCX 文档.docx";
            string docPath = @"c:\";

            Process pr = new Process();

            pr.StartInfo.FileName = docPath+ docName;//文件全称-包括文件后缀

            pr.StartInfo.CreateNoWindow = true;

            pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            pr.StartInfo.Verb = "Print";

            pr.Start();
        }
    }
}
