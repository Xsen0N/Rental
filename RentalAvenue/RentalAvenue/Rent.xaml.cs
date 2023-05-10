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

namespace RentalAvenue
{
    /// <summary>
    /// Логика взаимодействия для Rent.xaml
    /// </summary>
    public partial class Rent : Window
    {
        public Rent()
        {
            InitializeComponent();

        }
        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            // Создаем новый объект жилья и заполняем его данными из формы
            RentalProperty property = new RentalProperty();
            property.PropertyType = PropertyTypeComboBox.Text;
            property.Addres = AddressTextBox.Text;
            property.Price = Convert.ToDouble(PriceTextBox.Text);
            property.Rooms = Convert.ToInt32(RoomsComboBox.Text);
            property.Description = DescriptionTextBox.Text;

            // Добавляем объект в базу данных
            //using (var db = new RentalDbContext())
            //{
            //    db.RentalProperties.Add(property);
            //    db.SaveChanges();
            //}

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
