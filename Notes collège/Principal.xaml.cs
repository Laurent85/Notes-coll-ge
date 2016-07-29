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
    /// Logique d'interaction pour Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        //private string connectionString = "Data Source=laurent\\sqlexpress;Initial Catalog=Notes;Persist Security Info=True;User ID=sa;Password=sa;Pooling=False";
        //private string connectionString = "Data Source=manceau.dtdns.net\\sqlexpress,1433;Network Library=DBMSSOCN;Initial Catalog=Notes;Persist Security Info=True;User ID=sa;Password=sa;Pooling=False";
        private string connectionString = "Data Source=PCLAURENT\\SQLEXPRESS;Initial Catalog=Notes;Integrated Security=True";
        public static string elève = "";
        public static string classe = "";
        public static string moy1_Baptiste = "";
        public static string moy2_Baptiste = "";
        public static string moy3_Baptiste = "";
        public static double moy1 = 0;
        public static double moy2 = 0;
        public static double moy3 = 0;
        public static double moy1_classe = 0;
        public static double moy2_classe = 0;
        public static double moy3_classe = 0;

        public Principal()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
            Lire_moyennes_classe();
            Graphique();
            Graphique_classe();
            Visibilité_mode_modification("1");
            //if (Moyenne1.Text == "") { Moyenne1_classe.Visibility = Visibility.Hidden; }
            Moyenne1.Focus();
            Moyenne1.SelectAll();
        }

        private void Btn_Modifier2_Click(object sender, RoutedEventArgs e)
        {
            effacer();
            Lire_moyennes();
            Lire_moyennes_classe();
            Graphique();
            Graphique_classe();
            Visibilité_mode_modification("2");
            //if (Moyenne2.Text == "") { Moyenne2_classe.Visibility = Visibility.Hidden; }
            Moyenne2.Focus();
            Moyenne2.SelectAll();
        }

        private void Btn_Modifier3_Click(object sender, RoutedEventArgs e)
        {
            effacer();
            Lire_moyennes();
            Lire_moyennes_classe();
            Graphique();
            Graphique_classe();
            Visibilité_mode_modification("3");
            //if (Moyenne3.Text == "") { Moyenne3_classe.Visibility = Visibility.Hidden; }
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
            Lire_moyennes();            
            Calcul_moyenne_générale();            
            Saisie_moyenne_classe("1er trimestre", Moyenne1_classe, Moyenne1, Moy1, Moy1_classe, "1");
            effacer();
            Lire_moyennes();
            Lire_moyennes_classe();
            Calcul_moyenne_générale();
            Moyennes_graphique.Clear();
            Moyennes_graphique_classe.Clear();
            Graphique();
            Graphique_classe();
        }

        private void Btn_Valider2_Click(object sender, RoutedEventArgs e)
        {
            Saisie_moyenne("2ème trimestre", Moyenne2, Moyenne2_classe, Moy2, Moy2_classe, "2");            
            Lire_moyennes();            
            Calcul_moyenne_générale();            
            Saisie_moyenne_classe("2ème trimestre", Moyenne2_classe, Moyenne2, Moy2, Moy2_classe, "2");
            effacer();
            Lire_moyennes();
            Lire_moyennes_classe();
            Calcul_moyenne_générale();
            Moyennes_graphique.Clear();
            Moyennes_graphique_classe.Clear();
            Graphique();
            Graphique_classe();
        }

        private void Btn_Valider3_Click(object sender, RoutedEventArgs e)
        {
            Saisie_moyenne("3ème trimestre", Moyenne3, Moyenne3_classe, Moy3, Moy3_classe, "3");            
            Lire_moyennes();            
            Calcul_moyenne_générale();            
            Saisie_moyenne_classe("3ème trimestre", Moyenne3_classe, Moyenne3, Moy3, Moy3_classe, "3");
            effacer();
            Lire_moyennes();
            Lire_moyennes_classe();
            Calcul_moyenne_générale();
            Moyennes_graphique.Clear();
            Moyennes_graphique_classe.Clear();
            Graphique();
            Graphique_classe();
        }

        private void Classe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            effacer();
            Lire_moyennes();
            Lire_moyennes_classe();
            Calcul_moyenne_générale();
            Graphique();
            Graphique_classe();
            Afficher_Sous_titre();
        }

        private void Eleve_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            effacer();
            Lire_moyennes();
            Lire_moyennes_classe();
            Calcul_moyenne_générale();
            Graphique();
            Graphique_classe();
            Afficher_photo();
            Afficher_Sous_titre();
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

        private void Lire_moyennes()
        {
            string st = "SELECT Moyenne FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='1er trimestre'";
            string st1 = "SELECT Moyenne FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='2ème trimestre'";
            string st2 = "SELECT Moyenne FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='3ème trimestre'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(st, con);
            SqlCommand cmd1 = new SqlCommand(st1, con);
            SqlCommand cmd2 = new SqlCommand(st2, con);
            SqlDataReader reader;
            SqlDataReader reader1;
            SqlDataReader reader2;

            con.Open();

            reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                Moy1.Content = reader["Moyenne"].ToString();
                Moyenne1.Text = reader["Moyenne"].ToString();
            }
            catch { }
            finally { reader.Close(); }

            reader1 = cmd1.ExecuteReader();
            reader1.Read();
            try
            {
                Moy2.Content = reader1["Moyenne"].ToString();
                Moyenne2.Text = reader1["Moyenne"].ToString();
            }
            catch { }
            finally { reader1.Close(); }

            reader2 = cmd2.ExecuteReader();
            reader2.Read();
            try
            {
                Moy3.Content = reader2["Moyenne"].ToString();
                Moyenne3.Text = reader2["Moyenne"].ToString();
            }
            catch { }
            finally { reader2.Close(); }
            con.Close();
        }

        private void Lire_moyennes_classe()
        {
            string st = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='1er trimestre'";
            string st1 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='2ème trimestre'";
            string st2 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='3ème trimestre'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(st, con);
            SqlCommand cmd1 = new SqlCommand(st1, con);
            SqlCommand cmd2 = new SqlCommand(st2, con);
            SqlDataReader reader;
            SqlDataReader reader1;
            SqlDataReader reader2;

            con.Open();

            reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                Moy1_classe.Content = reader["Moyenne_classe"].ToString();
                Moyenne1_classe.Text = reader["Moyenne_classe"].ToString();
            }
            catch { }
            finally { reader.Close(); }

            reader1 = cmd1.ExecuteReader();
            reader1.Read();
            try
            {
                Moy2_classe.Content = reader1["Moyenne_classe"].ToString();
                Moyenne2_classe.Text = reader1["Moyenne_classe"].ToString();
            }
            catch { }
            finally { reader1.Close(); }

            reader2 = cmd2.ExecuteReader();
            reader2.Read();
            try
            {
                Moy3_classe.Content = reader2["Moyenne_classe"].ToString();
                Moyenne3_classe.Text = reader2["Moyenne_classe"].ToString();
            }
            catch { }
            finally { reader2.Close(); }
            con.Close();
        }

        private void Calcul_moyenne_générale()
        {
            string st = "SELECT CAST(AVG(Moyenne) as decimal(18,2)) FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "'";
            string st1 = "SELECT CAST(AVG(Moyenne_classe) as decimal(18,2)) FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(st, con);
            SqlCommand cmd1 = new SqlCommand(st1, con);
            con.Open();

            try
            {                
                Moyenne_générale.Text = cmd.ExecuteScalar().ToString();
            }
            catch { }

            try
            {                
                Moyenne_générale_classe.Text = cmd1.ExecuteScalar().ToString();
            }
            catch { }
            finally { con.Close(); }
        }

        private void Saisie_moyenne(string trimestre, TextBox moyenne, TextBox moyenne_classe, Label moy, Label moy_classe, string visibilité)
        {
            string st1 = "SELECT Moyenne FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd1 = new SqlCommand(st1, con);                   

            con.Open();
            string st = "Insert into Notes (Eleve, Classe, Trimestre, Moyenne) VALUES (@Eleve, @Classe, @Trimestre, @Moyenne)";
            string st2 = "Update Notes Set Moyenne = @Moyenne WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st3 = "Delete from Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st4 = "Update Notes Set Moyenne = NULL WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            SqlCommand cmd = new SqlCommand(st, con);
            SqlCommand cmd2 = new SqlCommand(st2, con);
            SqlCommand cmd3 = new SqlCommand(st3, con);
            SqlCommand cmd4 = new SqlCommand(st4, con);
            cmd.Parameters.AddWithValue("@Eleve", Eleve.SelectedValue);
            cmd.Parameters.AddWithValue("@Classe", Classe.SelectedValue);
            cmd.Parameters.AddWithValue("@Trimestre", trimestre);
            try
            {
                cmd.Parameters.AddWithValue("@Moyenne", Convert.ToDouble(moyenne.Text));
                cmd2.Parameters.AddWithValue("@Moyenne", Convert.ToDouble(moyenne.Text));
            }
            catch { }
            
            //Insertion ligne
            if ((moy.Content.ToString() == "") && (moy_classe.Content.ToString() == "") && (moyenne.Text != ""))
            {
                cmd.ExecuteNonQuery();
            }

            //Insertion moyenne
            if ((moy.Content.ToString() == "") && (moy_classe.Content.ToString() != "") && (moyenne.Text != ""))
            {
                cmd2.ExecuteNonQuery();
            }

            //Modification
            if ((moy.Content.ToString() != "") && (moyenne.Text != ""))
            {
                cmd2.ExecuteNonQuery();
            }

            //Suppression ligne
            if ((moy.Content.ToString() != "") && (moyenne.Text == "") && (moy_classe.Content.ToString() == ""))
            {
                cmd3.ExecuteNonQuery();
            }

            //Suppression moyenne
            if ((moy.Content.ToString() != "") && (moyenne.Text == "") && (moy_classe.Content.ToString() != ""))
            {
                cmd4.ExecuteNonQuery();
            }

            con.Close();
            Visibilité_mode_consultation(visibilité);
        }

        private void Saisie_moyenne_classe(string trimestre, TextBox moyenne_classe, TextBox moyenne, Label moy, Label moy_classe, string visibilité)
        {
            string st1 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";

            SqlConnection con = new SqlConnection(connectionString);
            
            con.Open();
            string st = "Insert into Notes (Eleve, Classe, Trimestre, Moyenne_classe) VALUES (@Eleve, @Classe, @Trimestre, @Moyenne_classe)";
            string st2 = "Update Notes Set Moyenne_classe = @Moyenne_classe WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st3 = "Update Notes Set Moyenne_classe = NULL WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            string st4 = "Delete from Notes WHERE Eleve='" + Eleve.SelectedValue + "' AND Classe='" + Classe.SelectedValue + "' AND Trimestre='" + trimestre + "'";
            SqlCommand cmd = new SqlCommand(st, con);
            SqlCommand cmd2 = new SqlCommand(st2, con);
            SqlCommand cmd3 = new SqlCommand(st3, con);
            SqlCommand cmd4 = new SqlCommand(st4, con);
            cmd.Parameters.AddWithValue("@Eleve", Eleve.SelectedValue);
            cmd.Parameters.AddWithValue("@Classe", Classe.SelectedValue);
            cmd.Parameters.AddWithValue("@Trimestre", trimestre);
            try
            {
                cmd.Parameters.AddWithValue("@Moyenne_classe", Convert.ToDouble(moyenne_classe.Text));
                cmd2.Parameters.AddWithValue("@Moyenne_classe", Convert.ToDouble(moyenne_classe.Text));
            }
            catch { }

            //Insertion ligne
            if ((moy.Content.ToString() == "") && (moy_classe.Content.ToString() == "") && (moyenne_classe.Text != ""))
            {
                cmd.ExecuteNonQuery();
            }

            //Insertion moyenne
            if ((moy.Content.ToString() != "") && (moy_classe.Content.ToString() == "") && (moyenne_classe.Text != ""))
            {
                cmd2.ExecuteNonQuery();
            }

            //Modification
            if ((moy_classe.Content.ToString() != "") && (moyenne_classe.Text != ""))
            {
                cmd2.ExecuteNonQuery();
            }

            //Suppression moyenne
            if ((moy_classe.Content.ToString() != "") && (moyenne_classe.Text == ""))
            {
                cmd3.ExecuteNonQuery();
            }

            //Suppression ligne
            if ((moy.Content.ToString() == "") && (moy_classe.Content.ToString() != "") && (moyenne_classe.Text == ""))
            {
                cmd4.ExecuteNonQuery();
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

        private void Btn_Bilan_Click(object sender, RoutedEventArgs e)
        {
            classe = Classe.SelectedValue.ToString();           
            Bilan_Année bilan = new Bilan_Année();
            bilan.Show();
        }
    }
}