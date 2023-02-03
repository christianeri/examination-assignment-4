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





        [RelayCommand]
        private void UpdateContact()
        {
            MessageBox.Show($"Vald kontakt: {selectedContact.DisplayName}");
            Update(selectedContact.Id, selectedContact);

        }
        private void Update(Guid id, ContactModel contact)
        {
            fileService.UpdateListItem(id, contact);
        }





        [RelayCommand]
        private void RemoveContact()
        {
            MessageBox.Show($"Är du säker på att du vill ta bort kontakten: {selectedContact.DisplayName}");
            Remove(selectedContact.Id);
        }
        private void Remove(Guid id)
        {
            fileService.RemoveFromList(id);
        }

    }
}
