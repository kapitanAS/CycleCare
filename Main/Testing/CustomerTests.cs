using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Main.Classes;

namespace Main.Testing
{
   [TestFixture]
   class CustomerTests:TestHelpers
   {
      [Test]
      public void invalidTelNoFails()
      {
         //work on it later
         Customer customer = new Customer();
         customer.Address.TelNumber = "288";
         Assert.AreEqual(customer.Address.TelNumber, "0288");
      }

      [TearDown]
      public void cleanupDB()
      {
         
         TestHelpers.CleanDB();
      }
      [Test]
      public void orderIsPersistedInDatabase()
      {
         Order o = new Order();
         o.Customer.Address.Email = "bezkres@op.pl";
         o.Customer.Address.TelNumber = "02084854753";
         o.Customer.FirstName = "Michal";
         o.Customer.LastName = "Kepa";
         o.Price = 244.83m;
         o.Bicycle = "Damka";
         o.DueDate=DateTime.Now;
         o.DueDate = (DateTime.Now).AddDays(3);
         o.Comments="Jaska";
         SqlAccess.addOrder(o);

      }
   }
}
