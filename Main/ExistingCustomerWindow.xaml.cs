using System;
using System.Windows;
using System.Windows.Controls;

namespace Main
{
   /// <summary>
   /// Interaction logic for ExistingCustomerWindow.xaml
   /// </summary>
   public partial class ExistingCustomerWindow : Window
   {
      private AddOrderWindow _addOrderWin;

      public ExistingCustomerWindow(AddOrderWindow sender)
      {
         InitializeComponent();
         this._addOrderWin = sender;
      }

      private void customersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         throw new NotImplementedException();

         /*TODO: Verify this code after changes to direct SQL queries
          var item = customersDataGrid.CurrentCell.Item;
          Customer currentCustomer = (Customer)item;
          _addOrderWin.setCustomer(currentCustomer);
          _addOrderWin.IsEnabled = true;
          this.Close();
        */
      }
   }
}