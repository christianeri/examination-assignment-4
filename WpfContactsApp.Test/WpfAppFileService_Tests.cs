using System.Collections.ObjectModel;
using WpfContactsApp.MVVM.Models;
using WpfContactsApp.MVVM.ViewModels;
using WpfContactsApp.Services;

namespace WpfContactsApp.Test
{
    public class WpfAppFileService_Tests
    {
        //Arrange
        private FileService fileService;
        private ContactModel testContactItem;

        public WpfAppFileService_Tests()
        {
            fileService = new FileService();
            testContactItem = new ContactModel
            {

                Id = Guid.NewGuid(),
                FirstName = "preTestValue",
                LastName = "preTestValue",
                Email = "preTestValue",
                Phone = "preTestValue",
                StreetAddress = "preTestValue"
            };
        }


        [Fact]
        public void Should_Add_Item_To_List()
        {
            var preAddList = fileService.Contacts();
            int preAddCount = preAddList.Count();
                                  
            fileService.AddToList(testContactItem);
            
            var postAddList = fileService.Contacts();
            int postAddCount = postAddList.Count();



            Assert.True(preAddCount < postAddCount);
        }


        [Fact]
        public void Should_Update_List_Item_Propery_Values()
        {
            fileService.AddToList(testContactItem);

            ContactModel postUpdateContactItem = new ContactModel
            {
                Id = testContactItem.Id,
                FirstName = "postUpdateTestValue",
                LastName = "postUpdateTestValue",
                Email = "postUpdateTestValue",
                Phone = "postUpdateTestValue",
                StreetAddress = "postUpdateTestValue"
            };
            fileService.UpdateListItem(testContactItem.Id, postUpdateContactItem);


            var postUpdateList = fileService.Contacts();
            var postUpdateItem = postUpdateList.FirstOrDefault(x => x.Id == testContactItem.Id);



            Assert.NotEqual(testContactItem.FirstName, postUpdateItem.FirstName);
            Assert.NotEqual(testContactItem.LastName, postUpdateItem.LastName);
            Assert.NotEqual(testContactItem.Email, postUpdateItem.Email);
            Assert.NotEqual(testContactItem.Phone, postUpdateItem.Phone);
            Assert.NotEqual(testContactItem.StreetAddress, postUpdateItem.StreetAddress);
        }

        [Fact]
        public void Should_Remove_Item_From_List()
        {
            fileService.AddToList(testContactItem);
            var preTestList = fileService.Contacts();
            int preTestCount = preTestList.Count();


            fileService.RemoveFromList(testContactItem.Id);
            var postTestList = fileService.Contacts();
            int postTestCount = postTestList.Count();



            Assert.True(preTestCount > postTestCount);
        }
    }
}