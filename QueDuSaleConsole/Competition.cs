using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    class Competition
    {
        private int id, nbSaisonsDisponible;
        private Pays unPays;
        private string nom, code;
        private DateTime maj;


        public Competition()
        {
            Console.WriteLine("Nouvelle compétition créé");
        }

        public Competition(int pId, int pNbSaisonsDisponible, string pNom, string pCode, DateTime pMaj)
        {
            this.id = pId;
            this.nbSaisonsDisponible = pNbSaisonsDisponible;
            this.nom = pNom;
            this.code = pCode;
            this.maj = pMaj;
            Console.WriteLine("Compétition n° " + id + " - "+ nom + "crée ");
        }

        ~Competition()
        {
            Console.WriteLine("Compétition détruite");
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

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public DateTime Maj
        {
            get
            {
                return maj;
            }

            set
            {
                maj = value;
            }
        }

        public int NbSaisonsDisponible
        {
            get
            {
                return nbSaisonsDisponible;
            }

            set
            {
                nbSaisonsDisponible = value;
            }
        }
    }
}
