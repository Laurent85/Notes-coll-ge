using System.Data.SqlClient;
using System.Windows.Controls;

namespace Notes_collège
{
    internal class LireMoyennesEleves
    {
        private string connectionString = "Data Source=laurent\\sqlexpress;Initial Catalog=Notes;Persist Security Info=True;User ID=sa;Password=sa;Pooling=False";
        //x private string connectionString = "Data Source=PCLAURENT\\SQLEXPRESS;Initial Catalog=Notes;Integrated Security=True";

        public Label Tri1 = new Label();
        public Label Tri2 = new Label();
        public Label Tri3 = new Label();
        public Label Tri1Classe = new Label();
        public Label Tri2Classe = new Label();
        public Label Tri3Classe = new Label();
        public Label Annee = new Label();
        public Label AnneeClasse = new Label();

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
                Tri1.Content = reader["Moyenne"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader.Close(); }

            reader1 = cmd1.ExecuteReader();
            reader1.Read();
            try
            {
                Tri2.Content = reader1["Moyenne"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader1.Close(); }

            reader2 = cmd2.ExecuteReader();
            reader2.Read();
            try
            {
                Tri3.Content = reader2["Moyenne"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader2.Close(); }

            reader3 = cmd3.ExecuteReader();
            reader3.Read();
            try
            {
                Tri1Classe.Content = reader3["Moyenne_classe"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader3.Close(); }

            reader4 = cmd4.ExecuteReader();
            reader4.Read();
            try
            {
                Tri2Classe.Content = reader4["Moyenne_classe"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader4.Close(); }

            reader5 = cmd5.ExecuteReader();
            reader5.Read();
            try
            {
                Tri3Classe.Content = reader5["Moyenne_classe"].ToString();
            }
            catch
            {
                // ignored
            }
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
                Tri1.Content = reader["Moyenne"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader.Close(); }

            reader1 = cmd1.ExecuteReader();
            reader1.Read();
            try
            {
                Tri2.Content = reader1["Moyenne"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader1.Close(); }

            reader2 = cmd2.ExecuteReader();
            reader2.Read();
            try
            {
                Tri3.Content = reader2["Moyenne"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader2.Close(); }

            reader3 = cmd3.ExecuteReader();
            reader3.Read();
            try
            {
                Tri1Classe.Content = reader3["Moyenne_classe"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader3.Close(); }

            reader4 = cmd4.ExecuteReader();
            reader4.Read();
            try
            {
                Tri2Classe.Content = reader4["Moyenne_classe"].ToString();
            }
            catch
            {
                // ignored
            }
            finally { reader4.Close(); }

            reader5 = cmd5.ExecuteReader();
            reader5.Read();
            try
            {
                Tri3Classe.Content = reader5["Moyenne_classe"].ToString();
            }
            catch
            {
                // ignored
            }
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
                Annee.Content = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                // ignored
            }

            try
            {
                AnneeClasse.Content = cmd1.ExecuteScalar().ToString();
            }
            catch
            {
                // ignored
            }
            con.Close();
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
                Annee.Content = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                // ignored
            }

            try
            {
                AnneeClasse.Content = cmd1.ExecuteScalar().ToString();
            }
            catch
            {
                // ignored
            }
            con.Close();
        }
    }
}