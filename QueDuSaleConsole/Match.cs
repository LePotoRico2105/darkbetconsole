using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    class Match
    {
        #region Variables
        private Competition uneCompetition;
        private int id, journee;
        private Saison laSaison;
        private DateTime dateEtHeure, maj;
        private string gagnant;
        private List<int> scoreMT;
        private List<int> scoreFT;
        private List<int> scoreProlongation;
        private List<int> scorePenalty;
        private List<Equipe> equipes;
        #endregion

        #region Constructeur/Destructeur
        /**
         * <summary> Constructeur de la classe Match </summary>
         **/
        public Match()
        {

        }

        /**
         * <summary> Constructeur de la classe Match avec ses paramètres </summary>
         **/
        public Match(Competition pUneCompetition, int pId, int pJournee, int pScoreMTEquipeDomicile, int pScoreMTEquipeExterieure, 
            int pScoreFTEquipeDomicile, int pScoreFTEquipeExterieure, int pScoreProlongationEquipeDomicile, int pScoreProlongationEquipeExterieure,
            int pScorePenaltyEquipeDomicile, int pScorePenaltyEquipeExterieure, Saison pLaSaison, DateTime pDateEtHeure, DateTime pMaj, string pGagnant,
            Equipe pEquipeDomicile, Equipe pEquipeExterieure)
        {
            this.uneCompetition = pUneCompetition;
            this.id = pId;
            this.journee = pJournee;
            this.laSaison = pLaSaison;
            this.dateEtHeure = pDateEtHeure;
            this.maj = pMaj;
            this.gagnant = pGagnant;
            // Liste des scores à la fin de la 1ère mi-temps
            scoreMT = new List<int>();
            scoreMT.Add(pScoreMTEquipeDomicile);
            scoreMT.Add(pScoreMTEquipeExterieure);
            // Liste des scores à la fin du temps réglementaire
            scoreFT = new List<int>();
            scoreFT.Add(pScoreFTEquipeDomicile);
            scoreFT.Add(pScoreFTEquipeExterieure);
            // Liste des scores à la fin des prolongations
            scoreProlongation = new List<int>();
            scoreProlongation.Add(pScoreProlongationEquipeDomicile);
            scoreProlongation.Add(pScoreProlongationEquipeExterieure);
            // Liste des scores à la fin des penaltys
            scorePenalty = new List<int>();
            scorePenalty.Add(pScoreProlongationEquipeDomicile);
            scorePenalty.Add(pScoreProlongationEquipeExterieure);
            // Liste des scores à la fin des penaltys
            equipes = new List<Equipe>();
            equipes.Add(pEquipeDomicile);
            equipes.Add(pEquipeExterieure);
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
        public Competition UneCompetition
        {
            get
            {
                return UneCompetition;
            }

            set
            {
                UneCompetition = value;
            }
        }

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
         * <summary> Accesseur/Mutateur de la variable laSaison </summary>
         **/
        public Saison LaSaison
        {
            get
            {
                return laSaison;
            }

            set
            {
                laSaison = value;
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
                ;
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

        /**
         * <summmary> Accesseur/Mutateur de la liste equipes </summmary>
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
