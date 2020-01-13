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
    /// Logique d'interaction pour ModuleEntraineurs.xaml
    /// </summary>
    public partial class ModuleEntraineurs : Window, INotifyPropertyChanged
    {
        List<Entraineur> liste_entraineur;
        ObservableCollection<Entraineur> ocEntraineur;
        public ModuleEntraineurs()
        {
            InitializeComponent();
        }
        public ModuleEntraineurs(List<Entraineur> listeEntraineur)
        {

            InitializeComponent();
            this.liste_entraineur = listeEntraineur;
            ocEntraineur = new ObservableCollection<Entraineur>(this.liste_entraineur);
            DataContext = this;
        }

        public List<Entraineur> ListeEntraineur
        {
            get { return liste_entraineur; }
        }
        public ObservableCollection<Entraineur> OcEntraineur
        {
            get { return ocEntraineur; }
            set
            {
                ocEntraineur = value;
                GenerePropertyChanged("ocEntraineur");
            }
        }

        private void btnRetourMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void btnAide_Click(object sender, RoutedEventArgs e)
        {
            FenAide pageAide = new FenAide();
            pageAide.Owner = this;
            pageAide.Show();
        }
        private void btnEffacer_Click(object sender, RoutedEventArgs e)
        {
            if (grilleDonnees.SelectedIndex >= 0)
            {
                Entraineur aEffacer = grilleDonnees.SelectedItem as Entraineur;
                ocEntraineur.Remove(aEffacer);
            }
        }
        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            FenAjoutEntraineur ajoutEntraineur = new FenAjoutEntraineur();
            ajoutEntraineur.Owner = this;
            ajoutEntraineur.ShowDialog();
            if (ajoutEntraineur.DialogResult == true)
            {
                ocEntraineur.Add(ajoutEntraineur.AAjouter);
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
            if (e.PropertyName == "Club_Affilie")
            {
                e.Column.IsReadOnly = true;
            }
        }
        
    }
}