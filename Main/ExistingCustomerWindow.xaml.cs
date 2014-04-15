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
using System.Windows.Shapes;

namespace Main
{
    /// <summary>
    /// Interaction logic for ExistingCustomerWindow.xaml
    /// </summary>
    public partial class ExistingCustomerWindow : Window
    {
        OrderWindow OrderWin;
        public ExistingCustomerWindow(OrderWindow sender)
        {
            InitializeComponent();
            this.OrderWin = sender;
        }

        private void customersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var item = customersDataGrid.CurrentCell.Item;
            Customer currentCustomer = (Customer)item;
            OrderWin.setCustomer(currentCustomer);
            OrderWin.IsEnabled = true;
            this.Close();
          
        }
    }
}
