using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Pronostic
    {
        #region Variables
        private List<string> nomEquipes;
        private int idCompetition;
        private string prono;
        private DateTime dateHeure;
        private double fiabilite;
        private List<int> score;
        #endregion

        #region Constructeur/Destructeur
        /**
         * <summary> Constructeur de la classe Match </summary>
         **/
        public Pronostic()
        {
            this.nomEquipes = new List<string>();
            this.idCompetition = 0;
            this.prono = "";
            this.dateHeure = new DateTime();
            this.fiabilite = 0.0;
            this.score = new List<int>();
        }

        /**
         * <summary> Constructeur de la classe Match avec ses paramètres </summary>
         **/
        public Pronostic(List<string> pNomEquipes, int pIdCompetition, string pProno, DateTime pDateHeure, double pFiabilite, List<int> pScore)
        {
            this.nomEquipes = pNomEquipes;
            this.idCompetition = pIdCompetition;
            this.prono = pProno;
            this.dateHeure = pDateHeure;
            this.fiabilite = pFiabilite;
            this.score = pScore;
        }

        /**
         * <summary> Destructeur de la classe Match </summary>
         **/
        ~Pronostic()
        {

        }
        #endregion

        #region Accesseur(Getter->get)/Mutateur(Setter->set)
        /**
         * <summary> Accesseur/Mutateur de la variable nomEquipes </summary>
         **/
        public List<string> NomEquipes
        {
            get
            {
                return nomEquipes;
            }

            set
            {
                nomEquipes = value;
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
         * <summary> Accesseur/Mutateur de la variable prono </summary>
         **/
        public string Prono
        {
            get
            {
                return prono;
            }

            set
            {
                prono = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable dateHeure </summary>
         **/
        public DateTime DateHeure
        {
            get
            {
                return dateHeure;
            }

            set
            {
                dateHeure = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable fiabilite </summary>
         **/
        public double Fiabilite
        {
            get
            {
                return fiabilite;
            }

            set
            {
               fiabilite = value;
            }
        }
        /**
         * <summary> Accesseur/Mutateur de la variable nomEquipes </summary>
         **/
        public List<int> Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }
        #endregion
    }
}
