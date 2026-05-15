using System.Linq;
using System.Windows;
using programm.Views.Windows;
using programm.Windows;

namespace programm.Window
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordTb.Password))
            {
                MessageBox.Show("Заполните поля", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                App.currentUser = App.context.Users.FirstOrDefault(u => u.Login == LoginTb.Text && u.Password == PasswordTb.Password);

                if (App.currentUser != null)
                {

                    MessageBox.Show("Вы успешно авторизовались", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);


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
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }





            }


        }

        private void ReserPasswordHl_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
            changePasswordWindow.ShowDialog();
        }

        private void RegHl_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }
    }
}
