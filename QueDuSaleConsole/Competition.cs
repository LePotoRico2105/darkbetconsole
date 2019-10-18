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
        private List<Saison> saisons;
        private string nom, code;
        private DateTime maj;
        #endregion

        #region Constructeur/Destructeur
        /**
         * <summary> Constructeur de la classe Compétition </summary>
         **/
        public Competition()
        {

        }

        /**
         * <summary> Constructeur de la classe Compétition avec ses paramètres </summary>
         **/
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

        /**
         * <summary> Destructeur de la classe Compétition </summary>
         **/
        ~Competition()
        {

        }
        #endregion

        #region Acesseur(Getter->get)/Mutateur(Setter->set)
        /**
         * <summary> Acesseur/Mutateur de la variable id </summary>
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
         * <summary> Acesseur/Mutateur de la variable nom </summary>
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
         * <summary> Acesseur/Mutateur de la variable code </summary>
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
         * <summary> Acesseur/Mutateur de la variable maj </summary>
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
         * <summary> Acesseur/Mutateur de la variable nbSaisonsDisponible </summary>
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
         * <summary> Acesseur/Mutateur de la variable unPays </summary>
         * <remarks> Une compétition appartient à un pays </remarks>
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
         * <summary> Acesseur/Mutateur de la variable saisonActuelle </summary>
         * <remarks> Une compétition comporte une saison actuelle </remarks>
         **/
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

        /**
         * <summary> Acesseur/Mutateur de la variable saisons </summary>
         * <remarks> Une compétition comporte plusieurs saisons </remarks>
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