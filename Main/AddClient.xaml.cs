using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Data.Entity;
using System.Threading;

namespace Main
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>

    public partial class AddClient : Window
    {
        CycleCareEntities cycleCare = new CycleCareEntities();

        public AddClient()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            saveButton.IsEnabled = false;
            DbSet<Customer> customerDetails = cycleCare.Customers;
            DbSet<Address> addressDetails = cycleCare.Addresses;

            Customer newCustomer = new Customer();
            Address newAddress = new Address();
            newCustomer.FirstName = firstNameText.Text;
            newCustomer.LastName = lastNameText.Text;
            newAddress.FirstLine = addressText.Text;
            newAddress.Town = townText.Text;
            newAddress.PostCode = postCodeText.Text;
            if (telNoText.Text.Trim().Length!=0)
            {
                try
                {
                    Convert.ToInt32(telNoText.Text);
                    newAddress.TelNumber = telNoText.Text;
                }catch
                    {
                        telNoLabel.Foreground = new SolidColorBrush(Colors.Red);
                        telNoLabel.Content = "Invalid tel number!";
                        saveButton.IsEnabled = true;
                        return;
                    }
            }
            if (emailText.Text != "")
            {
                try 
                {
                    var addr = new System.Net.Mail.MailAddress(emailText.Text);
                }catch 
                    {
                        emailLabel.Foreground = new SolidColorBrush(Colors.Red);
                        emailLabel.Content = "Invalid email!";
                        saveButton.IsEnabled = true;
                        return;
                    }
                }
                newAddress.Email = emailText.Text;

            //var query =
            //    from customer in customerDetails
            //    where customer.LastName.ToLower().Equals(newCustomer.LastName.ToLower())
            //    && customer.Address.Town.ToLower().Contains(newAddress.Town.ToLower())
            //    select new{ customer.Address.AddressID, customer.CustomerID, customer.FirstName, customer.LastName, customer.LastUpdate, customer.Address.FirstLine, customer.Address.Town, customer.Address.PostCode, customer.Address.TelNumber, customer.Address.Email, customer.Address.Comments };
       
            ////var identicalNames = query.ToList().Select(r=> new CustomerAddress(r.AddressID,r.CustomerID,r.FirstName,r.LastName,r.LastUpdate,r.FirstLine,r.Town,r.PostCode,r.TelNumber,r.Email,r.Comments));
            ////List<CustomerDetail> list = identicalNames.ToList();
            ////if (list.Count() > 0 )
            //{
            //    CustomerFoundWindow custFound = new CustomerFoundWindow(newCustomer, newAddress, list, this);
            //    custFound.Show();
            //    this.Visibility = System.Windows.Visibility.Hidden;
            //    saveButton.IsEnabled = true;
            //    changesSavedLabel.Visibility = System.Windows.Visibility.Visible;
     
            //}
            //else
            //{
            //    addressDetails.Add(newAddress);
            //    customerDetails.Add(newCustomer);
            //    cycleCare.SaveChanges();
            //    saveButton.IsEnabled = true;
            //    changesSavedLabel.Content = "Saved";
            //    changesSavedLabel.Visibility = System.Windows.Visibility.Visible;
            //    new Thread(() =>
            //    {
            //        Thread.Sleep(3000);
            //        this.Dispatcher.Invoke((Action)(() =>
            //        {
            //            changesSavedLabel.Visibility = System.Windows.Visibility.Hidden;
            //        }));


            //    }
            //    ).Start();
            //}
            ////catch

        }
    }
}

