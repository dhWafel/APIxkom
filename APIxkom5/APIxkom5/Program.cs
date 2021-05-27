using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIxkom5 {
    internal class Program {
        static void Main(string[] args) {

            MeetingController meetingController = new MeetingController();
            Connection connection = new Connection();

   
            Menu menu = new Menu(connection, meetingController);
            menu.StartMenu();

            //connection.execute();


        }

    }
}