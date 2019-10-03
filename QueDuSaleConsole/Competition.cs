using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Competition
    {
        private int id, nbSaisonsDisponible;
        private Pays unPays;
        private Saison saisonActuelle;
        private string nom, code;
        private DateTime maj;


        public Competition()
        {
        }

        public Competition(int pId, Pays pUnPays, Saison pSaisonActuelle, int pNbSaisonsDisponible, string pNom, string pCode, DateTime pMaj)
        {
            this.id = pId;
            this.unPays = pUnPays;
            this.saisonActuelle = pSaisonActuelle;
            this.nbSaisonsDisponible = pNbSaisonsDisponible;
            this.nom = pNom;
            this.code = pCode;
            this.maj = pMaj;
        }

        ~Competition()
        {
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

        public Pays UnPays
        {
            get
            {
                return unPays;
            }

            set
            {
                unPays = value;
            }
        }
    }
}
