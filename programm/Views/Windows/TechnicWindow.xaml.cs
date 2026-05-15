using System.Windows;
using programm.Views.Windows;
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTechnicWindow addTechnicWindow = new AddTechnicWindow();
            addTechnicWindow.Show();
            Close();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }

        private void TechninBtn_Click(object sender, RoutedEventArgs e)
        {

            //MainFrame.Navigate(new TechnicPages());

            ListTechnicWindow listtechnicWindow = new ListTechnicWindow();
            listtechnicWindow.Show();
            Close();

        }

        private void UsersAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUsersWindow usersWindow = new AddUsersWindow();
            usersWindow.Show();
            Close();
        }



        //private void RegisterMaintenanceBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    MaintenanceRegistrationTechnWindow maintenanceRegistrationTechnWindow = new MaintenanceRegistrationTechnWindow();
        //    maintenanceRegistrationTechnWindow.Show();
        //    this.Hide();
        //}
    }
}
