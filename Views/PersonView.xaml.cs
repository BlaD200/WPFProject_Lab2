using System.Windows.Controls;
using WPFProject_Lab2.ViewModels;

namespace WPFProject_Lab2.Views
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        private PersonViewModel _viewModel;

        public PersonView()
        {
            InitializeComponent();
            DataContext = _viewModel = new PersonViewModel();
        }
    }
}
