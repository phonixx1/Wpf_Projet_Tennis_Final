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

namespace WpfTennis
{
    /// <summary>
    /// Logique d'interaction pour FenAjoutCompetition.xaml
    /// </summary>
    public partial class FenAjoutCompetition : Window
    {
        Competition aAjouter;
        Club clubOrgaisateur;
        public FenAjoutCompetition()
        {
            InitializeComponent();
        }
        public FenAjoutCompetition(Club club)
        {
            InitializeComponent();
            this.clubOrgaisateur = club;
        }

        public Competition ACreer
        {
            get { return aAjouter; }
        }
        private void btnValidation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TimeSpan duree;
                string type;
                if ((Convert.ToDateTime(txtBoxDebut.Text) <= Convert.ToDateTime(txtBoxFin.Text))&&(Convert.ToDateTime(txtBoxDebut.Text) > DateTime.Now))
                {
                    duree = Convert.ToDateTime(txtBoxFin.Text)-Convert.ToDateTime(txtBoxDebut.Text);
                }
                else
                {
                    MessageBox.Show("stop tester mon pauvre programme ... les dates :)");
                    throw new Exception();
                }
                if((txtBoxType.Text== "simple homme")||(txtBoxType.Text == "simple femme") || (txtBoxType.Text == "double femme")|| (txtBoxType.Text == "double homme") || (txtBoxType.Text == "equipe homme") || (txtBoxType.Text == "equipe femme"))
                {
                    type = txtBoxType.Text;
                }
                else
                {
                    MessageBox.Show("pb dans le type de compet :simple homme,simple femme ,double femme,double homme,equipe homme,equipe femme");
                    throw new Exception();
                }
                if(Convert.ToInt64(txtBoxAge.Text)<=0)
                {
                    MessageBox.Show("Age positif plz");
                    throw new Exception();

                }
                if (Convert.ToInt64(txtBoxPrix.Text) < 0)
                {
                    MessageBox.Show("Vous pouvez mettre a 0 le prix mais pas negatif quand meme..");
                    throw new Exception();

                }
                if (Convert.ToInt64(txtBoxNbJoueur.Text) <= 0)
                {
                    MessageBox.Show("Nb de joueur soit superieur a 0 plz");
                    throw new Exception();

                }
                if ((Convert.ToInt64(txtBoxNbJoueur.Text)%2!=0)&& ((txtBoxType.Text == "double femme")|| (txtBoxType.Text == "double homme")))
                {
                    MessageBox.Show("Nb de joueur pair pour une compet de type double");
                    throw new Exception();

                }
                if ((Convert.ToInt64(txtBoxNbJoueur.Text) <2) && ((txtBoxType.Text == "equipe femme") || (txtBoxType.Text == "equipe homme")))
                {
                    MessageBox.Show("Pour une compet equipe le nombre de joueur par equipe doit etre superieur a 1");
                    throw new Exception();

                }


                aAjouter = new Competition(txtBoxNom.Text, Convert.ToInt32(txtBoxPrix.Text), Convert.ToDateTime(txtBoxDebut.Text), duree,this.clubOrgaisateur,type,Convert.ToInt32(txtBoxAge.Text),txtBoxNiveau.Text,Convert.ToInt32(txtBoxNbJoueur.Text),Convert.ToDouble(txtBoxClassement.Text));
                MessageBox.Show("Ajout Reussi");
                this.DialogResult = true;

            }
            catch { MessageBox.Show("Echec de l'ajout. Verifier il n'y ai pas de faute de frappe"); }
        }
    }
}
