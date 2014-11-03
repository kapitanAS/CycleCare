using System;
using System.Windows;
using System.Windows.Input;

namespace Main
{
   /// <summary>
   /// Interaction logic for ClientSearchWindow.xaml
   /// </summary>
   /// Here is a short comment to make
   public partial class ClientSearchWindow : Window
   {
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
            string search = customerSearchText.Text.ToLower();

            // TODO: SQL query for a client with given name
            throw new NotImplementedException();
         }
      }

      private void addCustomerButton_Click(object sender, RoutedEventArgs e)
      {
         (new AddClient()).Show();
      }
   }
}