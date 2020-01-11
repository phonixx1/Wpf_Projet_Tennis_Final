using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ConsoleApp1;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace WpfTennis
{
    /// <summary>
    /// Logique d'interaction pour Chargement.xaml
    /// </summary>
    public partial class Chargement : Window
    {
        string msgAReturn="Chargement Reussi";
        string majLabel="Aucun club chargé";
        bool resultatDialog;


        Club clubAChager = null;
        string nom_du_club;
        string adresse_Club;
        string ville_Club;
        int codePostal_Club;
        List<Membre> liste_membre_club=new List<Membre>();
        List<Personne_Administration> liste_administration = new List<Personne_Administration>();
        List<Entraineur> liste_entraineur = new List<Entraineur>();
       
        
        
       public Chargement()
        {
            InitializeComponent();
        }

        public string MajLabel
        {
            get { return majLabel; }
        }
        public Club ClubCharge
        {
            get { return this.clubAChager; }
        }

        private void btnChargerLesLillas_Click(object sender, RoutedEventArgs e)
        {
            bool charge1 = chargerInfoClub("Les Lillas");
            bool charge2 = chargerListeMembre("Les Lillas");
            bool charge3 = chargerListeAdministration("Les Lillas");
            bool charge4 = chargerListeEntraineur("Les Lillas");
            resultatDialog = charge1 && charge2&&charge3 && charge4;
            if(charge1&&charge2 && charge3 && charge4)
            {
                clubAChager = new Club(this.nom_du_club, this.adresse_Club, this.ville_Club, this.codePostal_Club, this.liste_membre_club, this.liste_administration,this.liste_entraineur);
                MajClubMembre(clubAChager.Liste_Membre, clubAChager);
                MajClubEntraineur(clubAChager.Liste_Entraineur, clubAChager);
                majLabel = clubAChager.Nom;
                labelChargement.Content = msgAReturn;
                this.labelChargement2.Content = "";
            }
            else
            {
                labelChargement.Content = "Echec";
            }

            
        }

        private void btnChargerAceClub_Click(object sender, RoutedEventArgs e)
        {
            bool charge1 = chargerInfoClub("Ace Club");
            bool charge2 = chargerListeMembre("Ace Club");
            bool charge3 = chargerListeAdministration("Ace Club");
            bool charge4 = chargerListeEntraineur("Ace Club");


            resultatDialog = charge1 && charge2 && charge3&&charge4;
            if (charge1 && charge2 && charge3 && charge4)
            {
                clubAChager = new Club(this.nom_du_club, this.adresse_Club, this.ville_Club, this.codePostal_Club, this.liste_membre_club,this.liste_administration,this.liste_entraineur);
                MajClubMembre(clubAChager.Liste_Membre, clubAChager);
                MajClubEntraineur(clubAChager.Liste_Entraineur, clubAChager);
                majLabel = clubAChager.Nom;
                labelChargement.Content = msgAReturn;
                this.labelChargement2.Content = "";
            }
            else
            {
                labelChargement.Content = "Echec";
            }
        }

        private void retourChargement_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = resultatDialog;
        }
        void MajClubEntraineur(List<Entraineur> liste,Club club)
        {
            for (int i = 0; i < liste.Count; i++)
            {
                liste[i].Club_Affilie = club;
            }
        }
        void MajClubMembre(List<Membre> liste,Club club)
        {
            for(int i=0;i<liste.Count;i++)
            {
                liste[i].Club_Affilie = club;
            }
        }
        #region FctDeChargement
        bool chargerInfoClub(string nom_club)
        {
            bool chargementReussi;
            Excel.Application appExcel=null;
            Excel._Workbook workBook=null;
            Excel._Worksheet workSheet=null;

            try
            {

                chargementReussi = true;
                appExcel = new Excel.Application();
                appExcel.Visible = false;

                //Get a new workbook.

                workBook = (Excel._Workbook)(appExcel.Workbooks.Open(Environment.CurrentDirectory.ToString() + "/" + nom_club + "/InfoClub.xlsx"));
                workSheet = (Excel._Worksheet)workBook.ActiveSheet;
                this.nom_du_club = Convert.ToString(workSheet.Cells[1, 1].Value);

                if (nom_club != Convert.ToString(workSheet.Cells[1, 1].Value))
                {
                    msgAReturn = "Les données ont été ouverte mais ne correspondent pas au club";
                    chargementReussi = false;
                }

                this.adresse_Club = Convert.ToString(workSheet.Cells[1, 2].Value);
                this.ville_Club = Convert.ToString(workSheet.Cells[1, 3].Value);

                try
                {
                    this.codePostal_Club = Convert.ToInt32(Convert.ToString(workSheet.Cells[1, 4].Value));
                }
                catch
                {
                    msgAReturn = "Erreur de lecture d'une info du club";
                    chargementReussi = false;
                }
                // workBook.Close(true,Missing.value,Missing.value); pour save
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                chargementReussi = false;

                msgAReturn = "Echec chargement Info" + nom_club;
                //labelChargement.Content = "Echec chargement Info Club";
                //this.resultatDialog = false;
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
            //workSheet = null;

            workBook.Close(true);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
            //workBook = null;

            appExcel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
            //appExcel = null;

            return chargementReussi;

        }
        bool chargerListeAdministration(string nom_club)
        {

            Excel.Application appExcel = null;
            Excel._Workbook workBook = null;
            Excel._Worksheet workSheet = null;
            
            bool chargementReussi=false;
            int nbAdministration=0;

            Personne_Administration personneAdd;

            string nom_membre;
            string prenom_membre;
            string sexe_membre;
            string adresse_membre;
            string ville_membre;
            DateTime naissance_membre;
            string numero_telephone;

            DateTime date_Entree;
            double salaire;
            string coordoneesBancaire;
           
            
            try
            {
                appExcel = new Excel.Application();
                appExcel.Visible = false;

                //Get a new workbook.
                workBook = (Excel._Workbook)(appExcel.Workbooks.Open(Environment.CurrentDirectory.ToString() + "/" + nom_club + "/FichierAdministration" + nom_club + ".xlsx"));
                workSheet = (Excel._Worksheet)workBook.ActiveSheet;
                

                nbAdministration = Convert.ToInt32(Convert.ToString(workSheet.Cells[1, 1].Value));
                
                if (nbAdministration != 0)
                {
                    
                    for (int i = 0; i < nbAdministration; i++)
                    {
                        nom_membre = Convert.ToString(workSheet.Cells[i + 2, 1].Value);
                        prenom_membre = Convert.ToString(workSheet.Cells[i + 2, 2].Value);
                        sexe_membre = Convert.ToString(workSheet.Cells[i + 2, 3].Value);
                        adresse_membre = Convert.ToString(workSheet.Cells[i + 2, 4].Value);
                        ville_membre = Convert.ToString(workSheet.Cells[i + 2, 5].Value);
                        naissance_membre = Convert.ToDateTime(workSheet.Cells[i + 2, 6].Value);
                        numero_telephone = "0" + Convert.ToString(workSheet.Cells[i + 2, 7].Value);
                        date_Entree = Convert.ToDateTime(workSheet.Cells[i + 2, 8].Value);
                        salaire = Convert.ToDouble(workSheet.Cells[i + 2, 9].Value);
                        coordoneesBancaire = Convert.ToString((workSheet.Cells[i + 2, 10].Value));


                        personneAdd = new Personne_Administration(nom_membre, prenom_membre, sexe_membre, adresse_membre, ville_membre, naissance_membre, numero_telephone, date_Entree, salaire, coordoneesBancaire);

                        this.liste_administration.Add(personneAdd);

                    }
                }
               

                
                chargementReussi = true;

            }
            catch 
            {
                chargementReussi = false;
                msgAReturn = "Echec chargement Administration " + nom_club;
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
            
            workBook.Close(true);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
            
            appExcel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);

            return chargementReussi;

        }
        bool chargerListeEntraineur(string nom_club)
        {

            Excel.Application appExcel = null;
            Excel._Workbook workBook = null;
            Excel._Worksheet workSheet = null;
            
            bool chargementReussi;
            int nbEntraineur;

            Entraineur entraineurAdd;
            
            string nom_membre;
            string prenom_membre;
            string sexe_membre;
            string adresse_membre;
            string ville_membre;
            DateTime naissance_membre;
            string numero_telephone;
            int argent_membre;
            double compet_membre;
            bool cotis_membre;

            bool status_salarie;
            DateTime dateEntree;
            double salaire;
            string coordonneesBancaire;

            try
            {

                
                chargementReussi = true;
                appExcel = new Excel.Application();
                appExcel.Visible = false;

                //Get a new workbook.
                workBook = (Excel._Workbook)(appExcel.Workbooks.Open(Environment.CurrentDirectory.ToString() + "/" + nom_club + "/FichierEntraineur" + nom_club + ".xlsx"));
                workSheet = (Excel._Worksheet)workBook.ActiveSheet;
                
                nbEntraineur = Convert.ToInt32(Convert.ToString(workSheet.Cells[1, 1].Value));
                
                if (nbEntraineur != 0)
                {
                    for (int i = 0; i < nbEntraineur; i++)
                    {
                        
                        nom_membre = Convert.ToString(workSheet.Cells[i + 2, 1].Value);
                        prenom_membre = Convert.ToString(workSheet.Cells[i + 2, 2].Value);
                        sexe_membre = Convert.ToString(workSheet.Cells[i + 2, 3].Value);
                        adresse_membre = Convert.ToString(workSheet.Cells[i + 2, 4].Value);
                        ville_membre = Convert.ToString(workSheet.Cells[i + 2, 5].Value);
                        naissance_membre = Convert.ToDateTime(workSheet.Cells[i + 2, 6].Value);
                        numero_telephone = "0" + Convert.ToString(workSheet.Cells[i + 2, 7].Value);
                        argent_membre = Convert.ToInt32(workSheet.Cells[i + 2, 9].Value);
                        compet_membre = Convert.ToDouble(workSheet.Cells[i + 2, 10].Value);
                        if (Convert.ToString((workSheet.Cells[i + 2, 11].Value)) == "O")
                        {
                            cotis_membre = true;
                        }
                        else
                        {
                            cotis_membre = false;
                        }
                        if (Convert.ToString((workSheet.Cells[i + 2, 12].Value)) == "O")
                        {
                            status_salarie = true;
                        }
                        else
                        {
                            status_salarie = false;
                        }
                        dateEntree = Convert.ToDateTime(workSheet.Cells[i + 2, 13].Value);
                        salaire = Convert.ToDouble(workSheet.Cells[i + 2, 14].Value);
                        coordonneesBancaire=Convert.ToString(workSheet.Cells[i + 2, 15].Value);
                        
                        entraineurAdd = new Entraineur(nom_membre, prenom_membre, sexe_membre, adresse_membre, ville_membre, naissance_membre, numero_telephone, this.clubAChager, argent_membre, compet_membre, cotis_membre,status_salarie,salaire,dateEntree,coordonneesBancaire);
                        
                        this.liste_entraineur.Add(entraineurAdd);

                    }
                }

            }
            catch
            {
                
                chargementReussi = false;
                msgAReturn = "Echec chargement Entraineur " + nom_club;
                
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
            //workSheet = null;

            workBook.Close(true);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
            //workBook = null;

            appExcel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);

            return chargementReussi;

        }
        bool chargerListeMembre(string nom_club)
        {

            Excel.Application appExcel=null;
            Excel._Workbook workBook=null;
            Excel._Worksheet workSheet=null;
            bool chargementReussi;
            int nbMembres;
            Membre membreAdd;
            string nom_membre;
            string prenom_membre;
            string sexe_membre;
            string adresse_membre;
            string ville_membre;
            DateTime naissance_membre;
            string numero_telephone;
            int argent_membre;
            double compet_membre;
            bool cotis_membre;
            try
            {


                chargementReussi = true;
                appExcel = new Excel.Application();
                appExcel.Visible = false;

                //Get a new workbook.
                workBook = (Excel._Workbook)(appExcel.Workbooks.Open(Environment.CurrentDirectory.ToString() + "/" + nom_club + "/FichierMembres" + nom_club + ".xlsx"));
                workSheet = (Excel._Worksheet)workBook.ActiveSheet;


                try
                {
                    nbMembres = Convert.ToInt32(Convert.ToString(workSheet.Cells[1, 1].Value));
                }
                catch
                {
                    msgAReturn = "Erreur de lecture d'une info du club";
                    nbMembres = 0;
                    chargementReussi = false;
                }
                if (nbMembres != 0)
                {
                    for (int i = 0; i < nbMembres; i++)
                    {
                        nom_membre = Convert.ToString(workSheet.Cells[i + 2, 1].Value);
                        prenom_membre = Convert.ToString(workSheet.Cells[i + 2, 2].Value);
                        sexe_membre = Convert.ToString(workSheet.Cells[i + 2, 3].Value);
                        adresse_membre = Convert.ToString(workSheet.Cells[i + 2, 4].Value);
                        ville_membre = Convert.ToString(workSheet.Cells[i + 2, 5].Value);
                        naissance_membre = Convert.ToDateTime(workSheet.Cells[i + 2, 6].Value);
                        numero_telephone = "0" + Convert.ToString(workSheet.Cells[i + 2, 7].Value);
                        argent_membre = Convert.ToInt32(workSheet.Cells[i + 2, 9].Value);
                        compet_membre = Convert.ToDouble(workSheet.Cells[i + 2, 10].Value);
                        if (Convert.ToString((workSheet.Cells[i + 2, 11].Value)) == "O")
                        {
                            cotis_membre = true;
                        }
                        else
                        {
                            cotis_membre = false;
                        }

                        membreAdd = new Membre(nom_membre, prenom_membre, sexe_membre, adresse_membre, ville_membre, naissance_membre, numero_telephone, this.clubAChager, argent_membre, compet_membre, cotis_membre);

                        this.liste_membre_club.Add(membreAdd);

                    }
                }

            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                chargementReussi = false;
                msgAReturn = "Echec chargement Membre " + nom_club;
                //labelChargement.Content = "Echec chargement Info Club";
                //this.resultatDialog = false;
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
            //workSheet = null;

            workBook.Close(true);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
            //workBook = null;

            appExcel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);

            return chargementReussi;

        }
        #endregion
    }
}
