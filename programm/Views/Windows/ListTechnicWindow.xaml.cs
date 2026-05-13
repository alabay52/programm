using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using programm.Modl;
using programm.Windows;

namespace programm.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ListTechnicWindow.xaml
    /// </summary>
    public partial class ListTechnicWindow
    {
        private string _selectedTechicStatus = "Все"; // Значение по умолчанию
        private List<string> _techicStatus = new List<string>()
        {
            "Все",
            "Забронирован",

            "Не забронирован",
            "На ремонте"
        };
        private List<Technic> _technices;
        public ListTechnicWindow()
        {
            InitializeComponent();
            FilterCmb.ItemsSource = _techicStatus;  // добавляем
            FilterCmb.SelectedIndex = 0;            // выбираем "Все" по умолчанию (индекс 1)
            LoadData();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            TechnicWindow technicWindow = new TechnicWindow();
            technicWindow.Show();
            Close();
        }
        private void LoadData()
        {
            _technices = App.context.Technic.ToList();

            // Затем применяем фильтр по статусу
            ApplyStatusFilter();
            //TechnicLv.ItemsSource = App.context.Technic.ToList();
            //if (selectedTechicStatus == "Все")
            //{
            //    TechnicLv.ItemsSource = _technices;
            //}
            //else
            //{
            //    TechnicLv.ItemsSource = _technices.Where(c => c.Status.Name == selectedTechicStatus);
            //}


            //_technices = App.context.Technic.ToList();

        }
        private void ApplyStatusFilter()
        {
            if (_technices == null) return;

            if (_selectedTechicStatus == "Все")
            {
                TechnicLv.ItemsSource = _technices;
            }
            else
            {
                var filtered = _technices.Where(c => c.Status.Name == _selectedTechicStatus).ToList();
                TechnicLv.ItemsSource = filtered;
            }
        }
        private void SearchTb_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text.ToLower();

            // Если ввели хоть один символ, переключаем комбо-бокс на "Все"
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                // Меняем выбранный элемент, не вызывая событие повторно
                FilterCmb.SelectionChanged -= FilterCmb_SelectionChanged;
                FilterCmb.SelectedItem = "Все";
                _selectedTechicStatus = "Все";
                FilterCmb.SelectionChanged += FilterCmb_SelectionChanged;
            }

            // Далее логика фильтрации
            if (string.IsNullOrWhiteSpace(searchString))
            {
                ApplyStatusFilter();
                return;
            }

            // Фильтр по поиску уже без учета статуса (т.к. статус = Все)
            var filteredList = _technices
                .Where(technic =>
                    technic.Name.ToLower().Contains(searchString) ||
                    technic.VIN.ToLower().Contains(searchString) ||
                    (technic.Status?.Name?.ToLower().Contains(searchString) ?? false))
                .ToList();

            TechnicLv.ItemsSource = filteredList;
            //  string searchString = SearchTb.Text.ToLower();
            //  if (string.IsNullOrWhiteSpace(searchString))
            //  {
            //      LoadData();
            //      return;
            //  }
            //  var filteredList = _technices.Where(Technic => Technic.Name.ToLower().Contains(searchString) ||
            //Technic.VIN.ToLower().Contains(searchString) ||
            //Technic.Status.Name.ToLower().Contains(searchString)).ToList();
            //  TechnicLv.ItemsSource = filteredList;
        }

        private void FilterCmb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (FilterCmb.SelectedItem != null)
            {
                _selectedTechicStatus = FilterCmb.SelectedItem.ToString();
                // При смене статуса сбрасываем поиск (опционально)
                SearchTb.Text = "";
                ApplyStatusFilter();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Technic selectedtechnic = (Technic)TechnicLv.SelectedItem;
            //if (selectedtechnic != null)
            //{
            //    try
            //    {
            //        App.context.Technic.Remove(selectedtechnic);
            //        App.context.SaveChanges();
            //        MessageBox.Show("Техника успешно удалено.");
            //        LoadData();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Невозможно удалить технику, так как она участвует в бронированиях.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        LoadData();
            //    }
            Technic selectedtechnic = (Technic)TechnicLv.SelectedItem;
            if (selectedtechnic == null)
            {
                MessageBox.Show("Выберите технику для удаления.");
                return;
            }

            // Проверяем, есть ли у техники связанные бронирования
            bool hasBookings = App.context.Booking.Any(b => b.IdTechnical == selectedtechnic.IdTechnical); // предположим, у Technic есть Id
            if (hasBookings)
            {
                MessageBox.Show("Невозможно удалить технику, так как она участвует в бронированиях.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                LoadData(); // перезагружаем данные, чтобы очистить возможные некорректные состояния
                return;
            }

            try
            {
                App.context.Technic.Remove(selectedtechnic);
                App.context.SaveChanges();
                MessageBox.Show("Техника успешно удалена.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                LoadData(); // перезагружаем данные в любом случае
            }
        }
    }
}

