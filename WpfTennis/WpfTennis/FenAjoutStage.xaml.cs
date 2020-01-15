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
    /// Logique d'interaction pour FenAjoutStage.xaml
    /// </summary>
    public partial class FenAjoutStage : Window
    {
        Stage aCreer;
        Club club;
        public FenAjoutStage(Club club)
        {
            InitializeComponent();
            this.club = club;
        }
        public Stage ACreer
        {
            get { return this.aCreer; }
        }

        private void btnValidation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TimeSpan duree;
                if ((Convert.ToDateTime(txtBoxDebut.Text) <= Convert.ToDateTime(txtBoxFin.Text)) && (Convert.ToDateTime(txtBoxDebut.Text) > DateTime.Now))
                {
                    duree = Convert.ToDateTime(txtBoxFin.Text) - Convert.ToDateTime(txtBoxDebut.Text);
                }
                else
                {
                    MessageBox.Show("stop tester mon pauvre programme ... les dates :)");
                    throw new Exception();
                }
                
                
                if (Convert.ToInt64(txtBoxPrix.Text) < 0)
                {
                    MessageBox.Show("Vous pouvez mettre a 0 le prix mais pas negatif quand meme..");
                    throw new Exception();

                }



                aCreer = new Stage(txtBoxNom.Text, Convert.ToInt32(txtBoxPrix.Text), Convert.ToDateTime(txtBoxDebut.Text), duree, this.club);
                MessageBox.Show("Creation stage Reussi");
                this.DialogResult = true;

            }
            catch { MessageBox.Show("Echec de la creation du stage. Verifier il n'y ai pas de faute de frappe"); }
        }
    }
}
