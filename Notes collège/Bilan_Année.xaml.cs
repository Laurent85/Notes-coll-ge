using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            Lire_Moyennes_eleves lire_moyennes = new Lire_Moyennes_eleves();

            lire_moyennes.Lecture_moyennes("Baptiste", Principal.classe);
            lire_moyennes.Calcul_moyenne_générale("Baptiste", Principal.classe);
            Lecture_Moyenne("Baptiste");

            lire_moyennes.Lecture_moyennes("Justine", Principal.classe);
            lire_moyennes.Calcul_moyenne_générale("Justine", Principal.classe);
            Lecture_Moyenne("Justine");

            lire_moyennes.Lecture_moyennes("Emilien", Principal.classe);
            lire_moyennes.Calcul_moyenne_générale("Emilien", Principal.classe);
            Lecture_Moyenne("Emilien");
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
            lire_moyennes.tri1.Content = "";
            lire_moyennes.tri2.Content = "";
            lire_moyennes.tri3.Content = "";
            lire_moyennes.tri1_classe.Content = "";
            lire_moyennes.tri2_classe.Content = "";
            lire_moyennes.tri3_classe.Content = "";           

            
        }
    }
}