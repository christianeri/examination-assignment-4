using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using WpfContactsApp.MVVM.Models;
using WpfContactsApp.Services;

namespace WpfContactsApp.MVVM.ViewModels
{
    public partial class AllContactsViewModel : ObservableObject
    {
        private readonly FileService fileService;
        public AllContactsViewModel()
        {
            fileService = new FileService();
            contacts = fileService.Contacts();
        }

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

        [ObservableProperty]
        private ContactModel selectedContact = null!;







        [ObservableProperty]
        private string firstName = string.Empty;
        [ObservableProperty]
        private string lastName = string.Empty;
        [ObservableProperty]
        private string email = string.Empty;
        [ObservableProperty]
        private string phone = string.Empty;
        [ObservableProperty]
        private string streetAddress = string.Empty;

        [RelayCommand]
        private void AddContact()
        {
            fileService.AddToList(new ContactModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                StreetAddress = StreetAddress
            });
            ClearForm();
        }
        private void ClearForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            StreetAddress = string.Empty;
        }





        [RelayCommand]
        private void UpdateContact()
        {
            try
            {
                Update(selectedContact.Id, selectedContact);    
            }
            catch
            {
                Error();
            }

        }

        private void Update(Guid id, ContactModel contact)
        {
            fileService.UpdateListItem(id, contact);
        }



        private void Error()
        {
            MessageBox.Show("Fel");
        }



        [RelayCommand]
        private void RemoveContact()
        {
            //if (MessageBox.Show("Är du säker på att du vill ta bort kontakten?",
            //    "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
                Remove(selectedContact.Id);
                contacts.Remove(selectedContact);
            //}
            //else { }

            //    //REFRESH MAIN VIEW (FUNGERAR INTE)
            //    //MainViewModel.Instance.GoToAllContacts();
        }

        private void Remove(Guid id)
        {
            fileService.RemoveFromList(id);
        }
    }
}
