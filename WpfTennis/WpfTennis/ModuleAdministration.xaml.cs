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
    /// Logique d'interaction pour ModuleAdministration.xaml
    /// </summary>
    public partial class ModuleAdministration : Window , INotifyPropertyChanged
    {
        List<Personne_Administration> liste_administration;
        ObservableCollection<Personne_Administration> ocAdministration;
        public ModuleAdministration()
        {
            InitializeComponent();
        }
        public ModuleAdministration(List<Personne_Administration> listeMliste_administrationembre)
        {
            InitializeComponent();
            this.liste_administration = listeMliste_administrationembre;
            ocAdministration = new ObservableCollection<Personne_Administration>(this.liste_administration);
            DataContext = this;
        }
        public List<Personne_Administration> ListeAdministration
        {
            get { return this.liste_administration; }
        }
        public ObservableCollection<Personne_Administration> OcAdministration
        {
            get { return ocAdministration; }
            set
            {
                ocAdministration = value;
                GenerePropertyChanged("ocAdministration");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void GenerePropertyChanged(string Propriete)
        {
            if (this.PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(Propriete));
        }

        private void btnEffacer_Click(object sender, RoutedEventArgs e)
        {
            if (grilleDonnees.SelectedIndex >= 0)
            {
                Personne_Administration aEffacer = grilleDonnees.SelectedItem as Personne_Administration;
                ocAdministration.Remove(aEffacer);
            }

        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            FenAjoutAdministration ajoutAdministration = new FenAjoutAdministration();
            ajoutAdministration.Owner = this;
            ajoutAdministration.ShowDialog();
            if (ajoutAdministration.DialogResult == true)
            {
                ocAdministration.Add(ajoutAdministration.AAJouter);
            }
        }

        private void btnAide_Click(object sender, RoutedEventArgs e)
        {
            FenAide pageAide = new FenAide();
            pageAide.Owner = this;
            pageAide.Show();

        }

        private void btnRetourMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
