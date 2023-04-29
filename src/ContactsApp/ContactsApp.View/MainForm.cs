﻿namespace ContactsApp.View
{
    using ContactsApp.Model;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект класса Project.
        /// </summary>
        private Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
            AddContact();
            UpdateListBox();
        }

        /// <summary>
        /// Обновляет список контактов в ContactsListBox.
        /// </summary>
        private void UpdateListBox() 
        {
            ContactsListBox.Items.Clear();
            foreach (var item in _project.Contacts)
            {
                ContactsListBox.Items.Add(item.FullName);
            }
        }

        /// <summary>
        /// Добавляет новый контакт в проект.
        /// </summary>
        private void AddContact()
        {
            var rand = new Random();
            List<string> testContacts = new List<string>() 
            {
                "Левина Ксения", "Александрова София", "Бирюков Богдан", "Борисов Игорь",
                "Михайлов Павел", "Одинцова Эмилия", "Пименова Антонина", "Максимова Анна",
                "Тихомиров Максим", "Бычкова Варвара", "Столярова Юлия", "Ульянов Александр",
                "Смирнов Максим", "Попов Всеволод", "Леонов Тигран", "Тарасова Стефания", 
                "Косарева Милана", "Калинин Даниил", "Козлов Евгений",
            };

            Project project = new Project();

            for (int i = 0; i < testContacts.Count; i++)
            {
                Contact contact = new Contact(" ", " ", "+7 (000) 000-00-00", DateTime.Today, " ");
                contact.FullName = testContacts[rand.Next(testContacts.Count)];
                project.Contacts.Add(contact);
                
            }
            _project = project;
        }

        /// <summary>
        /// Удаление контакта из проекта.
        /// </summary>
        /// <param name="index">Индекс выбранного контакта в ContactsListBox.</param>
        private void RemoveContact(int index)
        {
            if (index == -1)
            {
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить " 
                + _project.Contacts[index].FullName, "Предупреждение", MessageBoxButtons.YesNo
                , MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                _project.Contacts.RemoveAt(index);
                ClearSelectedContact();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        /// <summary>
        /// Обновляет данные в TextBox в соответствии с выбранным контактом.
        /// </summary>
        /// <param name="index">Индекс выбранного контакта в ContactsListBox.</param>
        private void UpdateSelectedContact(int index)
        {
            var contact = _project.Contacts[index];
            FullNameTextBox.Text = contact.FullName;
            EmailTextBox.Text = contact.EMail;
            PhoneNumberTextBox.Text = contact.PhoneNumber;
            DateOfBirthTextBox.Text = System.Convert.ToString(contact.DateOfBirth);
            VKTextBox.Text = contact.IdVK;
        }

        /// <summary>
        /// Отчищает TexBox если не выбран контакт.
        /// </summary>
        private void ClearSelectedContact()
        {
            FullNameTextBox.Clear();
            EmailTextBox.Clear();
            PhoneNumberTextBox.Clear();
            DateOfBirthTextBox.Clear();
            VKTextBox.Clear();
        }

        private void AddContactbutton_Click(object sender, EventArgs e)
        {
            AddContact();
            UpdateListBox();
            //var form = new ContactForm();
            //form.ShowDialog();
            //Activate();
        }

        private void RemoveContactbutton_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            UpdateListBox();
        }

        private void EditContactbutton_Click(object sender, EventArgs e)
        {
            var form = new ContactForm();
            form.ShowDialog();
            Activate();
        }

        private void AddContactbutton_MouseEnter(object sender, EventArgs e)
        {
            AddContactbutton.Image = Properties.Resources.add_contact_32x32;
            AddContactbutton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5FF");
        }

        private void AddContactbutton_MouseLeave(object sender, EventArgs e)
        {
            AddContactbutton.Image = Properties.Resources.add_contact_32x32_gray;
            AddContactbutton.BackColor = Color.White;
        }

        private void EditContactbutton_MouseEnter(object sender, EventArgs e)
        {
            EditContactbutton.Image = Properties.Resources.edit_contact_32x32;
            EditContactbutton.BackColor = System.Drawing.ColorTranslator.FromHtml("#F5F5FF");
        }

        private void EditContactbutton_MouseLeave(object sender, EventArgs e)
        {
            EditContactbutton.Image = Properties.Resources.edit_contact_32x32_gray;
            EditContactbutton.BackColor = Color.White;
        }

        private void RemoveContactbutton_MouseEnter(object sender, EventArgs e)
        {
            RemoveContactbutton.Image = Properties.Resources.remove_contact_32x32;
            RemoveContactbutton.BackColor = System.Drawing.ColorTranslator.FromHtml("#FAF5F5");
        }

        private void RemoveContactbutton_MouseLeave(object sender, EventArgs e)
        {
            RemoveContactbutton.Image = Properties.Resources.remove_contact_32x32_gray;
            RemoveContactbutton.BackColor = Color.White;
        }

        private void BirthdayPanelCloseButton_Click(object sender, EventArgs e)
        {
            BirthdayPanel.Visible = false;
        }

        private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            using (var helpForm = new AboutForm())
            {
                helpForm.ShowDialog();
                Activate();
            }
        }

        private void FullNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void PhoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void DateOfBirthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void VKTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                ClearSelectedContact();
            }
            else
            {
                UpdateSelectedContact(ContactsListBox.SelectedIndex);
            }
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var isFormClosing = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            e.Cancel = !(isFormClosing == DialogResult.Yes);
        }
    }
}