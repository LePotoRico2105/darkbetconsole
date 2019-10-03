using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    class Saison
    {
        private int id;
        private DateTime debut, fin;

        public Saison()
        {
            Console.WriteLine("Nouvelle saison créé");
        }

        public Saison(int pId, DateTime pDebut, DateTime pFin)
        {
            this.id = pId;
            this.debut = pDebut;
            this.fin = pFin;
            Console.WriteLine("Saison n° " + id + "crée ");
        }

        ~Saison()
        {
            Console.WriteLine("Saison détruite");
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public DateTime Debut
        {
            get
            {
                return debut;
            }

            set
            {
                debut = value;
            }
        }

        public DateTime Fin
        {
            get
            {
                return fin;
            }

            set
            {
                fin = value;
            }
        }
    }
}
