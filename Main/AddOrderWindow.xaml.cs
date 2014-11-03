using Main.Classes;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Main
{
   /// <summary>
   /// Interaction logic for AddOrderWindow.xaml
   /// </summary>
   public partial class AddOrderWindow : Window
   {
      // REMOVE and move to pure SQL connections

      private Customer Customer;
      private Order ExistingOrder;

      public AddOrderWindow()
      {
         InitializeComponent();
      }

      public AddOrderWindow(Order order)
      {
         InitializeComponent();
         this.ExistingOrder = order;
         this.Customer = ExistingOrder.Customer;
         findButton.IsEnabled = false;
         if (isCompletedCheck.IsChecked.Value) { isCompletedCheck.IsEnabled = false; }
         fNameText.Text = Customer.FirstName;
         // Disable some fields and this is only update, decide which ones
         fNameText.IsEnabled = false;
         lNameText.Text = Customer.LastName;
         telephoneText.Text = Customer.Address.TelNumber;
         emailText.Text = Customer.Address.Email;
         priceText.Text = ExistingOrder.Price.ToString();
         BicycleText.Text = order.Bicycle;
         dueDateDatePicker.Text = order.DueDate.ToString();
         commentsText.Text = order.Comments;
         isCompletedCheck.IsChecked = order.Completed;
         // is it how I find check buttion value?
         if (isCompletedCheck.IsChecked.Value) { isCompletedCheck.IsEnabled = false; }
      }

      public void setCustomer(Customer customer)
      {
         this.Customer = customer;
         fNameText.Text = customer.FirstName;
         fNameText.IsEnabled = false;
         lNameText.Text = customer.LastName;
         lNameText.IsEnabled = false;
         telephoneText.Text = customer.Address.TelNumber;
         emailText.Text = customer.Address.Email;
         findButton.IsEnabled = false;
      }

      private bool addOrder()
      {
         if (missingValues()) return false;
         if (invalidTelephone()
             && invalidEmail()
             && invalidPrice()) return false;
         Address address = new Address();

         if (emailText.Text.Trim().Length != 0)
            address.Email = emailText.Text;
         address.TelNumber = telephoneText.Text;
         Customer customer = new Customer();

         customer.FirstName = fNameText.Text;
         customer.LastName = lNameText.Text;
         customer.LastUpdate = System.DateTime.Now;
         customer.Address = address;

         Order newOrder = new Order();

         newOrder.Bicycle = BicycleText.Text;
         newOrder.DueDate = dueDateDatePicker.SelectedDate;
         newOrder.OrderDate = System.DateTime.Now;
         newOrder.Completed = false;
         newOrder.Price = Convert.ToDecimal(priceText.Text);
         newOrder.Comments = commentsText.Text;
         newOrder.Customer = customer;
         if (saveOrder(newOrder)) return true;
         else return false;
      }

      private bool saveOrder(Order newOrder)
      {
         //TODO: Add Order to Database
         return SqlAccess.addOrder(newOrder);
         //throw new NotImplementedException();

      }

      private bool updateOrder()
      {
         if (missingValues()) return false;
         if (invalidTelephone()
             && invalidEmail()
             && invalidPrice()) return false;

         ExistingOrder = new Order();
         ExistingOrder.Customer.FirstName = fNameText.Text;
         ExistingOrder.Customer.LastName = lNameText.Text;
         ExistingOrder.Customer.Address.Email = emailText.Text;
         ExistingOrder.Customer.Address.TelNumber = telephoneText.Text;
         ExistingOrder.DueDate = dueDateDatePicker.SelectedDate;
         //HANDLE THIS
         ExistingOrder.Price = Convert.ToDecimal(priceText.Text);
         ExistingOrder.Comments = commentsText.Text;
         ExistingOrder.Completed = isCompletedCheck.IsChecked;
         if (updateOrderSQL()) return true;
         else return false;
      }

      private bool updateOrderSQL()
      {
         throw new NotImplementedException();
      }

      private int emptyText(TextBox textBox, Label label)
      {
         if (textBox.Text.Trim().Length == 0)
         {
            label.Visibility = System.Windows.Visibility.Visible;
            return 1;
         }
         else return 0;
      }

      private bool missingValues()
      {
         int missing = 0;
         if (dueDateDatePicker.SelectedDate == null)
         {
            invalidDueDateLabel.Visibility = System.Windows.Visibility.Visible;
            missing = 1;
         }
         missing = emptyText(fNameText, invalidFNameLabel)
             + emptyText(lNameText, invalidLNameLabel)
             + emptyText(telephoneText, invalidTelephoneLabel)
             + emptyText(priceText, invalidPriceLabel)
             + emptyText(BicycleText, invalidBicycleLabel);

         if (missing > 0) return true;
         else return false;
      }

      private bool invalidEmail()
      {
         try
         {
            new System.Net.Mail.MailAddress(emailText.Text);
            return false;
         }
         catch
         {
            invalidEmailLabel.Visibility = System.Windows.Visibility.Visible;
            return true;
         }
      }

      private bool invalidPrice()
      {
         try
         {
            Convert.ToDecimal(priceText.Text);
            return false;
         }
         catch
         {
            invalidPriceLabel.Visibility = System.Windows.Visibility.Visible;
            return true;
         }
      }

      private bool invalidTelephone()
      {
         try
         {
            Convert.ToInt64(telephoneText.Text);
            return false;
         }
         catch
         {
            invalidTelephoneLabel.Visibility = System.Windows.Visibility.Visible;
            return true;
         }
      }

      private void resetAllInvalidFields()
      {
         invalidFNameLabel.Visibility = System.Windows.Visibility.Hidden;
         invalidLNameLabel.Visibility = System.Windows.Visibility.Hidden;
         invalidTelephoneLabel.Visibility = System.Windows.Visibility.Hidden;
         invalidEmailLabel.Visibility = System.Windows.Visibility.Hidden;
         invalidBicycleLabel.Visibility = System.Windows.Visibility.Hidden;
         invalidPriceLabel.Visibility = System.Windows.Visibility.Hidden;
         invalidDueDateLabel.Visibility = System.Windows.Visibility.Hidden;
      }

      //TODO:
      private void findButton_Click(object sender, RoutedEventArgs e)
      {
         throw new NotImplementedException();
      }

      private void saveButton_Click(object sender, RoutedEventArgs e)
      {
         resetAllInvalidFields();
         if (missingValues()) return;

         if (ExistingOrder != null) updateOrder();
         else addOrder();
         saveButton.IsEnabled = false;

         changesSavedLabel.Visibility = System.Windows.Visibility.Visible;
         Thread.Sleep(3000);
         changesSavedLabel.Visibility = System.Windows.Visibility.Hidden;
         this.Close();
      }
      private void cancelButton_Click(object sender, RoutedEventArgs e)
      {
         this.Close();
      }
   }
}