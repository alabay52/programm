using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using programm.Modl;

namespace programm.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditTechnicWindow.xaml
    /// </summary>
    public partial class EditTechnicWindow
    {
        Technic selectedTechnic;
        public EditTechnicWindow(Technic selectedTechnic)
        {
            InitializeComponent();
            this.selectedTechnic = selectedTechnic;

            DataContext = selectedTechnic;



            StatusCmb.SelectedValuePath = "id";
            StatusCmb.SelectedIndex = 0;
            StatusCmb.DisplayMemberPath = "Name";
            StatusCmb.ItemsSource = App.context.Status.ToList();
        }

        private void PhotoBtn_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.jpg;*.png)|*.jpg;*.png"
            };

            if (fileDialog.ShowDialog() == true)
            {
                selectedTechnic.Photo = File.ReadAllBytes(fileDialog.FileName);
                MessageBox.Show("Фотография добавлена");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();
            MessageBox.Show("Техника отредактирована", "информация", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
        }
    }
}
