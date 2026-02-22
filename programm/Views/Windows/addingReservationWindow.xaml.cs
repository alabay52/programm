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
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BookingWindow AddingReservationWindow = new BookingWindow();
            AddingReservationWindow.Show();
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
