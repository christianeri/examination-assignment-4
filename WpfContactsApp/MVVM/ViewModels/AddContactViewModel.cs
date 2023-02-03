using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfContactsApp.MVVM.Models;
using WpfContactsApp.Services;

namespace WpfContactsApp.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public AddContactViewModel()
        {
            fileService = new FileService();
        }

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
        private void Add()
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
    }
}
