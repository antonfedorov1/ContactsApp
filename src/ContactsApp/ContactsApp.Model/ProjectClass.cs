namespace ContactsApp.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список всех контактов
        /// </summary>
        private List<Contact> _contactsList;

        /// <summary>
        /// Возвращает список контактов или добавляет нового пользователя в список контактов 
        /// </summary>
        public List<Contact> Contacts 
        {
            get { return _contactsList; }
            set 
            {
                _contactsList = SortContacts(value);
            }
        }

        /// <summary>
        /// Сортировка контактов
        /// </summary>
        public List<Contact> SortContacts(List<Contact> contactsList)
        {
            contactsList.Sort((c1, c2) => c1.FullName.CompareTo(c2.FullName));
            return contactsList;
        }

        /// <summary>
        /// Поиск именинников
        /// </summary>
        public List<Contact> SearchForBirthdays()
        {
            List<Contact> birthdays;
            DateTime dateTime = DateTime.Now;
            birthdays = _contactsList.FindAll(contact => contact.DateOfBirth.Date == dateTime);
            return birthdays;
        }

        /// <summary>
        /// Поиск именинников
        /// </summary>
        public List<Contact> SearchContact(string fullName)
        {
            return _contactsList; //дописать
        }
    }
}
