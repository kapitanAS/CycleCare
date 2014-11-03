using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Windows.Documents;
using Main.Classes;


namespace Main
{
   public static class SqlAccess
   {
      private static string SqlConnectionString = "Server=localhost;Database=CycleCare;Trusted_Connection=True;";

      public static bool addOrder(Order newOrder)
      {
         using (SqlConnection con = new SqlConnection(
            SqlConnectionString))
         {
            con.Open();
            try
            {
               using (SqlCommand command = new SqlCommand(
                  @"
                  BEGIN TRANSACTION
                  INSERT INTO Addresses(TelNumber,Email) VALUES (@TelNumber,@Email);
                  INSERT INTO Customers(AddressID,FirstName,LastName) VALUES ((SELECT TOP 1 AddressID FROM Addresses WHERE TelNumber=@TelNumber AND Email=@Email), @FirstName,@LastName);
                  INSERT INTO Repairs(CustomerID,Bicycle,Price,DueDate,Comments) VALUES((SELECT TOP 1 CustomerID FROM Customers WHERE 
                  FirstName=@FirstName AND LastName=@LastName AND AddressID=(SELECT TOP 1 AddressID FROM Addresses WHERE TelNumber=@TelNumber AND Email=@Email)),@Bicycle,@Price,@DueDate,@Comments);
                  COMMIT
", con))
               {
                  command.Parameters.Add(new SqlParameter("TelNumber", newOrder.Customer.Address.TelNumber));
                  command.Parameters.Add(new SqlParameter("Email", newOrder.Customer.Address.Email));
                  command.Parameters.Add(new SqlParameter("FirstName", newOrder.Customer.FirstName));
                  command.Parameters.Add(new SqlParameter("LastName", newOrder.Customer.LastName));
                  command.Parameters.Add(new SqlParameter("Bicycle", newOrder.Bicycle));
                  command.Parameters.Add(new SqlParameter("Price", newOrder.Price));
                  command.Parameters.Add(new SqlParameter("DueDate", newOrder.DueDate));
                  command.Parameters.Add(new SqlParameter("Comments", newOrder.Comments));
                  command.ExecuteNonQuery();
                  return true;
               }
            }
            catch (Exception e)
            {
               SqlExeptions(e);
               return false;
            }
         }
      }

      public static void SqlExeptions(Exception e)
      {
         Console.WriteLine(e);
      }

      public static void CleanDB()
      {
         using (SqlConnection con = new SqlConnection(
            SqlConnectionString))
         {
            con.Open();
            try
            {
               using (SqlCommand command = new SqlCommand(@"
                  BEGIN TRANSACTION
                  DELETE Sales
                  DELETE Repairs
                  DELETE Customers
                  DELETE Addresses
                  COMMIT
               ", con))
               {
                  command.ExecuteNonQuery();
               }
               ;
            }
            catch (Exception e)
            {
               SqlExeptions(e);
            }
         }
      }
   }
}