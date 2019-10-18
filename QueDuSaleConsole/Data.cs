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
         * <summary> Constructeur de la classe Data </summary>
         **/
        public Data()
        {
            json = new Json();
            competitions = json.CreateCompetitions(this);
        }

        /**
         * <summary> Destructeur de la classe Data </summary>
         **/
        ~Data()
        {

        }
        #endregion

        #region Accesseur(Getter->get)/Mutateur(Setter->set)
        /**
         *  <summary> Accesseur/Mutateur de la variable competitions </summary>
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
         * <summary> Accesseur/Mutateur de la variable json </summary>
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
