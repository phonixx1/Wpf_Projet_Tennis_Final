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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfTennis
{
    /// <summary>
    /// Logique d'interaction pour ModuleStatistiques.xaml
    /// </summary>
    public partial class ModuleStatistiques : Window, INotifyPropertyChanged
    {
        Club clubReferent;
        int nb_participation_en_cours=0;
        int nb_participation_finie=0;
        List<Membre> liste_membre;
        ObservableCollection<Membre> ocMembre;

        public ModuleStatistiques()
        {
            InitializeComponent();
        }
        
        public ModuleStatistiques(Club club)
        {
            
            InitializeComponent();
            this.clubReferent = club;
            foreach(Competition element in club.Liste_compet)
            {
                if(element.Compet_finie==true)
                {
                    nb_participation_finie++;
                }
                else
                {
                    nb_participation_en_cours++;
                }
            }
            grilleDonnees.IsReadOnly = true;
            this.participationCompet.Content = "Le Club a " + Convert.ToString(nb_participation_finie) + " competition(s) finie(s) et " + Convert.ToString(nb_participation_en_cours) + " competition(s) en cours";
            this.liste_membre = club.Liste_Membre;
            ocMembre = new ObservableCollection<Membre>(this.liste_membre);
            DataContext = this;
        }
        public ObservableCollection<Membre> OcMembre
        {
            get { return ocMembre; }
            set
            {
                ocMembre = value;
                GenerePropertyChanged("OcMembre");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void GenerePropertyChanged(string Propriete)
        {
            if (this.PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(Propriete));
        }
        private void dataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Equipes")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Cotisation")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Argent_membre")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Club_Affilie")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Numero_Telephone")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Adresse")
            {
                e.Column = null;
            }
            if (e.PropertyName == "NbVicSimple")
            {
                e.Column = null;
            }
            if (e.PropertyName == "NbVicDouble")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Stage")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Liste_cours")
            {
                e.Column = null;
            }
            


        }
    }
}
