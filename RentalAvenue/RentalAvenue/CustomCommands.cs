﻿using System.Windows.Input;

namespace RentalAvenue
{
    public class CustomCommands
    {
        public static readonly RoutedUICommand LogIntoProgram = new("Вход в программу", "LogIntoProgram", typeof(CustomCommands));
        public static readonly RoutedUICommand RegistrationRedirect = new("Переход на страницу регистрации", "RegistrationRedirect", typeof(CustomCommands));
        public static readonly RoutedUICommand LogInRedirect = new("Возврат на страницу входа", "LogInRedirect", typeof(CustomCommands));
        public static readonly RoutedUICommand ShowAllHouses = new("Отображение недвижимости", "ShowAllHouses", typeof(CustomCommands));
        public static readonly RoutedUICommand AddHouse = new("Добавление недвижимости", "AddHouse", typeof(CustomCommands));
    }
}