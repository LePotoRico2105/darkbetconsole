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
        private Saison saisonActuelle;
        private string nom, nomCourt, initiale, stade, logo;
        private DateTime maj;
        #endregion

        #region Constructeur/Destructeur
        /**
         * Constructeur de la classe Equipe
         **/
        public Equipe()
        {

        }

        /**
         * Constructeur de la classe Compétition avec ses paramètres
         **/
        public Equipe(int pId, Pays pPUnPays, Saison pSaisonActuelle, string pNom, string pNomCourt, string pInitiale, string pStade, string pLogo, DateTime pMaj)
        {
            this.id = pId;
            this.unPays = pPUnPays;
            this.saisonActuelle = pSaisonActuelle;
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
         * Destructeur de la classe Equipe
         **/
        ~Equipe()
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
                ;
            }

            set
            {
                nom = value;
            }
        }

        /**
         * Acesseur/Mutateur de la variable nomCourt
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
         * Acesseur/Mutateur de la variable initiale
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
         * Acesseur/Mutateur de la variable logo
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
         * Acesseur/Mutateur de la variable stade
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
        #endregion
    }
}