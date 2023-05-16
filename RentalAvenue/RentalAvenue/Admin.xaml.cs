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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        internal static DatabaseContext db = DB.connector;
        private List<Review> _reviews;

        // Индекс текущего отзыва
        private int _currentIndex = 0;
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        public string messageBoxText = ""; // сообщение при добавлении\изменении предмета
        public Admin()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
            //_reviews = LoadReviews();
            db.PropertyType.Load();
            db.Houses.Load();
            Database.ItemsSource = db.Houses.ToList();
            //DataContext = admin;
            //// Отображаем первый отзыв
            //ShowCurrentReview();
        }
        private void OnPrevClick(object sender, RoutedEventArgs e)
        {
            // Переходим к предыдущему отзыву
            if (_currentIndex > 0)
            {
                _currentIndex--;
               // ShowCurrentReview();
            }
        }

        // Обработчик нажатия на кнопку "Вперед"
        private void OnNextClick(object sender, RoutedEventArgs e)
        {
            // Переходим к следующему отзыву
            if (_currentIndex < _reviews.Count - 1)
            {
                _currentIndex++;
               // ShowCurrentReview();
            }
        }
        private void DatabaseSelectionChanged(object sender, SelectionChangedEventArgs e) // закидывает выделенный товар в поля формы для изменения
        {
            if (Database.SelectedItem != null)
            {
                Houses selectedModel = (Houses)Database.SelectedItem;

                newItemID.Text = selectedModel.Id.ToString();
                newItemProperty.Text = selectedModel.PropertyType.Type;
                newItemAddres.Text = selectedModel.Address;
                newItemRoom.Text = selectedModel.Rooms.ToString();
                newItemDesc.Text = selectedModel.Description;
                newItemPrice.Text = selectedModel.Price.ToString();
                AddImageButton.Content = selectedModel.Img;

                AddItemButton.Content = "Изменить товар";
            }
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
