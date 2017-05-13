using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp_BarCode
{
    class Program
    {
        static void Main(string[] args)
        {


            string chaine="V2200250I";
            char FirstChaine =(char) chaine.First();
            char LastChaine=(char)chaine.Last();
            string subs = chaine.Substring(0);
            Console.WriteLine("Le premier caractere de cette chaine est : {0}", FirstChaine);
            Console.WriteLine("Le dernier caractere de cette chaine est : {0}",LastChaine);
            //////////////////////////////////////////:
            Console.WriteLine("Veuillez sasir quelque chose : ");
            //string laSaisie = Console.ReadLine();
            //Console.WriteLine("{0} saisi au clavier ", laSaisie);
            //int key = Console.Read();
             ConsoleKeyInfo info =Console.ReadKey(); //affiche direcetement les infos saisi à l'ecarn
          //Console.WriteLine(key);
            /*
          if (Key == 'a')
              Console.WriteLine("ok");
          else
              Console.WriteLine("ko");
            */
            //Console.WriteLine(key);
               
            /**///////////////////////////////////////
             if (info.Key == ConsoleKey.Enter)
             {
                 Console.WriteLine("vous aves appuyer la touche 'ENTER'");

                 Console.WriteLine("Code clavier touche ENTER = {0}",ConsoleKey.Enter);
             }

             Console.WriteLine("Veuilez saisir à nouveau :");
             
                 info = Console.ReadKey();
             if (info.Key == ConsoleKey.Escape)
                 Console.WriteLine("You pressed Escape");

             // Call ReadKey again and test for the letter a.
             Console.WriteLine("Veuilez saisir à nouveau :");
             info = Console.ReadKey();
             if(info.KeyChar=='a')
                 Console.WriteLine("You pressed a");
             // Call ReadKey again and test for control-X.
             // ... This implements a shortcut sequence.
             Console.WriteLine("Veuilez saisir à nouveau :");
             info = Console.ReadKey();
             if (info.Key == ConsoleKey.X)
             {
                 Console.WriteLine("you pressed control X");
             }

            ///////////////////////////////////////////
            Console.Read();

        }
    }
}

/*infos*/
/*a touche "entrée" génère habituellement deux codes : 
un retour chariot et un saut de ligne, qui s'appellent respectivement CR (carriage return) et LF (line feed) 
10 et 13 sont les deux codes correspondants... 
*/