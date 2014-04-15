using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Main
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        // REMOVE and move to pure SQL connections

        private Customer Customer;
        private CustomerRepair Order;
        public OrderWindow()
        {
            InitializeComponent();
        }

        public OrderWindow(CustomerRepair repair)
        {
            InitializeComponent();
            this.Order = repair;
            findButton.IsEnabled = false;
            if (isCompletedCheck.IsChecked.Value) { isCompletedCheck.IsEnabled = false; }
            fNameText.Text = repair.FirstName;
            // Disable some fields and this is only update, decide which ones
            fNameText.IsEnabled = false;
            lNameText.Text = repair.LastName;
            telephoneText.Text = repair.TelNumber.ToString();
            emailText.Text = repair.Email;
            priceText.Text = repair.Price.ToString();
            BicycleText.Text = repair.Bicycle;
            dueDateDatePicker.Text = repair.DueDate.ToString();
            commentsText.Text = repair.Comments;
            isCompletedCheck.IsChecked = repair.Completed;
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

        private void addOrder(CycleCareEntities context)
        {
            if (missingValues()) return;
            if (invalidTelephone()
                && invalidEmail()
                && invalidPrice()) return;
            Customer customer = new Customer();
            Address address = new Address();
            Repair order = new Repair();
            customer.FirstName = fNameText.Text;
            customer.LastName = lNameText.Text;
            customer.LastUpdate = System.DateTime.Now;

            if (emailText.Text.Trim().Length != 0)
                address.Email = emailText.Text;
            address.TelNumber = telephoneText.Text;
            order.Bicycle = BicycleText.Text;
            order.DueDate = dueDateDatePicker.SelectedDate;
            order.OrderDate = System.DateTime.Now;
            order.Completed = false;
            order.Price = Convert.ToDecimal(priceText.Text);
            order.Comments = commentsText.Text;
            customer.Address = address;
            order.Customer = customer;
            context.Repairs.Add(order);
        }

        private void updateOrder(CycleCareEntities context)
        {
            if (missingValues()) return;
            if (invalidTelephone()
                && invalidEmail()
                && invalidPrice()) return;

            var customer = context.Customers.First(c => c.CustomerID == Order.CustomerID);
            customer.FirstName = fNameText.Text;
            customer.LastName = lNameText.Text;
            customer.Address.Email = emailText.Text;
            customer.Address.TelNumber = telephoneText.Text;
            var repair = customer.Repairs.First(r => r.RepairID == Order.RepairID);
            repair.DueDate = dueDateDatePicker.SelectedDate;
            //HANDLE THIS
            repair.Price = Convert.ToDecimal(priceText.Text);
            repair.Comments = commentsText.Text;
            repair.Completed = isCompletedCheck.IsChecked;
            context.SaveChanges();
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
            resetAllInvalidFields();
            // find Customer here and return results with option to select one from the list
            if (lNameText.Text.Trim().Length == 0)
            {
                emptyText(lNameText, invalidLNameLabel);
                // clientNameLabel.Content = "CLIENT SAVED!";
            }
            else
            {
                this.IsEnabled = false;
                string lName = lNameText.Text.Trim().ToLower();
                var context = new CycleCareEntities();
                var query = from c in context.Customers
                            where c.LastName.ToLower() == lName
                            select c;

                //List<Customer> matchingLName = query.ToList();
                if (query.Count() > 0)
                {
                    ExistingCustomerWindow existingCustomersWindow = new ExistingCustomerWindow(this);
                    existingCustomersWindow.customersDataGrid.ItemsSource = query.ToList();
                    //set column visibility
                    //existingCustomersWindow.customersDataGrid.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                    existingCustomersWindow.Show();
                }
                // ELSE NO ENTRIES FOUND
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            resetAllInvalidFields();
            if (missingValues()) return;
            // grab values from fields
            using (var context = new CycleCareEntities())
            {
                if (Order != null) updateOrder(context);
                else addOrder(context);
                context.SaveChanges();
                saveButton.IsEnabled = false;
            }

            changesSavedLabel.Visibility = System.Windows.Visibility.Visible;
            Thread.Sleep(3000);
            changesSavedLabel.Visibility = System.Windows.Visibility.Hidden;
            this.Close();

            // verify them
            // save result to DB
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}