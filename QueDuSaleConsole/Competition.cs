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
        private List<Saison> saisons;
        private string nom, code;
        private DateTime maj;

        public Competition()
        {
        }

        public Competition(int pId, Pays pUnPays, List<Saison> pSaisons, int pNbSaisonsDisponible, string pNom, string pCode, DateTime pMaj)
        {
            this.id = pId;
            this.unPays = pUnPays;
            this.nbSaisonsDisponible = pNbSaisonsDisponible;
            this.nom = pNom;
            this.code = pCode;
            this.maj = pMaj;
            this.saisons = pSaisons;
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

        public Saison SaisonActuelle
        {
            get
            {
                return saisons[0];
            }

            set
            {
                saisons[0] = value;
            }
        }

        public List<Saison> Saisons
        {
            get
            {
                return saisons;
            }

            set
            {
                saisons = value;
            }
        }
    }
}
