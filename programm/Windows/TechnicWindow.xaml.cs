using System.Windows;
using programm.Window;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для TechnicWindow.xaml
    /// </summary>
    public partial class TechnicWindow
    {
        public TechnicWindow()
        {
            InitializeComponent();
        }

        private void BookingBtn_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow bookingWindow = new BookingWindow();
            bookingWindow.Show();
            this.Hide();
        }

        private void TechnikDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            TechnikDeleteWindow technikDeleteWindow = new TechnikDeleteWindow();
            technikDeleteWindow.Show();
            this.Hide();
        }

        private void RegisterMaintenanceBtn_Click(object sender, RoutedEventArgs e)
        {
            MaintenanceRegistrationTechnWindow maintenanceRegistrationTechnWindow = new MaintenanceRegistrationTechnWindow();
            maintenanceRegistrationTechnWindow.Show();
            this.Hide();
        }
    }
}
