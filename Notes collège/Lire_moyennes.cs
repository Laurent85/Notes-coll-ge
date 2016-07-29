using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Controls;


namespace Notes_collège
    {
    class Lire_moyennes:Bilan_Année
        {

        private string connectionString = "Data Source=PCLAURENT\\SQLEXPRESS;Initial Catalog=Notes;Integrated Security=True"; 
       public Label tri1 = new Label();
       public Label tri2 = new Label();
       public Label tri3 = new Label();
       public Label tri1_classe = new Label();
       public Label tri2_classe = new Label();
       public Label tri3_classe = new Label();
       public Label annee = new Label();
       public Label annee_classe= new Label();
               
        public void Lecture_moyennes(string eleve, string niveau)
            {
            string st = "SELECT Moyenne FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='1er trimestre'";
            string st1 = "SELECT Moyenne FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='2ème trimestre'";
            string st2 = "SELECT Moyenne FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='3ème trimestre'";
            string st3 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='1er trimestre'";
            string st4 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='2ème trimestre'";
            string st5 = "SELECT Moyenne_classe FROM Notes WHERE Eleve='" + eleve + "' AND Classe='" + niveau + "' AND Trimestre='3ème trimestre'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(st, con);
            SqlCommand cmd1 = new SqlCommand(st1, con);
            SqlCommand cmd2 = new SqlCommand(st2, con);
            SqlCommand cmd3 = new SqlCommand(st3, con);
            SqlCommand cmd4 = new SqlCommand(st4, con);
            SqlCommand cmd5 = new SqlCommand(st5, con);
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
                tri1.Name = "moy1_" + eleve;
                tri1.Content = reader["Moyenne"].ToString();                         
                }
            catch { }
            finally { reader.Close(); }

            reader1 = cmd1.ExecuteReader();
            reader1.Read();
            try
                {
                tri2.Name = "moy2_" + eleve;
                tri2.Content = reader1["Moyenne"].ToString();
                }
            catch { }
            finally { reader1.Close(); }

            reader2 = cmd2.ExecuteReader();
            reader2.Read();
            try
                {
                 tri3.Name = "moy3_" + eleve;
                 tri3.Content = reader2["Moyenne"].ToString();
                }
            catch { }
            finally { reader2.Close(); }

            reader3 = cmd3.ExecuteReader();
            reader3.Read();
            try
                {
                tri1_classe.Name = "moy1_classe_" + eleve;
                tri1_classe.Content = reader3["Moyenne_classe"].ToString();
                }
            catch { }
            finally { reader3.Close(); }

            reader4 = cmd4.ExecuteReader();
            reader4.Read();
            try
                {
                tri2_classe.Name = "moy2_classe_" + eleve;
                tri2_classe.Content = reader4["Moyenne_classe"].ToString();
                }
            catch { }
            finally { reader4.Close(); }

            reader5 = cmd5.ExecuteReader();
            reader5.Read();
            try
                {
                tri3_classe.Name = "moy3_classe_" + eleve;
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
                annee.Name = "moy_annee_" + eleve;
                annee.Content = cmd.ExecuteScalar().ToString();                
                }
            catch { }

            try
                {
                annee_classe.Name = "moy_annee_classe_" + eleve;
                annee_classe.Content = cmd1.ExecuteScalar().ToString();
                }
            catch { }
            finally { con.Close(); }
            }
        }
    }
