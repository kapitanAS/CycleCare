using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Data.Entity;

namespace Main
{
    /// <summary>
    /// Interaction logic for ClientSearchWindow.xaml
    /// </summary>
    /// Here is a short comment to make
    public partial class ClientSearchWindow : Window
    {
        CycleCareEntities cycleCare = new CycleCareEntities();

        public ClientSearchWindow()
        {   
            InitializeComponent();
        }

        private void ClientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                DbSet<Customer> customers = cycleCare.Customers;
                DbSet<Address> addresses = cycleCare.Addresses;
                string search = customerSearchText.Text.ToLower();
                

                var query =
                    from c in customers
                    join a in addresses on c.AddressID equals a.AddressID
                    where c.LastName.ToLower().Contains(search)
                    select new { c.FirstName, c.LastName, a.FirstLine, a.Town, a.PostCode, a.TelNumber };

                this.clientList.ItemsSource = query.ToList();
            }
        }

        private void addCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            (new AddClient()).Show();
        }

    }
}
