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

        /// <summary>
        /// Список отображаемых контактов.
        /// </summary>
        private List<Contact> _currentContacts;

        public MainForm()
        {
            InitializeComponent();
            UpdateCurrentProject();
        }

        /// <summary>
        /// Обновляет список контактов в ContactsListBox.
        /// </summary>
        private void UpdateListBox() 
        {
            ContactsListBox.Items.Clear();
            foreach (var item in _currentContacts)
            {
                ContactsListBox.Items.Add(item.FullName);
            }
        }

        /// <summary>
        /// Добавляет новый контакт в проект.
        /// </summary>
        private void AddContact()
        {
            ContactForm contactForm = new ContactForm();

            if (contactForm.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts.Add(contactForm.Contact);
            }
        }

        private void EditContact(int index)
        {
            if (index == -1)
            {
                return;
            }

            ContactForm contactForm = new ContactForm();
            contactForm.Contact = (Contact)_project.Contacts[index].Clone();

            if (contactForm.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts[index] = contactForm.Contact;
            }
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
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete "
                + _project.Contacts[index].FullName + "?", "Warning", MessageBoxButtons.YesNo
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
            var contact = _currentContacts[index];
            FullNameTextBox.Text = contact.FullName;
            EmailTextBox.Text = contact.EMail;
            PhoneNumberTextBox.Text = contact.PhoneNumber;
            DateOfBirthTextBox.Text = System.Convert.ToString(contact.DateOfBirth);
            VKTextBox.Text = contact.IdVK;
        }

        private void UpdateCurrentProject()
        {
            if (FindTextBox.Text == "")
            {
                _currentContacts = _project.Contacts;
            }
            else
            {
                _currentContacts = _project.FindContactsBySubstring(FindTextBox.Text);
            }
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
            _project.SortContacts(_project.Contacts);
            UpdateCurrentProject();
            UpdateListBox();
        }

        private void EditContactbutton_Click(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex != -1)
            {
                var index = _project.Contacts.IndexOf(_currentContacts[ContactsListBox.SelectedIndex]);
                EditContact(index);
                _project.SortContacts(_project.Contacts);
                UpdateCurrentProject();
                UpdateListBox();
                if (_currentContacts.Count == 0)
                {
                    FindTextBox.Text = "";
                    UpdateCurrentProject();
                    UpdateListBox();
                    UpdateSelectedContact(index);
                    ContactsListBox.SelectedIndex = index;
                }
                else
                {
                    UpdateSelectedContact(0);
                }
            }
        }

        private void RemoveContactbutton_Click(object sender, EventArgs e)
        {
            RemoveContact(_project.Contacts.IndexOf(_currentContacts[ContactsListBox.SelectedIndex]));
            _project.SortContacts(_project.Contacts);
            UpdateCurrentProject();
            UpdateListBox();
        }
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateCurrentProject();
            UpdateListBox();
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
            var isFormClosing = MessageBox.Show("Do you really want to leave?", "Exiting the program",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            e.Cancel = !(isFormClosing == DialogResult.Yes);
        }

        private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            using (var helpForm = new AboutForm())
            {
                helpForm.ShowDialog();
                Activate();
            }
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
    }
}