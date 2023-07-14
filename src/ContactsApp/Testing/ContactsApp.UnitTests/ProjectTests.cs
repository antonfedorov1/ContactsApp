namespace ContactsApp.Model.UnitTests
{
    using NUnit.Framework;
    using ContactsApp.Model;
    using System.Collections.Generic;
    using System;

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
                    null,
                "Anton Fedorov",
                "anton_fedorov@mail.ru",
                "+7 (000) 700-12-30",
                new DateTime(2000, 01, 18),
                "325432");
                var secondContact = new Contact(
                    null,
                    "Kirill Ivanov",
                    "kirill_ivanov@mail.ru",
                    "+7 (000) 800-43-04",
                    new DateTime(1979, 05, 12),
                    "325432");
                var thirdContact = new Contact(
                    null,
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

        /// <summary>
        /// ��������� ������� �� FullName.
        /// </summary>
        /// <param name="expected">��������� ������.</param>
        /// <param name="actual">�������������� ������.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AssertList(List<Contact> expected, List<Contact> actual)
        {
            if (expected.Count == actual.Count)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].FullName, actual[i].FullName);
                }
            }
            else
            {
                throw new ArgumentException("Returned a different number of contacts.");
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
            AssertList(expected, actual);   
        }

        [Test(Description = "Check for the correct search for birthdays.")]
        public void FindBirthdays_Searching_BirthdayList()
        {
            // Arrange
            var project = new Project();
            var contacts = ContactsForTests;
            var expected = new List<Contact> { contacts[1] };

            // Act
            var birthdayList = project.FindBirthdays(contacts, new DateTime(1979, 05, 12));
            var actual = birthdayList;

            // Assert
            AssertList(expected, actual);
        }

        [Test(Description = "Check for correct substring search.")]
        public void FindContactsBySubstring_Searching_ListContainingSubstring()
        {
            // Arrange
            var contacts = ContactsForTests;
            var expected = ContactsForTests;
            expected.RemoveAt(1);
            var project = new Project();
            var substring = "rov";

            // Act
            var listContainingSubstring = project.FindContactsBySubstring(contacts, substring);
            var actual = listContainingSubstring;

            // Assert
            AssertList(expected, actual);
        }

        [Test(Description = "Check if searching for an empty substring is correct.")]
        public void FindContactsBySubstringEmptyString_Searching_ListContainingSubstring()
        {
            // Arrange
            var project = new Project();
            var contacts = ContactsForTests;
            var expected = ContactsForTests;
            expected = project.SortContacts(expected);
            var substring = "";

            // Act
            var listContainingSubstring = project.FindContactsBySubstring(contacts, substring);
            var actual = listContainingSubstring;

            // Assert
            AssertList(expected, actual);
        }
    }
}