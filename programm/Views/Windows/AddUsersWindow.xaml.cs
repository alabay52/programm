using System.Collections.Generic;
using System.Linq;
using System.Windows;
using programm.Modl;
using programm.Windows;

namespace programm.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUsersWindow.xaml
    /// </summary>
    public partial class AddUsersWindow
    {
        private List<Users> _users;
        private Users newModel = new Users();
        public AddUsersWindow()
        {
            InitializeComponent();
            RoleClientCmb.SelectedValuePath = "Id";
            RoleClientCmb.DisplayMemberPath = "Name";
            RoleClientCmb.ItemsSource = App.context.Role.ToList();
            var managerRole = App.context.Role.FirstOrDefault(r => r.Name == "Клиент");
            if (managerRole != null)
            {
                RoleClientCmb.ItemsSource = new List<Role> { managerRole };
                RoleClientCmb.SelectedIndex = 0;
            }
            RefreshUsersList();
        }
        private void RefreshUsersList()
        {
            List<Users> users = App.context.Users
                .Where(u => u.Role.Name == "клиент" || u.Role.Name == "менеджер")
        .ToList();
            UsersLv.ItemsSource = users;
            _users = users; // сохраняем для поиска
        }


        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameClientTb.Text) && string.IsNullOrEmpty(EmailClientTb.Text) && string.IsNullOrEmpty(PassportClientTb.Text) && string.IsNullOrEmpty(TelephoneClientTb.Text) && string.IsNullOrEmpty(RoleClientCmb.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            newModel.FullName = NameClientTb.Text;

            newModel.Email = EmailClientTb.Text;
            newModel.PassportData = PassportClientTb.Text;
            newModel.Telephone = TelephoneClientTb.Text;
            newModel.Role = RoleClientCmb.SelectedItem as Role;


            App.context.Users.Add(newModel);
            App.context.SaveChanges();

            MessageBox.Show("Клиент добавлен");

            newModel = new Users(); // подготовка для следующей записи
            RefreshUsersList(); // обновляем список
                                // Очистка полей ввода (по желанию)
            NameClientTb.Text = "";
            EmailClientTb.Text = "";
            PassportClientTb.Text = "";
            TelephoneClientTb.Text = "";
            RoleClientCmb.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            TechnicWindow technicWindow = new TechnicWindow();
            technicWindow.Show();
            Close();
        }




        private void SearchTb_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchString))
            {
                UsersLv.ItemsSource = _users;
                return;
            }

            var filteredList = _users.Where(u =>
                (u.FullName != null && u.FullName.ToLower().Contains(searchString)) ||
                (u.PassportData != null && u.PassportData.ToLower().Contains(searchString)) ||
                (u.Telephone != null && u.Telephone.ToLower().Contains(searchString))
            ).ToList();

            UsersLv.ItemsSource = filteredList;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Users selectedUsers = (Users)UsersLv.SelectedItem;
            if (selectedUsers == null)
            {
                MessageBox.Show("Выберите пользователя для удаления");
                return;
            }
            try
            {
                App.context.Users.Remove(selectedUsers);
                App.context.SaveChanges();
                MessageBox.Show("Пользователь успешно удален.");
                RefreshUsersList();
            }
            catch
            {

                MessageBox.Show("Невозможно удалить пользователя");
            }
        }

        private void EditUsers_Click(object sender, RoutedEventArgs e)
        {
            Users selectedUsers = UsersLv.SelectedItem as Users;
            if (selectedUsers != null)
            {
                EditUsersWindow editTaskWindow = new EditUsersWindow(selectedUsers);
                if (editTaskWindow.ShowDialog() == true)
                {
                    RefreshUsersList();

                }
            }
        }
    }
}
