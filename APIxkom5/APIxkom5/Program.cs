using System;

namespace APIxkom5 {
    class Program {
        static void Main(string[] args) {
            MeetingController meetingController = new MeetingController();


            Console.WriteLine("Hello World!");

            
            meetingController.AddMeeting(new Meeting());

            Console.WriteLine();


        }
    }
}