using System;
using System.Collections.Generic;
using System.Data;

namespace APIxkom5 {
    internal class Program {
        static void Main(string[] args) {

            MeetingController meetingController = new MeetingController();
  
            Menu menu = new Menu(meetingController);
            menu.StartMenu();
        }
    }
}