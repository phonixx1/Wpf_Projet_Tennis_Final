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
    /// Logique d'interaction pour FenAjoutMembre.xaml
    /// </summary>
    public partial class FenAjoutMembre : Window
    {
        Membre aAjouter;
        public FenAjoutMembre()
        {
            InitializeComponent();
        }
        public Membre AAjouter
        {
            get { return this.aAjouter; }
        }

        private void btnValidation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                aAjouter = new Membre(txtBoxNom.Text, txtBoxPrenom.Text, txtBoxSexe.Text, txtBoxAdresse.Text, txtBoxVille.Text, Convert.ToDateTime(txtBoxNaissance.Text),txtBoxTel.Text, null, Convert.ToInt32(txtBoxArgent.Text), Convert.ToDouble(txtBoxCompet.Text), false);
                MessageBox.Show("Ajout Reussi");
                this.DialogResult = true;

            }
            catch { MessageBox.Show("Echec de l'ajout"); }
            
            
        }
    }
}
