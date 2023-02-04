using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfContactsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddContactsViewButton_Click(object sender, RoutedEventArgs e)
        {
            AddContactViewButton.Visibility = Visibility.Hidden;
            ContactsViewButton.Visibility = Visibility.Visible;
        }

        private void ContactsViewButton_Click(object sender, RoutedEventArgs e)
        {
            AddContactViewButton.Visibility = Visibility.Visible;
            ContactsViewButton.Visibility = Visibility.Hidden;
        }
    }
}
