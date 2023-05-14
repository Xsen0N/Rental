using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static RentalAvenue.Entities;

namespace RentalAvenue
{
    /// <summary>
    /// Логика взаимодействия для Rent.xaml
    /// </summary>
    public partial class Rent : Window
    {
        internal static DatabaseContext db = DB.connector;
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        public Rent()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов

        }
        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            // Создаем новый объект жилья и заполняем его данными из формы
            string type = PropertyTypeComboBox.SelectedValue.ToString();
            string Address = AddressTextBox.Text;
            //Houses houses = new Houses();
            Houses houses = db.Houses.FirstOrDefault(pt => pt.PropertyType == PropertyTypeComboBox.SelectedValue);

            // Создаем новый объект жилья и заполняем его данными из формы

            int Price = Convert.ToInt32(PriceTextBox.Text);
            int Rooms = Convert.ToInt32(RoomsComboBox.Text);
            string Description = DescriptionTextBox.Text;

            // Добавляем объект в базу данных
            // _context.Houses.Add(houses);
            //_context.SaveChanges();

            // Очищаем форму для следующего ввода
            PropertyTypeComboBox.SelectedIndex = 0;
            AddressTextBox.Clear();
            PriceTextBox.Clear();
            RoomsComboBox.SelectedIndex = 0;
            DescriptionTextBox.Clear();

            // Показываем сообщение об успешной отправке данных
            MessageBox.Show("Your rental property has been submitted successfully.");
        }
    }
}
