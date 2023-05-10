using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalAvenue
{
    public class User
    {
        [LoginAttribute(ErrorMessage = "Ошибка в заполнении поля логина")]
        public string Login { get; set; }
        [EmailAttribute(ErrorMessage = "Ошибка в заполнении поля электронной почты!")]
        public string Email { get; set; }
    }
}
