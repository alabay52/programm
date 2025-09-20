using programm.Window;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookingHistoryWindow.xaml
    /// </summary>
    public partial class BookingHistoryWindow
    {
        public BookingHistoryWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BookingWindow AddingReservationWindow = new BookingWindow();
            AddingReservationWindow.Show();
            this.Hide();
        }
    }
}
