using System;
using System.Linq;
using System.Net.Mail;

namespace Main.Classes
{
   public class Address
   {
      private MailAddress _email;
      private int _telNo;
      public string FirstLine { get; set; }

      public string SecondLine { get; set; }

      public string Town { get; set; }

      public string PostCode { get; set; }

      public string Comments { get; set; }

      public string TelNumber
      {
         get { return "0"+_telNo.ToString(); }
         set
         {
            try
            {
               _telNo = int.Parse(value);
            }
            catch (FormatException e)
            {
               throw new FormatException();
               // TODO: Redirect to error window and display stack trace
               //Console.WriteLine("Couldn't parse the tel no. Exception {0}", e);
            }
         }
      }

      public string Email
      {
         get { return _email.ToString(); }
         set { _email = new MailAddress(value); }
      }
   }
}