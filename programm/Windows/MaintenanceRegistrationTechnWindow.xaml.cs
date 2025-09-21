using System.Windows;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для MaintenanceRegistrationTechnWindow.xaml
    /// </summary>
    public partial class MaintenanceRegistrationTechnWindow
    {
        public MaintenanceRegistrationTechnWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            TechnicWindow technicWindow = new TechnicWindow();
            technicWindow.Show();
            this.Hide();
        }
    }
}
