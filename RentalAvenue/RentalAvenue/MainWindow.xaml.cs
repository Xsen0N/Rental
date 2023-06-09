﻿using Microsoft.EntityFrameworkCore;
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
using static RentalAvenue.Entities;

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
        private void AllFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получите выбранный элемент
            var selectedFilter = AllFilters.SelectedItem as PropertyType;

            if (selectedFilter != null)
            {
                // Загрузите данные только выбранного типа
                var filteredData = db.Houses.Where(house => house.PropertyType == selectedFilter).ToList();
                ItemsList.ItemsSource = filteredData;
            }
            else
            {
                // Если ничего не выбрано, отобразите все данные
                ItemsList.ItemsSource = db.Houses.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OnNavigateToRentalForm(object sender, RoutedEventArgs e)
        {
            Rent rentWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            rentWindow.Show();
        }
        
        private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchField.Text; // Получаем текст из TextBox

            db.Houses.Load();
            ItemsList.ItemsSource = db.Houses.ToList().Where(house => house.Description.Contains(searchText));
        }
        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            db.Houses.Load();
            ItemsList.ItemsSource = db.Houses.ToList();
        }
        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            Rent rentWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            rentWindow.Show();
           
        }
        private void AddReview_Click(object sender, RoutedEventArgs e)
        {
            Review rentalForm = new Review();
            rentalForm.Show();
        }
        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            popupMenu.IsOpen = !popupMenu.IsOpen;
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
                MessageBox.Show("Произошла ошибка открытия окна! Попробуйте еще раз.");
            }
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
                else {
                    MessageBox.Show("Элемент удален");
                    houses.IsFavorite = false;
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка! Попробуйте еще раз.");
            }
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
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
        private void OnNavigateToAdmin(object sender, RoutedEventArgs e)
        {
            Rent rentalForm = new Rent();
            rentalForm.Show();
        }

        private void SearchField(object sender, TextChangedEventArgs e)
        {
            string searchText = searchField.Text; // Получаем текст из TextBox

            db.Houses.Load();
            ItemsList.ItemsSource = db.Houses.ToList().Where(house => house.Address.Contains(searchText) || house.Metrage.ToString().Contains(searchText) || house.Owner.Login.Contains(searchText) || house.Price.ToString().Contains(searchText) || house.PropertyType.Type.Contains(searchText));

        }

        
    }
}
