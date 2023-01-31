using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SelfServicePrinter.Common;
using SelfServicePrinter.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ViewModels.Dialogs
{
    public class PrintSettingViewModel : BindableBase, IDialogHostAware
    {
        public PrintSettingViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);

            Printers = new ObservableCollection<string>();
            foreach (string name in PrinterSettings.InstalledPrinters)
                Printers.Add(name);
        }

        private PrintSettingModel model;

        public PrintSettingModel Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<string> printers;

        public ObservableCollection<string> Printers
        {
            get { return printers; }
            set { printers = value; RaisePropertyChanged(); }
        }


        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Model.Printer) ||
                Model.PrintCount == 0) return;

            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                //确定时,把编辑的实体返回并且返回OK
                DialogParameters param = new DialogParameters();
                param.Add("Value", Model);
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
            }
        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public void OnDialogOpend(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Value"))
            {
                Model = parameters.GetValue<PrintSettingModel>("Value");
            }
            else
                Model = new PrintSettingModel();
        }
    }
}
