namespace ContactsApp.Model
{
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Контакт.
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Максимальная длина строки фамилия и имя.
        /// </summary>
        const int maxLineLengthFullName = 100;

        /// <summary>
        /// Максимальная длина строки E-mail.
        /// </summary>
        const int maxLineLengthEMail = 100;

        /// <summary>
        /// Максимальная длина строки E-mail.
        /// </summary>
        const int maxLineLengthIdVK = 50;

        /// <summary>
        /// Это регулярное выражение будет сопоставлять телефонные номера, введенные с 
        /// разделителями (пробелами, точками, скобками и т. д.).
        /// Пример оформления номера: +7 (000) 000-00-00.
        /// </summary>
        const string regex = "^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)" +
                    "?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$";

        /// <summary>
        /// Фамилия и имя контакта.
        /// </summary>
        private string _fullName;

        /// <summary>
        /// Почтовый ящик контакта.
        /// </summary>
        private string _eMail;

        /// <summary>
        /// Телефонный номер контакта.
        /// </summary>
        private string _phoneNumber;

        /// <summary>
        /// Дата рождения контакта.
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        /// ID в VK контакта
        /// </summary>
        private string _idVK;

        /// <summary>
        /// Возвращает и задает фамилия и имя контакта.
        /// </summary>
        public string FullName
        {
            get 
            { 
                return _fullName; 
            }
            set
            {
                if (_fullName.Length <= 0 || _fullName.Length > maxLineLengthFullName)
                {
                    throw new ArgumentException($"Длина поля Полное имя не должно быть меньше" +
                        $"0 и больше {maxLineLengthFullName} символов.");
                }
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                value = textInfo.ToTitleCase(value);
                _fullName = value;
            }
        }

        /// <summary>
        /// Возвращает и задает почтовый ящик контакта.
        /// </summary>
        public string EMail
        {
            get 
            { 
                return _eMail; 
            }
            set
            {
                if (_eMail.Length <= 0 || _eMail.Length > maxLineLengthEMail)
                {
                    throw new ArgumentException($"Длина поля E-mail не должно быть меньше" +
                        $"0 и больше {maxLineLengthEMail} символов.");
                }
                _eMail = value;
            }
        }

        /// <summary>
        /// Возвращает и задает телефонный номер контакта.
        /// </summary>
        public string PhoneNumber
        {
            get 
            { 
                return _phoneNumber; 
            }
            set 
            {
                Regex validatePhoneNumberRegex = new Regex(regex);
                if (!validatePhoneNumberRegex.IsMatch(value))
                {
                    throw new ArgumentException($"Номер телефона может содержать только" +
                        $"цифры и знаки ‘+’, ‘(’ ‘)’ ‘-’ ‘ ’. Формат номера: +7 (000) 000-00-00");
                }
                _phoneNumber = value; 
            }
        }

        /// <summary>
        /// Возвращает или задает дату рождения контакта.
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
                DateTime nowDate = DateTime.Now;

                if (value > nowDate || value < minDate)
                {
                    throw new ArgumentException($"Дата рождения не может быть более текущей " +
                        $"даты и не может быть менее 1900 года.");
                }
                _dateOfBirth = value; 
            }
        }

        /// <summary>
        /// Возвращает или задает ID в VK контакта.
        /// </summary>
        public string IdVK
        {
            get 
            { 
                return _idVK; 
            }
            set
            {
                if (_idVK.Length <= 0 || _idVK.Length > maxLineLengthIdVK)
                {
                    throw new ArgumentException($"Длина поля ID Вконтакте не должно быть меньше" +
                        $"0 и больше {maxLineLengthIdVK} символов.");
                }
                _idVK = value;
            }
        }

        /// <summary>
        /// Конструктор класса <see cref="Contact"/>.
        /// </summary>
        /// <param name="_fullName"></param>
        /// <param name="_eMail"></param>
        /// <param name="_phoneNumber"></param>
        /// <param name="_dateOfBirth"></param>
        /// <param name="_idVK"></param>
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
        /// Создает экземпляр класса <see cref="Contact"/>.
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Клонирование данного объекта.
        /// </summary>
        public object Clone()
        {
            return new Contact(_fullName, _eMail, _phoneNumber, _dateOfBirth, _idVK);
        }
    }
}
