using System.Data.SqlClient;
using System.Windows.Controls;

namespace Notes_collège
{
    internal class Lire_Moyennes_eleves
    {
        private string connectionString = "Data Source=laurent\\sqlexpress;Initial Catalog=Notes;Persist Security Info=True;User ID=sa;Password=sa;Pooling=False";
        //private string connectionString = "Data Source=PCLAURENT\\SQLEXPRESS;Initial Catalog=Notes;Integrated Security=True";

        public Label tri1 = new Label();
        public Label tri2 = new Label();
        public Label tri3 = new Label();
        public Label tri1_classe = new Label();
        public Label tri2_classe = new Label();
        public Label tri3_classe = new Label();
        public Label annee = new Label();
        public Label annee_classe = new Label();

        public void Lecture_moyennes(string eleve, string niveau)
        {
            string str = "SELECT Moyenne FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='1er trimestre'";
            string str1 = "SELECT Moyenne FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='2ème trimestre'";
            string str2 = "SELECT Moyenne FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='3ème trimestre'";
            string str3 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='1er trimestre'";
            string str4 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='2ème trimestre'";
            string str5 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='3ème trimestre'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(str, con);
            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlCommand cmd2 = new SqlCommand(str2, con);
            SqlCommand cmd3 = new SqlCommand(str3, con);
            SqlCommand cmd4 = new SqlCommand(str4, con);
            SqlCommand cmd5 = new SqlCommand(str5, con);
            SqlDataReader reader;
            SqlDataReader reader1;
            SqlDataReader reader2;
            SqlDataReader reader3;
            SqlDataReader reader4;
            SqlDataReader reader5;

            con.Open();

            reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                tri1.Content = reader["Moyenne"].ToString();
            }
            catch { }
            finally { reader.Close(); }

            reader1 = cmd1.ExecuteReader();
            reader1.Read();
            try
            {
                tri2.Content = reader1["Moyenne"].ToString();
            }
            catch { }
            finally { reader1.Close(); }

            reader2 = cmd2.ExecuteReader();
            reader2.Read();
            try
            {
                tri3.Content = reader2["Moyenne"].ToString();
            }
            catch { }
            finally { reader2.Close(); }

            reader3 = cmd3.ExecuteReader();
            reader3.Read();
            try
            {
                tri1_classe.Content = reader3["Moyenne_classe"].ToString();
            }
            catch { }
            finally { reader3.Close(); }

            reader4 = cmd4.ExecuteReader();
            reader4.Read();
            try
            {
                tri2_classe.Content = reader4["Moyenne_classe"].ToString();
            }
            catch { }
            finally { reader4.Close(); }

            reader5 = cmd5.ExecuteReader();
            reader5.Read();
            try
            {
                tri3_classe.Content = reader5["Moyenne_classe"].ToString();
            }
            catch { }
            finally { reader5.Close(); }
            con.Close();
        }

        public void Lecture_moyennes(ComboBox élève, ComboBox classe)
        {
            string str = "SELECT Moyenne FROM Notes WHERE Eleve='" + élève.SelectedValue + "' AND Classe='" + classe.SelectedValue + "' AND Trimestre='1er trimestre'";
            string str1 = "SELECT Moyenne FROM Notes WHERE Eleve='" + élève.SelectedValue + "' AND Classe='" + classe.SelectedValue + "' AND Trimestre='2ème trimestre'";
            string str2 = "SELECT Moyenne FROM Notes WHERE Eleve='" + élève.SelectedValue + "' AND Classe='" + classe.SelectedValue + "' AND Trimestre='3ème trimestre'";
            string str3 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + élève.SelectedValue + "' AND Classe='" + classe.SelectedValue + "' AND Trimestre='1er trimestre'";
            string str4 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + élève.SelectedValue + "' AND Classe='" + classe.SelectedValue + "' AND Trimestre='2ème trimestre'";
            string str5 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + élève.SelectedValue + "' AND Classe='" + classe.SelectedValue + "' AND Trimestre='3ème trimestre'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(str, con);
            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlCommand cmd2 = new SqlCommand(str2, con);
            SqlCommand cmd3 = new SqlCommand(str3, con);
            SqlCommand cmd4 = new SqlCommand(str4, con);
            SqlCommand cmd5 = new SqlCommand(str5, con);
            SqlDataReader reader;
            SqlDataReader reader1;
            SqlDataReader reader2;
            SqlDataReader reader3;
            SqlDataReader reader4;
            SqlDataReader reader5;

            con.Open();

            reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                tri1.Content = reader["Moyenne"].ToString();
            }
            catch { }
            finally { reader.Close(); }

            reader1 = cmd1.ExecuteReader();
            reader1.Read();
            try
            {
                tri2.Content = reader1["Moyenne"].ToString();
            }
            catch { }
            finally { reader1.Close(); }

            reader2 = cmd2.ExecuteReader();
            reader2.Read();
            try
            {
                tri3.Content = reader2["Moyenne"].ToString();
            }
            catch { }
            finally { reader2.Close(); }

            reader3 = cmd3.ExecuteReader();
            reader3.Read();
            try
            {
                tri1_classe.Content = reader3["Moyenne_classe"].ToString();
            }
            catch { }
            finally { reader3.Close(); }

            reader4 = cmd4.ExecuteReader();
            reader4.Read();
            try
            {
                tri2_classe.Content = reader4["Moyenne_classe"].ToString();
            }
            catch { }
            finally { reader4.Close(); }

            reader5 = cmd5.ExecuteReader();
            reader5.Read();
            try
            {
                tri3_classe.Content = reader5["Moyenne_classe"].ToString();
            }
            catch { }
            finally { reader5.Close(); }
            con.Close();
        }

        public void Calcul_moyenne_générale(string eleve, string niveau)
        {
            string st = "SELECT CAST(AVG(Moyenne) as decimal(18,2)) FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "'";
            string st1 = "SELECT CAST(AVG(Moyenne_classe) as decimal(18,2)) FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(st, con);
            SqlCommand cmd1 = new SqlCommand(st1, con);
            con.Open();

            try
            {
                annee.Content = cmd.ExecuteScalar().ToString();
            }
            catch { }

            try
            {
                annee_classe.Content = cmd1.ExecuteScalar().ToString();
            }
            catch { }
            finally { con.Close(); }
        }

        public void Calcul_moyenne_générale(ComboBox élève, ComboBox classe)
        {
            string st = "SELECT CAST(AVG(Moyenne) as decimal(18,2)) FROM Notes WHERE Eleve='" + élève.SelectedValue + "' AND Classe='" + classe.SelectedValue + "'";
            string st1 = "SELECT CAST(AVG(Moyenne_classe) as decimal(18,2)) FROM Notes WHERE Eleve='" + élève.SelectedValue + "' AND Classe='" + classe.SelectedValue + "'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(st, con);
            SqlCommand cmd1 = new SqlCommand(st1, con);
            con.Open();

            try
            {
                annee.Content = cmd.ExecuteScalar().ToString();
            }
            catch { }

            try
            {
                annee_classe.Content = cmd1.ExecuteScalar().ToString();
            }
            catch { }
            finally { con.Close(); }
        }
    }
}