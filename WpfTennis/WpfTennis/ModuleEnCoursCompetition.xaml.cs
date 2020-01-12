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

namespace WpfTennis
{
    /// <summary>
    /// Logique d'interaction pour ModuleEnCoursCompetition.xaml
    /// </summary>
    public partial class ModuleEnCoursCompetition : Window
    {
        int nbAreturn;
        int nbEntree;
        public ModuleEnCoursCompetition()
        {
            InitializeComponent();
        }
        public ModuleEnCoursCompetition(int nb)
        {
            InitializeComponent();
            this.nbEntree = nb;
            this.nombreCrée.Content +=" "+Convert.ToString(nb)+" competition(s)";
        }
        public int NbReturn
        {
            get { return nbAreturn; }
        }

        private void btnValidation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(this.txtBoxNumero.Text) <= nbEntree) && (Convert.ToInt32(this.txtBoxNumero.Text) >= 1))
                {
                    this.nbAreturn = Convert.ToInt32(this.txtBoxNumero.Text);
                    MessageBox.Show("Competition trouvée");
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Erreur :Le nombre doit etre compris entre 1 et "+Convert.ToString(nbEntree));
                }
            }
            catch
            {
                MessageBox.Show("Erreur de votre entree");
            }
        }
    }
}
