﻿using System;
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
using System.Windows.Shapes;

namespace RentalAvenue
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        internal static DatabaseContext db = DB.connector;
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        private readonly RentalAvenue.Entities.FavoriteHouses currenthouse;
        public Users()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
            db.Houses.Load();
            ItemsList.ItemsSource = db.Houses.ToList().Where(house => house.IsFavorite == true);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
            Rent rentWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            rentWindow.Show();
            
        }
        private void AddReview_Click(object sender, RoutedEventArgs e)
        {
            Review rentWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            rentWindow.Show();
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
        private void RedirectToFavoriteWindow(object sender, ExecutedRoutedEventArgs e)
        {
            var houses = e.Parameter as RentalAvenue.Entities.Houses;
            if (houses != null)
            {
                if (houses.IsFavorite == false)
                {


                    MessageBox.Show("Элемент добавлен");
                    houses.IsFavorite = true;
                }
                else
                {
                    MessageBox.Show("Элемент удален");
                    houses.IsFavorite = false;
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка! Попробуйте еще раз.");
            }
        }
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            mainWindow.Show();
            Close();
        }
        private void RedirectToHouseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            var houses = e.Parameter as RentalAvenue.Entities.Houses;
            if (houses != null)
            {
                House housePage = new(houses)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                housePage.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Произошла ошибка ! Попробуйте еще раз.");
            }
        }
    }
}
