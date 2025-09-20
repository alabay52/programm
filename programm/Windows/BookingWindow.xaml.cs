using programm.Windows;

namespace programm.Window
{
    /// <summary>
    /// Логика взаимодействия для BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow
    {
        public BookingWindow()
        {
            InitializeComponent();
        }

        private void statusEquipmentBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void AddReservation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void HistoryBooking_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BookingHistoryWindow bookingHistoryWindow = new BookingHistoryWindow();
            bookingHistoryWindow.Show();
            this.Hide();
        }

        private void TechnikBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TechnicWindow technicWindow = new TechnicWindow();
            technicWindow.Show();
            this.Hide();
        }
    }
}
