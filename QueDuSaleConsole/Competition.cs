using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Competition
    {
        #region Variables
        private int id, nbSaisonsDisponible;
        private Pays unPays;
        private Saison saisonActuelle;
        private List<Saison> saisons;
        private string nom, code;
        private DateTime maj;
        #endregion

        #region Constructeur/Destructeur
        /**
         * Constructeur de la classe Compétition
         **/
        public Competition()
        {

        }

        /**
         * Constructeur de la classe Compétition avec ses paramètres
         **/
        public Competition(int pId, Pays pUnPays, Saison pSaisonActuelle, List<Saison> pSaisons, int pNbSaisonsDisponible, string pNom, string pCode, DateTime pMaj)
        {
            this.id = pId;
            this.unPays = pUnPays;
            this.saisonActuelle = pSaisonActuelle;
            this.nbSaisonsDisponible = pNbSaisonsDisponible;
            this.nom = pNom;
            this.code = pCode;
            this.maj = pMaj;
            this.saisons = pSaisons;
        }

        /**
         * Destructeur de la classe Compétition
         **/
        ~Competition()
        {

        }
        #endregion

        #region Acesseur(Getter->get)/Mutateur(Setter->set)
        /**
         * Acesseur/Mutateur de la variable id
         **/
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

        /**
         * Acesseur/Mutateur de la variable nom
         **/
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

        /**
         * Acesseur/Mutateur de la variable code
         **/
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

        /**
         * Acesseur/Mutateur de la variable maj
         **/
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

        /**
         * Acesseur/Mutateur de la variable nbSaisonsDisponible
         **/
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

        /**
         * Acesseur/Mutateur de la variable unPays
         **/
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

        /**
         * Acesseur/Mutateur de la variable saisonActuelle
         **/
        public Saison SaisonActuelle
        {
            get
            {
                return saisonActuelle;
            }

            set
            {
                saisonActuelle = value;
            }
        }

        /**
         * Acesseur/Mutateur de la variable saisons
         **/
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
        #endregion
    }
}