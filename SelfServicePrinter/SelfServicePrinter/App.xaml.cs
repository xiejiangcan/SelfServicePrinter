using Prism.Ioc;
using SelfServicePrinter.Common;
using SelfServicePrinter.ViewModels.Dialogs;
using SelfServicePrinter.Views;
using SelfServicePrinter.Views.Dialogs;
using System.Windows;

namespace SelfServicePrinter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDialogHostService, DialogHostService>();


            containerRegistry.RegisterForNavigation<MsgView, MsgViewModel>();
        }
    }
}
