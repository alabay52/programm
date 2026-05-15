using System.Collections.Generic;
using System.Linq;
using System.Windows;
using programm.Modl;

namespace programm.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow
    {
        private List<Users> _users;
        private Users newModel = new Users();
        public RegistrationWindow()
        {
            InitializeComponent();
            RoleEmployeeCmb.SelectedValuePath = "Id";
            RoleEmployeeCmb.DisplayMemberPath = "Name";
            RoleEmployeeCmb.ItemsSource = App.context.Role.ToList();
            var managerRole = App.context.Role.FirstOrDefault(r => r.Name == "Менеджер");
            if (managerRole != null)
            {
                RoleEmployeeCmb.ItemsSource = new List<Role> { managerRole };
                RoleEmployeeCmb.SelectedIndex = 0;
            }

        }

        private void btnSaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameEmployeeTb.Text) && string.IsNullOrEmpty(EmailEmployeeTb.Text) && string.IsNullOrEmpty(TelephoneTb.Text) && string.IsNullOrEmpty(LoginTb.Text) && string.IsNullOrEmpty(PaswordPb.Password) && string.IsNullOrEmpty(RoleEmployeeCmb.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            newModel.FullName = NameEmployeeTb.Text;

            newModel.Email = EmailEmployeeTb.Text;
            newModel.Telephone = TelephoneTb.Text;
            newModel.Login = LoginTb.Text;
            newModel.Password = PaswordPb.Password;
            newModel.Role = RoleEmployeeCmb.SelectedItem as Role;


            App.context.Users.Add(newModel);
            App.context.SaveChanges();

            MessageBox.Show("Вы зарегистрировались");

            newModel = new Users(); // подготовка для следующей записи

            NameEmployeeTb.Text = "";
            EmailEmployeeTb.Text = "";
            TelephoneTb.Text = "";
            LoginTb.Text = "";
            PaswordPb.Password = "";
            RoleEmployeeCmb.SelectedIndex = 0;
        }
    }
}
