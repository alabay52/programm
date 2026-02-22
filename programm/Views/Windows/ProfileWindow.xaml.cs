using System.Windows;
using programm.Window;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow
    {
        public ProfileWindow()
        {
            InitializeComponent();
            NameTbl.Text = App.currentUser.FullName.ToString();
            RoleTbl.Text = App.currentUser.Role.Name;
            EmailTbl.Text = App.currentUser.Email.ToString();
            PhoneTbl.Text = App.currentUser.Telephone.ToString();
            LoginTbl.Text = App.currentUser.Login.ToString();

        }






        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void BackBtnd_Click(object sender, RoutedEventArgs e)
        {
            if (App.currentUser.Role.Name == "Администратор")
            {
                TechnicWindow technicWindow = new TechnicWindow();
                technicWindow.Show();
                Close();
            }
            if (App.currentUser.Role.Name == "Менеджер")
            {
                BookingWindow bookingWindow = new BookingWindow();
                bookingWindow.Show();
                Close();
            }
        }
    }
}
