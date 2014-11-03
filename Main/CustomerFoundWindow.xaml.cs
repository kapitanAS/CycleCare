using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Main.Classes;

namespace Main
{
    /// <summary>
    /// Interaction logic for CustomerFoundWindow.xaml
    /// </summary>
    public partial class CustomerFoundWindow : Window
    {
        //TODO: Practically all. Double check that List is of a vaild type
        Customer Customer;
        Address Address;
        List<Customer> SameNamesList;
        AddClient ParentWindow;

        public CustomerFoundWindow(Customer customer, Address address, List<Customer> sameNameInDB, AddClient c)
        {
            InitializeComponent();
            this.Customer = customer;
            this.Address = address;
            this.SameNamesList = sameNameInDB;
            ParentWindow = c;
            clientNameLabel.Content = string.Format("{0} {1} {2} exists", this.Customer.FirstName, this.Customer.LastName, this.Address.Town);
            clientNameLabel.Visibility = Visibility.Visible;
        }


        private void viewButton_Click(object sender, RoutedEventArgs e)
        {
           custompersList.ItemsSource = SameNamesList;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveAnywayButton_Click(object sender, RoutedEventArgs e)
        {

            saveChangesSQL();
            clientNameLabel.Content = "CLIENT SAVED!";
            Thread.Sleep(2000);
            this.Close();
            ParentWindow.Visibility = System.Windows.Visibility.Visible;
            
            
        }

       private bool saveChangesSQL()
       {
          throw new NotImplementedException();
       }
    }
}
