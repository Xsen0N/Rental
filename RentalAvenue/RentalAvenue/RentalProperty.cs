using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalAvenue
{
    public class RentalProperty
    {
        public string PropertyType { get; set; }
        [AddresAttribute(ErrorMessage = "Ошибка в заполнении поля адреса!")]
        public string Address { get; set; }
        public double Price { get; set; }
        [NumericAttribute(ErrorMessage = "Ошибка в заполнении поля числа комнат!")]
        public int Rooms { get; set; }

        [DiscrAttribute(ErrorMessage = "Ошибка в заполнении поля описания!")]
        public string Description { get; set; }
    }
}
