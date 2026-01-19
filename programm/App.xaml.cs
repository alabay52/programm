using programm.Modl;
using System.Windows;


namespace programm
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
      public static SochnevBd2Entities context = new SochnevBd2Entities();
        public static Users currentUser = new Users();
    }
}
