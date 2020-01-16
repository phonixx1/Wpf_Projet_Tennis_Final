using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Class entraineur qui herite de memebre
    /// On remarqe juste que le statut salarie demande des parametres en plus qui sont nuls si lentraineur nest pas salarie
    /// Lors de la creation d'un entraineur vous aurez juste a ne pas remplir les champs correspondants a salaire banque et date d'entree
    /// </summary>
    public class Entraineur :Membre
    {
        
        bool statut_salarie; // si true salarie si false independant
        double salaire = double.NaN;
        DateTime dateEntree;
        string coordonneesBancaire=string.Empty;
        List<Cours> liste_cours = new List<Cours>();

        public Entraineur(string nom, string prenom, string sexe, string adresse, string ville, DateTime date_naissance, string numero_telephone, Club nom_du_club, int argent_depart, double competition,bool cotis, bool statut, double salaire, DateTime dateEntree,string banque)
            : base(nom, prenom, sexe, adresse, ville, date_naissance,numero_telephone, nom_du_club, argent_depart, competition,cotis)
        {
            this.statut_salarie = statut;
            if (this.statut_salarie == true)
            {
                this.salaire = salaire;
                this.coordonneesBancaire = banque;
                this.dateEntree = dateEntree;

            }
            
        }
        #region Proprietes
       public bool Statut_Salarie
       {
            get { return this.statut_salarie; }
       }
        public double Salaire
        {
            get { return this.salaire; }
        }
        public DateTime Date_Entree
        {
            get { return this.dateEntree; }
        }
        public string CoordoneesBancaire
        {
            get { return this.coordonneesBancaire; }
        }
        

        #endregion
    }
}
