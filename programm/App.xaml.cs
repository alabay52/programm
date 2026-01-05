using System.Windows;
using programm.Modl;

namespace programm
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SochnevBdEntities context = new SochnevBdEntities();
        public static Users currentUser = new Users();
    }
}
