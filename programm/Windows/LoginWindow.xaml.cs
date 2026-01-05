using System.Linq;
using System.Windows;
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

            if (string.IsNullOrEmpty(LoginBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Заполните поля", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                App.currentUser = App.context.Users.FirstOrDefault(u => u.Login == LoginBox.Text && u.Password == PasswordBox.Password);

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
    }
}
