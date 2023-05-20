using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Metrics;
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
            db.Users.Load();
            Database.ItemsSource = db.Houses.ToList();
            Database1.ItemsSource= db.Users.ToList();
            ItemsList.ItemsSource = db.Review.ToList();
            //ReviewsContainer.ItemsSource = db.Review.ToList();

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
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            mainWindow.Show();
        }
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            mainWindow.Show();
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

        // Обработчик нажатия на кнопку "Вперед"


        private void DatabaseSelectionChanged(object sender, SelectionChangedEventArgs e) // закидывает выделенный товар в поля формы для изменения
        {
            if (Database.SelectedItem != null)
            {
                Houses selectedModel = (Houses)Database.SelectedItem;

                newItemID.Text = selectedModel.Id.ToString();
                newItemProperty.Text = selectedModel.PropertyType.Type;
                newItemAddres.Text = selectedModel.Address;
                newItemMetr.Text = selectedModel.Metrage.ToString();
                newItemRoom.Text = selectedModel.Rooms.ToString();
                newItemDesc.Text = selectedModel.Description;
                newItemPrice.Text = selectedModel.Price.ToString();
                AddImageButton.Content = selectedModel.Img;

            }
        }
        private void DatabaseUsersSelectionChanged(object sender, SelectionChangedEventArgs e) // закидывает выделенный товар в поля формы для изменения
        {
            if (Database1.SelectedItem != null)
            {
                User selectedModel = (User)Database1.SelectedItem;
                newItemIDUser.Text = selectedModel.Id.ToString();
                newItemLogin.Text = selectedModel.Login;
                newItemEmail.Text = selectedModel.Email;

            }
        }
        private void AddNewUser(object sender, RoutedEventArgs e) // закидывает выделенный товар в поля формы для изменения
        {
            try
            {
                User user = CurrentSessionUser.User;
                string name = newItemLogin.Text;
                string email = newItemEmail.Text;
                if (db.Users.Any(u => u.Email == email && u.Login != name))
                {
                    throw new Exception("Пользователь с такой почтой уже существует, но логин другой");
                }
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(email, emailPattern))
                {
                    throw new Exception("Неправильный формат почты");
                }
                User newUser = new()
                {
                    Login = name,
                    Email = email,
                    IsAdmin = false
                };
                
                _ = db.Users.Add(newUser);
                _ = db.SaveChanges();
                MessageBox.Show("Добавлено!");

                db.Users.Load();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка заполнения");
            }

        }
        private void SearchField(object sender, TextChangedEventArgs e)
        {
            string searchText = searchField.Text; // Получаем текст из TextBox

            db.Houses.Load();
            ItemsList.ItemsSource = db.Houses.ToList().Where(house => house.Address.Contains(searchText) || house.Owner.Login.Contains(searchText) || house.Price.ToString().Contains(searchText) || house.PropertyType.Type.Contains(searchText) || house.Metrage.ToString().Contains(searchText) || house.Description.Contains(searchText));
        }
        private void AddNewHouse(object sender, RoutedEventArgs e) // закидывает выделенный товар в поля формы для изменения
        {
                try
                {
                User owner = CurrentSessionUser.User;
                int OId = CurrentSessionUser.User.Id;
                string img = AddImageButton.Content.ToString();
                string type = newItemProperty.Text;
                string Description = newItemDesc.Text;
                string Address = newItemAddres.Text;
                int metr = Convert.ToInt32(newItemMetr.Text);
                int Price = Convert.ToInt32(newItemPrice.Text);
                int Rooms = Convert.ToInt32(newItemRoom.Text);
                PropertyType propertyType = db.PropertyType.FirstOrDefault(pt => pt.Type == type);
                
                Houses newhouse = new()
                {
                    Address = Address,
                    Price = Price,
                    Metrage = metr,
                    Rooms = Rooms,
                    Owner = owner,
                    OwnerId = OId,
                    Description = Description,
                    PropertyType = propertyType, // Используем существующий объект propertyType
                    Img = img,
                    IsFavorite = false
                };
                User currentUser = db.Users.FirstOrDefault(u => u.Id == CurrentSessionUser.User.Id);
                if (currentUser != null)
                {
                    newhouse.Owner = owner;
                    newhouse.OwnerId = OId;
                }
                _ = db.Houses.Add(newhouse);
                _ = db.SaveChanges();
                MessageBox.Show("Добавлено!");
                newItemID.Clear();
                newItemProperty.Clear();
                newItemAddres.Clear();
                newItemRoom.Clear();
                newItemPrice.Clear();
                newItemDesc.Clear();
                db.Houses.Load();

            }
                catch (Exception ) { 
                MessageBox.Show("Ошибка заполнения");
                }
            
        }
        private void DeletebyId(object sender, RoutedEventArgs e) // функция загрузки изображения
        {
            try
            {
                int id = Convert.ToInt32(deletedItemIdInput.Text);
                Houses newhouse = db.Houses.FirstOrDefault(u => u.Id == id);
                if (db.Houses.Any(u => u.Id == id))
                {
                    _ = db.Houses.Remove(newhouse);
                    _ = db.SaveChanges();
                    MessageBox.Show("Удалено!");
                }
                deletedItemIdInput.Clear();
                db.Houses.Load();
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не Id");
            }

        }
        private void DeletebyIdUser(object sender, RoutedEventArgs e) // функция загрузки изображения
        {
            try
            {
                int id = Convert.ToInt32(deletedItemIdInput2.Text);
                User newuser = db.Users.FirstOrDefault(u => u.Id == id);
                if (db.Houses.Any(u => u.Id == id))
                {
                    _ = db.Users.Remove(newuser);
                    _ = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не Id");
            }

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

                AddImageButton.Content = image.UriSource.AbsoluteUri; // обрезка пути, использование только нужной
            }

        }
        private void ClearForm(object sender, RoutedEventArgs e) // очищает форму
        {

            newItemID.Clear();
            newItemProperty.Clear();
            newItemAddres.Clear();
            newItemRoom.Clear();
            newItemPrice.Clear();
            newItemDesc.Clear();


            AddImageButton.Content = "";
            AddItemButton.Content = "Добавить товар";
            MessageBox.Show("Форма очищена!");

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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
