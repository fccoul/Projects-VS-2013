using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_WebSCe
{
   public class Employee
    {
       public string FirstName { get;set;}
       public string LastName { get; set; }
       public int EmpCode { get; set; }
       public string Designation { get; set; }

       public string getEmployeeName()
       {
           string fullname = FirstName + " " + LastName;
           return fullname;
       }


    }
}
