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
            cmbTechnic.ItemsSource = App.context.Technic.ToList();

            cmbTariff.SelectedValuePath = "IdTariff";
            cmbTariff.DisplayMemberPath = "Name";
            cmbTariff.ItemsSource = App.context.TariffRents.ToList();

            var userRole = App.context.Role.FirstOrDefault(r => r.Name == "Пользователь");
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
            if (dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
            {
                MessageBox.Show("Выберите даты начала и окончания.");
                return;
            }

            // Получаем выбранные объекты
            Users selectedUser = (Users)cmbUser.SelectedItem;
            TariffRents selectedTariff = (TariffRents)cmbTariff.SelectedItem;
            Technic selectedTechnic = (Technic)cmbTechnic.SelectedItem;

            DateTime start = dpStartDate.SelectedDate.Value.Date;
            DateTime finish = dpEndDate.SelectedDate.Value.Date;

            if (finish <= start)
            {
                MessageBox.Show("Дата окончания должна быть позже даты начала.");
                return;
            }

            // Проверка текущего администратора
            if (App.currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации администратора.");
                return;
            }

            TimeSpan days = finish - start; // или finish.Subtract(start)
            decimal totalDays = (decimal)days.TotalDays;

            Booking booking = new Booking()
            {
                IdUsers = selectedUser.IdUser,
                IdTariff = selectedTariff.IdTariff,
                IdTechnical = selectedTechnic.IdTechnical,
                StartDateBooking = start,
                Price = selectedTariff.Price * totalDays,
                EndDateBooking = finish,
                IdAdministrotor = App.currentUser.IdUser
            };

            // Обновление статуса техники
            selectedTechnic.IdStatus = 1; // Предполагается, что статус 1 означает "занят"

            App.context.Booking.Add(booking);
            App.context.SaveChanges();

            MessageBox.Show("Бронирование успешно сохранено.");














            //App.currentTarif = cmbTariff.SelectedValue as TariffRents;

            //DateTime start = dpStartDate.SelectedDate.Value.Date;
            //DateTime finish = dpEndDate.SelectedDate.Value.Date;
            //TimeSpan days = finish.Subtract(start);
            //Booking booking = new Booking()
            //{
            //    IdUsers = cmbUser.SelectedIndex + 1,
            //    IdTariff = cmbTariff.SelectedIndex + 1,
            //    IdTechnical = cmbTechnic.SelectedIndex + 1,
            //    StartDateBooking = start,
            //    Price = App.currentTarif.Price * (decimal)days.TotalDays,
            //    EndDateBooking = finish,
            //    IdAdministrotor = App.currentUser.IdUser
            //};
            //App.currentTechnic.IdStatus = 1;
            //App.context.Booking.Add(booking);
            //App.context.SaveChanges();
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








