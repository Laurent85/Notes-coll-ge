using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Notes_collège
{
    /// <summary>
    /// Logique d'interaction pour Bilan_Année.xaml
    /// </summary>
    public partial class Bilan_Année : Window
    {
        public Bilan_Année()
        {
            InitializeComponent();
        }

        private void Bilan_Loaded(object sender, RoutedEventArgs e)
        {        
            Titre.Content = "Bilan - " + Principal.classe;

            try
            {
                Lecture_Moyenne("Baptiste");
            }
            catch { }
            try
            {
                Lecture_Moyenne("Justine");
            }
            catch { }
            try
            {
                Lecture_Moyenne("Emilien");
            }
            catch { }

        }

        private void Lecture_Moyenne(string prenom)
        {
            Label moyenne1 = (Label)this.FindName("moy1_" + prenom);
            Label moyenne2 = (Label)this.FindName("moy2_" + prenom);
            Label moyenne3 = (Label)this.FindName("moy3_" + prenom);
            Label moyenne1_classe = (Label)this.FindName("moy1_classe_" + prenom);
            Label moyenne2_classe = (Label)this.FindName("moy2_classe_" + prenom);
            Label moyenne3_classe = (Label)this.FindName("moy3_classe_" + prenom);
            Label moyenne_annee = (Label)this.FindName("moy_annee_" + prenom);
            Label moyenne_annee_classe = (Label)this.FindName("moy_annee_classe_" + prenom);

            Lire_Moyennes_eleves lire_moyennes = new Lire_Moyennes_eleves();

            lire_moyennes.Lecture_moyennes(prenom, Principal.classe);
            moyenne1.Content = lire_moyennes.tri1.Content;
            moyenne2.Content = lire_moyennes.tri2.Content;
            moyenne3.Content = lire_moyennes.tri3.Content;
            moyenne1_classe.Content = lire_moyennes.tri1_classe.Content;
            moyenne2_classe.Content = lire_moyennes.tri2_classe.Content;
            moyenne3_classe.Content = lire_moyennes.tri3_classe.Content;

            lire_moyennes.Calcul_moyenne_générale(prenom, Principal.classe);
            moyenne_annee.Content = lire_moyennes.annee.Content;
            moyenne_annee_classe.Content = lire_moyennes.annee_classe.Content;

            if (((Convert.ToDouble(moyenne1.Content)) > (Convert.ToDouble(moyenne2.Content))) &&
                     (moyenne1.Content.ToString() != "") && (moyenne2.Content.ToString() != ""))
            {
                Afficher_fleche("Régression", prenom, "1");
            }
            if (((Convert.ToDouble(moyenne1.Content)) < (Convert.ToDouble(moyenne2.Content))) &&
                    (moyenne1.Content.ToString() != "") && (moyenne2.Content.ToString() != ""))
            {
                Afficher_fleche("Progression", prenom, "1");
            }
            if (moyenne2.Content.ToString() == "")
            { Supprimer_fleche(prenom, "1"); }

            if (((Convert.ToDouble(moyenne2.Content)) > (Convert.ToDouble(moyenne3.Content))) &&
                    (moyenne2.Content.ToString() != "") && (moyenne3.Content.ToString() != ""))
            {
                Afficher_fleche("Régression", prenom, "2");
            }
            if (((Convert.ToDouble(moyenne2.Content)) < (Convert.ToDouble(moyenne3.Content))) &&
                    (moyenne2.Content.ToString() != "") && (moyenne3.Content.ToString() != ""))
            {
                Afficher_fleche("Progression", prenom, "2");
            }
            if (moyenne3.Content.ToString() == "")
            { Supprimer_fleche(prenom, "2"); }

            lire_moyennes.tri1.Content = "";
            lire_moyennes.tri2.Content = "";
            lire_moyennes.tri3.Content = "";
            lire_moyennes.tri1_classe.Content = "";
            lire_moyennes.tri2_classe.Content = "";
            lire_moyennes.tri3_classe.Content = "";
        }

        private void Afficher_fleche(string progression, string prenom, string trimestre)
            {
            Image Fleche = (Image)this.FindName("Fleche" + trimestre + "_" + prenom);
            string chemin = "Ressources\\" + progression.ToString() + ".png";
            Fleche.Source = new BitmapImage(new Uri(@chemin, UriKind.Relative));            
            }

        private void Supprimer_fleche(string prenom, string trimestre)
            {
            Image Fleche = (Image)this.FindName("Fleche" + trimestre + "_" + prenom);
            Fleche.Source = null;
            }

        private void effacer()
            {
            moy1_Baptiste.Content = "";
            moy1_Justine.Content = "";
            moy1_Emilien.Content = "";
            moy2_Baptiste.Content = "";
            moy2_Justine.Content = "";
            moy2_Emilien.Content = "";
            moy3_Baptiste.Content = "";
            moy3_Justine.Content = "";
            moy3_Emilien.Content = "";
            moy_annee_Baptiste.Content = "";
            moy_annee_classe_Baptiste.Content = "";
            moy_annee_Justine.Content = "";
            moy_annee_classe_Justine.Content = "";
            moy_annee_Emilien.Content = "";
            moy_annee_classe_Emilien.Content = "";
            Fleche1_Baptiste.Source = null;
            Fleche2_Baptiste.Source = null;
            Fleche1_Justine.Source = null;
            Fleche2_Justine.Source = null;
            Fleche1_Emilien.Source = null;
            Fleche2_Emilien.Source = null;
            }
    }
}