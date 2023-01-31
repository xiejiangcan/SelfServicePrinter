using Microsoft.Win32;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using SelfServicePrinter.Common;
using SelfServicePrinter.Common.Models;
using Spire.Pdf;
using Spire.Pdf.Print;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SelfServicePrinter.ViewModels
{
    public class HomeViewModel : NavigationViewModel
    {
        private readonly PrintDocument pd = new PrintDocument();
        private readonly IDialogHostService dialogHost;

        public HomeViewModel(IContainerProvider provider)
           : base(provider)
        {
            ExecuteCommand = new DelegateCommand<string>(Execute);
            dialogHost = provider.Resolve<IDialogHostService>();
            PrintSettingModel = new PrintSettingModel();
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public PrintSettingModel PrintSettingModel { get; set; }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "设置": Setting(); break;
                case "添加": Add(); break;
                case "删除": Delete(); break;
            }
        }

        private async void Setting()
        {
            DialogParameters param = new DialogParameters();
            if (PrintSettingModel != null)
                param.Add("Value", PrintSettingModel);

            var dialogResult = await dialogHost.ShowDialog("PrintSettingView", param);
            if (dialogResult.Result == ButtonResult.OK)
            {
                PrintSettingModel = dialogResult.Parameters.GetValue<PrintSettingModel>("Value");
            }
        }

        private void Add()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF document (.pdf)|*.pdf";
            dialog.DefaultExt = ".pdf";
            dialog.FileName = "Document";

            var result = dialog.ShowDialog();
            if (result != true)
            {
                return;
            }

            string fileName = dialog.FileName;

            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(fileName);

            pdf.PrintSettings.DocumentName = "Test.pdf";

            // 设置打印机
            pdf.PrintSettings.PrinterName = PrintSettingModel.Printer;
            pd.PrinterSettings.PrinterName = PrintSettingModel.Printer;

            if (!pd.PrinterSettings.IsValid)
            {
                // 提示打印机不可用
                MessageBox.Show("Printer is not valid");
                return;
            }

            // 设置打印颜色
            if (!pd.PrinterSettings.SupportsColor && PrintSettingModel.PrintColor == EnumPrintColor.Colors)
            {
                // 提示打印机不可用
                MessageBox.Show("Printer is not support Colors");
                return;
            }
            // 设置打印颜色
            pd.DefaultPageSettings.Color = PrintSettingModel.PrintColor == EnumPrintColor.Colors;
            pdf.PrintSettings.Color = PrintSettingModel.PrintColor == EnumPrintColor.Colors;

            // 设置双面打印
            switch (PrintSettingModel.PrintPage)
            {
                case EnumPrintPageType.SinglePage:
                    pd.PrinterSettings.Duplex = Duplex.Simplex;
                    pdf.PrintSettings.Duplex = Duplex.Simplex;
                    break;
                case EnumPrintPageType.DoublePage:
                    if (PrintSettingModel.PageOrientation == EnumPageOrientation.Horizontal)
                    {
                        pd.PrinterSettings.Duplex = Duplex.Horizontal;
                        pdf.PrintSettings.Duplex = Duplex.Horizontal;
                    }
                    else
                    {
                        pd.PrinterSettings.Duplex = Duplex.Vertical;
                        pdf.PrintSettings.Duplex = Duplex.Vertical;
                    }
                    break;
            }

            // 设置打印方向
            pd.DefaultPageSettings.Landscape = PrintSettingModel.PageOrientation == EnumPageOrientation.Horizontal;
            pdf.PrintSettings.Landscape = PrintSettingModel.PageOrientation == EnumPageOrientation.Horizontal;

            // 设置打印份数
            pdf.PrintSettings.Copies = (short)PrintSettingModel.PrintCount;

            // 设置打印布局
            switch (PrintSettingModel.PageLayout)
            {
                case EnumPageLayout.NoScale:
                    {
                        //获取原文档第一页的纸张大小,这里的单位是Point
                        SizeF size = pdf.Pages[0].Size;

                        //实例化PaperSize对象，设置其宽高
                        //需要特别注意的是这里涉及到单位的转换，PaperSize的宽高参数默认单位是百英寸 
                        PaperSize paper = new PaperSize("Custom", (int)size.Width / 72 * 100, (int)size.Height / 72 * 100);
                        paper.RawKind = (int)PaperKind.Custom;

                        //设置打印的纸张大小为原来文档的大小
                        pdf.PrintSettings.PaperSize = paper;

                        //需要选择FitSize打印模式
                        pdf.PrintSettings.SelectSinglePageLayout(PdfSinglePageScalingMode.FitSize, true);
                    }
                    break;
                case EnumPageLayout.OnePage:
                    pdf.PrintSettings.SelectMultiPageLayout(1, 1);
                    break;
                case EnumPageLayout.TwoPage:
                    pdf.PrintSettings.SelectMultiPageLayout(1, 2);
                    break;
                case EnumPageLayout.FourPage:
                    pdf.PrintSettings.SelectMultiPageLayout(2, 2);
                    break;
                case EnumPageLayout.SixPage:
                    pdf.PrintSettings.SelectMultiPageLayout(3, 2);
                    break;
                case EnumPageLayout.NinePage:
                    pdf.PrintSettings.SelectMultiPageLayout(3, 3);
                    break;
            }

            pdf.PrintSettings.SelectPageRange(11, 19);
            pdf.Print();

        }

        private void Delete()
        {

        }
    }
}
