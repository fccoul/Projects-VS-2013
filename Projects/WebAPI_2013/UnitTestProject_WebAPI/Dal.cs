using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject_WebAPI
{
    class Dal : IDal1
    {
        public Meteo ObtenirMeteoDuJour()
        {
            throw new NotImplementedException();
        }
    }

    public interface IDal1
    {
        Meteo ObtenirMeteoDuJour();
    }

    public class Meteo
    {
        public double Temperature { get; set; }
        public Temps temps { get; set; }
    }

    public enum Temps
    {
        Soleil,
        pluie
    }


    public interface IGenerateur
    {
        int Valeur { get; }
    }

    public class Generateur : IGenerateur
    {
        private Random r;
        public Generateur()
        {
            r = new Random();
        }
        public int Valeur
        {
            //throw new NotImplementedException();
            get
            {
                return r.Next(1, 100);
            }
        }
    }
}
