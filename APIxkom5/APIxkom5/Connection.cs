using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace APIxkom5 {
    internal class Connection {

        private MySqlConnection m_connection;
        private MySqlCommand m_command = new MySqlCommand();
        private MySqlDataReader dataReader;

        private List<Meeting> list = new List<Meeting>();

        private const string selectSql = "SELECT * FROM meetings ";

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

            string connectionString = GetConnectionString();
            m_connection = new MySqlConnection(connectionString);
            m_command = new MySqlCommand(selectSql, m_connection);

            m_connection.Open();
            dataReader = m_command.ExecuteReader();

            while (dataReader.Read()) {

                int id = (int)dataReader["MeetingId"];
                string name = dataReader["MeetingName"].ToString();

                if (name.Equals(meetingName)){

                    m_connection.Close();
                    return id.ToString();
                }
            }
            return null;
        }

        public string AddMeeting(string meetingName) {
            return Execute(m_command.CommandText = "INSERT INTO meetings (MeetingName) VALUES ('" + meetingName + "')");
        }

        public string RemoveMeeting(string meetingName) {
            return Execute(m_command.CommandText = "DELETE FROM meetings WHERE MeetingName = '" + meetingName + "'");
        }

        public string AddUser(User user, string meetingName) {
            string id = ReturnMeetingByName(meetingName);
            return Execute(m_command.CommandText = "INSERT INTO users (MeetingId, UserName, UserMail) VALUES ('"+ id + "','" + user.UserName + "','" + user.Email + "')");
        }
            
        private string Execute(String query) {

            string connectionString = GetConnectionString();     
            m_connection = new MySqlConnection(connectionString);

            try {
                m_connection.Open();
                m_command = new MySqlCommand(query, m_connection);
                m_command.ExecuteNonQuery();

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