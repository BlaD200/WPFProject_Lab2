using System.ComponentModel;
using System.Windows;

namespace WPFProject_Lab2.Tools
{
    interface ILoaderOwner: INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
