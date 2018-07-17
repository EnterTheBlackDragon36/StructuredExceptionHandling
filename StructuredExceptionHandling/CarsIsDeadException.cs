using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuredExceptionHandling
{
    public class CarIsDeadException : ApplicationException
    {

      //Application Level Exceptions
      private string messageDetails = String.Empty;
      public DateTime ErrorTimeStamp {get; set;}
      public string CauseOfError {get; set;}
        
      // Constructors
      public CarIsDeadException(){ }
      // Feed message to parent constructor
      public CarIsDeadException(string message, string cause, DateTime time) : base(message)
      {
          CauseOfError = cause;
          ErrorTimeStamp = time;
      }
      
      #region First Custom Exception
      //public CarIsDeadException(string message, string cause, DateTime time)
      //{
      //  messageDetails = message;
      //  CauseOfError = cause;
      //  ErrorTimeStamp = time;
      //}
      #endregion

      // Override the Exception.Message property
      public override string Message
      {
        get
        {
          return string.Format("Car Error Message: {0}", messageDetails);
        }
      }

    }
}
