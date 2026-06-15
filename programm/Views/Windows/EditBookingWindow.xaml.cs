using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using programm.Modl;

namespace programm.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditBookingWindow.xaml
    /// </summary>
    public partial class EditBookingWindow
    {
        Booking selectedbooking;
        public EditBookingWindow(Booking selectedbooking)
        {
            InitializeComponent();
            this.selectedbooking = selectedbooking;

            DataContext = selectedbooking;



            TatiffCmb.SelectedValuePath = "id";
            TatiffCmb.SelectedIndex = 0;
            TatiffCmb.DisplayMemberPath = "Name";
            TatiffCmb.ItemsSource = App.context.TariffRents.ToList();
            TatiffCmb.SelectionChanged += Tariff_SelectionChanged; // подписка

            var availableTech = App.context.Technic
                .Where(t => t.IdStatus == 2) // свободная техника
                .ToList();

            // Если текущая техника не входит в список свободных (например, статус 3 - забронирована), добавляем её
            if (selectedbooking.Technic != null && !availableTech.Contains(selectedbooking.Technic))
            {
                availableTech.Add(selectedbooking.Technic);
            }

            TechnikCmb.ItemsSource = availableTech;
            TechnikCmb.SelectedItem = selectedbooking.Technic;

            // Подписка на изменения дат
            DateStartDp.SelectedDateChanged += Date_SelectedDateChanged;
            DateEbdDp.SelectedDateChanged += Date_SelectedDateChanged;

            // Первоначальный расчёт цены
            CalculateAndUpdatePrice();


        }
        private void CalculateAndUpdatePrice()
        {
            // Проверяем, что обе даты заданы (не null)
            if (selectedbooking.StartDateBooking == null || selectedbooking.EndDateBooking == null)
            {
                TotalPriceTextBlock.Text = "0 ₽";
                return;
            }

            // Теперь можно безопасно использовать .Value
            DateTime start = selectedbooking.StartDateBooking.Date;
            DateTime end = selectedbooking.EndDateBooking.Value;

            // Проверка, что дата окончания не раньше даты начала
            if (end < start)
            {
                TotalPriceTextBlock.Text = "Ошибка дат";
                return;
            }

            // Количество дней (включительно)
            int days = (end - start).Days;
            if (days < 1) days = 1;

            var tariff = TatiffCmb.SelectedItem as TariffRents;
            if (tariff == null)
            {
                TotalPriceTextBlock.Text = "Выберите тариф";
                return;
            }

            // Убедитесь, что PricePerDay – это действительно цена за 1 день
            decimal totalPrice = tariff.Price * days;

            TotalPriceTextBlock.Text = $"{totalPrice:N0} ₽";
            selectedbooking.Price = totalPrice;

        }
        private void Tariff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обновляем выбранный тариф в объекте
            if (TatiffCmb.SelectedItem is TariffRents tariff)
                selectedbooking.TariffRents = tariff;

            CalculateAndUpdatePrice();
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Даты уже обновляются через привязку SelectedDate
            CalculateAndUpdatePrice();
        }




        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TechnikCmb.SelectedItem == null || TatiffCmb.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Принудительный пересчёт на всякий случай
            CalculateAndUpdatePrice();

            App.context.SaveChanges();
            MessageBox.Show("Бронирование отредактировано", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
        }
    }
}
