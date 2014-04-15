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
using System.Data.Entity;

namespace Main
{
    /// <summary>
    /// Interaction logic for OrderSearch.xaml
    /// </summary>
     
    

    public partial class OrderSearch : Window
    {
        CycleCareEntities cycleCare = new CycleCareEntities();
        List<CustomerRepair> openRepairsList;

        public OrderSearch()
        {
            openRepairsList = new List<CustomerRepair>();
            InitializeComponent();

        }

        private void openOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            List<CustomerRepair> openRepairsList = getOrders(false, lNameText.Text);

        foreach (CustomerRepair repair in openRepairsList)
            {

               OrderWindow orderWindow = new OrderWindow(repair);
               orderWindow.Activate();
               orderWindow.Show();
            }
        }
        public List<CustomerRepair> getOrders(bool completed, string lName)
        {   
            DbSet<CustomerRepair> orders = cycleCare.CustomerRepairs;
            string lastName = lName.ToLower();

            var query = from od in orders
                        where od.Completed == completed && od.LastName.ToLower().Contains(lastName)
                        select od;
         var openedRepairs = query.ToList();

            return openedRepairs;
    }            
     
        private void historicalOrdersButton_Click(object sender, RoutedEventArgs e)
        {
        List<CustomerRepair> openRepairsList = getOrders(true, lNameText.Text);

        OrdersList.ItemsSource = openRepairsList;
        OrdersList.Columns[0].Visibility = System.Windows.Visibility.Hidden;
        OrdersList.Columns[1].Visibility = System.Windows.Visibility.Hidden;
        OrdersList.Columns[2].Visibility = System.Windows.Visibility.Hidden;
        OrdersList.Columns[5].Visibility = System.Windows.Visibility.Hidden;
        OrdersList.Columns[6].Visibility = System.Windows.Visibility.Hidden;
        OrdersList.Columns[7].Visibility = System.Windows.Visibility.Hidden;
        OrdersList.Columns[8].Visibility = System.Windows.Visibility.Hidden;
        OrdersList.Columns[9].Visibility = System.Windows.Visibility.Hidden;
        //foreach (CustomerRepair repair in openRepairsList)
        //    {
        //       OrderWindow orderWindow = new OrderWindow(repair);
        //       orderWindow.Activate();
        //       orderWindow.Show();
        //    }
        }

        private void OrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // take order from the list
            var item = OrdersList.CurrentCell.Item;
            CustomerRepair historicalRepair = (CustomerRepair)item;
            OrderWindow orderWindow = new OrderWindow(historicalRepair);
            orderWindow.Activate();
            orderWindow.Show(); 

        }
        }
    }

