namespace ContactsApp.View
{
    using ContactsApp.Model;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class ContactForm : Form
    {
        /// <summary>
        /// Экземпляр класса Contact 
        /// </summary>
        private Contact _contact = 
            new Contact(" ", " ", "+7 (000) 000-00-00", DateTime.Today, " ");

        /// <summary>
        /// Сообщение об ошибке в поле _fullName.
        /// </summary>
        private string _fullNameError;

        /// <summary>
        /// Сообщение об ошибке в поле _eMail.
        /// </summary>
        private string _eMailError;

        /// <summary>
        /// Сообщение об ошибке в поле _phoneNumber.
        /// </summary>
        private string _phoneNumberError;

        /// <summary>
        /// Сообщение об ошибке в поле _dateOfBirth.
        /// </summary>
        private string _dateOfBirthError;

        /// <summary>
        /// Сообщение об ошибке в поле _idVK.
        /// </summary>
        private string _idVKError;

        public ContactForm()
        {
            InitializeComponent();
            UpdataForm();
        }

        /// <summary>
        /// Заполняет поля формы данными из экземпляра класса Contact.
        /// </summary>
        private void UpdataForm()
        {
            FullNameTextBox.Text = _contact.FullName;
            EmailTextBox.Text = _contact.EMail;
            PhoneNumberTextBox.Text = _contact.PhoneNumber;
            DateOfBirthDateTimePicker.Text = System.Convert.ToString(_contact.DateOfBirth);
            VKTextBox.Text = _contact.IdVK;
        }

        /// <summary>
        /// Заполняет данными поля экземпляра класса Contact из формы.
        /// </summary>
        private void UpdateContact()
        {
            _contact.FullName = FullNameTextBox.Text;
            _contact.EMail = EmailTextBox.Text;
            _contact.PhoneNumber = PhoneNumberTextBox.Text;
            _contact.DateOfBirth = DateOfBirthDateTimePicker.Value;
            _contact.IdVK = VKTextBox.Text;
        }

        /// <summary>
        /// Проверяет на наличие ошибок в полях формы.
        /// </summary>
        /// <returns>true - нет ошибок. false - есть ошибки.</returns>
        private bool CheckFormOnErrors()
        {
            string fullMessageErrors = "";

            if (_fullNameError.Length > 1)
            {
                fullMessageErrors = _fullNameError;
            }
            if (_eMailError.Length > 1)
            {
                fullMessageErrors += "\n" + _eMailError;
            }
            if (_phoneNumberError.Length > 1)
            {
                fullMessageErrors += "\n" + _phoneNumberError;
            }
            if (_dateOfBirthError.Length > 1)
            {
                fullMessageErrors += "\n" + _dateOfBirthError;
            }
            if (_idVKError.Length > 1)
            {
                fullMessageErrors += "\n" + _idVKError;
            }

            if (_fullNameError.Length > 1 || _eMailError.Length > 1 ||
                _phoneNumberError.Length > 1 || _dateOfBirthError.Length > 1 ||
                _idVKError.Length > 1)
            {
                MessageBox.Show(fullMessageErrors, "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (CheckFormOnErrors())
            {
                UpdateContact();
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void AddPhotoButton_MouseEnter(object sender, EventArgs e)
        {
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32;
            AddPhotoButton.BackColor = Color.White;
        }

        private void AddPhotoButton_MouseLeave(object sender, EventArgs e)
        {
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32_gray;
            AddPhotoButton.BackColor = Color.White;
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FullNameTextBox.BackColor= Color.White;
                _contact.FullName = FullNameTextBox.Text;
                _fullNameError = string.Empty;
            }
            catch (ArgumentException exception)
            {
                FullNameTextBox.BackColor = Color.LightPink;
                _fullNameError = exception.Message;
                MessageBox.Show(exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EmailTextBox.BackColor = Color.White;
                _contact.EMail = EmailTextBox.Text;
                _eMailError = string.Empty;
            }
            catch (ArgumentException exception)
            {
                EmailTextBox.BackColor = Color.LightPink;
                _eMailError = exception.Message;
                MessageBox.Show(exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PhoneNumberTextBox.BackColor = Color.White;
                _contact.PhoneNumber = PhoneNumberTextBox.Text;
                _phoneNumberError = string.Empty;
            }
            catch (ArgumentException exception)
            {
                PhoneNumberTextBox.BackColor = Color.LightPink;
                _phoneNumberError = exception.Message;
                //MessageBox.Show(exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DateOfBirthDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateOfBirthDateTimePicker.BackColor = Color.White;
                _contact.DateOfBirth = DateOfBirthDateTimePicker.Value;
                _dateOfBirthError = string.Empty;
            }
            catch (ArgumentException exception)
            {
                DateOfBirthDateTimePicker.BackColor = Color.LightPink;
                _dateOfBirthError = exception.Message;
                MessageBox.Show(exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                VKTextBox.BackColor = Color.White;
                _contact.IdVK = VKTextBox.Text;
                _idVKError = string.Empty;
            }
            catch (ArgumentException exception)
            {
                VKTextBox.BackColor = Color.LightPink;
                _idVKError = exception.Message;
                MessageBox.Show(exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
