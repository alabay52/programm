using System.Windows;
using programm.Window;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для TechnicWindow.xaml
    /// </summary>
    public partial class TechnicWindow
    {
        public TechnicWindow()
        {
            InitializeComponent();
        }

        private void BookingBtn_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow bookingWindow = new BookingWindow();
            bookingWindow.Show();
            this.Hide();
        }
    }
}
