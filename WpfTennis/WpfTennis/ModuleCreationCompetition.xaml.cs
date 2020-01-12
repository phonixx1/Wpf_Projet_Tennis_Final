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
    /// Logique d'interaction pour ModuleCreationCompetition.xaml
    /// </summary>
    public partial class ModuleCreationCompetition : Window
    {
        Competition competCree;
        List<Membre> listeDesMembres;
        
        
        public ModuleCreationCompetition()
        {
            InitializeComponent();
        }
        public ModuleCreationCompetition(Competition compet,List<Membre> liste)
        {
            InitializeComponent();
            this.competCree = compet;
            this.listeDesMembres = liste;
            this.nbEquipe.Content = "Nombre d'equipe : "+Convert.ToString(compet.Equipe_participante.Count);
        }
        public Competition CompetCree
        {
            get { return this.competCree; }
        }


        private void btnRetourMainWindow_Click(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = true;
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            
            FenAjoutEquipeCompet nouvelleEquipeComet = new FenAjoutEquipeCompet(this.listeDesMembres, this.competCree);
            nouvelleEquipeComet.Owner = this;
            nouvelleEquipeComet.ShowDialog();
            if (nouvelleEquipeComet.DialogResult == true)
            {
                if(competCree.Ajouter_Equipe(nouvelleEquipeComet.AAjouter))
                {
                    competCree.Equipe_participante.Add(nouvelleEquipeComet.AAjouter);
                    this.nbEquipe.Content ="Nombre d'equipe : " +Convert.ToString(competCree.Equipe_participante.Count);
                }
            }

        }

        

        private void btnStrat_Click(object sender, RoutedEventArgs e)
        {
            if(competCree.Equipe_participante.Count%2==0)
            {

            }
            else
            {
                MessageBox.Show("Nombre dequipe pair on peut pas start la compet");
            }
        }
    }
}
