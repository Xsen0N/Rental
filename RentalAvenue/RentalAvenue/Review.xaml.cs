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
using System.Windows.Shapes;
using static RentalAvenue.Entities;

namespace RentalAvenue
{
    /// <summary>
    /// Логика взаимодействия для Review.xaml
    /// </summary>
    public partial class Review : Window
    {

        public string messageBoxText = ""; // сообщение при добавлении\изменении предмета
        internal static DatabaseContext db = DB.connector;
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        public Review()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LogTextBox.Text = CurrentSessionUser.User.Login;        

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string comment = CommTextBox.Text;
            int userid = CurrentSessionUser.User.Id;
            User user = CurrentSessionUser.User;
            Entities.Review review = new()
            {
            Comment = comment,
            User = user,
            UserId = userid
            };
            db.Review.Add(review);
            _ = db.SaveChanges();

            _ = MessageBox.Show("Спасибо за ваш отзыв!!!!!");

        }

        
    }
}
