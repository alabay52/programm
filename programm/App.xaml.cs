using System.Windows;
using programm.Modl;


namespace programm
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SochnevBd2Entities context = new SochnevBd2Entities();
        public static Users currentUser { get; set; }
        public static Users selectedUser { get; set; }
        public static TariffRents currentTarif { get; set; }
        public static Technic currentTechnic { get; set; }
    }
}
