using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// class abstract qui est mere de tout type d'evenement (compet stage)
    /// 
    /// </summary>
    public abstract class Evenement: IComparable<Evenement>
    {
        protected string nom_de_evenement; // tous les evenements on un titre ou nom ( exp "stage_ete_2020" "tournoi_amical_du_dimanche")
        protected DateTime date_debut_evenement;
        protected DateTime date_fin_evenement;// on le calcul dans le constructeur
        protected TimeSpan duree_evenement;
        protected int prix; // on considere on reste en euros pas de centime meme si ca aurat pu etre le cas mais bon...

        public Evenement(string nom, int prix, DateTime debut, TimeSpan duree)
        {
            this.nom_de_evenement = nom;
            this.prix = prix;
            this.date_debut_evenement = debut;
            this.duree_evenement = duree;
            this.date_fin_evenement = this.date_debut_evenement + this.duree_evenement;
        }

        public DateTime Date_debut_evenement
        {
            get { return date_debut_evenement; }
        }
        public TimeSpan Duree_evenement
        {
            get { return duree_evenement; }
        }
        public DateTime Date_fin_evenement
        {
            get { return date_fin_evenement; }
        }

        public int CompareTo(Evenement other) 
        {
            return Convert.ToString(this.GetType()).CompareTo(Convert.ToString(other.GetType()));
        }
    }
}
