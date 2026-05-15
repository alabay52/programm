using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using programm.Modl;
using programm.Window;
using programm.Windows;

namespace programm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            cmbTechnic.SelectedValuePath = "IdTechnical";
            cmbTechnic.DisplayMemberPath = "Name";
            cmbTechnic.ItemsSource = App.context.Technic
       .Where(t => t.IdStatus == 2) // Фильтр по статусу
       .ToList();

            cmbTariff.SelectedValuePath = "IdTariff";
            cmbTariff.DisplayMemberPath = "Name";
            cmbTariff.ItemsSource = App.context.TariffRents.ToList();

            var userRole = App.context.Role.FirstOrDefault(r => r.Name == "Клиент");
            if (userRole != null)
            {
                cmbUser.ItemsSource = App.context.Users
                    .Where(u => u.IdRole == userRole.IdRole)
                    .ToList();
            }
            else
            {
                cmbUser.ItemsSource = new List<Users>();
            }
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BookingWindow AddingReservationWindow = new BookingWindow();
            AddingReservationWindow.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверка выбора пользователя
            if (cmbUser.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя.");
                return;
            }
            // Проверка выбора тарифа
            if (cmbTariff.SelectedItem == null)
            {
                MessageBox.Show("Выберите тариф.");
                return;
            }
            // Проверка выбора техники
            if (cmbTechnic.SelectedItem == null)
            {
                MessageBox.Show("Выберите технику.");
                return;
            }
            // Проверка выбора дат
            if (dpStartDate.SelectedDate == null)
            {
                MessageBox.Show("Выберите даты начала и окончания.");
                return;
            }


            Users selectedUser = (Users)cmbUser.SelectedItem;
            TariffRents selectedTariff = (TariffRents)cmbTariff.SelectedItem;
            Technic selectedTechnic = (Technic)cmbTechnic.SelectedItem;

            DateTime start = dpStartDate.SelectedDate.Value.Date;
            DateTime? finish = dpEndDate.SelectedDate?.Date;

            if (finish <= start)
            {
                MessageBox.Show("Дата окончания должна быть позже даты начала.");
                return;
            }


            if (App.currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации администратора.");
                return;
            }

            DateTime now = DateTime.Now.Date;

            decimal price;
            if (finish == null)
            {
                // Бессрочное бронирование: всегда считаем активным
                price = selectedTariff.Price;
                selectedTechnic.IdStatus = 1; // забронирован
            }
            else
            {
                // Проверка, что finish > start уже выполнена ранее
                TimeSpan days = finish.Value - start;
                price = selectedTariff.Price * (decimal)days.TotalDays;

                // Определяем статус в зависимости от того, наступила ли дата окончания
                if (finish.Value > now)
                {
                    // Дата окончания ещё не наступила -> бронирование актуально
                    selectedTechnic.IdStatus = 1; // забронирован
                }
                else
                {
                    // Дата окончания уже прошла -> техника свободна
                    selectedTechnic.IdStatus = 2; // не забронирован
                }
            }

            Booking booking = new Booking()
            {
                IdUsers = selectedUser.IdUser,
                IdTariff = selectedTariff.IdTariff,
                IdTechnical = selectedTechnic.IdTechnical,
                StartDateBooking = start,
                Price = price,
                EndDateBooking = finish,
                IdAdministrotor = App.currentUser.IdUser
            };




            App.context.Booking.Add(booking);
            App.context.SaveChanges();

            MessageBox.Show("Бронирование успешно сохранено.");

            dpEndDate.Text = "";
            dpStartDate.Text = "";

            cmbTariff.SelectedIndex = -1;
            cmbTechnic.SelectedIndex = -1;
            cmbUser.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow bookingWindow = new BookingWindow();
            bookingWindow.Show();
            Close();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }
    }

}








