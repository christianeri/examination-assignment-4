using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfContactsApp.MVVM.Models;
using WpfContactsApp.Services;

namespace WpfContactsApp.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {





        //private static MainViewModel _instance = new MainViewModel();
        //public static MainViewModel Instance { get { return _instance; } }

        //public void Refresh()
        //{
        //    GoToAllContacts();
        //} 
        //other stuff here

        



        [ObservableProperty]
        public ObservableObject currentViewModel = new AllContactsViewModel();

        [RelayCommand]
        private void GoToAddContact() => CurrentViewModel = new AddContactViewModel();

        [RelayCommand]
        public void GoToAllContacts() => CurrentViewModel = new AllContactsViewModel();
    }
}
