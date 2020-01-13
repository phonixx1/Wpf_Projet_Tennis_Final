﻿using System;
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
    /// Logique d'interaction pour FenAjoutEquipeCompet.xaml
    /// </summary>
    public partial class FenAjoutEquipeCompet : Window, INotifyPropertyChanged
    {
        Equipe_Competition aAjouter;
        List<Membre> listeMembre;
        int[] tabNbEquipeCompet;
        ObservableCollection<Membre> ocMembre;
        Membre cptn=null;
        Membre membreAAjouter;
        Competition competCourante;
        public FenAjoutEquipeCompet()
        {
            InitializeComponent();
        }
        public FenAjoutEquipeCompet(List<Membre> listmembre,Competition compet )
        {
            InitializeComponent();
           
            this.listeMembre = listmembre;
            this.competCourante = compet;
            tabNbEquipeCompet = new int[listmembre.Count];
            int i = 0;
            foreach(Membre elem1 in listeMembre)
            {

                tabNbEquipeCompet[i] = elem1.Equipes.Count;
                i++;
            }
            
            this.labelNbJoueur.Content = "Nombre de joueur : 0/" + Convert.ToString(compet.Nb_Joueur);
            ocMembre = new ObservableCollection<Membre>(this.listeMembre);
            aAjouter = new Equipe_Competition(this.competCourante);
            DataContext = this;
        }
        public List<Membre> ListeMembre
        {
            get { return this.listeMembre; }
        }
        public Equipe_Competition AAjouter
        {
            get { return this.aAjouter; }
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


        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            if (grilleDonnees.SelectedIndex >= 0)
            {
                if(cptn==null)
                {
                    cptn = grilleDonnees.SelectedItem as Membre;
                    if (aAjouter.Ajouter_un_membre(cptn))
                    {
                        aAjouter.FaireAjoutUnMembre(cptn);
                        aAjouter.Capitaine = cptn;
                        this.labelNbJoueur.Content = "Nombre de joueur : 1/" + Convert.ToString(this.competCourante.Nb_Joueur);
                        MessageBox.Show("capitaine ajouté");
                       
                    }
                    else
                    {
                        cptn = null;
                        MessageBox.Show("Le capitaine n'a pas pu etre ajouté. Essayer un autre membre");
                    }
                }
                else
                {
                    if(aAjouter.Composition_Equipe.Count<this.competCourante.Nb_Joueur)
                    {
                        membreAAjouter= grilleDonnees.SelectedItem as Membre;
                        if(aAjouter.Ajouter_un_membre(membreAAjouter))
                        {
                            aAjouter.FaireAjoutUnMembre(membreAAjouter);
                            this.labelNbJoueur.Content = "Nombre de joueur : "+Convert.ToString(aAjouter.Composition_Equipe.Count)+"/" + Convert.ToString(this.competCourante.Nb_Joueur);
                            MessageBox.Show("joueur ajouté");

                        }
                        else
                        {
                            MessageBox.Show("Le joueur n'a pas pu etre ajouté. Essayer un autre membre. Faire attention aux dates communes de compet, à l'age et au sexe");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Votre equipe est complete retourner au menu princiale");
                    }
                }
                
            }
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
           
            if (aAjouter.Composition_Equipe.Count == this.competCourante.Nb_Joueur)
            {
                this.DialogResult = true; 
            }
            else
            {
               
                foreach(Membre element in this.listeMembre)
                {
                    if(tabNbEquipeCompet[i]!=element.Equipes.Count)
                    {
                        element.Equipes.RemoveAt(element.Equipes.Count - 1);
                    }
                    i++;
                }
                this.DialogResult = false;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void GenerePropertyChanged(string Propriete)
        {
            if (this.PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(Propriete));
        }
    }
}
