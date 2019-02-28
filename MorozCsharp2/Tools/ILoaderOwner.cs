using System.ComponentModel;
using System.Windows;

namespace KMA.ProgrammingInCSharp2019.Practice4.LoginControlAsync.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
