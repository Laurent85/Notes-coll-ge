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

namespace Notes_collège
    {
    /// <summary>
    /// Logique d'interaction pour Bilan_Année.xaml
    /// </summary>
    public partial class Bilan_Année : Window
        {
        public string essai = "";
        public Bilan_Année()
            {
            InitializeComponent();
            }

        private void Bilan_Loaded(object sender, RoutedEventArgs e)
            {
            Titre.Content = "Bilan - " + Principal.classe;
            Lire_moyennes lire_moyennes = new Lire_moyennes();

            lire_moyennes.Lecture_moyennes("Baptiste", Principal.classe);
            moy1_Baptiste.Content = lire_moyennes.tri1.Content;
            moy2_Baptiste.Content = lire_moyennes.tri2.Content;
            moy3_Baptiste.Content = lire_moyennes.tri3.Content;
            moy1_classe_Baptiste.Content = lire_moyennes.tri1_classe.Content;
            moy2_classe_Baptiste.Content = lire_moyennes.tri2_classe.Content;
            moy3_classe_Baptiste.Content = lire_moyennes.tri3_classe.Content;
            lire_moyennes.Calcul_moyenne_générale("Baptiste", Principal.classe);
            moy_annee_Baptiste.Content = lire_moyennes.annee.Content;
            moy_annee_classe_Baptiste.Content = lire_moyennes.annee_classe.Content;
            lire_moyennes.tri1.Content = "";
            lire_moyennes.tri2.Content = "";
            lire_moyennes.tri3.Content = "";
            lire_moyennes.tri1_classe.Content = "";
            lire_moyennes.tri2_classe.Content = "";
            lire_moyennes.tri3_classe.Content = "";

            lire_moyennes.Lecture_moyennes("Justine", Principal.classe);
            moy1_Justine.Content = lire_moyennes.tri1.Content;
            moy2_Justine.Content = lire_moyennes.tri2.Content;
            moy3_Justine.Content = lire_moyennes.tri3.Content;
            moy1_classe_Justine.Content = lire_moyennes.tri1_classe.Content;
            moy2_classe_Justine.Content = lire_moyennes.tri2_classe.Content;
            moy3_classe_Justine.Content = lire_moyennes.tri3_classe.Content;
            lire_moyennes.Calcul_moyenne_générale("Justine", Principal.classe);
            moy_annee_Justine.Content = lire_moyennes.annee.Content;
            moy_annee_classe_Justine.Content = lire_moyennes.annee_classe.Content;
            lire_moyennes.tri1.Content = "";
            lire_moyennes.tri2.Content = "";
            lire_moyennes.tri3.Content = "";
            lire_moyennes.tri1_classe.Content = "";
            lire_moyennes.tri2_classe.Content = "";
            lire_moyennes.tri3_classe.Content = "";

            lire_moyennes.Lecture_moyennes("Emilien", Principal.classe);
            moy1_Emilien.Content = lire_moyennes.tri1.Content;
            moy2_Emilien.Content = lire_moyennes.tri2.Content;
            moy3_Emilien.Content = lire_moyennes.tri3.Content;
            moy1_classe_Emilien.Content = lire_moyennes.tri1_classe.Content;
            moy2_classe_Emilien.Content = lire_moyennes.tri2_classe.Content;
            moy3_classe_Emilien.Content = lire_moyennes.tri3_classe.Content;
            lire_moyennes.Calcul_moyenne_générale("Emilien", Principal.classe);
            moy_annee_Emilien.Content = lire_moyennes.annee.Content;
            moy_annee_classe_Emilien.Content = lire_moyennes.annee_classe.Content;
            lire_moyennes.tri1.Content = "";
            lire_moyennes.tri2.Content = "";
            lire_moyennes.tri3.Content = "";
            lire_moyennes.tri1_classe.Content = "";
            lire_moyennes.tri2_classe.Content = "";
            lire_moyennes.tri3_classe.Content = "";
            }
        }
    }
