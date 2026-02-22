using System.Windows;

namespace programm.Windows
{
    /// <summary>
    /// Логика взаимодействия для TechnikDeleteWindow.xaml
    /// </summary>
    public partial class TechnikDeleteWindow
    {
        public TechnikDeleteWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            TechnicWindow technicWindow = new TechnicWindow();
            technicWindow.Show();
            this.Hide();
        }
    }
}
