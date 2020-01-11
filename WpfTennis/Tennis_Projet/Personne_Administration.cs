using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Personne_Administration : Personne
    {
        double salaire;
        string coordonnees_banque;
        DateTime date_entree;
        public Personne_Administration(string nom, string prenom, string sexe, string adresse, string ville, DateTime date_naissance,string numero_telephone, DateTime date_entree,double salaire,string banque)
           : base(nom, prenom, sexe, adresse, ville, date_naissance, numero_telephone)
        {
            this.salaire = salaire;
            this.coordonnees_banque = banque;
            this.date_entree = date_entree;
        }
        #region Proprieté
        public string Nom
        {
            get { return this.nom; }

        }
        public string Prenom
        {
            get { return this.prenom; }

        }
        public string Sexe
        {
            get { return this.sexe; }

        }
        public string Adresse
        {
            get { return this.adresse; }
            set
            {
                this.adresse = value;
            }
        }
        public string Ville
        {
            get { return this.ville; }
            set
            {
                this.ville = value;
            }
        }
        public DateTime Date_naissance
        {
            get { return (this.date_naissance.Date); }

        }
        public string Numero_Telephone
        {
            get { return this.numero_telephone; }
            set { this.numero_telephone = value; }
        }
        public DateTime DateEntree
        {
            get { return this.date_entree; }
        }
        public double Salaire
        {
            get { return this.salaire; }
        }
        public string CoordoBancaire
        {
            get { return this.coordonnees_banque; }
        }
        #endregion
    }
}
