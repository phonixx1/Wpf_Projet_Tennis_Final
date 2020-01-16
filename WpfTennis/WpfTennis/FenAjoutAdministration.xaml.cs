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
    /// Toutes les fenetres du type "FenAjout..." sont les affichages des ajouts on reucpere et on cree les entrees de lutilisateur 
    /// </summary>
    public partial class FenAjoutAdministration : Window
    {
        Personne_Administration aAjouter;
        public FenAjoutAdministration()
        {
            InitializeComponent();
        }
        public Personne_Administration AAJouter
        {
            get { return this.aAjouter; }
        }

        private void btnValidation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                aAjouter = new Personne_Administration(txtBoxNom.Text, txtBoxPrenom.Text, txtBoxSexe.Text, txtBoxAdresse.Text, txtBoxVille.Text, Convert.ToDateTime(txtBoxNaissance.Text), txtBoxTel.Text,Convert.ToDateTime(txtBoxEntree.Text),Convert.ToDouble(txtBoxSalaire.Text),txtBoxBancaire.Text);
                MessageBox.Show("Ajout Reussi");
                this.DialogResult = true;

            }
            catch { MessageBox.Show("Echec de l'ajout"); }

        }
    }
}
