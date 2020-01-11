using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ConsoleApp1
{
    public class Club: IComparable<Club>,IToString
    {
        string nom_du_club;
        string adresse;
        string ville;
        int code_postal;
        List<Personne_Administration> groupe_administratif;
        List<Entraineur> liste_entraineur;
        List<Membre> liste_membre;
        //List<Competition> liste_compet=new List<Competition>();

        #region Constructeurs
        public Club(string nom_du_club, string adresse, string ville, int code_postal)
        {
            this.nom_du_club = nom_du_club;
            this.adresse = adresse;
            this.ville = ville;
            this.code_postal = code_postal;
        }
        public Club(string nom_du_club, string adresse, string ville, int code_postal,List<Membre> listem)
        {
            this.nom_du_club = nom_du_club;
            this.adresse = adresse;
            this.ville = ville;
            this.code_postal = code_postal;
            this.liste_membre = listem;
        }
        public Club(string nom_du_club, string adresse, string ville, int code_postal, List<Membre> listem,List<Personne_Administration> listadmini)
        {
            this.nom_du_club = nom_du_club;
            this.adresse = adresse;
            this.ville = ville;
            this.code_postal = code_postal;
            this.liste_membre = listem;
            this.groupe_administratif = listadmini;
        }
        public Club(string nom_du_club, string adresse, string ville, int code_postal, List<Membre> listem, List<Personne_Administration> listadmini,List<Entraineur> listentrain)
        {
            this.nom_du_club = nom_du_club;
            this.adresse = adresse;
            this.ville = ville;
            this.code_postal = code_postal;
            this.liste_membre = listem;
            this.groupe_administratif = listadmini;
            this.liste_entraineur = listentrain;
        }
        #endregion

        #region Propriétés
        public List<Membre> Liste_Membre
        {
            get { return this.liste_membre; }
            set { this.liste_membre = value; }
        }
        public List<Personne_Administration> Groupe_Administratif
        {
            get { return this.groupe_administratif; }
            set { this.groupe_administratif = value; }
        }
        public List<Entraineur>Liste_Entraineur
        {
            get { return this.liste_entraineur; }
            set { this.liste_entraineur = value; }
        }
        public string Nom
        {
            get { return this.nom_du_club; }
        }
        public string Ville
        {
            get { return this.ville; }
        }
        #endregion 
        public override string ToString()
        {
            return this.nom_du_club;
        }
       public void AjouterMembre(string nom, string prenom, string sexe, string adresse, string ville, DateTime date_naissance,string tel, int argent_depart, double competition)
        {
            Membre ajout = new Membre(nom, prenom, sexe, adresse, ville, date_naissance,tel, this, argent_depart, competition);
            liste_membre.Add(ajout);
        }

        public int CompareTo(Club other)
        {
            return this.nom_du_club.CompareTo(other.nom_du_club);
        }

        
    }
}
