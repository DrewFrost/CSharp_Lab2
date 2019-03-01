using System.Windows.Controls;
using MorozCsharp2.ViewModel;

namespace MorozCsharp2.View
{
    /// <summary>
    /// Логика взаимодействия для UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
            DataContext = new UserViewModel();
        }
    }
}
