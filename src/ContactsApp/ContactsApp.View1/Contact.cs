﻿namespace ContactsApp.Model
{
    using System;
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
        private const int MaxLineLengthFullName = 100;

        /// <summary>
        /// Максимальная длина строки E-mail.
        /// </summary>
        private const int MaxLineLengthEMail = 100;

        /// <summary>
        /// Максимальная длина строки E-mail.
        /// </summary>
        private const int MaxLineLengthIdVK = 50;

        /// <summary>
        /// Это регулярное выражение будет сопоставлять телефонные номера, введенные с 
        /// разделителями (пробелами, точками, скобками и т. д.).
        /// Пример оформления номера: +7 (000) 000-00-00.
        /// </summary>
        const string PhoneNumberRegex = "^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)" +
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
        /// Возвращает и задает фамилию и имя контакта.
        /// </summary>
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (value.Length <= 0 || value.Length > MaxLineLengthFullName)
                {
                    throw new ArgumentException($"Длина поля Полное имя не должно быть меньше" +
                        $" 0 и больше {MaxLineLengthFullName} символов.");
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
                if (value.Length <= 0 || value.Length > MaxLineLengthEMail)
                {
                    throw new ArgumentException($"Длина поля E-mail не должно быть меньше" +
                        $"0 и больше {MaxLineLengthEMail} символов.");
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
                Regex validatePhoneNumberRegex = new Regex(PhoneNumberRegex);
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
                if (value.Length <= 0 || value.Length > MaxLineLengthIdVK)
                {
                    throw new ArgumentException($"Длина поля ID Вконтакте не должно быть меньше" +
                        $"0 и больше {MaxLineLengthIdVK} символов.");
                }
                _idVK = value;
            }
        }

        /// <summary>
        /// Конструктор класса <see cref="Contact"/>.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="eMail"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="idVK"></param>
        public Contact(string fullName, string eMail, string phoneNumber,
            DateTime dateOfBirth, string idVK)
        {
            FullName = fullName;
            EMail = eMail;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            IdVK = idVK;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Contact"/>.
        /// </summary>
        public Contact()
        {
            FullName = "";
            EMail = "";
            PhoneNumber = "";
            DateOfBirth = DateTime.Now;
            IdVK = "";
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