using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_WebSCe
{
    //Class responsible for handling error messages
    public class ErrorHandler
    {
        static StringBuilder errMessage = new StringBuilder();

        //Make class immutable
        static ErrorHandler()
        {
        }
        /// <summary>
        /// Property - holds exception messages encountered 
        /// at code execution
        /// </summary>
        public string ErrorMessage
        {
            get { return errMessage.ToString(); }
            set
            {
                errMessage.AppendLine(value);
            }
        }
    }
}
