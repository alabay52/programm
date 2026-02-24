using programm.Modl;
using System.Windows;


namespace programm
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
      public static SochnevBd22Entities context = new SochnevBd22Entities();
        public static Users currentUser { get; set; }
        public static Users selectedUser { get; set; }
        public static TariffRents currentTarif { get; set; }
        public static Technic currentTechnic { get; set; }
    }
}
