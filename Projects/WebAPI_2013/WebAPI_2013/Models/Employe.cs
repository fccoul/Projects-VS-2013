using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_2013.Models
{

    //vu que checkEmp n'est pas encore implementé, on utilisera un mock avec la methode insertEmploye pour faire nos tests
    //dans cet exemple chekEmploye depend d'un autre developpeur et processEmployee depend de moi
    public class checkEmploye
    {
        public virtual Boolean checkEmp()
        {
            throw new NotImplementedException();
        }
    }

        public class processEmployee
        {
        //verifie que l'employe n'exts pas en BDD avant de le créér...
            public Boolean insertEmployee(checkEmploye objtmp)
            {
                objtmp.checkEmp();
                return true;
            }
        }

    
}