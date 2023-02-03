using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WpfContactsApp.MVVM.Models;
using WpfContactsApp.Services;

namespace WpfContactsApp.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel = new AllContactsViewModel();

        [RelayCommand]
        private void GoToAddContact() => CurrentViewModel = new AddContactViewModel();

        [RelayCommand]
        private void GoToAllContacts() => CurrentViewModel = new AllContactsViewModel();

        public void RefreshView()
        {
            GoToAllContacts();  
        }
    }
}
