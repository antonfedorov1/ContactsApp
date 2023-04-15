﻿namespace ContactsApp.Model
{
    /// <summary>
    /// Список контактов.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список всех контактов.
        /// </summary>
        public List<Contact> Contacts { get; private set; } = new List<Contact>();

        /// <summary>
        /// Сортировка контактов.
        /// </summary>
        /// <param name="contacts">Список всех контактов.</param>
        /// <returns>Отсортированный список контактов.</returns>
        public List<Contact> SortContacts(List<Contact> contacts)
        {
            contacts.Sort((c1, c2) => c1.FullName.CompareTo(c2.FullName));
            return contacts;
        }

        /// <summary>
        /// Поиск именинников.
        /// </summary>
        /// <param name="contacts">Список всех контактов.</param>
        /// <returns>Список всех именинников.</returns>
        public List<Contact> FindBirthdays(List<Contact> contacts)
        {
            List<Contact> birthDayContacts = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (contact.DateOfBirth.Day == DateTime.Today.Day &&
                    contact.DateOfBirth.Month == DateTime.Today.Month)
                {
                    birthDayContacts.Add(contact);
                }
            }
            return birthDayContacts;
        }

        /// <summary>
        /// Поиск контакта по подстроке.
        /// </summary>
        /// <param name="contacts">Список всех контактов.</param>
        /// <param name="substring">Подстрока поиска.</param>
        /// <returns></returns>
        public List<Contact> FindContactsBySubstring(List<Contact> contacts, string substring)
        {
            substring = substring.ToLower();
            return contacts.FindAll(contact => contact.FullName.ToLower().Contains(substring));
        }
    }
}
