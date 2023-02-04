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





        private void ListView_Selected(object sender, RoutedEventArgs e)
        {
            var listViewItem = (Button)sender;
            var contact = (ContactModel)listViewItem.DataContext;

            //MessageBox.Show(contact.DisplayName);
        }

        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditContactForm.Visibility = Visibility.Hidden;
            ContactDetails.Visibility = Visibility.Visible;
        }






        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            ContactDetails.Visibility = Visibility.Hidden;
            EditContactForm.Visibility = Visibility.Visible;
        }

        private void EditFormButton_Click(object sender, RoutedEventArgs e)
        {
            EditContactForm.Visibility = Visibility.Hidden;
            ContactDetails.Visibility = Visibility.Visible;
        }

        private void CancelEdit_Button_Click(object sender, RoutedEventArgs e)
        {
            EditContactForm.Visibility = Visibility.Hidden;
            ContactDetails.Visibility = Visibility.Visible;
        }





        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            //ContactDetails.Visibility = Visibility.Hidden;
            RemoveContactGatekeeper.Visibility = Visibility.Visible;
        }

        private void RemoveGatekeeperYesButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveContactGatekeeper.Visibility = Visibility.Hidden;
            ContactDetails.Visibility = Visibility.Hidden;
        }

        private void RemoveGatekeeperNoButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveContactGatekeeper.Visibility = Visibility.Hidden;
        }

    }
}
