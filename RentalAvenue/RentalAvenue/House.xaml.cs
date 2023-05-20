using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using static RentalAvenue.Entities;

namespace RentalAvenue
{
    /// <summary>
    /// Логика взаимодействия для House.xaml
    /// </summary>
    public partial class House : Window
    {
        internal static DatabaseContext db = DB.connector;
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        private readonly RentalAvenue.Entities.Houses currenthouse;
        
        public House()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
            Name.Text = CurrentSessionUser.User.Login;
            Email.Text = CurrentSessionUser.User.Email;
        }
        public House(Entities.Houses houses) {
            InitializeComponent();
            db.Houses.Load();
            Resources.MergedDictionaries.Add(ruDict);
            DataContext = houses;
            currenthouse = houses;
            Name.Text = CurrentSessionUser.User.Login;
            Email.Text = CurrentSessionUser.User.Email;
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
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            mainWindow.Show();
        }
        private void AddReview_Click(object sender, RoutedEventArgs e)
        {
            Review rentWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            rentWindow.Show();
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
        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            Rent rentWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            rentWindow.Show();
            
        }
        private void ShowLikeed_Click(object sender, RoutedEventArgs e)
        {
            RentalAvenue.Users userWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            userWindow.Show();
            Close();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                string name = Name.Text;
                if (name == null) {
                    throw new Exception("Надо ввести имя!");
                }
                string email = Email.Text;
                int id = currenthouse.Id;
                RentalAvenue.Entities.Houses houses = currenthouse;
                DateTime BookingDate1 = DateTime.Now;
                Entities.User user = CurrentSessionUser.User;
                int userId = CurrentSessionUser.User.Id;
                Booking booking = new()
                {
                    BookingDate = BookingDate1,
                    UserId = userId,
                    HouseId = id,
                    User = user
                };
                _ = db.Booking.Add(booking);
                _ = db.SaveChanges();
                MessageBox.Show($"Момент бронирования {booking.BookingDate.ToString()}, Недвижимость под ID {booking.HouseId}. Владелец ответит вам на почту: {email} в ближайшее время, {user.Login} " );
            }
            catch(Exception ) {
                MessageBox.Show("Ошибка");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
