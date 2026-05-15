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
            var managerRole = App.context.Role.FirstOrDefault(r => r.Name == "Пользователь");
            if (managerRole != null)
            {
                RoleClientCmb.ItemsSource = new List<Role> { managerRole };
                RoleClientCmb.SelectedIndex = 0;
            }
            LoadData();
            LoadUsers();
        }

        private void LoadUsers()
        {
            List<Users> users = App.context.Users
                .Where(u => u.Role.Name == "пользователь")
                .ToList();

            UsersLv.ItemsSource = users; // где usersListView - имя вашего ListView
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

            MessageBox.Show("Пользователь добавлена");

            newModel = new Users(); // подготовка для следующей записи
            LoadData();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            TechnicWindow technicWindow = new TechnicWindow();
            technicWindow.Show();
            Close();
        }

        private void LoadData()
        {
            _users = App.context.Users.ToList();
            UsersLv.ItemsSource = App.context.Users.ToList();
        }


        private void SearchTb_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchString))
            {
                LoadUsers();
                return;
            }
            var filteredList = _users.Where(Users => Users.FullName.ToLower().Contains(searchString) ||
          Users.PassportData.ToLower().Contains(searchString) ||
          Users.Telephone.ToLower().Contains(searchString)).ToList();
            UsersLv.ItemsSource = filteredList;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Users selectedUsers = (Users)UsersLv.SelectedItem;
            try
            {
                App.context.Users.Remove(selectedUsers);
                App.context.SaveChanges();
                MessageBox.Show("Пользователь успешно удален.");
                LoadData();
            }
            catch
            {

                MessageBox.Show("Невозможно удалить пользователя");
            }
        }
    }
}
