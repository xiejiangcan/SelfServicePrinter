using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.Common.Models
{
    public class PrePrintFileModel : BindableBase
    {
        private bool _checked;
        /// <summary>
        /// 文件名称
        /// </summary>
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; RaisePropertyChanged(); }
        }

        private string _fileName;
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; RaisePropertyChanged(); }
        }

        private string _fileDir;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FileDir
        {
            get { return _fileDir; }
            set { _fileDir = value; RaisePropertyChanged(); }
        }

        private double _progressValue;
        /// <summary>
        /// 文件上传进度值
        /// </summary>
        public double ProgressValue
        {
            get { return _progressValue; }
            set { _progressValue = value; RaisePropertyChanged(); }
        }
    }
}
