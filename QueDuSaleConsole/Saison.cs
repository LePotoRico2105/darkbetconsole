using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Saison
    {
        #region Variables
        private int id;
        private string gagnant;
        private DateTime debut, fin;
        private List<Equipe> equipes;
        #endregion

        #region
        /**
         * Constructeur de la classe Saison
         **/
        public Saison()
        {

        }

        /**
         * Constructeur de la classe Saison avec ses paramètres
         **/
        public Saison(int pId, string pGagnant, DateTime pDebut, DateTime pFin)
        {
            this.id = pId;
            if (this.gagnant == null) this.gagnant = null;
                else this.gagnant = pGagnant;
            this.debut = pDebut;
            this.fin = pFin;
            this.equipes = new List<Equipe>();
        }

        /**
         * Destructeur de la classe Saison
         **/
        ~Saison()
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
         * Acesseur/Mutateur de la variable gagnant
         **/
        public string Gagnant
        {
            get
            {
                return gagnant;
;
            }

            set
            {
                gagnant = value;
            }
        }

        /**
         * Acesseur/Mutateur de la variable debut
         **/
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

        /**
         * Acesseur/Mutateur de la variable fin
         **/
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

        /**
         * Acesseur/Mutateur de la variable Equipe
         **/
        public List<Equipe> Equipes
        {
            get
            {
                return equipes;
            }

            set
            {
                equipes = value;
            }
        }
        #endregion
    }
}
