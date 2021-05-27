using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIxkom5 {
    class Connection {

        private SqlConnection connection;


        public void execute(string instruction) 
        {
            //SqlCommand sc = connection.CreateCommand();
            

        }

        private bool Connect() {
            
            string connectionString = GetConnectionString();
            connection = new SqlConnection(connectionString);
            try {
                connection.Open();


                //TU OPERACJE NA BAZIE DANYCH
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Połączenie OK");
                Console.ResetColor();
                //Console.WriteLine("Połączenie OK");
            } catch (SqlException se) {
                Console.WriteLine("Błąd: " + se.StackTrace);
            } finally {
                if (connection.State == ConnectionState.Open) {
                    Console.WriteLine("Zamknięcie połączenia");
                    connection.Close();
                }
            }

            return true;
        } 


        private static string GetConnectionString() {
            string host = "localhost";
            int tcpPort = 1433;
            string dbName = "MyDatabaseFernus";
            string login = "DESKTOP-8RSPAER,28ferny";
            string password = "";

            string connectionString =
                "Data Source=" + host + "," + tcpPort +
                ";Initial Catalog=" + dbName +
                ";User Id=" + login +
                ";Password=" + password + ";";

            return connectionString;
        }
    }
}
