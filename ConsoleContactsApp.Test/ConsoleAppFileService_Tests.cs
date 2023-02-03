using ConsoleContactsApp.Models;
using ConsoleContactsApp.Services;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleContactsApp.Test
{
    [TestClass]
    public class ConsoleAppFileService_Tests
    {
        [TestMethod]
        public void Should_Add_New_Contact_To_List()
        {
            //Arrange - f�rberedelser
            FileService fileServiceSUT = new FileService();

            ContactModel contactSUT = new ContactModel();

            var preAddList = fileServiceSUT.AllContacts();
            int preAddCount = preAddList.Count();


            //Act - utf�rande
            fileServiceSUT.AddListItem(contactSUT);

            var postAddList = fileServiceSUT.AllContacts();
            int postAddCount = postAddList.Count();


            //Assert - utv�rdering
            Assert.IsTrue(preAddCount < postAddCount);
        }

        public void Should_Remove_Contact_From_List()
        {
            //Arrange - f�rberedelser
            FileService fileServiceSUT = new FileService();
            ContactModel contactSUT = new ContactModel();
            
            fileServiceSUT.AddListItem(contactSUT);

            var preRemoveList = fileServiceSUT.AllContacts();
            int preRemoveCount = preRemoveList.Count();



            //Act - utf�rande
            fileServiceSUT.RemoveListItem(preRemoveCount - 1);

            var postRemoveList = fileServiceSUT.AllContacts();
            int postRemoveCount = postRemoveList.Count();


            //Assert - utv�rdering
            Assert.IsTrue(preRemoveCount > postRemoveCount);
        }
    }
}