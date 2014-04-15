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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void clientSearchButton_Click(object sender, RoutedEventArgs e)
        {
            (new ClientSearchWindow()).Show();
        }

        private void findOrderButton_Click(object sender, RoutedEventArgs e)
        {
            (new OrderSearch()).Show();

        }

        private void addOrderButton_Click(object sender, RoutedEventArgs e)
        {
            new OrderWindow().Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
