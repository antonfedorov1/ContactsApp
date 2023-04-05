namespace ContactsApp.Model
{
    public class ContactClass
    {
        private string _fullName;
        private string _eMail;
        private string _phoneNumber;
        private string _dateOfBirth;
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
                for (int i = 0; i < _fullName.Length; i++)
                {

                }
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
            set { _phoneNumber = value; }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
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
    }
}
