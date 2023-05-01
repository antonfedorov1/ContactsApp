namespace ContactsApp.View
{
    using ContactsApp.Model;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ContactForm : Form
    {
        /// <summary>
        /// Цвет, если всё правильно.
        /// </summary>
        private Color correctСolor = Color.White;

        /// <summary>
        /// Цвет, если есть ошибка.
        /// </summary>
        private Color errorColor = Color.LightPink;

        /// <summary>
        /// Словарь ошибок полей.
        /// TKey - это ошибка в соответствующем поле.
        /// TValue - это сообщение ошибки.
        /// </summary>
        private Dictionary<string, string> dictionaryErrors = new Dictionary<string, string>()
        {
            { "fullNameError", "" },
            { "eMailError", "" },
            { "phoneNumberError", "" },
            { "dateOfBirthError", "" },
            { "idVKError", "" }
        };

        /// <summary>
        /// Экземпляр класса Contact.
        /// </summary>
        private Contact _contact = new Contact();

        public ContactForm()
        {
            InitializeComponent();
            UpdateForm();
        }

        /// <summary>
        /// Заполняет поля формы данными из экземпляра класса Contact.
        /// </summary>
        private void UpdateForm()
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
            var errors = new List<string>();
            foreach (var error in dictionaryErrors)
            {
                errors.Add(error.Value);
            }
            errors = errors.Where(error => error != "").ToList();

            string fullErrorsMessage = "";
            fullErrorsMessage = " - " + string.Join("\n - ", errors);

            if (fullErrorsMessage.Length > 3) //Length > 3 because fullErrorsMessage always has " - " , which is three characters.
            {
                MessageBox.Show(fullErrorsMessage, "Errors",
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

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            dictionaryErrors["fullNameError"] = "";
            FullNameTextBox.BackColor = correctСolor;
            try
            {
                _contact.FullName = FullNameTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                FullNameTextBox.BackColor = errorColor;
                dictionaryErrors["fullNameError"] = exception.Message;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            EmailTextBox.BackColor = correctСolor;
            dictionaryErrors["eMailError"] = "";
            try
            {
                _contact.EMail = EmailTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                EmailTextBox.BackColor = errorColor;
                dictionaryErrors["eMailError"] = exception.Message;
            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            PhoneNumberTextBox.BackColor = correctСolor;
            dictionaryErrors["phoneNumberError"] = "";
            try
            {
                _contact.PhoneNumber = PhoneNumberTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                PhoneNumberTextBox.BackColor = errorColor;
                dictionaryErrors["phoneNumberError"] = exception.Message;
            }
        }

        private void DateOfBirthDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateOfBirthDateTimePicker.MinDate = new DateTime(1900, 01, 01);
            DateOfBirthDateTimePicker.MaxDate = DateTime.Today;

            DateOfBirthDateTimePicker.BackColor = correctСolor;
            dictionaryErrors["dateOfBirthError"] = "";
            try
            {
                _contact.DateOfBirth = DateOfBirthDateTimePicker.Value;
            }
            catch (ArgumentException exception)
            {
                DateOfBirthDateTimePicker.BackColor = errorColor;
                dictionaryErrors["dateOfBirthError"] = exception.Message;
            }
        }

        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            VKTextBox.BackColor = correctСolor;
            dictionaryErrors["idVKError"] = "";
            try
            {
                _contact.IdVK = VKTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                VKTextBox.BackColor = errorColor;
                dictionaryErrors["idVKError"] = exception.Message;
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
    }
}
