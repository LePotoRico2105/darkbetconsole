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
        private string champion;
        private DateTime debut, fin;

        public Saison()
        {
            Console.WriteLine("Nouvelle saison créé");
        }

        public Saison(int pId, string pChampion, DateTime pDebut, DateTime pFin)
        {
            this.id = pId;
            this.champion = pChampion;
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

        public string Champion
        {
            get
            {
                return champion;
            }

            set
            {
                champion = value;
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
