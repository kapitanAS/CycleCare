using System;

namespace Main.Classes
{
   public class Customer
   {
      public int CustomerId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public Address Address;
      public DateTime LastUpdate { get; set; }

      public Customer()
      {
         Address = new Address();
      }
   }
}