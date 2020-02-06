using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Match
    {
        #region Variables
        private int id, idCompetition, idSaison, journee;
        private List<string> nomEquipes;
        private List<int> idEquipes;
        private DateTime dateEtHeure, maj;
        private string gagnant;
        private List<int> scoreMT;
        private List<int> scoreFT;
        private List<int> scoreProlongation;
        private List<int> scorePenalty;
        #endregion

        #region Constructeur/Destructeur
        /**
         * <summary> Constructeur de la classe Match </summary>
         **/
        public Match()
        {
            this.id = 0;
            this.idCompetition = 0;
            this.idSaison = 0;
            this.idEquipes = new List<int>();
            this.nomEquipes = new List<string>();
            this.journee = 0;
            this.dateEtHeure = new DateTime();
            this.maj = new DateTime();
            this.gagnant = "";
            // Liste des scores à la fin de la 1ère mi-temps
            scoreMT = new List<int>();
            // Liste des scores à la fin du temps réglementaire
            scoreFT = new List<int>();
            // Liste des scores à la fin des prolongations
            scoreProlongation = new List<int>();
            // Liste des scores à la fin des penaltys
            scorePenalty = new List<int>();
            // Liste des scores à la fin des penaltys
        }

        /**
         * <summary> Constructeur de la classe Match avec ses paramètres </summary>
         **/
        public Match(int pId, int pIdCompetition, int pIdSaison, List<string> pNomEquipes, List<int> pIdEquipes, int pJournee, List<int> pScoreMT, List<int> pScoreFT,List<int> pScoreProlongation, List<int> pScorePenalty, DateTime pDateEtHeure, DateTime pMaj, string pGagnant)
        {
            this.id = pId;
            this.idCompetition = pIdCompetition;
            this.idSaison = pIdSaison;
            this.idEquipes = pIdEquipes;
            this.nomEquipes = pNomEquipes;
            this.journee = pJournee;
            this.dateEtHeure = pDateEtHeure;
            this.maj = pMaj;
            this.gagnant = pGagnant;
            // Liste des scores à la fin de la 1ère mi-temps
            scoreMT = pScoreMT;
            // Liste des scores à la fin du temps réglementaire
            scoreFT = pScoreFT;
            // Liste des scores à la fin des prolongations
            scoreProlongation = pScoreProlongation;
            // Liste des scores à la fin des penaltys
            scorePenalty = pScorePenalty;
            // Liste des scores à la fin des penaltys
        }

        /**
         * <summary> Destructeur de la classe Match </summary>
         **/
        ~Match()
        {

        }
        #endregion

        #region Accesseur(Getter->get)/Mutateur(Setter->set)
        /**
         * <summary> Accesseur/Mutateur de la variable uneCompetition </summary>
         **/

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
         * <summary> Accesseur/Mutateur de la variable idSaison </summary>
         **/
        public int IdSaison
        {
            get
            {
                return idSaison;
            }

            set
            {
                idSaison = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable idEquipes </summary>
         **/
        public List<int> IdEquipes
        {
            get
            {
                return idEquipes;
            }

            set
            {
                idEquipes = value;
            }
        }

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
         * <summary> Accesseur/Mutateur de la variable journee </summary>
         **/
        public int Journee
        {
            get
            {
                return journee;
            }

            set
            {
                journee = value;
            }
        }

        /**
         * <summary> Accesseur/Mutateur de la variable dateEtHeure </summary>
         **/
        public DateTime DateEtHeure
        {
            get
            {
                return dateEtHeure;
            }

            set
            {
                dateEtHeure = value;
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
         * <summary> Accesseur/Mutateur de la variable gagnant </summary>
         **/
        public string Gagnant
        {
            get
            {
                return gagnant;            
            }

            set
            {
                gagnant = value;
            }
        }

        /**
         * <summmary> Accesseur/Mutateur de la liste scoreMT </summmary>
         **/
        public List<int> ScoreMT
        {
            get
            {
                return scoreMT;
            }

            set
            {
                scoreMT = value;
            }
        }

        /**
         * <summmary> Accesseur/Mutateur de la liste scoreFT </summmary>
         **/
        public List<int> ScoreFT
        {
            get
            {
                return scoreFT;
            }

            set
            {
                scoreFT = value;
            }
        }

        /**
         * <summmary> Accesseur/Mutateur de la liste scoreProlongation </summmary>
         **/
        public List<int> ScoreProlongation
        {
            get
            {
                return scoreProlongation;
            }

            set
            {
                scoreProlongation = value;
            }
        }

        /**
         * <summmary> Accesseur/Mutateur de la liste scorePenalty </summmary>
         **/
        public List<int> ScorePenalty
        {
            get
            {
                return scorePenalty;
            }

            set
            {
                scorePenalty = value;
            }
        }
        #endregion
    }
}
