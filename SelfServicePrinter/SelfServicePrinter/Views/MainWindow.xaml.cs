using Prism.Events;
using SelfServicePrinter.Common;
using System.Windows;
using System.Windows.Input;

namespace SelfServicePrinter.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IEventAggregator aggregator, IDialogHostService dialogHostService)
        {
            InitializeComponent();

            btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            
            btnClose.Click += async (s, e) =>
            {
                var dialogResult = await dialogHostService.Question("温馨提示", "确认退出系统?");
                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
                this.Close();
            };
            ColorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            };
        }
    }
}
