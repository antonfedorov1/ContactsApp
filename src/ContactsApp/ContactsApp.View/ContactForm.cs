﻿namespace ContactsApp.View
{
    using ContactsApp.Model;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.IO;

    public partial class ContactForm : Form
    {
        /// <summary>
        /// Цвет, если всё правильно.
        /// </summary>
        private readonly Color _correctСolor = Color.White;

        /// <summary>
        /// Цвет, если есть ошибка.
        /// </summary>
        private readonly Color _errorColor = Color.LightPink;

        /// <summary>
        /// Минимальная дата для DateOfBirthDateTimePicker.
        /// </summary>
        private readonly DateTime MinDate = new DateTime(1900, 01, 01);

        /// <summary>
        /// Максимальная дата для DateOfBirthDateTimePicker.
        /// </summary>
        private readonly DateTime MaxDate = DateTime.Now;

        /// <summary>
        /// Словарь ошибок полей.
        /// TKey - это ошибка в соответствующем поле.
        /// TValue - это сообщение ошибки.
        /// </summary>
        private Dictionary<string, string> dictionaryErrors = new Dictionary<string, string>()
        {
            { nameof(FullNameTextBox), "" },
            { nameof(EmailTextBox), "" },
            { nameof(PhoneNumberTextBox), "" },
            { nameof(DateOfBirthDateTimePicker), "" },
            { nameof(VKTextBox), "" }
        };

        /// <summary>
        /// Экземпляр класса Contact.
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Возвращает и задает экземпляр класса Contact.
        /// </summary>
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                if (value != null)
                {
                    UpdateForm();
                }
            }
        }

        /// <summary>
        /// Конструктор ContactForm без параметров.
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
            DateOfBirthDateTimePicker.MinDate = MinDate;
            DateOfBirthDateTimePicker.MaxDate = MaxDate;
            Contact = new Contact();
            FullNameTextBox.Text = "";
        }

        /// <summary>
        /// Заполняет поля формы данными из экземпляра класса Contact.
        /// </summary>
        private void UpdateForm()
        { 
            ConvertingImgToStrAndBack convertingImgToStrAndBack = new ConvertingImgToStrAndBack();
            PhotoPictureBox.Image = convertingImgToStrAndBack.StrToImg(_contact.Avatar);
            FullNameTextBox.Text = _contact.FullName;
            EmailTextBox.Text = _contact.EMail;
            PhoneNumberTextBox.Text = _contact.PhoneNumber;
            DateOfBirthDateTimePicker.Value = _contact.DateOfBirth;
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
            var errors = dictionaryErrors.Values.Where(error => error != "").ToList();

            if (errors.Count == 0) return true;

            string fullErrorsMessage = "";
            fullErrorsMessage = " - " + string.Join("\n - ", errors);

            
            MessageBox.Show(fullErrorsMessage, "Errors",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (CheckFormOnErrors())
            {
                UpdateContact();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FullNameTextBox.BackColor = _correctСolor;
            dictionaryErrors[nameof(FullNameTextBox)] = "";
            try
            {
                _contact.FullName = FullNameTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                FullNameTextBox.BackColor = _errorColor;
                dictionaryErrors[nameof(FullNameTextBox)] = exception.Message;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            EmailTextBox.BackColor = _correctСolor;
            dictionaryErrors[nameof(EmailTextBox)] = "";
            try
            {
                _contact.EMail = EmailTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                EmailTextBox.BackColor = _errorColor;
                dictionaryErrors[nameof(EmailTextBox)] = exception.Message;
            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            PhoneNumberTextBox.BackColor = _correctСolor;
            dictionaryErrors[nameof(PhoneNumberTextBox)] = "";
            try
            {
                _contact.PhoneNumber = PhoneNumberTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                PhoneNumberTextBox.BackColor = _errorColor;
                dictionaryErrors[nameof(PhoneNumberTextBox)] = exception.Message;
            }
        }

        private void DateOfBirthDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateOfBirthDateTimePicker.BackColor = _correctСolor;
            dictionaryErrors[nameof(DateOfBirthDateTimePicker)] = "";
            try
            {
                _contact.DateOfBirth = DateOfBirthDateTimePicker.Value;
            }
            catch (ArgumentException exception)
            {
                DateOfBirthDateTimePicker.BackColor = _errorColor;
                dictionaryErrors[nameof(DateOfBirthDateTimePicker)] = exception.Message;
            }
        }

        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            VKTextBox.BackColor = _correctСolor;
            dictionaryErrors[nameof(VKTextBox)] = "";
            try
            {
                _contact.IdVK = VKTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                VKTextBox.BackColor = _errorColor;
                dictionaryErrors[nameof(VKTextBox)] = exception.Message;
            }
        }

        private void AddPhotoButton_Click(object sender, EventArgs e)
        {
            openImage.Title = "Choose a photo";
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PhotoPictureBox.Image = new Bitmap(openImage.FileName);
                }
                catch
                {
                    MessageBox.Show("Wrong file format selected", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var path = new ImageCompressor().Compressor(openImage.FileName);
                _contact.Avatar = new ConvertingImgToStrAndBack().ImgToStr(path);
                File.Delete(path);
            }
            else _contact.Avatar = null;
        }

        private void AddPhotoButton_MouseEnter(object sender, EventArgs e)
        {
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32;
        }

        private void AddPhotoButton_MouseLeave(object sender, EventArgs e)
        {
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32_gray;
        }
    }
}
