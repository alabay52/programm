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


            #region 
            //else
            //{
            //    var currentUser = App.context.Users.FirstOrDefault(u => u.Login == LoginTb.Text);

            //    if (currentUser == null)
            //    {
            //        MessageBox.Show("Пользователь не найден  ", "Проверьте введеные данные", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //    if (currentUser != null)
            //    {

            //        if (App.currentUser.Password == OldPasswordPb.Password && NewPasswordPb.Password == ChangeNewPasswordPb.Password)
            //        {
            //            MessageBox.Show("Пароль изменен", "Информация", MessageBoxButton.OK, MessageBoxImage.Warning);

            //            App.currentUser.Password = NewPasswordPb.Password;

            //            App.context.SaveChanges();

            //        }

            //        else
            //        {
            //            MessageBox.Show("Старый пароль указан неправильно или несовпадают новые пароли  ", "Проверьте введеные данные", MessageBoxButton.OK, MessageBoxImage.Error);

            //        }
            //    }

            //}
            #endregion


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
