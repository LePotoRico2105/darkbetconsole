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
         * <summary> Constructeur de la classe Pays </summary>
         **/
        public Pays()
        {
        }

        /**
         * <summary> Constructeur de la classe Pays avec ses paramètres </summary>
         **/
        public Pays(int pId, string pNom)
        {
            this.id = pId;
            this.nom = pNom;
        }

        /**
         * <summary> Destructeur de la classe Pays </summary>
         **/
        ~Pays()
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
         * <summary> Accesseur/Mutateur de la variable nom </summary>
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