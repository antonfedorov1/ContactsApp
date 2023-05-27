namespace ContactsApp.Model.UnitTests
{
    using NUnit.Framework;
    using ContactsApp.Model;
    using System.Collections.Generic;

    [TestFixture]
    public class ProjectTests
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        /// <returns>Список контактов для тестов.</returns>
        public List<Contact> ContactsForTests()
        {
            var firstContact = new Contact(
                "Anton Fedorov",
                "anton_fedorov@mail.ru",
                "+7 (000) 700-12-30",
                new DateTime(2000, 01, 18),
                "325432");
            var secondContact = new Contact(
                "Kirill Ivanov",
                "kirill_ivanov@mail.ru",
                "+7 (000) 800-43-04",
                DateTime.Today,
                "325432");
            var thirdContact = new Contact(
                "Gleb Petrov",
                "gleb_petrov@mail.ru",
                "+7 (000) 100-32-43",
                new DateTime(2003, 09, 02),
                "325432");
            List<Contact> contacts = new List<Contact>
            {
                firstContact,
                secondContact,
                thirdContact
            };
            return contacts;
        }

        [Test(Description = "Check for correct sorting of contact lists.")]
        public void SortContacts_SortingContactList_ListIsSorted()
        {
            // Arrange
            var project = new Project();
            var contacts = ContactsForTests();
            var expexted = contacts;
            var secondContact = expexted[2];
            expexted.RemoveAt(1);
            expexted.Add(secondContact);

            // Act
            var sortContacts = project.SortContacts(contacts);
            var actual = sortContacts;

            // Assert
            CollectionAssert.AreEqual(expexted, actual);
        }

        [Test(Description = "Check for the correct search for birthdays.")]
        public void FindBirthdays_Searching_BirthdayList()
        {
            // Arrange
            var project = new Project();
            var contacts = ContactsForTests();
            var expexted = new List<Contact> { contacts[1] };

            // Act
            var birthdayList = project.FindBirthdays(contacts);
            var actual = birthdayList;

            // Assert
            CollectionAssert.AreEqual(expexted, actual);
        }

        [Test(Description = "Check for correct substring search.")]
        public void FindContactsBySubstring_Searching_ListContainingSubstring()
        {
            // Arrange
            var contacts = ContactsForTests();
            var expexted = contacts;
            expexted.RemoveAt(1);
            var project = new Project();
            project.Contacts.Add(expexted[0]);
            project.Contacts.Add(expexted[1]);
            var substring = "rov";

            // Act
            var listContainingSubstring = project.FindContactsBySubstring(substring);
            var actual = listContainingSubstring;

            // Assert
            CollectionAssert.AreEqual(expexted, actual);
        }
    }
}