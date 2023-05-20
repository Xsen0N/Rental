using System.Windows.Input;

namespace RentalAvenue
{
    public class CustomCommands
    {
        public static readonly RoutedUICommand LogIntoProgram = new("Вход в программу", "LogIntoProgram", typeof(CustomCommands));
        public static readonly RoutedUICommand RegistrationRedirect = new("Переход на страницу регистрации", "RegistrationRedirect", typeof(CustomCommands));
        public static readonly RoutedUICommand ShowAllHouses = new("Отображение недвижимости", "ShowAllHouses", typeof(CustomCommands));
        public static readonly RoutedUICommand AddHouse = new("Добавление недвижимости", "AddHouse", typeof(CustomCommands));
        public static readonly RoutedUICommand AddReview = new("Добавление отзыва", "AddReview", typeof(CustomCommands));
        public static readonly RoutedUICommand Paste = new("Вставка изображения", "Paste", typeof(CustomCommands));
        public static readonly RoutedUICommand Save = new("Сохранение изображения", "Paste", typeof(CustomCommands));
        public static readonly RoutedUICommand ClearPage = new("Очистка формы", "Сlear", typeof(CustomCommands));
        public static readonly RoutedUICommand ToMain = new("Переход на главную страницу", "ToMain", typeof(CustomCommands));
        public static readonly RoutedUICommand Exit = new("Выход", "ToMain", typeof(CustomCommands));
        public static readonly RoutedUICommand ToRentPage = new("Переход на страницу сдачи жилья", "ToMain", typeof(CustomCommands));
        public static readonly RoutedUICommand AddUser = new("Добавление пользователя", "AddUser", typeof(CustomCommands));
        public static readonly RoutedUICommand DeleteUser = new("Удаление пользователя", "DeleteUser", typeof(CustomCommands));
        public static readonly RoutedUICommand DeleteHouse = new("Удаление дома", "DeleteHouse", typeof(CustomCommands));
        public static readonly RoutedUICommand ShowNewHouse = new("Отображение отдельной страницы", "ShowNewHouse", typeof(CustomCommands));
        public static readonly RoutedUICommand AddToFavorite = new("Добавление в понравившиеся", "AddToFavorite", typeof(CustomCommands));
    }
}
