using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using SelfServicePrinter.Common;
using SelfServicePrinter.Extensions;

namespace SelfServicePrinter.ViewModels
{
    public class MainWindowViewModel : BindableBase, IConfigureService
    {
        private string _title = "Prism Application";
        private readonly IContainerProvider containerProvider;
        private readonly IRegionManager regionManager;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IContainerProvider containerProvider,
            IRegionManager regionManager)
        {
            this.containerProvider = containerProvider;
            this.regionManager = regionManager;
        }

        public void Configure()
        {
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("HomeView");
        }
    }
}
