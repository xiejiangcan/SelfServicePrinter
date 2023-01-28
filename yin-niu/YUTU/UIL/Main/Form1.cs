using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YUTU.ThirdPartyApi;
using static YUTU.ThirdPartyApi.ApiYnHelper;

namespace YUTU.UIL.Main
{
    public partial class Form1 : Form
    {
        private int id;
        private int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Form1(int noteId)
        {
            id = noteId;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NoticeDetailData noticeDetailData;
            ApiYnHelper.GetNoticeDetail(Id,out noticeDetailData);

            label1.Text= noticeDetailData.title;
            switch (noticeDetailData.type)
            {
                case 1:
                    label2.Text = "活动公告";
                    break;
                case 2:
                    label2.Text = "经营公告";
                    break;
                case 3:
                    label2.Text = "店铺公告";
                    break;
            }
            
            label3.Text = noticeDetailData.create_time;
            webBrowser1.DocumentText = noticeDetailData.content;
        }
    }
}
