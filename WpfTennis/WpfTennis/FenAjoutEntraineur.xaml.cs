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
    /// Logique d'interaction pour FenAjoutEntraineur.xaml
    /// </summary>
    public partial class FenAjoutEntraineur : Window
    {
        Entraineur aAjouter; 
        public FenAjoutEntraineur()
        {
            InitializeComponent();
        }
        public Entraineur AAjouter
        {
            get { return this.aAjouter; }
        }

        private void btnValidation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string banque= txtBoxBancaire.Text.ToString();
                string salaire= txtBoxSalaire.Text.ToString();
                string entree= txtBoxEntree.Text.ToString();
                bool statut = true;
                if((banque == "Coordonnees Bancaire") && (salaire== "salaire")&& (entree== "date entree"))
                {
                    statut = false;
                    banque = "";
                    salaire = Convert.ToString(double.NaN);
                    entree = "01/01/0001";

                }
                aAjouter = new Entraineur(txtBoxNom.Text, txtBoxPrenom.Text, txtBoxSexe.Text, txtBoxAdresse.Text, txtBoxVille.Text, Convert.ToDateTime(txtBoxNaissance.Text), txtBoxTel.Text, null, Convert.ToInt32(txtBoxArgent.Text), Convert.ToDouble(txtBoxCompet.Text), false, statut, Convert.ToDouble(salaire),Convert.ToDateTime(entree),banque) ;
                MessageBox.Show("Ajout Reussi");
                this.DialogResult = true;

            }
            catch { MessageBox.Show("Echec de l'ajout"); }
        }
    }
}
