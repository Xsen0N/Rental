using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    public partial class Rent : Window
    {
        internal static DatabaseContext db = DB.connector;
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        public Rent()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
           // UserData.DataContext = Entity_Framework.CurrentSessionUser.User;

        }
        private void LoadImageFile(object sender, RoutedEventArgs e) // функция загрузки изображения
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"; // фильтр

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();

                image.BeginInit();
                image.UriSource = new Uri(openFileDialog.FileName);
                image.EndInit();

                PhotoTextBox.Content = "./" + image.UriSource.Segments[image.UriSource.Segments.Length - 2] + image.UriSource.Segments[image.UriSource.Segments.Length - 1]; // обрезка пути, использование только нужной
            }

        }
        private void OnSubmit(object sender, RoutedEventArgs e)
        {

            try
            {
                
                
            string img = PhotoTextBox.Content.ToString();
            string type = PropertyTypeComboBox.Text;
            string Address = AddressTextBox.Text;
            int metr = Convert.ToInt32(Metr.Text);
            int Price = Convert.ToInt32(PriceTextBox.Text);
            int Rooms = Convert.ToInt32(RoomsComboBox.Text);
            string Description = DescriptionTextBox.Text;
            Houses houses = db.Houses.FirstOrDefault(pt => pt.PropertyType.Type == PropertyTypeComboBox.Text);
                // считываем данные из полей ввода

                // проверяем почту на уникальность
                if (db.Houses.Any(u => u.Img == img && u.Metrage == metr))
                {
                    throw new Exception("Такое объявление уже есть");
                }

                // проверяем правильность ввода почты и телефона с помощью regex
                string pattern = @"^(ул\.|str\.)\s*(\D+)\s+(\d+)(?:-(\d+))?";

                if (!Regex.IsMatch(Address, pattern))
                {
                    throw new Exception("Неправильный формат улицы, введите по примерно так: ул. Примерная 123-45/str. Example 789");
                }
                PropertyType types = new PropertyType();
                types.Type = type;

                // создаем новый объект User
                Houses newhouse = new()
                {
                    Address = Address,
                    Price = Price,
                    Metrage= metr,
                    Rooms = Rooms,
                    Owner = CurrentSessionUser.User.Id.ToString(),
                    Description = Description,
                    PropertyType = types,
                    Img = img
                    
                };

                // добавляем нового пользователя в контекст данных
                _ = db.Houses.Add(newhouse);
                _ = db.SaveChanges();


                // выводим сообщение об успешном завершении 
                _ = MessageBox.Show("Заполнение прошло успешно!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

                Close();
            
            }
            catch (Exception ex)
            {
                // выводим сообщение об ошибке
                _ = MessageBox.Show($"Ошибка при добавлении объявления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
