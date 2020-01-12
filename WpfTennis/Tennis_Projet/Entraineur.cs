using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Entraineur :Membre
    {
        //List<Cours> liste_cours;
        bool statut_salarie; // si true salarie si false independant
        double salaire = double.NaN;
        DateTime dateEntree;
        string coordonneesBancaire;
        /*public Entraineur(string nom, string prenom, string sexe, string adresse, string ville, DateTime date_naissance,string numero_telephone, Club nom_du_club, int argent_depart, double competition,bool statut,double salaire,DateTime dateEntree,string banque,  List<Cours> liste_cours)
            : base(nom, prenom, sexe, adresse, ville, date_naissance, numero_telephone, nom_du_club, argent_depart, competition)
        {
            this.liste_cours = liste_cours;
            this.statut_salarie = statut;
            if(this.statut_salarie==true)
            {
                this.salaire = salaire;
                this.dateEntree = dateEntree;
                this.coordonneesBancaire = banque;
            }

        }*/
        public Entraineur(string nom, string prenom, string sexe, string adresse, string ville, DateTime date_naissance, string numero_telephone, Club nom_du_club, int argent_depart, double competition,bool cotis, bool statut, double salaire, DateTime dateEntree,string banque)
            : base(nom, prenom, sexe, adresse, ville, date_naissance,numero_telephone, nom_du_club, argent_depart, competition,cotis)
        {
            this.statut_salarie = statut;
            if (this.statut_salarie == true)
            {
                this.salaire = salaire;
                this.dateEntree = dateEntree;
                this.coordonneesBancaire = banque;
                
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
