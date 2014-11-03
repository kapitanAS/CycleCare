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
using Main.Classes;

namespace Main
{
    /// <summary>
    /// Interaction logic for OrderSearch.xaml
    /// </summary>
     
    

    public partial class OrderSearch : Window
    {
        List<Order> openRepairsList;

        public OrderSearch()
        {
            openRepairsList = new List<Order>();
            InitializeComponent();

        }

        private void openOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            List<Order> openRepairsList = getOrders(false, lNameText.Text);

        foreach (Order repair in openRepairsList)
            {

               AddOrderWindow addOrderWindow = new AddOrderWindow(repair);
               addOrderWindow.Activate();
               addOrderWindow.Show();
            }
        }
        public List<Order> getOrders(bool completed, string lName)
        {   
            //TODO: Return orders from DB
           throw new NotImplementedException();
            //return openedRepairs;
    }            
     
        private void historicalOrdersButton_Click(object sender, RoutedEventArgs e)
        {
        List<Order> openRepairsList = getOrders(true, lNameText.Text);

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
        //       AddOrderWindow orderWindow = new AddOrderWindow(repair);
        //       orderWindow.Activate();
        //       orderWindow.Show();
        //    }
        }

        private void OrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // take order from the list
            var item = OrdersList.CurrentCell.Item;
            Order historicalRepair = (Order)item;
            AddOrderWindow addOrderWindow = new AddOrderWindow(historicalRepair);
            addOrderWindow.Activate();
            addOrderWindow.Show(); 

        }
        }
    }

