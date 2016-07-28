using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Notes_collège
    {
    class Lire_moyennes:Principal
        {

        private string connectionString = "Data Source=PCLAURENT\\SQLEXPRESS;Initial Catalog=Notes;Integrated Security=True";
        public void Lire_moyennes()
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
        }
    }
