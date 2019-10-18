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
         * <summary> Constructeur de la classe Saison </summary>
         **/
        public Saison()
        {

        }

        /**
         * <summary> Constructeur de la classe Saison avec ses paramètres </summary>
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
         * <summary> Destructeur de la classe Saison </summary>
         **/
        ~Saison()
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
         * <summary> Acesseur/Mutateur de la variable gagnant </summary>
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
         * <summary> Acesseur/Mutateur de la variable debut </summary>
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
         * <summary> Acesseur/Mutateur de la variable fin </summary>
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
         * <summmary> Acesseur/Mutateur de la variable Equipe </summmary>
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
