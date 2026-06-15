using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using programm.Modl;
using programm.Views.Windows;
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
            var filteredList = _booking.Where(Booking => Booking.Technic.Name.ToLower().Contains(searchString) || Booking.TariffRents.Name.ToLower().Contains(searchString) ||
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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Booking selectedbooking = BookindLv.SelectedItem as Booking;
            if (selectedbooking == null)
            {
                MessageBox.Show("Выберите бронирование для редактирования.", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем, можно ли редактировать: если закончилось более 3 дней назад — запрет
            if (selectedbooking.EndDateBooking < DateTime.Today.AddDays(-3))
            {
                MessageBox.Show("Редактирование недоступно: бронирование завершилось более 3 дней назад.",
                                "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Если бронирование уже закончилось, но не более 3 дней назад — предупреждаем
            if (selectedbooking.EndDateBooking < DateTime.Today)
            {
                var result = MessageBox.Show(
                    "Внимание: дата окончания бронирования уже прошла, но ещё не превысила 3 дня.\nВы уверены, что хотите редактировать?",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    return;
            }
            EditBookingWindow editTaskWindow = new EditBookingWindow(selectedbooking);
            if (editTaskWindow.ShowDialog() == true)
            {
                // Обновляем список бронирований после редактирования
                BookindLv.ItemsSource = App.context.Booking.ToList();
            }
        }
    }
}
