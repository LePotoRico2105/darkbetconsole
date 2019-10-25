using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Equipe
    {
        #region Variables
        private int id;
        private Pays unPays;
        private List<Saison> saisons;
        private List<Match> matchs;
        private string nom, nomCourt, initiale, stade, logo;
        private DateTime maj;
        #endregion

        #region Constructeur/Destructeur
        /**
         * <summary> Constructeur de la classe Equipe </summary>
         **/
        public Equipe()
        {
            this.id = 0;
            this.unPays = new Pays();
            this.saisons = new List<Saison>();
            this.matchs = new List<Match>();
            this.nom = "";
            this.nomCourt = "";
            this.initiale = "";
            this.stade = "";
            this.logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRd6OLePQd6vAlw-npkXL-9jaQRXxj8ADDrusZjon19DyEsPgLU-g";
            this.maj = new DateTime();
        }

        /**
         * <summary> Constructeur de la classe Compétition avec ses paramètres </summary>
         **/
        public Equipe(int pId, Pays pPUnPays, string pNom, string pNomCourt, string pInitiale, string pStade, string pLogo, DateTime pMaj)
        {
            this.id = pId;
            this.unPays = pPUnPays;
            this.saisons = new List<Saison>();
            this.matchs = new List<Match>();
            this.nom = pNom;
            this.nomCourt = pNomCourt;
            this.initiale = pInitiale;
            if (this.stade == null) this.stade = "";
                else this.stade = pStade;
            if (this.logo == null) this.logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRd6OLePQd6vAlw-npkXL-9jaQRXxj8ADDrusZjon19DyEsPgLU-g";
                else this.logo = pLogo;
            this.maj = pMaj;
        }

        /**
         * <summary> Destructeur de la classe Equipe </summary>
         **/
        ~Equipe()
        {

        }
        #endregion

        #region Accesseur(Getter->get)/Mutateur(Setter->set)
        /**
         * <summary> Accesseur/Mutateur de la variable id </summary>
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
         * <summary> Accesseur/Mutateur de la variable nom </summary>
         **/
        public string Nom
        {
            get
            {
                return nom;
                ;
            }

            set
            {
                nom = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable nomCourt </summary>
         **/
        public string NomCourt
        {
            get
            {
                return nomCourt;
            }

            set
            {
                nomCourt = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable initiale </summary>
         **/
        public string Initiale
        {
            get
            {
                return initiale;
            }

            set
            {
                initiale = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable logo </summary>
         **/
        public string Logo
        {
            get
            {
                return logo;
            }

            set
            {
                logo = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable stade </summary>
         **/
        public string Stade
        {
            get
            {
                return stade;
            }

            set
            {
                stade = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable maj </summary>
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
         * <summary> Accesseur/Mutateur de la variable saisons </summary>
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

        /**
        * <summary> Accesseur/Mutateur de la variable matchs</summary>
        **/
        public List<Match> Matchs
        {
            get
            {
                return matchs;
            }

            set
            {
                matchs = value;
            }
        }
        #endregion
    }
}