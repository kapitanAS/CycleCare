using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Classes
{
   public class Order
   {
      public int OrderId { get; set; }
      public Customer Customer { get; set; }
      public string Bicycle { get; set; }
      public decimal Price { get; set; }
      public DateTime OrderDate { get; set; }
      public DateTime? DueDate { get; set; }
      public string Comments { get; set; }
      public bool? Completed { get; set; }

      public Order()
      {
         Customer = new Customer();
      }
   }
}
