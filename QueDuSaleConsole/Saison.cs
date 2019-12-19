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
        private int id, idCompetition;
        private string gagnant;
        private DateTime debut, fin;
        private List<Equipe> equipes;
        private List<List<List<int>>> butsSaisons;
        #endregion

        #region Constructeur/Destructeur
        /**
         * <summary> Constructeur de la classe Saison </summary>
         **/
        public Saison()
        {
            this.id = 0;
            this.gagnant = "";
            this.debut = new DateTime();
            this.fin = new DateTime();
            this.equipes = new List<Equipe>();
            this.idCompetition = 0;
            this.butsSaisons = new List<List<List<int>>>
            {
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
            };
        }

        /**
         * <summary> Constructeur de la classe Saison avec ses paramètres </summary>
         **/
        public Saison(int pId, int pIdCompetition, string pGagnant, DateTime pDebut, DateTime pFin)
        {
            this.id = pId;
            if (this.gagnant == null) this.gagnant = null;
                else this.gagnant = pGagnant;
            this.debut = pDebut;
            this.fin = pFin;
            this.equipes = new List<Equipe>();
            this.idCompetition = pIdCompetition;
            this.butsSaisons = new List<List<List<int>>>
            {
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
                new List<List<int>>
                {
                    new List<int>{ 0, 0, 0, 0},
                    new List<int>{ 0, 0, 0, 0},
                },
            };
        }

        /**
         * <summary> Destructeur de la classe Saison </summary>
         **/
        ~Saison()
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
         * <summary> Accesseur/Mutateur de la variable idCompetition </summary>
         **/
        public int IdCompetition
        {
            get
            {
                return idCompetition;
            }

            set
            {
                idCompetition = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable gagnant </summary>
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
         * <summary> Accesseur/Mutateur de la variable debut </summary>
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
         * <summary> Accesseur/Mutateur de la variable fin </summary>
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
         * <summmary> Accesseur/Mutateur de la variable Equipes </summmary>
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

        /**
        * <summary> Accesseur/Mutateur de la variable butsSaisons</summary>
        **/
        public List<List<List<int>>> ButsSaisons
        {
            get
            {
                return butsSaisons;
            }

            set
            {
                butsSaisons = value;
            }
        }
        #endregion
    }
}
