namespace ContactsApp.Model.UnitTests
{
    using NUnit.Framework;
    using ContactsApp.Model;
    using System.Collections.Generic;

    [TestFixture]
    public class ProjectTests
    {
        /// <summary>
        /// ������ ���������.
        /// </summary>
        /// <returns>������ ��������� ��� ������.</returns>
        public List<Contact> ContactsForTests
        {
            get 
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
            
        }

        [Test(Description = "Check for correct sorting of contact lists.")]
        public void SortContacts_SortingContactList_ListIsSorted()
        {
            // Arrange
            var project = new Project();
            var contacts = ContactsForTests;
            var expected = ContactsForTests;
            var secondContact = expected[1];
            expected.RemoveAt(1);
            expected.Add(secondContact);

            // Act
            var sortContacts = project.SortContacts(contacts);
            var actual = sortContacts;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test(Description = "Check for the correct search for birthdays.")]
        public void FindBirthdays_Searching_BirthdayList()
        {
            // Arrange
            var project = new Project();
            var contacts = ContactsForTests;
            var expected = new List<Contact> { contacts[1] };

            // Act
            var birthdayList = project.FindBirthdays(contacts);
            var actual = birthdayList;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test(Description = "Check for correct substring search.")]
        public void FindContactsBySubstring_Searching_ListContainingSubstring()
        {
            // Arrange
            var contacts = ContactsForTests;
            var expected = contacts;
            expected.RemoveAt(1);
            var project = new Project();
            project.Contacts.Add(expected[0]);
            project.Contacts.Add(expected[1]);
            var substring = "rov";

            // Act
            var listContainingSubstring = project.FindContactsBySubstring(contacts, substring);
            var actual = listContainingSubstring;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}