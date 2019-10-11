using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Data
    {
        private List<Competition> competitions;
        private Json json;
        public Data()
        {
            json = new Json();
            competitions = json.CreateCompetitions(this);
        }

        ~Data()
        {

        }

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
    }
}
