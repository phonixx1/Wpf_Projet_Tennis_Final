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
    /// Logique d'interaction pour ModuleMembres.xaml
    /// </summary>
    public partial class ModuleMembres : Window, INotifyPropertyChanged
    {
        List<Membre> liste_membre;
        ObservableCollection<Membre> ocMembre;
        public ModuleMembres()
        {
            InitializeComponent();
        }
        public ModuleMembres(List<Membre> listeMembre)
        {

            InitializeComponent();
            this.liste_membre = listeMembre;
            ocMembre = new ObservableCollection<Membre>(this.liste_membre);
            DataContext = this;

        }
        public List<Membre> ListeMembreAff
        {
            get { return liste_membre; }
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
        
        
        

        private void btnRetourMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void btnEffacer_Click(object sender, RoutedEventArgs e)
        {
            if (grilleDonnees.SelectedIndex >= 0)
            {
                Membre aEffacer = grilleDonnees.SelectedItem as Membre;
                ocMembre.Remove(aEffacer);
            }
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            FenAjoutMembre ajoutMembre = new FenAjoutMembre();
            ajoutMembre.Owner = this;
            ajoutMembre.ShowDialog();
            if(ajoutMembre.DialogResult==true)
            {
                ocMembre.Add(ajoutMembre.AAjouter);
            }
            
        }

        private void btnAide_Click(object sender, RoutedEventArgs e)
        {
            FenAide pageAide = new FenAide();
            pageAide.Owner = this;
            pageAide.Show();
        }
        private void dataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Equipes")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Club_Affilie")
            {
                e.Column.IsReadOnly = true;
            }
            if (e.PropertyName == "Nb_Victoires")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Nb_Defaites")
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
            if (e.PropertyName == "NbVicSimple")
            {
                e.Column = null;
            }
            if (e.PropertyName == "NbVicDouble")
            {
                e.Column = null;
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void GenerePropertyChanged(string Propriete)
        {
            if (this.PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(Propriete));
        }


    }
}
