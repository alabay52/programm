using System.Linq;
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
    }
}
