﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ServiceProcess;

namespace Notes_collège
{
    /// <summary>
    /// Logique d'interaction pour Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private string connectionString = "Data Source=laurent\\sqlexpress;Initial Catalog=Notes;Persist Security Info=True;User ID=sa;Password=sa;Pooling=False";

        //x private string connectionString = "Data Source=manceau.dtdns.net\\sqlexpress,1433;Network Library=DBMSSOCN;Initial Catalog=Notes;Persist Security Info=True;User ID=sa;Password=sa;Pooling=False";
        //x private string connectionString = "Data Source=PCLAURENT\\SQLEXPRESS;Initial Catalog=Notes;Integrated Security=True";
        public static string elève = "";

        public static int index_classe = 0;
        public static string classe = "";
        public static double moy1 = 0;
        public static double moy2 = 0;
        public static double moy3 = 0;
        public static double moy1_classe = 0;
        public static double moy2_classe = 0;
        public static double moy3_classe = 0;
        public static void StartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch
            {
                // ...
            }
        }

        public Principal()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartService("SQL SERVER (SQLEXPRESS)", 10000);
            effacer();
            Visibilité_mode_consultation("1");
            Visibilité_mode_consultation("2");
            Visibilité_mode_consultation("3");
        }

        private void Eleve_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Baptiste");
            data.Add("Justine");
            data.Add("Emilien");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        private void Classe_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("6ème");
            data.Add("5ème");
            data.Add("4ème");
            data.Add("3ème");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        private void Btn_Modifier1_Click(object sender, RoutedEventArgs e)
        {
            effacer();
            Lire_moyennes();
            Graphique();
            Graphique_classe();
            Visibilité_mode_modification("1");
            Activation_bouton_valider("1");
            Moyenne1.Focus();
            Moyenne1.SelectAll();            
        }

        private void Btn_Modifier2_Click(object sender, RoutedEventArgs e)
        {
            effacer();
            Lire_moyennes();
            Graphique();
            Graphique_classe();
            Visibilité_mode_modification("2");
            Activation_bouton_valider("2");
            Moyenne2.Focus();
            Moyenne2.SelectAll();
        }

        private void Btn_Modifier3_Click(object sender, RoutedEventArgs e)
        {
            effacer();
            Lire_moyennes();
            Graphique();
            Graphique_classe();
            Visibilité_mode_modification("3");
            Activation_bouton_valider("3");
            Moyenne3.Focus();
            Moyenne3.SelectAll();
        }

        private void Btn_Annuler1_Click(object sender, RoutedEventArgs e)
        {
            Visibilité_mode_consultation("1");
        }

        private void Btn_Annuler2_Click(object sender, RoutedEventArgs e)
        {
            Visibilité_mode_consultation("2");
        }

        private void Btn_Annuler3_Click(object sender, RoutedEventArgs e)
        {
            Visibilité_mode_consultation("3");
        }

        private void Btn_Valider1_Click(object sender, RoutedEventArgs e)
        {
            Saisie_moyenne("1er trimestre", Moyenne1, Moyenne1_classe, Moy1, Moy1_classe, "1");
            Saisie_moyenne_classe("1er trimestre", Moyenne1_classe, Moyenne1, Moy1, Moy1_classe, "1");
            effacer();
            Lire_moyennes();
            Moyennes_graphique.Clear();
            Moyennes_graphique_classe.Clear();
            Graphique();
            Graphique_classe();
        }

        private void Btn_Valider2_Click(object sender, RoutedEventArgs e)
        {
            Saisie_moyenne("2ème trimestre", Moyenne2, Moyenne2_classe, Moy2, Moy2_classe, "2");
            Saisie_moyenne_classe("2ème trimestre", Moyenne2_classe, Moyenne2, Moy2, Moy2_classe, "2");
            effacer();
            Lire_moyennes();
            Moyennes_graphique.Clear();
            Moyennes_graphique_classe.Clear();
            Graphique();
            Graphique_classe();
        }

        private void Btn_Valider3_Click(object sender, RoutedEventArgs e)
        {
            Saisie_moyenne("3ème trimestre", Moyenne3, Moyenne3_classe, Moy3, Moy3_classe, "3");
            Saisie_moyenne_classe("3ème trimestre", Moyenne3_classe, Moyenne3, Moy3, Moy3_classe, "3");
            effacer();
            Lire_moyennes();
            Moyennes_graphique.Clear();
            Moyennes_graphique_classe.Clear();
            Graphique();
            Graphique_classe();
        }

        private void Btn_Bilan_Click(object sender, RoutedEventArgs e)
        {
            classe = Classe.SelectedValue.ToString();
            index_classe = Classe.SelectedIndex;
            Bilan_Année bilan = new Bilan_Année();
            bilan.Show();
        }

        private void Eleve_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            effacer();
            Lire_moyennes();
            Graphique();
            Graphique_classe();
            Afficher_photo();
            Afficher_Sous_titre();
        }

        private void Classe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            effacer();
            Lire_moyennes();
            Graphique();
            Graphique_classe();
            Afficher_Sous_titre();
            Btn_Bilan.Content = "Bilan - " + Classe.SelectedValue.ToString();
        }

        private void Moyenne1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changer_Décimale("1");
            Activation_bouton_valider("1");
        }

        private void Moyenne2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changer_Décimale("2");
            Activation_bouton_valider("2");
        }

        private void Moyenne3_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changer_Décimale("3");
            Activation_bouton_valider("3");
        }

        private void Moyenne1_classe_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changer_Décimale("1");
            Activation_bouton_valider("1");
        }

        private void Moyenne2_classe_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changer_Décimale("2");
            Activation_bouton_valider("2");
        }

        private void Moyenne3_classe_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changer_Décimale("3");
            Activation_bouton_valider("3");
        }

        private void Afficher_photo()
        {
            string chemin = "Ressources\\" + Eleve.SelectedValue.ToString() + ".jpg";
            Photo.Source = new BitmapImage(new Uri(@chemin, UriKind.Relative));
        }

        private void Afficher_Sous_titre()
        {
            Sous_titre.Content = Eleve.SelectedValue + " - " + Classe.SelectedValue;
        }

        private void Visibilité_mode_modification(string num)
        {
            Button valider = (Button)this.FindName("Btn_Valider" + num);
            valider.Visibility = Visibility.Visible;
            Button annuler = (Button)this.FindName("Btn_Annuler" + num);
            annuler.Visibility = Visibility.Visible;
            Button modifier = (Button)this.FindName("Btn_Modifier" + num);
            modifier.Visibility = Visibility.Hidden;
            TextBox moyenne = (TextBox)this.FindName("Moyenne" + num);
            moyenne.Visibility = Visibility.Visible;
            Label moy = (Label)this.FindName("Moy" + num);
            moy.Visibility = Visibility.Hidden;
            TextBox moyenne_classe = (TextBox)this.FindName("Moyenne" + num + "_classe");
            moyenne_classe.Visibility = Visibility.Visible;
            Label moy_classe = (Label)this.FindName("Moy" + num + "_classe");
            moy_classe.Visibility = Visibility.Hidden;
        }

        private void Visibilité_mode_consultation(string num)
        {
            Button valider = (Button)this.FindName("Btn_Valider" + num);
            valider.Visibility = Visibility.Hidden;
            Button annuler = (Button)this.FindName("Btn_Annuler" + num);
            annuler.Visibility = Visibility.Hidden;
            Button modifier = (Button)this.FindName("Btn_Modifier" + num);
            modifier.Visibility = Visibility.Visible;
            TextBox moyenne = (TextBox)this.FindName("Moyenne" + num);
            moyenne.Visibility = Visibility.Hidden;
            Label moy = (Label)this.FindName("Moy" + num);
            moy.Visibility = Visibility.Visible;
            TextBox moyenne_classe = (TextBox)this.FindName("Moyenne" + num + "_classe");
            moyenne_classe.Visibility = Visibility.Hidden;
            Label moy_classe = (Label)this.FindName("Moy" + num + "_classe");
            moy_classe.Visibility = Visibility.Visible;
        }

        private void Changer_Décimale(string num)
        {            
            TextBox moy_élève = (TextBox)this.FindName("Moyenne" + num);
            TextBox moy_classe = (TextBox)this.FindName("Moyenne" + num + "_classe");            

            if (moy_élève.Text.Contains("."))
            {
                moy_élève.Text = moy_élève.Text.Replace('.', ',');
                moy_élève.SelectionStart = moy_élève.Text.IndexOf(',') + 1;
                moy_élève.SelectionLength = 0;
                moy_élève.Focus();
            }

            if (moy_classe.Text.Contains("."))
            {
                moy_classe.Text = moy_classe.Text.Replace('.', ',');
                moy_classe.SelectionStart = moy_classe.Text.IndexOf(',') + 1;
                moy_classe.SelectionLength = 0;
                moy_classe.Focus();
            }
        }

        private void Activation_bouton_valider(string num)
        {
            Button valider = (Button)this.FindName("Btn_Valider" + num);
            TextBox moy_élève = (TextBox)this.FindName("Moyenne" + num);
            TextBox moy_classe = (TextBox)this.FindName("Moyenne" + num + "_classe");
            Label moyenne_élève = (Label)this.FindName("Moy" + num);
            Label moyenne_classe = (Label)this.FindName("Moy" + num + "_classe");
            double test;
            bool moy_élève_OK = double.TryParse(moy_élève.Text, out test);
            bool moy_classe_OK = double.TryParse(moy_classe.Text, out test);

            if ((moy_élève_OK == true) || (moy_classe_OK == true))
            {
                valider.IsEnabled = true;
            }
            else if ((moyenne_élève.Content.ToString() != "") || (moyenne_classe.Content.ToString() != ""))
            {
                valider.IsEnabled = true;
            }
            else
                valider.IsEnabled = false;
            if ((moy_élève_OK == false) && (moy_élève.Text != ""))
            {
                valider.IsEnabled = false;
            }
            if ((moy_classe_OK == false) && (moy_classe.Text != ""))
            {
                valider.IsEnabled = false;
            }
        }

        private void Lire_moyennes()
        {
            LireMoyennesEleves lire_moyenne_élève = new LireMoyennesEleves();
            lire_moyenne_élève.Lecture_moyennes(Eleve, Classe);
            LireMoyennesEleves calcul_moyenne_générale = new LireMoyennesEleves();
            calcul_moyenne_générale.Calcul_moyenne_générale(Eleve, Classe);
            try
            {
                Moy1.Content = lire_moyenne_élève.Tri1.Content.ToString();
                Moy1_classe.Content = lire_moyenne_élève.Tri1Classe.Content.ToString();
                Moyenne1.Text = lire_moyenne_élève.Tri1.Content.ToString();
                Moyenne1_classe.Text = lire_moyenne_élève.Tri1Classe.Content.ToString();
            }
            catch { }

            try
            {
                Moy2.Content = lire_moyenne_élève.Tri2.Content.ToString();
                Moy2_classe.Content = lire_moyenne_élève.Tri2Classe.Content.ToString();
                Moyenne2.Text = lire_moyenne_élève.Tri2.Content.ToString();
                Moyenne2_classe.Text = lire_moyenne_élève.Tri2Classe.Content.ToString();
            }
            catch { }

            try
            {
                Moy3.Content = lire_moyenne_élève.Tri3.Content.ToString();
                Moy3_classe.Content = lire_moyenne_élève.Tri3Classe.Content.ToString();
                Moyenne3.Text = lire_moyenne_élève.Tri3.Content.ToString();
                Moyenne3_classe.Text = lire_moyenne_élève.Tri3Classe.Content.ToString();
        }
            catch { }

            try
            {
                Moyenne_générale.Text = calcul_moyenne_générale.Annee.Content.ToString();
                Moyenne_générale_classe.Text = calcul_moyenne_générale.AnneeClasse.Content.ToString();
            }
            catch { }
        }

        private void Saisie_moyenne(string trimestre, TextBox moyenne, TextBox moyenne_classe, Label moy, Label moy_classe, string visibilité)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();            
            
            string st1 = "Insert into Notes (Eleve, Classe, Trimestre, Moyenne) VALUES (@Eleve, @Classe, @Trimestre, @Moyenne)";
            string st2 = "Update Notes Set Moyenne = @Moyenne WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st3 = "Delete from Notes WHERE Eleve=@Eleve AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st4 = "Update Notes Set Moyenne = NULL WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st5 = "SELECT COUNT(Moyenne_classe) FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st6 = "SELECT COUNT(Moyenne) FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            SqlCommand cmd1 = new SqlCommand(st1, con);
            SqlCommand cmd2 = new SqlCommand(st2, con);
            SqlCommand cmd3 = new SqlCommand(st3, con);
            SqlCommand cmd4 = new SqlCommand(st4, con);
            SqlCommand cmd5 = new SqlCommand(st5, con);
            SqlCommand cmd6 = new SqlCommand(st6, con);
            int moyenne_présente = (int)cmd6.ExecuteScalar();
            int moyenne_classe_présente = (int)cmd5.ExecuteScalar();
            cmd1.Parameters.AddWithValue("@Eleve", Eleve.SelectedValue);
            cmd3.Parameters.AddWithValue("@Eleve", Eleve.SelectedValue);
            cmd1.Parameters.AddWithValue("@Classe", Classe.SelectedValue);
            cmd1.Parameters.AddWithValue("@Trimestre", trimestre);

            try
            {
                cmd1.Parameters.AddWithValue("@Moyenne", Convert.ToDouble(moyenne.Text));
                cmd2.Parameters.AddWithValue("@Moyenne", Convert.ToDouble(moyenne.Text));
            }
            catch { }

            //Insertion ligne
            if ((moyenne.Text != "") && (moyenne_présente == 0) && (moyenne_classe_présente == 0))
            {
                cmd1.ExecuteNonQuery();
            }

            //Insertion moyenne
            if ((moyenne.Text != "") && ((moyenne_présente != 0) || (moyenne_classe_présente != 0)))
            {
                cmd2.ExecuteNonQuery();
            }

            //Modification
            if ((moyenne.Text != "") && (moyenne_présente != 0))
            {
                cmd2.ExecuteNonQuery();
            }

            //Suppression ligne
            if ((moyenne_présente != 0) && (moyenne.Text == "") && (moyenne_classe_présente == 0))
            {
                cmd3.ExecuteNonQuery();
            }

            //Suppression moyenne
            if ((moyenne_présente != 0) && (moyenne.Text == "") && (moyenne_classe_présente != 0))
            {
                cmd4.ExecuteNonQuery();
            }

            con.Close();
            Visibilité_mode_consultation(visibilité);
        }

        private void Saisie_moyenne_classe(string trimestre, TextBox moyenne_classe, TextBox moyenne, Label moy, Label moy_classe, string visibilité)
        {
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            string st1 = "Insert into Notes (Eleve, Classe, Trimestre, Moyenne_classe) VALUES (@Eleve, @Classe, @Trimestre, @Moyenne_classe)";
            string st2 = "Update Notes Set Moyenne_classe = @Moyenne_classe WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st3 = "Update Notes Set Moyenne_classe = NULL WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st4 = "Delete from Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st5 = "SELECT COUNT(Moyenne) FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st6 = "SELECT COUNT(Moyenne_classe) FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            SqlCommand cmd1 = new SqlCommand(st1, con);            
            SqlCommand cmd2 = new SqlCommand(st2, con);
            SqlCommand cmd3 = new SqlCommand(st3, con);
            SqlCommand cmd4 = new SqlCommand(st4, con);
            SqlCommand cmd5 = new SqlCommand(st5, con);
            SqlCommand cmd6 = new SqlCommand(st6, con);
            int moyenne_présente = (int)cmd5.ExecuteScalar();
            int moyenne_classe_présente = (int)cmd6.ExecuteScalar();
            cmd1.Parameters.AddWithValue("@Eleve", Eleve.SelectedValue);
            cmd1.Parameters.AddWithValue("@Classe", Classe.SelectedValue);
            cmd1.Parameters.AddWithValue("@Trimestre", trimestre);
            try
            {
                cmd1.Parameters.AddWithValue("@Moyenne_classe", Convert.ToDouble(moyenne_classe.Text));
                cmd2.Parameters.AddWithValue("@Moyenne_classe", Convert.ToDouble(moyenne_classe.Text));
            }
            catch { }

            //Insertion ligne
            if ((moyenne_classe.Text != "") && (moyenne_présente == 0) && (moyenne_classe_présente == 0))
            {
                cmd1.ExecuteNonQuery();
            }

            //Insertion moyenne
            if ((moyenne_classe.Text != "") && ((moyenne_présente != 0) || (moyenne_classe_présente != 0)))
            {
                cmd2.ExecuteNonQuery();
            }

            //Modification
            if ((moyenne_classe.Text != "") && (moyenne_classe_présente != 0))
            {
                cmd2.ExecuteNonQuery();
            }

            //Suppression ligne
            if ((moyenne_classe_présente != 0) && (moyenne_classe.Text == "") && (moyenne_présente == 0))
            {
                cmd4.ExecuteNonQuery();
            }

            //Suppression moyenne
            if ((moyenne_classe_présente != 0) && (moyenne_classe.Text == "") && (moyenne_présente != 0))
            {
                cmd3.ExecuteNonQuery();
            }

            con.Close();
            Visibilité_mode_consultation(visibilité);
        }

        private void effacer()
        {
            Moyenne1.Text = "";
            Moyenne2.Text = "";
            Moyenne3.Text = "";
            Moy1.Content = "";
            Moy2.Content = "";
            Moy3.Content = "";
            Moyenne1_classe.Text = "";
            Moyenne2_classe.Text = "";
            Moyenne3_classe.Text = "";
            Moy1_classe.Content = "";
            Moy2_classe.Content = "";
            Moy3_classe.Content = "";
            Moyenne_générale.Text = "";
            Moyenne_générale_classe.Text = "";
            Moyennes_graphique.Clear();
            Moyennes_graphique_classe.Clear();
        }

        private ObservableCollection<Point> Moyennes_graphique = new ObservableCollection<Point>();
        private ObservableCollection<Point_classe> Moyennes_graphique_classe = new ObservableCollection<Point_classe>();

        private void Graphique()
        {
            try { Moyennes_graphique.Add(new Point("1er trimestre", Convert.ToDouble(Moy1.Content))); }
            catch { }
            try { Moyennes_graphique.Add(new Point("2ème trimestre", Convert.ToDouble(Moy2.Content))); }
            catch { }
            try { Moyennes_graphique.Add(new Point("3ème trimestre", Convert.ToDouble(Moy3.Content))); }
            catch { }
        }

        private void Graphique_classe()
        {
            try { Moyennes_graphique_classe.Add(new Point_classe("1er trimestre", Convert.ToDouble(Moy1_classe.Content))); }
            catch { }
            try { Moyennes_graphique_classe.Add(new Point_classe("2ème trimestre", Convert.ToDouble(Moy2_classe.Content))); }
            catch { }
            try { Moyennes_graphique_classe.Add(new Point_classe("3ème trimestre", Convert.ToDouble(Moy3_classe.Content))); }
            catch { }
        }

        public ObservableCollection<Point> Data
        {
            get { return Moyennes_graphique; }
        }

        public ObservableCollection<Point_classe> Data_classe
        {
            get { return Moyennes_graphique_classe; }
        }

        public class Point : DependencyObject
        {
            public static readonly DependencyProperty trimestre = DependencyProperty.Register("Trimestre", typeof(String), typeof(Point));

            public Point(String période, double note)
            {
                Trimestre = période;
                Moyenne = note;
            }

            public String Trimestre
            {
                get { return (String)GetValue(trimestre); }
                set { SetValue(trimestre, value); }
            }

            public static readonly DependencyProperty valeur = DependencyProperty.Register("Moyenne", typeof(double), typeof(Point));

            public double Moyenne
            {
                get { return (double)GetValue(valeur); }
                set { SetValue(valeur, value); }
            }
        }

        public class Point_classe : DependencyObject
        {
            public static readonly DependencyProperty trimestre = DependencyProperty.Register("Trimestre", typeof(String), typeof(Point_classe));

            public Point_classe(String période, double note)
            {
                Trimestre = période;
                Moyenne_classe = note;
            }

            public String Trimestre
            {
                get { return (String)GetValue(trimestre); }
                set { SetValue(trimestre, value); }
            }

            public static readonly DependencyProperty valeur1 = DependencyProperty.Register("Moyenne_classe", typeof(double), typeof(Point_classe));

            public double Moyenne_classe
            {
                get { return (double)GetValue(valeur1); }
                set { SetValue(valeur1, value); }
            }            
        }
    }
}