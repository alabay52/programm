using System.Windows;
using programm.Window;
namespace programm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        //private SochnevBd2Entities _context = new SochnevBd2Entities();
        //private int _currentUserId; // id администратора
        public MainWindow(/*int currentUserId*/)
        {
            InitializeComponent();
            //_currentUserId = currentUserId;
            //LoadData();
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BookingWindow AddingReservationWindow = new BookingWindow();
            AddingReservationWindow.Show();
            this.Hide();
        }
        //private void LoadData()
        //{
        //    // Загружаем пользователей
        //    cmbUser.ItemsSource = _context.Users.ToList();
        //    cmbUser.SelectedValuePath = "IdUser";
        //    cmbUser.DisplayMemberPath = "FullName";

        //    // Загружаем свободную технику (статус "не забронирован")
        //    // Предположим, что статус с именем "Свободен" или "Не забронирован"
        //    var freeStatus = _context.Status.FirstOrDefault(s => s.Name == "Не забронирован" || s.Name == "Свободен");
        //    if (freeStatus != null)
        //    {
        //        cmbTechnic.ItemsSource = _context.Technic.Where(t => t.IdStatus == freeStatus.IdStatus).ToList();
        //    }
        //    else
        //    {
        //        // если нет такого статуса, загружаем всю технику (но это нежелательно)
        //        cmbTechnic.ItemsSource = _context.Technic.ToList();
        //    }
        //    cmbTechnic.SelectedValuePath = "IdTechnic";
        //    cmbTechnic.DisplayMemberPath = "Name";

        //    // Загружаем тарифы
        //    // Для удобства отображения создадим список с вычисляемым полем
        //    var tariffs = _context.TariffRents.ToList();
        //    // Можно использовать DisplayMemberPath с форматированием через ItemTemplate
        //    cmbTariff.ItemsSource = tariffs;
        //    cmbTariff.SelectedValuePath = "IdTariff";
        //    // Используем ItemTemplate для отображения
        //    cmbTariff.ItemTemplate = (DataTemplate)FindResource("TariffTemplate"); // определим в ресурсах
        //}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {





            //if (cmbUser.SelectedItem == null || cmbTechnic.SelectedItem == null || cmbTariff.SelectedItem == null ||
            //       dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
            //{
            //    MessageBox.Show("Заполните все поля");
            //    return;
            //}

            //// Проверка дат
            //if (dpStartDate.SelectedDate >= dpEndDate.SelectedDate)
            //{
            //    MessageBox.Show("Дата окончания должна быть позже даты начала");
            //    return;
            //}

            //decimal price;
            //if (!decimal.TryParse(txtPrice.Text, out price))
            //{
            //    MessageBox.Show("Некорректная цена");
            //    return;
            //}

            //// Получаем выбранные Id
            //int userId = (int)cmbUser.SelectedValue;
            //int technicId = (int)cmbTechnic.SelectedValue;
            //int tariffId = (int)cmbTariff.SelectedValue;
            //try
            //{
            //    // ... проверки как выше ...

            //    // Создаем бронирование
            //    var booking = new Booking
            //    {
            //        IdUsers = userId,
            //        StartDateBooking = dpStartDate.SelectedDate.Value,
            //        EndDateBooking = dpEndDate.SelectedDate.Value,
            //        Price = price,
            //        IdAdministrotor = _currentUserId
            //    };

            //    _context.Booking.Add(booking);
            //    _context.SaveChanges();

            //    // Создаем связь
            //    var technicalTariff = new TechicalTariff
            //    {
            //        IdTechical = technicId,
            //        IdTariff = tariffId,
            //        IdBooking = booking.IdBooking
            //    };

            //    _context.TechicalTariff.Add(technicalTariff);

            //    // Обновляем статус
            //    var technic = _context.Technic.Find(technicId);
            //    var bookedStatus = _context.Status.FirstOrDefault(s => s.Name == "Забронирован");
            //    if (bookedStatus != null)
            //    {
            //        technic.IdStatus = bookedStatus.IdStatus;
            //    }

            //    _context.SaveChanges();

            //    MessageBox.Show("Бронирование успешно добавлено!");
            //    this.DialogResult = true;
            //    this.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Ошибка: {ex.Message}");
        }
    }

}








