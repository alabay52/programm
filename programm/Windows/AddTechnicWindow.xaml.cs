using Microsoft.Win32;
using programm.Modl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTechnicWindow.xaml
    /// </summary>
    public partial class AddTechnicWindow
    {


        //private byte[] photoTechnic;
        private Technic newModel = new Technic();


        public AddTechnicWindow()
        {
            InitializeComponent();
            StatusCmb.SelectedValuePath = "Id";
            StatusCmb.DisplayMemberPath = "Name";
            StatusCmb.ItemsSource = App.context.Status.ToList();
            
        }

        //public void AddPhoto()
        //{
        //    Technic photoTechnic = new Technic();


        //    OpenFileDialog fileDialog = new OpenFileDialog();
        //    fileDialog.ShowDialog();

        //    foreach (var photo in fileDialog.FileNames)
        //    {
        //        photoTechnic.Photo = File.ReadAllBytes(photo);
        //       App.context.Technic.Add(photoTechnic);



        //    }
        //    MessageBox.Show("Фотография добавлена");
        //}



        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
           //AddPhoto();
            
        
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
            //else
            //{


            //    Technic technic = new Technic()
            //    {
            //        Name = NameTb.Text,
            //        VIN = VINTb.Text,
            //        Description = DescriptionTb.Text,



            //        Status = StatusCmb.SelectedItem as Status
            //    };
            //App.context.Technic.Add(technic);
            //App.context.SaveChanges();
            //MessageBox.Show("Техника добавлена");

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

        }
    }
    }

