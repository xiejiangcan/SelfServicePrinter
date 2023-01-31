using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.Common.Models
{
    public class PrintSettingModel : BindableBase
    {
		private string _printer;
		/// <summary>
		/// 打印机名称
		/// </summary>
		public string Printer
		{
			get { return _printer; }
			set { _printer = value; RaisePropertyChanged(); }
		}

		private EnumPrintColor _printColor;
		/// <summary>
		/// 打印颜色
		/// </summary>
		public EnumPrintColor PrintColor
		{
			get { return _printColor; }
			set { _printColor = value; RaisePropertyChanged(); }
		}

		private EnumPrintPageType _printPage;
		/// <summary>
		/// 单双面
		/// </summary>
		public EnumPrintPageType PrintPage
		{
			get { return _printPage; }
			set { _printPage = value; RaisePropertyChanged(); }
		}

		private EnumPageOrientation _pageOrientation;
		/// <summary>
		/// 页面方向
		/// </summary>
		public EnumPageOrientation PageOrientation
		{
			get { return _pageOrientation; }
			set { _pageOrientation = value; RaisePropertyChanged(); }
		}

		private EnumPageLayout _pageLayout;
		/// <summary>
		/// 页面布局
		/// </summary>
		public EnumPageLayout PageLayout
		{
			get { return _pageLayout; }
			set { _pageLayout = value; RaisePropertyChanged(); }
		}

		private int _printCount;
		/// <summary>
		/// 打印数量
		/// </summary>
		public int PrintCount
		{
			get { return _printCount; }
			set { _printCount = value; RaisePropertyChanged(); }
		}

	}
}
