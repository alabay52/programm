using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using programm.Modl;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTechnicWindow.xaml
    /// </summary>
    public partial class AddTechnicWindow
    {


        private Technic newModel = new Technic();
        public AddTechnicWindow()
        {
            InitializeComponent();
            StatusCmb.SelectedValuePath = "Id";
            StatusCmb.DisplayMemberPath = "Name";
            StatusCmb.ItemsSource = App.context.Status.ToList();

        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.jpg;*.png)|*.jpg;*.png"
            };

            if (fileDialog.ShowDialog() == true)
            {
                newModel.Photo = File.ReadAllBytes(fileDialog.FileName);
                MessageBox.Show("Фотография добавлена");
            }
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            TechnicWindow technicWindow = new TechnicWindow();
            technicWindow.Show();
            Close();
        }
        private void AddTechnicBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Text) && string.IsNullOrEmpty(VINTb.Text) && string.IsNullOrEmpty(StatusCmb.Text) && string.IsNullOrEmpty(DescriptionTb.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            newModel.Name = NameTb.Text;
            newModel.VIN = VINTb.Text;
            newModel.Description = DescriptionTb.Text;
            newModel.Status = StatusCmb.SelectedItem as Status;
            App.context.Technic.Add(newModel);
            App.context.SaveChanges();

            MessageBox.Show("Техника добавлена");

            newModel = new Technic(); // подготовка для следующей записи
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }
    }
}

