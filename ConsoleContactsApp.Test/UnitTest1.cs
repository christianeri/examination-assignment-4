using ConsoleContactsApp.Models;
using ConsoleContactsApp.Services;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleContactsApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Should_Add_New_Contact_To_List()
        {
            //Arrange - f�rberedelser
            FileService fileServiceSUT = new FileService();

            ContactModel contactSUT = new ContactModel
            {
                FirstName = "Firstnametest",
                LastName = "Lastnametest",
                Email = "test@domain.com",
                PhoneNumber = "000-0000000",
                Address = "Testaddress"
            };

            //Act - utf�rande
            var preTestList = fileServiceSUT.AllContacts();
            int preTestCount = preTestList.Count();

            fileServiceSUT.AddListItem(contactSUT);

            var postTestList = fileServiceSUT.AllContacts();
            int postTestCount = postTestList.Count();

            //Assert - utv�rdering
            Assert.IsTrue(preTestCount < postTestCount);

        }
    }
}