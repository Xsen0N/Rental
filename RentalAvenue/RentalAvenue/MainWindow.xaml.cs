using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentalAvenue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static DatabaseContext db = DB.connector;
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        public MainWindow()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Manual;
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
            db.PropertyType.Load();
            db.Houses.Load();
            ItemsList.ItemsSource = db.Houses.ToList();
            AllFilters.ItemsSource = db.PropertyType.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OnNavigateToRentalForm(object sender, RoutedEventArgs e)
        {
            Rent rentalForm = new Rent();
            rentalForm.Show();
            Close();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Regist registrationForm = new Regist();
            registrationForm.Show();
            Close();
        }
        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            Rent rentWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            rentWindow.Show();
            Close();
        }
        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            popupMenu.IsOpen = !popupMenu.IsOpen;
        }
        #region Функции смены языка

        private void Ru_Selected(object sender, RoutedEventArgs e) // смена языка на русский путем добавления-удаления словарей
        {
            Resources.MergedDictionaries.Remove(enDict);
            Resources.MergedDictionaries.Add(ruDict);
        }
        private void Eng_Selected(object sender, RoutedEventArgs e) // смена языка на английский путем добавления-удаления словарей
        {
            Resources.MergedDictionaries.Remove(ruDict);
            Resources.MergedDictionaries.Add(enDict);
        }
        #endregion
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
        private void OnNavigateToAdmin(object sender, RoutedEventArgs e)
        {
            Rent rentalForm = new Rent();
            rentalForm.Show();
        }
    }
}
