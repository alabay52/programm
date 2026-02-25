using System.Linq;
using System.Windows;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(OldPasswordPb.Password) || string.IsNullOrEmpty(NewPasswordPb.Password) || string.IsNullOrEmpty(ChangeNewPasswordPb.Password))
            {
                MessageBox.Show("Заполните поля  ", "Предупреждения", MessageBoxButton.OK, MessageBoxImage.Warning);



            }


            else
            {
                // Ищем пользователя по логину
                var user = App.context.Users
                    .FirstOrDefault(u => u.Login.Trim() == LoginTb.Text.Trim());

                if (user == null)
                {
                    MessageBox.Show("Пользователь с таким логином не найден",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Проверка старого пароля
                if (user.Password != OldPasswordPb.Password)
                {
                    MessageBox.Show("Неверный старый пароль",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Проверка совпадения новых паролей
                if (NewPasswordPb.Password != ChangeNewPasswordPb.Password)
                {
                    MessageBox.Show("Новые пароли не совпадают",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Смена пароля
                user.Password = NewPasswordPb.Password;
                int saved = App.context.SaveChanges();

                MessageBox.Show($"Пароль изменён. Сохранено записей: {saved}",
                    "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
