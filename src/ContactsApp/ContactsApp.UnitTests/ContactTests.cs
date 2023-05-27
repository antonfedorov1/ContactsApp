namespace ContactsApp.UnitTests
{
    using NUnit.Framework;
    using ContactsApp.Model;


    [TestFixture]
    public class ContactTests
    {
        [Test(Description = "�������� �� ���������� ������������ � ���� FullName.")]
        public void FullName_SetIncorrectValue_ArgumentException()
        {
            // Arrange
            var wrongFullName = 
                "�������-�������-�������-�������-�������-��������������" +
                "�������-�������-�������-�������-�������-��������������" +
                "�������-�������-�������-�������-�������-��������������";
            var contact = new Contact();

            // Assert
            Assert.Throws<ArgumentException>(() => 
            { 
                // Act
                contact.FullName = wrongFullName; 
            },
            "The length of the Full Name field must not be more than 100 characters.");
        }

        [Test(Description = "�������� �� ���������� ������������ � ���� FullName.")]
        public void FullName_SetCorrectValue_ArgumentException()
        {
            // Arrange
            var correctFullName = "Fedorov Anton";
            var expexted = correctFullName;
            var contact = new Contact();

            // Act
            contact.FullName = correctFullName;
            var actual = contact.FullName;

            // Assert
            Assert.AreEqual(expexted, actual);
        }

        [Test(Description = "�������� �� ���������� ������������ � ���� E-mail.")]
        public void EMail_SetIncorrectValue_ArgumentException()
        {
            // Arrange
            var wrongEMail =
                "E-mail-E-mail-E-mail-E-mail-E-mail-E-mail-E-mail" +
                "E-mail-E-mail-E-mail-E-mail-E-mail-E-mail-E-mail" +
                "E-mail-E-mail-E-mail-E-mail-E-mail-E-mail-E-mail" +
                "E-mail-E-mail-E-mail-E-mail-E-mail-E-mail-E-mail";
            var contact = new Contact();

            // Assert
            Assert.Throws<ArgumentException>(() => 
            { 
                // Act
                contact.EMail = wrongEMail; 
            },
            "The length of the E-mail field must not be greater than 100 characters.");
        }

        [Test(Description = "�������� �� ���������� ������������ � ���� E-mail.")]
        public void EMail_SetCorrectValue_Assignation()
        {
            // Arrange
            var correctEMaile = "anton_fedorov#gmail.com";
            var expexted = correctEMaile;
            var contact = new Contact();

            // Act
            contact.EMail = correctEMaile;
            var actual = contact.EMail;

            // Assert
            Assert.AreEqual(expexted, actual);
        }

        [Test(Description = "�������� �� ���������� ������������ � ���� PhoneNumber.")]
        public void PhoneNumber_SetIncorrectValue_ArgumentException()
        {
            // Arrange
            var wrongPhoneNumber = "+1-2+43325";
            var contact = new Contact();

            // Assert
            Assert.Throws<ArgumentException>(() => 
            {
                // Act
                contact.PhoneNumber = wrongPhoneNumber; 
            },
            "Phone Number can only contain numbers and signs �+�, �(� �)� �-� � �." +
            " Number format: +7 (000) 000-00-00.");
        }

        [Test(Description = "�������� �� ���������� ������������ � ���� PhoneNumber.")]
        public void PhoneNumber_SetCorrectValue_Assignation()
        {
            // Arrange
            var correctPhoneNumber = "+7 (000) 000-00-00";
            var expexted = correctPhoneNumber;
            var contact = new Contact();

            // Act
            contact.PhoneNumber = correctPhoneNumber;
            var actual = contact.PhoneNumber;

            // Assert
            Assert.AreEqual(expexted, actual);
        }

        [Test(Description = "�������� �� ���������� ������������ � ���� DateOfBirth.")]
        [TestCase("1700-05-24T00:00:00+07:00", "������ ��������� ����������, " +
            "���� ���� �������� ������ 1900, 1, 1", 
            TestName = "���������� 1700 ���� � �������� ���� ��������")]
        [TestCase("2100-05-24T00:00:00+07:00", "������ ��������� ����������, " +
            "���� ���� �������� ������ ������� ����",
            TestName = "���������� 2100 ���� � �������� ���� ��������")]
        public void DateOfBirth_SetIncorrectValue_ArgumentException
            (string wrongDateOfBirth, string message)
        {
            // Arrange
            var contact = new Contact();

            // Assert
            Assert.Throws<ArgumentException>(() => 
            {
                // Act
                contact.DateOfBirth = Convert.ToDateTime(wrongDateOfBirth); 
            },
            message);
        }

        [Test(Description = "�������� �� ���������� ������������ � ���� DateOfBirth.")]
        public void DateOfBirth_SetCorrectValue_Assignation()
        {
            // Arrange
            var correctDateOfBirth = DateTime.Today;
            var expexted = correctDateOfBirth;
            var contact = new Contact();

            // Act
            contact.DateOfBirth = correctDateOfBirth;
            var actual = contact.DateOfBirth;

            // Assert
            Assert.AreEqual(expexted, actual);
        }

        [Test(Description = "�������� �� ���������� ������������ � ���� IdVK.")]
        public void IdVK_SetIncorrectValue_ArgumentException()
        {
            // Arrange
            var wrongIdVK = 
                "VK is the best messenger in the worldVK is the best messenger in the world" +
                "VK is the best messenger in the worldVK is the best messenger in the world" +
                "VK is the best messenger in the worldVK is the best messenger in the world";
            var contact = new Contact();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                contact.IdVK = wrongIdVK;
            },
            "The length of the VK field should not be more than 50 characters.");
        }

        [Test(Description = "�������� �� ���������� ������������ � ���� IdVK.")]
        public void IdVK_SetCorrectValue_Assignation()
        {
            // Arrange
            var correctIdVK = "325432";
            var expexted = correctIdVK;
            var contact = new Contact();

            // Act
            contact.IdVK = correctIdVK;
            var actual = contact.IdVK;

            // Assert
            Assert.AreEqual(expexted, actual);
        }

        [Test(Description = "�������� �� ���������� ������������ � ����������� Contact.")]
        public void Contact_PassingInvalidParameter_ArgumentException()
        {
            // Arrange
            var wrongFullName =
                 "�������-�������-�������-�������-�������-��������������" +
                 "�������-�������-�������-�������-�������-��������������" +
                 "�������-�������-�������-�������-�������-��������������";

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                new Contact(wrongFullName, "gmail", "+7000000", new DateTime(2006, 1, 1), "4324");
            },
            "���������� ����������� �������� � ����������� Contact.");
        }

        [Test(Description = "�������� �� ���������� ������������ � � ����������� Contact.")]
        public void Contact_PassingCorrectParameter_Assignation()
        {
            // Arrange
            var correctFullName = "Anton Fedorov";
            var expectedFullName = correctFullName;

            var correctEMail = "mail.ru";
            var expectedEMail = correctEMail;

            var correctPhoneNumber = "+7 (000) 000-00-00";
            var expectedPhoneNumber = correctPhoneNumber;

            var correctDateOfBirth = new DateTime(2000, 01, 18);
            var expectedDateOfBirth = correctDateOfBirth;

            var correctIdVK = "325432";
            var expextedIdVK = correctIdVK;

            // Act
            var contact = new Contact(
                correctFullName,
                correctEMail,
                correctPhoneNumber,
                correctDateOfBirth,
                correctIdVK);

            var actualContact = contact;

            // Assert
            Assert.AreEqual(expectedFullName, actualContact.FullName);
            Assert.AreEqual(expectedEMail, actualContact.EMail);
            Assert.AreEqual(expectedPhoneNumber, actualContact.PhoneNumber);
            Assert.AreEqual(expectedDateOfBirth, actualContact.DateOfBirth);
            Assert.AreEqual(expextedIdVK, actualContact.IdVK);
        }

        [Test(Description = "�������� �� ���������� ������������ � � ����������� Contact.")]
        public void Clone_PassingCorrectParameter_Assignation()
        {
            // Arrange
            var correctContact = new Contact(
                "Anton Fedorov",
                "mail.ru",
                "+7 (000) 000-00-00",
                new DateTime(2000, 01, 18),
                "325432");

            var expectedContact = correctContact;

            // Act
            var contactClone = (Contact)correctContact.Clone();
            var actualContact = contactClone;

            // Assert
            Assert.AreEqual(expectedContact.FullName, actualContact.FullName);
            Assert.AreEqual(expectedContact.EMail, actualContact.EMail);
            Assert.AreEqual(expectedContact.PhoneNumber, actualContact.PhoneNumber);
            Assert.AreEqual(expectedContact.DateOfBirth, actualContact.DateOfBirth);
            Assert.AreEqual(expectedContact.IdVK, actualContact.IdVK);
        }
    }
}