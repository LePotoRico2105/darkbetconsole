using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Data
    {
        #region Variables
        private List<Competition> competitions;
        private Json json;
        #endregion

        #region Constructeur/Destructeur
        /**
         * Constructeur de la classe Data
         **/
        public Data()
        {
            json = new Json();
            competitions = json.CreateCompetitions(this);
        }

        /**
         * Destructeur de la classe Data 
         **/
        ~Data()
        {

        }
        #endregion

        #region Acesseur(Getter->get)/Mutateur(Setter->set)
        /**
         *  Acesseur/Mutateur de la variable competitions
         **/
        public List<Competition> Competitions
        {
            get
            {
                return competitions;
            }

            set
            {
                competitions = value;
            }
        }

        /**
         *  Acesseur/Mutateur de la variable json
         **/
        public Json _Json
        {
            get
            {
                return json;
            }

            set
            {
                json = value;
            }
        }
        #endregion
    }
}
