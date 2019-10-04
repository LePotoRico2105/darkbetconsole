using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    class Equipe
    {
        private int id;
        private Pays unPays;
        private Saison saisonActuelle;
        private string nom, nomCourt, initiale, stade, logo;
        private DateTime maj;

        public Equipe()
        {
        }

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

        ~Equipe()
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
                ;
            }

            set
            {
                nom = value;
            }
        }


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
    }
}
