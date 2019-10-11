using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueDuSaleConsole
{
    public class Pays
    {
        #region Variables
        private int id;
        private string nom;
        #endregion
    
        #region
        /**
         * Constructeur de la classe Pays
         **/
        public Pays()
        {

        }

        /**
         * Constructeur de la classe Pays avec ses paramètres
         **/
        public Pays(int pId, string pNom)
        {
            this.id = pId;
            this.nom = pNom;
        }

        /**
         * Destructeur de la classe Pays
         **/
        ~Pays()
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
         * Acesseur/Mutateur de la variable nom
         **/
        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }
        #endregion
    }
}