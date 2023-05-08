using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RentalAvenue
{
    public class NumericAttribute : ValidationAttribute // проверка числовых значений
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            int.TryParse(value.ToString(), out int result);
            if (result <= 0 && result > 99999)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
    public class AddresAttribute : ValidationAttribute // проверка адреса
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                Regex regex = new Regex("^([\\p{L}\\d\\s.,-]+),\\s*([\\p{L}\\d\\s.,-]+),\\s*([\\p{L}\\d\\s.,-]+),\\s*(\\d+\\/?\\d*)?(\\s*[кк]\\.\\s*\\d+)?$");
                if (!regex.IsMatch(stringValue))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
    public class ImgAttribute : ValidationAttribute // проверка пути к картинке
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                Regex regex2 = new Regex("^(\\/?[a-zA-Z0-9\\s_\\\\.\\-\\(\\):])+(.jpg|.jpeg|.png|.gif|.bmp)$");
                if (!regex2.IsMatch(stringValue))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

    public class DiscrAttribute : ValidationAttribute // проверка описания
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                Regex regex = new Regex("^[a-zA-Zа-яА-ЯёЁ0-9()]+(?:[\\s-][a-zA-Zа-яА-ЯёЁ0-9()]+)*$");
                if (!regex.IsMatch(stringValue))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

    public class EmailAttribute : ValidationAttribute // проверка эл почты
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                Regex regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
                if (!regex.IsMatch(stringValue))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

    public class LoginAttribute : ValidationAttribute // проверка логина
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                Regex regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
                if (!regex.IsMatch(stringValue))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
