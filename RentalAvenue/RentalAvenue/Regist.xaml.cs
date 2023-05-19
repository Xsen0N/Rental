
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using static RentalAvenue.Entities;

namespace RentalAvenue
{
    /// <summary>
    /// Логика взаимодействия для Regist.xaml
    /// </summary>
    public partial class Regist : Window
    {
        internal static DatabaseContext db = DB.connector;
        private const string AdminEmail = "admin@admin.com";
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        public Regist()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
       
        public void LogIn(object sender, ExecutedRoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string name = LogTextBox.Text;


            Entities.User? user = db.Users.FirstOrDefault(u => u.Email == email && u.Login == name);
            if (user != null)
            {
                CurrentSessionUser.User = user;
                if (user.Email == AdminEmail)
                {
                    // Пользователь найден и это админ, делаем редирект на AdminWindow
                    Admin adminWindow = new()
                    {
                        WindowStartupLocation = WindowStartupLocation.CenterScreen
                    };
                    adminWindow.Show();
                    Close();
                }
                else { 
                // Пользователь найден, делаем редирект на MainWindow
                MainWindow mainWindow = new()
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                mainWindow.Show();
                Close();
                }
            }
            else
            {
                try
                {
                    // считываем данные из полей ввода

                    // проверяем почту на уникальность
                    if (db.Users.Any(u => u.Email == email && u.Login !=name))
                    {
                        throw new Exception("Пользователь с такой почтой уже существует, но логин другой");
                    }

                    // проверяем правильность ввода почты и телефона с помощью regex
                    string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                    if (!Regex.IsMatch(email, emailPattern))
                    {
                        throw new Exception("Неправильный формат почты");
                    }

                    if (db.Users.Any(u => u.Email == AdminEmail && u.Login != name))
                    {
                        throw new Exception("Логин не соответсвует, проверьте логин или введите другую электронную почту");
                    }
                    // создаем новый объект User
                    User newUser = new()
                    {
                        Login = name,
                        Email = email,
                        IsAdmin = false
                    };

                    // добавляем нового пользователя в контекст данных
                    _ = db.Users.Add(newUser);
                    _ = db.SaveChanges();


                    // выводим сообщение об успешной регистрации
                    _ = MessageBox.Show("Регистрация прошла успешно!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    //Regist = new();
                    //loginPage.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    // выводим сообщение об ошибке
                    _ = MessageBox.Show($"Ошибка при регистрации нового пользователя: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }




    }

}
