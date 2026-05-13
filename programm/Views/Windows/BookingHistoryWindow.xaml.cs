using System.Collections.Generic;
using System.Linq;
using System.Windows;
using programm.Modl;
using programm.Window;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookingHistoryWindow.xaml
    /// </summary>
    public partial class BookingHistoryWindow
    {

        private List<Booking> _booking;
        public BookingHistoryWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _booking = App.context.Booking.ToList();
            BookindLv.ItemsSource = App.context.Booking.ToList();
        }

        private void ProfileBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }

        private void BackBtn_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            BookingWindow bookingWindow = new BookingWindow();
            bookingWindow.Show();
            Close();
        }

        private void SearchTb_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchString))
            {
                LoadData();
                return;
            }
            var filteredList = _booking.Where(Booking => Booking.Technic.Name.ToLower().Contains(searchString) ||
          Booking.Users.FullName.ToLower().Contains(searchString) ||
          Booking.Users1.FullName.ToLower().Contains(searchString)).ToList();
            BookindLv.ItemsSource = filteredList;
        }

        private void DeleteBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Booking selectedBooking = (Booking)BookindLv.SelectedItem;
            if (selectedBooking != null)
            {
                try
                {

                    App.context.Booking.Remove(selectedBooking);
                    App.context.SaveChanges();
                    MessageBox.Show("Бронирование успешно удалено.");
                    LoadData();
                }
                catch

                {
                    MessageBox.Show("Невозможно удалить бронирование");
                }

            }
        }
    }
}
