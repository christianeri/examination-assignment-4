using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows;
using System.Windows.Controls;
using WpfContactsApp.MVVM.Models;
using WpfContactsApp.MVVM.ViewModels;
using WpfContactsApp.Services;

namespace WpfContactsApp.MVVM.Views
{
    public partial class AllContactsView : UserControl
    {
        private readonly FileService fileService;
        public AllContactsView()
        {
            InitializeComponent();
            fileService = new FileService();
        }







        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext;

            MessageBox.Show($"Är du säker på att du vill ta bort kontakten: {contact.DisplayName}");
            Remove(contact.Id);
        }

        private void Remove(Guid id)
        {
            fileService.RemoveFromList(id);
        }





        private void ListView_Selected(object sender, RoutedEventArgs e)
        {
            var listViewItem = (Button)sender;
            var contact = (ContactModel)listViewItem.DataContext;

            MessageBox.Show(contact.DisplayName);
        }





        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditContactForm.Visibility = Visibility.Hidden;
            ContactDetails.Visibility = Visibility.Visible;
        }




 





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContactDetails.Visibility = Visibility.Hidden;
            EditContactForm.Visibility= Visibility.Visible; 
        }
    }
}
