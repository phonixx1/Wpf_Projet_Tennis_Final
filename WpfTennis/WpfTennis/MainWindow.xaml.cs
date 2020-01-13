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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleApp1;
using Microsoft.Win32;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace WpfTennis
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Club club=null;
        public MainWindow()
        {
            
            InitializeComponent();

        }
        public Club MainClub
        {
            get { return this.club; }
        }

        private void btnDeChargement_Click(object sender, RoutedEventArgs e)
        {
            Chargement charge = new Chargement();
            this.Hide();
            charge.Owner = this;
            charge.ShowDialog();
            if ((charge.DialogResult == true))
            {
                nomclub.Content ="Club: "+ charge.MajLabel;
                club = charge.ClubCharge;
            }
            this.ShowDialog();

        }

        private void btnModuleMembres_Click(object sender, RoutedEventArgs e)
        {
            List<Membre> nouvelleListe = null;
            if (this.club!=null)
            {
                ModuleMembres modMembres = new ModuleMembres(this.club.Liste_Membre);
                this.Hide();
                modMembres.Owner = this;
                modMembres.ShowDialog();
                if (modMembres.IsActive == false)
                {
                    nouvelleListe = new List<Membre>(modMembres.OcMembre);
                    club.Liste_Membre = nouvelleListe;
                }
                this.ShowDialog();
            }
            else
            {
               MessageBox.Show( "Charger un club avant toutes actions");
            }
            
        }
        private void btnModuleAdministration_Click(object sender, RoutedEventArgs e)
        {
            List<Personne_Administration> nouvelleListe = null;
            if (this.club != null)
            {
                ModuleAdministration modAdmini = new ModuleAdministration(this.club.Groupe_Administratif);
                this.Hide();
                modAdmini.Owner = this;
                modAdmini.ShowDialog();
                if (modAdmini.IsActive == false)
                {
                    nouvelleListe = new List<Personne_Administration>(modAdmini.OcAdministration);
                    club.Groupe_Administratif = nouvelleListe;
                }
                this.ShowDialog();
            }
            else
            {
                MessageBox.Show("Charger un club avant toutes actions");
            }
        }
        private void btnModuleEntraineur_Click(object sender, RoutedEventArgs e)
        {
            List<Entraineur> nouvelleListe = null;
            if (this.club != null)
            {
                ModuleEntraineurs modEntraineur = new ModuleEntraineurs(this.club.Liste_Entraineur);
                this.Hide();
                modEntraineur.Owner = this;
                modEntraineur.ShowDialog();
                if (modEntraineur.IsActive == false)
                {
                    nouvelleListe = new List<Entraineur>(modEntraineur.OcEntraineur);
                    club.Liste_Entraineur = nouvelleListe;
                }
                this.ShowDialog();
            }
            else
            {
                MessageBox.Show("Charger un club avant toutes actions");
            }
        }
        private void btnModuleStatistiques_Click(object sender, RoutedEventArgs e)
        {
            if (this.club != null)
            {
                ModuleStatistiques modStats = new ModuleStatistiques(this.club);
                this.Hide();
                modStats.Owner = this;
                modStats.ShowDialog();
                this.ShowDialog();
            }
            else
            {
                MessageBox.Show("Charger un club avant toutes actions");
            }


        }
        private void btnModuleCompetitions_Click(object sender, RoutedEventArgs e)
        {
            Competition compet = null;
            if (this.club != null)
            {
                FenAjoutCompetition ajoutCompet = new FenAjoutCompetition(this.club);
                this.Hide();
                ajoutCompet.Owner = this;
                ajoutCompet.ShowDialog();
                if (ajoutCompet.IsActive == false&& ajoutCompet.DialogResult==true)
                {
                    compet = ajoutCompet.ACreer;
                    ModuleCreationCompetition creationResteDeLaCompet = new ModuleCreationCompetition(compet, this.club.Liste_Membre);
                    this.Hide();
                    creationResteDeLaCompet.Owner = this;
                    creationResteDeLaCompet.ShowDialog();
                    this.club.Liste_compet.Add(creationResteDeLaCompet.CompetCree);
                    



                }
                this.ShowDialog();
            }
            else
            {
                MessageBox.Show("Charger un club avant toutes actions");
            }
        }
        private void btnModuleCompetitionsEnCours_Click(object sender, RoutedEventArgs e)
        {
            if (this.club != null)
            {
               if(this.club.Liste_compet.Count==0)
                {
                    MessageBox.Show("Aucune competition en cours");
                }
                else
                {
                    ModuleEnCoursCompetition retrouverCompet = new ModuleEnCoursCompetition(this.club.Liste_compet.Count);
                    retrouverCompet.Owner = this;
                    retrouverCompet.ShowDialog();
                    if(retrouverCompet.DialogResult==true)
                    {
                        if (this.club.Liste_compet[retrouverCompet.NbReturn - 1].Compet_finie == false)
                        {
                            ModuleCreationCompetition creationResteDeLaCompet = new ModuleCreationCompetition(this.club.Liste_compet[retrouverCompet.NbReturn - 1], this.club.Liste_Membre);
                            this.Hide();
                            creationResteDeLaCompet.Owner = this;
                            creationResteDeLaCompet.ShowDialog();
                            this.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("La competition selectionnée a ete fini");
                        }
                        

                    }
                    

                }
            }
            else
            {
                MessageBox.Show("Charger un club avant toutes actions");
            }
        }

        private void btnSauvegarde_Click(object sender, RoutedEventArgs e)
        {
            if(SaveListeMembre()&& SaveListeAdministration()&& SaveListeEntraineur())
            {
                MessageBox.Show("Save reussie");
            }
            else
            {
                MessageBox.Show("Save echec");
            }
        }
        #region Fct Save
        bool SaveListeAdministration()
        {
            Excel.Application appExcel = null;
            Excel._Workbook workBook = null;
            Excel._Worksheet workSheet = null;
            int ancienNb;
            int nbAdministration;
            bool save = false;
            string nom_club;

            if (this.club != null)
            {
                nom_club = club.Nom;
                try
                {
                    
                    appExcel = new Excel.Application();
                    appExcel.Visible = false;

                    //Get a new workbook.
                    workBook = (Excel._Workbook)(appExcel.Workbooks.Open(Environment.CurrentDirectory.ToString() + "/" + nom_club + "/FichierAdministration" + nom_club + ".xlsx"));
                    workSheet = (Excel._Worksheet)workBook.ActiveSheet;

                    ancienNb = Convert.ToInt32(workSheet.Cells[1, 1].Value);
                    nbAdministration = this.club.Groupe_Administratif.Count;
                    workSheet.Cells[1, 1].Value = nbAdministration;
                    

                    for (int i = 0; i < nbAdministration; i++)
                    {
                        workSheet.Cells[i + 2, 1].Value = this.club.Groupe_Administratif[i].Nom;
                        workSheet.Cells[i + 2, 2].Value = this.club.Groupe_Administratif[i].Prenom;
                        workSheet.Cells[i + 2, 3].Value = this.club.Groupe_Administratif[i].Sexe;
                        workSheet.Cells[i + 2, 4].Value = this.club.Groupe_Administratif[i].Adresse;
                        workSheet.Cells[i + 2, 5].Value = this.club.Groupe_Administratif[i].Ville;
                        
                        workSheet.Cells[i + 2, 6].Value = this.club.Groupe_Administratif[i].Date_naissance;
                        workSheet.Cells[i + 2, 7].Value = this.club.Groupe_Administratif[i].Numero_Telephone;
                        workSheet.Cells[i + 2, 8].Value = this.club.Groupe_Administratif[i].DateEntree;
                        workSheet.Cells[i + 2, 9].Value = this.club.Groupe_Administratif[i].Salaire;
                        
                        workSheet.Cells[i + 2, 10].Value = this.club.Groupe_Administratif[i].CoordoBancaire;
                        

                    }
                    if (nbAdministration < ancienNb)
                    {
                        for (int i = nbAdministration; i < ancienNb;i++)
                        {
                            workSheet.Cells[i + 2, 1].Value =null;
                            workSheet.Cells[i + 2, 2].Value = null;
                            workSheet.Cells[i + 2, 3].Value = null;
                            workSheet.Cells[i + 2, 4].Value = null;
                            workSheet.Cells[i + 2, 5].Value = null;

                            workSheet.Cells[i + 2, 6].Value = null;
                            workSheet.Cells[i + 2, 7].Value = null;
                            workSheet.Cells[i + 2, 8].Value = null;
                            workSheet.Cells[i + 2, 9].Value = null;

                            workSheet.Cells[i + 2, 10].Value = null;
                        }
                    }
                    save = true;

                }
                catch (Exception theException)
                {
                    String errorMessage;
                    errorMessage = "Error: ";
                    errorMessage = String.Concat(errorMessage, theException.Message);
                    errorMessage = String.Concat(errorMessage, " Line: ");
                    errorMessage = String.Concat(errorMessage, theException.Source);
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                workBook.Close(true, Missing.Value, Missing.Value);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                //workBook = null;
                appExcel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
            }

            return save;

        }
        bool SaveListeEntraineur()
        {
            Excel.Application appExcel = null;
            Excel._Workbook workBook = null;
            Excel._Worksheet workSheet = null;

            int nbEntraineurs;
            int ancienNb;
            bool save = false;
            string nom_club;
            if (this.club != null)
            {
                nom_club = club.Nom;
                try
                {

                    appExcel = new Excel.Application();
                    appExcel.Visible = false;

                    //Get a new workbook.
                    workBook = (Excel._Workbook)(appExcel.Workbooks.Open(Environment.CurrentDirectory.ToString() + "/" + nom_club + "/FichierEntraineur" + nom_club + ".xlsx"));
                    workSheet = (Excel._Worksheet)workBook.ActiveSheet;

                    ancienNb = Convert.ToInt32(workSheet.Cells[1, 1].Value);

                    nbEntraineurs = this.club.Liste_Entraineur.Count;
                    workSheet.Cells[1, 1].Value = nbEntraineurs;


                    for (int i = 0; i < nbEntraineurs; i++)
                    {
                        this.club.Liste_Entraineur[i].Club_Affilie = this.club;
                        workSheet.Cells[i + 2, 1].Value = this.club.Liste_Entraineur[i].Nom;
                        workSheet.Cells[i + 2, 2].Value = this.club.Liste_Entraineur[i].Prenom;
                        workSheet.Cells[i + 2, 3].Value = this.club.Liste_Entraineur[i].Sexe;
                        workSheet.Cells[i + 2, 4].Value = this.club.Liste_Entraineur[i].Adresse;
                        workSheet.Cells[i + 2, 5].Value = this.club.Liste_Entraineur[i].Ville;
                        workSheet.Cells[i + 2, 6].Value = this.club.Liste_Entraineur[i].Date_naissance;
                        workSheet.Cells[i + 2, 7].Value = this.club.Liste_Entraineur[i].Numero_Telephone;
                        workSheet.Cells[i + 2, 8].Value = this.club.Nom;
                        workSheet.Cells[i + 2, 9].Value = this.club.Liste_Entraineur[i].Argent_membre;
                        if (this.club.Liste_Entraineur[i].Competition.ToString() == "NaN")
                        {
                            workSheet.Cells[i + 2, 10].Value = Convert.ToString(this.club.Liste_Entraineur[i].Competition);
                        }
                        else
                        {
                            workSheet.Cells[i + 2, 10].Value = this.club.Liste_Entraineur[i].Competition;
                        }
                        if (this.club.Liste_Entraineur[i].Cotisation == true)
                        {
                            workSheet.Cells[i + 2, 11].Value = "O";
                        }
                        else
                        {
                            workSheet.Cells[i + 2, 11].Value = "F";
                        }
                        if (this.club.Liste_Entraineur[i].Statut_Salarie == true)
                        {
                            workSheet.Cells[i + 2, 12].Value = "O";
                            workSheet.Cells[i + 2, 13].Value =this.club.Liste_Entraineur[i].Date_Entree;
                            workSheet.Cells[i + 2, 14].Value = this.club.Liste_Entraineur[i].Salaire;
                            workSheet.Cells[i + 2, 15].Value = this.club.Liste_Entraineur[i].CoordoneesBancaire;
                        }
                        else
                        {
                            workSheet.Cells[i + 2, 12].Value = "F";
                            workSheet.Cells[i + 2, 13].Value = null;
                            workSheet.Cells[i + 2, 14].Value = null;
                            workSheet.Cells[i + 2, 15].Value = null;
                        }

                    }
                    if (nbEntraineurs < ancienNb)
                    {
                        for (int i = nbEntraineurs; i < ancienNb; i++)
                        {
                            workSheet.Cells[i + 2, 1].Value = null;
                            workSheet.Cells[i + 2, 2].Value = null;
                            workSheet.Cells[i + 2, 3].Value = null;
                            workSheet.Cells[i + 2, 4].Value = null;
                            workSheet.Cells[i + 2, 5].Value = null;

                            workSheet.Cells[i + 2, 6].Value = null;
                            workSheet.Cells[i + 2, 7].Value = null;
                            workSheet.Cells[i + 2, 8].Value = null;
                            workSheet.Cells[i + 2, 9].Value = null;

                            workSheet.Cells[i + 2, 10].Value = null;
                            workSheet.Cells[i + 2, 11].Value = null;
                            workSheet.Cells[i + 2, 12].Value =null;
                            workSheet.Cells[i + 2, 13].Value = null;
                            workSheet.Cells[i + 2, 14].Value = null;
                            workSheet.Cells[i + 2, 15].Value = null;
                        }
                    }
                    save = true;

                }
                catch (Exception theException)
                {
                    String errorMessage;
                    errorMessage = "Error: ";
                    errorMessage = String.Concat(errorMessage, theException.Message);
                    errorMessage = String.Concat(errorMessage, " Line: ");
                    errorMessage = String.Concat(errorMessage, theException.Source);
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                workBook.Close(true, Missing.Value, Missing.Value);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                //workBook = null;
                appExcel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
            }

            return save;

        }

        bool SaveListeMembre()
        {
            Excel.Application appExcel=null;
            Excel._Workbook workBook=null;
            Excel._Worksheet workSheet=null;

            int nbMembres;
            int ancienNb;

            bool save = false;
            string nom_club;
            if (this.club!=null) 
            {
                nom_club = club.Nom;
                try
                {
                    
                    appExcel = new Excel.Application();
                    appExcel.Visible = false;

                    //Get a new workbook.
                    workBook = (Excel._Workbook)(appExcel.Workbooks.Open(Environment.CurrentDirectory.ToString() + "/" + nom_club + "/FichierMembres" + nom_club + ".xlsx"));
                    workSheet = (Excel._Worksheet)workBook.ActiveSheet;

                    ancienNb = Convert.ToInt32(workSheet.Cells[1, 1].Value);

                    nbMembres = this.club.Liste_Membre.Count;
                    workSheet.Cells[1, 1].Value = nbMembres;


                    for (int i = 0; i < nbMembres; i++)
                    {
                        this.club.Liste_Membre[i].Club_Affilie = this.club;
                        workSheet.Cells[i + 2, 1].Value = this.club.Liste_Membre[i].Nom;
                        workSheet.Cells[i + 2, 2].Value = this.club.Liste_Membre[i].Prenom;
                        workSheet.Cells[i + 2, 3].Value = this.club.Liste_Membre[i].Sexe;
                        workSheet.Cells[i + 2, 4].Value = this.club.Liste_Membre[i].Adresse;
                        workSheet.Cells[i + 2, 5].Value = this.club.Liste_Membre[i].Ville;
                        workSheet.Cells[i + 2, 6].Value = this.club.Liste_Membre[i].Date_naissance;
                        workSheet.Cells[i + 2, 7].Value = this.club.Liste_Membre[i].Numero_Telephone;
                        workSheet.Cells[i + 2, 8].Value = this.club.Nom;
                        workSheet.Cells[i + 2, 9].Value = this.club.Liste_Membre[i].Argent_membre;
                        if (this.club.Liste_Membre[i].Competition.ToString() == "NaN")
                        {
                            workSheet.Cells[i + 2, 10].Value = Convert.ToString(this.club.Liste_Membre[i].Competition);
                        }
                        else
                        {
                            workSheet.Cells[i + 2, 10].Value = this.club.Liste_Membre[i].Competition;
                        }
                        if (this.club.Liste_Membre[i].Cotisation == true)
                        {
                            workSheet.Cells[i + 2, 11].Value = "O";
                        }
                        else
                        {
                            workSheet.Cells[i + 2, 11].Value = "F";
                        }

                    }
                    if (nbMembres < ancienNb)
                    {
                        for (int i = nbMembres; i < ancienNb; i++)
                        {
                            workSheet.Cells[i + 2, 1].Value = null;
                            workSheet.Cells[i + 2, 2].Value = null;
                            workSheet.Cells[i + 2, 3].Value = null;
                            workSheet.Cells[i + 2, 4].Value = null;
                            workSheet.Cells[i + 2, 5].Value = null;

                            workSheet.Cells[i + 2, 6].Value = null;
                            workSheet.Cells[i + 2, 7].Value = null;
                            workSheet.Cells[i + 2, 8].Value = null;
                            workSheet.Cells[i + 2, 9].Value = null;

                            workSheet.Cells[i + 2, 10].Value = null;
                            workSheet.Cells[i + 2, 11].Value = null;
                        }
                    }
                    save = true;

                }
                catch (Exception theException)
                {
                    String errorMessage;
                    errorMessage = "Error: ";
                    errorMessage = String.Concat(errorMessage, theException.Message);
                    errorMessage = String.Concat(errorMessage, " Line: ");
                    errorMessage = String.Concat(errorMessage, theException.Source);
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                workBook.Close(true, Missing.Value, Missing.Value);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                //workBook = null;
                appExcel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
            }
            
            return save;

        }




        #endregion

       
    }
}
