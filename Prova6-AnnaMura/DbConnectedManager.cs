using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova6_AnnaMura
{
    class DbConnectedManager
    {
        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = ProvaAgenti;" +
                                          "Integrated Security=true;";


        public static List<Agente> GetAgenti()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Agente";

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    var codiceFiscale = (string)reader["CodiceFiscale"];
                    var areaGeografica = (string)reader["AreaGeografica"];
                    var inizioAttivita = (int)reader["InizioAttivita"];

                    Agente a  = new Agente(nome, cognome, codiceFiscale, areaGeografica, inizioAttivita );
                    agenti.Add(a);
                }
                connection.Close();

                return agenti;
            }
        }

        public static List<Agente> GetAgentiArea(string areaGeografica)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Agente where AreaGeografica = @AreaGeografica";
                command.Parameters.AddWithValue("@AreaGeografica", areaGeografica);

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    var codiceFiscale = (string)reader["CodiceFiscale"];
                    var inizioAttivita = (int)reader["InizioAttivita"];

                    Agente a = new Agente(nome, cognome, codiceFiscale, areaGeografica, inizioAttivita);
                    agenti.Add(a);
                }
                connection.Close();

                return agenti;
            }
        }

        public static List<Agente> GetAgentiAnni(int anni)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Agente";

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    var codiceFiscale = (string)reader["CodiceFiscale"];
                    var areaGeografica = (string)reader["AreaGeografica"];
                    var inizioAttivita = (int)reader["InizioAttivita"];
                    int anniServizio = 2021 - inizioAttivita; 

                    Agente a = new Agente(nome, cognome, codiceFiscale, areaGeografica, anniServizio);
                    agenti.Add(a);
                }
                connection.Close();

                return agenti;
            }
        }

        public static bool VerificaEsistenzaAgente(string codiceFiscale)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from dbo.Agente where CodiceFiscale = @codiceFiscale";
                    command.Parameters.AddWithValue("@codiceFiscale", codiceFiscale);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        return true;
                    connection.Close();
                    return false;
                }
            }

        public static void AddAgente(Agente agente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Agente values(@Nome, @Cognome, @CodiceFiscale, @AreaGeografica, @InizioAttivita)";
                command.Parameters.AddWithValue("@Nome", agente.Nome);
                command.Parameters.AddWithValue("@Cognome", agente.Cognome);
                command.Parameters.AddWithValue("@CodiceFiscale", agente.CodiceFiscale);
                command.Parameters.AddWithValue("@AreaGeografica", agente.AreaGeografica);
                command.Parameters.AddWithValue("@InizioAttivita", agente.InizioAttivita);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
