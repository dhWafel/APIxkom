using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIxkom5 {
    internal class Connection {

        private MySqlConnection m_connection;
        private MySqlCommand m_command = new MySqlCommand();
        private MySqlDataReader dataReader;

        private List<Meeting> list = new List<Meeting>();

        private const string selectSql = "SELECT * FROM meetings ";
        private const string selectByNameSql = "SELECT * FROM `meetings` WHERE MeetingName = {0}";


        public List<Meeting> GetMeetings() {

            string connectionString = GetConnectionString();
            m_connection = new MySqlConnection(connectionString);
            m_command = new MySqlCommand(selectSql, m_connection);

            m_connection.Open();
            dataReader = m_command.ExecuteReader();

            while (dataReader.Read()) {
                int id = (int)dataReader["MeetingId"];
                string name = dataReader["MeetingName"].ToString();
                Meeting m = new Meeting(name);
                list.Add(m);
            }
            m_connection.Close();
            return list;
        }

        public string ReturnMeetingByName(string meetingName) {
            return Execute(String.Format(selectByNameSql, meetingName));
        }

        public string AddMeeting(string meetingName) {
            return Execute(m_command.CommandText = "INSERT INTO meetings (MeetingName) VALUES ('" + meetingName + "')");
        }

        public string RemoveMeeting(string meetingName) {
            return Execute(m_command.CommandText = "DELETE FROM meetings WHERE MeetingName = '" + meetingName + "'");
        }

        public string AddUser(User user) {
            return Execute(m_command.CommandText = "INSERT INTO users (UserName, UserMail) VALUES ('" + user.UserName + "," + user.Email + "')");
        }
            
        private string Execute(String query) {

            string connectionString = GetConnectionString();     
            m_connection = new MySqlConnection(connectionString);

            try {

                m_connection.Open();
                m_command = new MySqlCommand(query, m_connection);
                m_command.ExecuteNonQuery();
                Console.WriteLine("GOTOWE");

            } catch (Exception ex) {
                Console.WriteLine("Błąd: " + ex.Message);
            } finally {
                if (m_connection.State == ConnectionState.Open) {
                    m_connection.Close();
                }
            } 
            return "";
        } 

        private static string GetConnectionString() {
            string host = "localhost";
            string dbName = "challenge";
            string login = "root";

            string connectionString =
                "server=" + host + "," +
                ";Initial Catalog=" + dbName +
                ";User Id=" + login + ";";

            return connectionString;
        }
    }
}