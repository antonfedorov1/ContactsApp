namespace ContactsApp.Model
{
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Контакт
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия и имя контакта
        /// </summary>
        private string _fullName;

        /// <summary>
        /// Почтовый ящик контакта
        /// </summary>
        private string _eMail;

        /// <summary>
        /// Телефонный номер контакта
        /// </summary>
        private string _phoneNumber;

        /// <summary>
        /// Дата рождения контакта
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        /// ID в VK контакта
        /// </summary>
        private string _idVK;

        /// <summary>
        /// Возвращает или задает фамилия и имя контакта
        /// </summary>
        public string FullName
        {
            get 
            { 
                return _fullName; 
            }
            set
            {
                if (_fullName.Length <= 0 || _fullName.Length > 100)
                {
                    throw new ArgumentException($"Длина поля Полное имя не должно быть меньше" +
                        $"0 и больше 100 символов.");
                }
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                value = textInfo.ToTitleCase(value);
                _fullName = value;
            }
        }

        /// <summary>
        /// Возвращает или задает почтовый ящик контакта
        /// </summary>
        public string EMail
        {
            get 
            { 
                return _eMail; 
            }
            set
            {
                if (_eMail.Length <= 0 || _eMail.Length > 100)
                {
                    throw new ArgumentException($"Длина поля E-mail не должно быть меньше" +
                        $"0 и больше 100 символов.");
                }
                _eMail = value;
            }
        }

        /// <summary>
        /// Возвращает или задает телефонный номер контакта
        /// </summary>
        public string PhoneNumber
        {
            get 
            { 
                return _phoneNumber; 
            }
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

        /// <summary>
        /// Возвращает или задает дату рождения контакта
        /// </summary>
        public DateTime DateOfBirth
        {
            get 
            { 
                return _dateOfBirth; 
            }
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

        /// <summary>
        /// Возвращает или задает ID в VK контакта
        /// </summary>
        public string IdVK
        {
            get 
            { 
                return _idVK; 
            }
            set
            {
                if (_idVK.Length <= 0 || _idVK.Length > 50)
                {
                    throw new ArgumentException($"Длина поля ID Вконтакте не должно быть меньше" +
                        $"0 и больше 50 символов.");
                }
                _idVK = value;
            }
        }

        /// <summary>
        /// Конструктор класса <see cref="Contact">
        /// </summary>
        public Contact(string _fullName, string _eMail, string _phoneNumber, 
            DateTime _dateOfBirth, string _idVK)
        {
            FullName = _fullName;
            EMail = _eMail;
            PhoneNumber = _phoneNumber;
            DateOfBirth = _dateOfBirth;
            IdVK = _idVK;
        }

        /// <summary>
        /// Создает экземпляр класса
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Клонирование данного объекта
        /// </summary>
        public object Clone()
        {
            Contact contact = new Contact();
            contact.FullName = FullName;
            contact.EMail = EMail;
            contact.PhoneNumber = PhoneNumber;
            contact.DateOfBirth = DateOfBirth;
            contact.IdVK = IdVK;
            return contact;
        }
    }
}
