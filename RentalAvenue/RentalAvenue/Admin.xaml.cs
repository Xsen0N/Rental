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
using System.Windows.Shapes;

namespace RentalAvenue
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        public string messageBoxText = ""; // сообщение при добавлении\изменении предмета
        public Admin()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
        }
        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            popupMenu.IsOpen = !popupMenu.IsOpen;
        }
        private void OnNavigateToRentalForm(object sender, RoutedEventArgs e)
        {
            Rent rentalForm = new Rent();

            rentalForm.Show();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Regist registrationForm = new Regist();
            registrationForm.Show();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
