using System.Globalization;
using System.Text.RegularExpressions;

namespace ContactsApp.Model
{
    public class Contact
    {
        private string _fullName;
        private string _eMail;
        private string _phoneNumber;
        private DateTime _dateOfBirth;
        private string _idVK;

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName.Length <= 0 || _fullName.Length >= 100)
                {
                    throw new ArgumentException($"Длина поля Полное имя не должно быть меньше" +
                        $"0 и больше 100 символов.");
                }
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                value = textInfo.ToTitleCase(value);
                _fullName = value;
            }
        }

        public string EMail
        {
            get { return _eMail; }
            set
            {
                if (_eMail.Length <= 0 || _eMail.Length >= 100)
                {
                    throw new ArgumentException($"Длина поля E-mail не должно быть меньше" +
                        $"0 и больше 100 символов.");
                }
                _eMail = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set 
            {
                Regex validatePhoneNumberRegex = new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)" +
                    "?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
                if (validatePhoneNumberRegex.IsMatch(value) == false)
                {
                    throw new ArgumentException($"Номер телефона может содержать только" +
                        $"цифры и знаки ‘+’, ‘(’ ‘)’ ‘-’ ‘ ’. Формат номера: +7 (000) 000-00-00");
                }
                _phoneNumber = value; 
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                DateTime minDate = new DateTime(1900, 1, 1);
                DateTime nowDate = new DateTime();
                nowDate = DateTime.Now;
                if (value > nowDate || value < minDate)
                {
                    throw new ArgumentException($"Дата рождения не может быть более текущей " +
                        $"даты и не может быть менее 1900 года.");
                }
                _dateOfBirth = value; 
            }
        }

        public string IdVK
        {
            get { return _idVK; }
            set
            {
                if (_idVK.Length <= 0 || _idVK.Length >= 50)
                {
                    throw new ArgumentException($"Длина поля ID Вконтакте не должно быть меньше" +
                        $"0 и больше 50 символов.");
                }
                _idVK = value;
            }
        }

        public Contact(string _fullName, string _eMail, string _phoneNumber, 
            DateTime _dateOfBirth, string _idVK)
        {
            FullName = _fullName;
            EMail = _eMail;
            PhoneNumber = _phoneNumber;
            DateOfBirth = _dateOfBirth;
            IdVK = _idVK;
        }
    }
}
