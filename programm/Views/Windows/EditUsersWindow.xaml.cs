using System.Windows;
using programm.Modl;

namespace programm.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditUsersWindow.xaml
    /// </summary>
    public partial class EditUsersWindow
    {
        Users selectedUsers;
        public EditUsersWindow(Users selectedUsers)
        {
            InitializeComponent();
            this.selectedUsers = selectedUsers;

            DataContext = selectedUsers;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();
            MessageBox.Show("Пользователь отредактирован", "информация", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }
    }
}
