using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalAvenue
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string selectedLanguage;
        public string SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                if (selectedLanguage != value)
                {
                    selectedLanguage = value;
                    OnPropertyChanged("SelectedLanguage");
                    ChangeLanguage(value); // Вызов метода для изменения языка
                }
            }
        }

        // Метод для изменения языка
        private void ChangeLanguage(string language)
        {
            // Ваш код для изменения языка
            // Например, можно использовать ResourceManager для загрузки ресурсов на нужном языке
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
