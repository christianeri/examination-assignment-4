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
            //Arrange - förberedelser
            FileService fileServiceSUT = new FileService();

            ContactModel contactSUT = new ContactModel
            {
                FirstName = "Firstnametest",
                LastName = "Lastnametest",
                Email = "test@domain.com",
                PhoneNumber = "000-0000000",
                Address = "Testaddress"
            };

            //Act - utförande
            var preTestList = fileServiceSUT.AllContacts();
            int preTestCount = preTestList.Count();

            fileServiceSUT.AddListItem(contactSUT);

            var postTestList = fileServiceSUT.AllContacts();
            int postTestCount = postTestList.Count();

            //Assert - utvärdering
            Assert.IsTrue(preTestCount < postTestCount);

        }
    }
}