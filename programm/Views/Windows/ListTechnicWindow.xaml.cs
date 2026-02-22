using System.Linq;
using System.Windows;
using programm.Windows;

namespace programm.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ListTechnicWindow.xaml
    /// </summary>
    public partial class ListTechnicWindow
    {
        public ListTechnicWindow()
        {
            InitializeComponent();
            TechnicLv.ItemsSource = App.context.Technic.ToList();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            TechnicWindow technicWindow = new TechnicWindow();
            technicWindow.Show();
            Close();
        }
    }
}
