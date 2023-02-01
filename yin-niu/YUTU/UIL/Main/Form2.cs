using HZH_Controls.Controls;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<DataNotice> dataNotices ;
            ApiYnHelper.GetNoticeList(1, 10, out dataNotices);

            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "id", HeadText = "ID", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "type", HeadText = "类型", Width = 220, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "title", HeadText = "标题", Width = 500, WidthType = SizeType.Absolute });
            //lstCulumns.Add(new DataGridViewColumnEntity() { HeadText = "操作", Width = 220, WidthType = SizeType.Absolute, CustomCellType = typeof(UCTestGridTable_CustomCell) });

            this.ucDataGridView1.Columns = lstCulumns;
            //this.ucDataGridView1.IsShowCheckBox = true;
            foreach (var item in dataNotices)
            {
                if (item.type == "1")
                {
                    item.type = "活动公告";
                }
                if (item.type == "2")
                {
                    item.type = "经营公告";
                }
                if (item.type == "3")
                {
                    item.type = "店铺公告";
                }
            }

            this.ucDataGridView1.DataSource = dataNotices;
        }

        private void ucDataGridView1_ItemClick(object sender, DataGridViewEventArgs e)
        {
            if (this.ucDataGridView1.SelectRows.Count == 0)
            {
                MessageBox.Show("请选择一条信息！");
                return;
            }

            int id = ((YUTU.ThirdPartyApi.ApiYnHelper.DataNotice)ucDataGridView1.SelectRows[0].DataSource).id;

            Form1 form1 = new Form1(id);
            form1.ShowDialog();

        }
    }
}
