using System;
using System.Linq;
using System.Windows;
using programm.Modl;
using programm.Window;
using programm.Windows;

namespace programm.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTariffWindow.xaml
    /// </summary>
    public partial class AddTariffWindow
    {
        private TariffRents newModel = new TariffRents();
        public AddTariffWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            TariffLv.ItemsSource = App.context.TariffRents.ToList();
        }
        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow bookingWindow = new BookingWindow();
            bookingWindow.Show();
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Text) && string.IsNullOrEmpty(PriceTb.Text) && string.IsNullOrEmpty(Descriptiontb.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            newModel.Name = NameTb.Text;

            newModel.Description = Descriptiontb.Text;
            newModel.Price = Convert.ToDecimal(PriceTb.Text);
            App.context.TariffRents.Add(newModel);
            App.context.SaveChanges();

            MessageBox.Show("Тариф добавлена");

            newModel = new TariffRents(); // подготовка для следующей записи
            LoadData();
            NameTb.Text = "";
            Descriptiontb.Text = "";
            PriceTb.Text = "";

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            TariffRents selectedTariff = (TariffRents)TariffLv.SelectedItem;
            if (selectedTariff != null)
            {
                try
                {
                    App.context.TariffRents.Remove(selectedTariff);
                    App.context.SaveChanges();
                    MessageBox.Show("Тариф успешно удален.");
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить тариф");
                }


            }
        }
    }
}
