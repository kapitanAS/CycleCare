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

namespace Main
{
    /// <summary>
    /// Interaction logic for CustomerFoundWindow.xaml
    /// </summary>
    public partial class CustomerFoundWindow : Window
    {
        
        Customer Customer;
        Address Address;
        List<CustomerAddress> SameNamesList;
        AddClient ParentWindow;

        public CustomerFoundWindow(Customer customer, Address address, List<CustomerAddress> sameNameInDB, AddClient c)
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
            CycleCareEntities cycleCare = new CycleCareEntities();
            DbSet<Customer> customer = cycleCare.Customers;
            DbSet<Address> address = cycleCare.Addresses;
            customer.Add(Customer);
            address.Add(Address);
            cycleCare.SaveChanges();
            clientNameLabel.Content = "CLIENT SAVED!";
            Thread.Sleep(2000);
            this.Close();
            ParentWindow.Visibility = System.Windows.Visibility.Visible;
            
            
        }
    }
}
