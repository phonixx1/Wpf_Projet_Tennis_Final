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
    /// module de gestion des equipes et de lancement d'une competition
    /// on verifie que les critetres sur les equipes soit correct pour lancer la competition
    /// </summary>
    public partial class ModuleCreationCompetition : Window
    {
        Competition competCree=null;
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
            else 
            {
               
                this.listeDesMembres = nouvelleEquipeComet.ListeMembre;
            }

        }

        

        private void btnStrat_Click(object sender, RoutedEventArgs e)
        {
            
            FenDefinirGagnant defGagnant;
            int compteur = 0;
            Equipe_Competition gagnant;
            int numeroGagnant=1;
            

            if (competCree != null)
            {
                
                if ((competCree.Equipe_participante.Count % 2 == 0)&&(competCree.Equipe_participante.Count!=0))
                {
                    
                    this.competCree.Creation_Liste_Match();
                    foreach (Match element in competCree.Liste_match)
                    {
                        defGagnant = new FenDefinirGagnant(element);
                        defGagnant.Owner = this;
                        defGagnant.ShowDialog();
                        if(defGagnant.DialogResult==true)
                        {
                            compteur++;
                        }
                        
                    }
                    if (competCree.Liste_match.Count==compteur)
                    {
                        gagnant = competCree.Equipe_participante[0];
                        for (int i=1;i<competCree.Equipe_participante.Count;i++)
                        {
                            if(gagnant.Points_Equipe< competCree.Equipe_participante[i].Points_Equipe)
                            {
                                gagnant = competCree.Equipe_participante[i];
                                numeroGagnant = i+1;
                            }
                            
                        }
                        MessageBox.Show("Lequipe numero " + Convert.ToString(numeroGagnant) + " a gagné et son capitaine est " + Convert.ToString(gagnant.Capitaine.Nom));
                        competCree.Compet_finie = true;
                        MessageBox.Show("La competition est finie");
                        this.DialogResult = true;

                    }
                    else
                    {
                        MessageBox.Show("Probleme dans la competition");
                    }


                }
                else
                {
                    MessageBox.Show(" Nombre dequipes pair et different de 0");
                }
            }
            else
            {
                MessageBox.Show("cree une compet");
            }
        }
    }
}
