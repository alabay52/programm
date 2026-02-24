using programm.Modl;
using programm.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            App.currentTarif = cmbTariff.SelectedValue as TariffRents;

            DateTime start = dpStartDate.SelectedDate.Value.Date;
            DateTime finish = dpEndDate.SelectedDate.Value.Date;
            TimeSpan days = finish.Subtract(start);
            Booking booking = new Booking()
            {
                IdUsers = cmbUser.SelectedIndex + 1,
                IdTariff = cmbTariff.SelectedIndex + 1,
                IdTechnical = cmbTechnic.SelectedIndex + 1,
                StartDateBooking = start,
                Price = App.currentTarif.Price * (decimal)days.TotalDays,
                EndDateBooking = finish,
                IdAdministrotor = App.currentUser.IdUser
            };
            App.currentTechnic.IdStatus = 1;
            App.context.Booking.Add(booking);
            App.context.SaveChanges();
        }

    }

}








