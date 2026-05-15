using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
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
            var status = App.context.Status.FirstOrDefault(r => r.Name == "Не забронирован");
            if (status != null)
            {
                StatusCmb.ItemsSource = new List<Status> { status };
                StatusCmb.SelectedIndex = 0;
            }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.jpg;*.png)|*.jpg;*.png"
            };

            if (fileDialog.ShowDialog() == true)
            {
                //newModel.Photo = File.ReadAllBytes(fileDialog.FileName);
                //MessageBox.Show("Фотография добавлена");
                byte[] imageBytes = File.ReadAllBytes(fileDialog.FileName);
                newModel.Photo = imageBytes;

                // Отобразить выбранное фото
                BitmapImage bitmap = new BitmapImage();
                using (var stream = new MemoryStream(imageBytes))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze();
                }
                PhotoPreview.Source = bitmap;
                MessageBox.Show("Фотография добавлена и отображается");
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

            newModel = new Technic();

            NameTb.Text = "";
            VINTb.Text = "";
            DescriptionTb.Text = "";
            PhotoPreview.Source = null;

        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }
    }
}

