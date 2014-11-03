using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Testing
{
   public class TestHelpers
   {
      public static string SqlConnectionString = "Server=localhost;Database=CycleCare;Trusted_Connection=True;";
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
               SqlAccess.SqlExeptions(e);
            }
         }
      }
   }
}
