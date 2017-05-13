using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez le premier chiffre");
            string valfirst=Console.ReadLine();

            Console.WriteLine("Entrez le second chiffre");
            string valSecond = Console.ReadLine();

            SceRef_asmx.Service1SoapClient proxy = new SceRef_asmx.Service1SoapClient();
            int result = proxy.MultiplicateInteger(int.Parse(valfirst), int.Parse(valSecond));
            Console.WriteLine("{0} X {1} donne comme resultat : {2}",valfirst,valSecond,result);

            Console.ReadLine();
        }
    }
}
