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
    /// Il devait y avoir toutes les aides pour le logiciel mais  on a pas eu le temps et c'etait pas prioritaire...
    /// </summary>
    public partial class FenAide : Window
    {
        public FenAide()
        {
            InitializeComponent();
            this.aide.Content = "Ajout : Ajout classique et cliquer sur Valider : tant que vous n'aurez pas sauvegardé dans le menu pricnipale la nouvelle liste d'objet(membre admistration ect), \n l'objet ne sera pas dans la base de donnees du club\n\n";
            this.aide.Content += "Effacer : Cliquer sur la ligne de l'objet a effacer puis sur le bouton Effacer...\n\n";
            this.aide.Content += "Modifie : Double clique sur la valeur a modifier \n(On considere que tout ne peut pas etre modifié comme le nom prenom ect..)\n\n";
            this.aide.Content += "Tri : Cliquer directement sur la tableau sur le parametre que vous voulez trier";

        }
    }
}
