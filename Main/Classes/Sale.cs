using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Classes
{
   public class Sale
   {
      public int CustomerId { get; set; }
      public int SaleId { get; set; }
      public string ItemName { get; set; }
      public string FrameNo { get; set; }
      public DateTime SaleDate { get; set; }
      public string Comments { get; set; }
   }
}
