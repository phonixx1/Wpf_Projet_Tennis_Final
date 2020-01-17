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
    /// cest ici que lutilisateur definit qui est le gagnant dun match de competition
    /// </summary>
    public partial class FenDefinirGagnant : Window
    {

        Match match;
        Match_Simple matchSimple;
        Match_Double matchDouble;
        Equipe_Competition equipegagnante;
        bool simple=true;
        public FenDefinirGagnant()
        {
            InitializeComponent();
        }
        public FenDefinirGagnant(Match match )
        {
            InitializeComponent();
            this.match = match;
            if (match.Type_match == "match simple")
            {
                simple = true;
                matchSimple = (Match_Simple)match;
                this.Joueur1equipe1.Content = matchSimple.Equipe1.Composition_Equipe[matchSimple.Indice_joueur_equipe1].Nom + " " + matchSimple.Equipe1.Composition_Equipe[matchSimple.Indice_joueur_equipe1].Prenom;
                this.Joueur1equipe2.Content = matchSimple.Equipe2.Composition_Equipe[matchSimple.Indice_joueur_equipe1].Nom + " " + matchSimple.Equipe2.Composition_Equipe[matchSimple.Indice_joueur_equipe1].Prenom;

            }
            else if (match.Type_match == "match double")
            {
                simple = false;
                matchDouble = (Match_Double)match;
                this.Joueur1equipe1.Content = matchDouble.Equipe1.Composition_Equipe[matchDouble.Indice_joueur1_equipe1].Nom + " " + matchDouble.Equipe1.Composition_Equipe[matchDouble.Indice_joueur1_equipe1].Prenom;
                this.Joueur2equipe1.Content = matchDouble.Equipe1.Composition_Equipe[matchDouble.Indice_joueur2_equipe1].Nom + " " + matchDouble.Equipe1.Composition_Equipe[matchDouble.Indice_joueur2_equipe1].Prenom;
                this.Joueur1equipe2.Content = matchDouble.Equipe2.Composition_Equipe[matchDouble.Indice_joueur1_equipe2].Nom + " " + matchDouble.Equipe2.Composition_Equipe[matchDouble.Indice_joueur1_equipe2].Prenom;
                this.Joueur2equipe2.Content = matchDouble.Equipe2.Composition_Equipe[matchDouble.Indice_joueur2_equipe2].Nom + " " + matchDouble.Equipe2.Composition_Equipe[matchDouble.Indice_joueur2_equipe2].Prenom;
            }
        }


        public Equipe_Competition EquipeGagnante
        {
            get { return this.equipegagnante; }
        }


        private void btnValide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                int resultat = Convert.ToInt32(txtBoxGagnant.Text);
                if(resultat==1||resultat==2)
                {
                    
                    if (simple == true)
                    {
                        
                        if (resultat == 1)
                        {
                            this.equipegagnante = matchSimple.Equipe1;
                            this.matchSimple.Equipe1.Composition_Equipe[matchSimple.Indice_joueur_equipe1].NbVicSimple++;
                        }
                        else
                        {
                            this.equipegagnante = matchSimple.Equipe2;
                            this.matchSimple.Equipe2.Composition_Equipe[matchSimple.Indice_joueur_equipe2].NbVicSimple++;
                        }
                        this.equipegagnante.Points_Equipe += 2;
                        
                        
                    }
                    else
                    {
                        
                        if (resultat == 1)
                        {
                            this.equipegagnante = matchDouble.Equipe1;
                            this.matchDouble.Equipe1.Composition_Equipe[matchDouble.Indice_joueur1_equipe1].NbVicDouble++;
                            this.matchDouble.Equipe1.Composition_Equipe[matchDouble.Indice_joueur2_equipe1].NbVicDouble++;
                        }
                        else
                        {
                            this.equipegagnante = matchDouble.Equipe2;
                            this.matchDouble.Equipe2.Composition_Equipe[matchDouble.Indice_joueur1_equipe2].NbVicDouble++;
                            this.matchDouble.Equipe2.Composition_Equipe[matchDouble.Indice_joueur2_equipe2].NbVicDouble++;
                        }
                        this.equipegagnante.Points_Equipe += 2;
                    }
                    this.DialogResult = true;
                }
                else
                {
                    throw new Exception();
                }
                

            }
            catch { MessageBox.Show("Echec : mettre un int 1 ou 2"); }
        }
    }
}
