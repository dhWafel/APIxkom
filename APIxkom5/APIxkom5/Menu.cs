using System;
using System.Collections.Generic;

namespace APIxkom5 {
    class Menu {

        private MeetingController meetingController;

        private int activeOptionMenu = 0;


        public Menu(MeetingController meetingController) {

            this.meetingController = meetingController;
        }

        public string[] optionsMenu = { "Dodaj spotkanie", "Usuń spotkanie",
                                        "Pokaż listę spotkań", "Dodaj uczestnika",
                                        "Koniec"
        };


        public void StartMenu() {

            Console.Title = "Menadżer spotkań";
            Console.CursorVisible = false;

            while (true) {
                ShowMenu();
                ChoiceOption();
                RunOption();
            }
        }

        private void ShowMenu() {

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(">>> Nasze spotkania <<<");
            Console.WriteLine();

            for(int i = 0; i < optionsMenu.Length; i++) {

                if (i == activeOptionMenu) {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0,-35}", optionsMenu[i]);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                } else {
                    Console.WriteLine(optionsMenu[i]);
                }
            }
        }

        private void ChoiceOption() {

            do {
                ConsoleKeyInfo choiceKey = Console.ReadKey();

                if (choiceKey.Key == ConsoleKey.UpArrow) {
                    activeOptionMenu = (activeOptionMenu > 0) ? activeOptionMenu - 1 : optionsMenu.Length - 1;
                    ShowMenu();
                } else if (choiceKey.Key == ConsoleKey.DownArrow) {
                    activeOptionMenu = (activeOptionMenu + 1) % optionsMenu.Length;
                    ShowMenu();
                } else if (choiceKey.Key == ConsoleKey.Escape) {
                    activeOptionMenu = optionsMenu.Length - 1;
                    break;
                } else if (choiceKey.Key == ConsoleKey.Enter) {
                    break;
                }
            } while (true);
        }

        private void RunOption() {

            switch (activeOptionMenu) {

                case 0: Console.Clear(); AddMeeting(); break;
                case 1: Console.Clear(); RemoveMeeting(); break;
                case 2: Console.Clear(); GetMeetings(); break;
                case 3: Console.Clear(); AddUser(); break;
                case 4: Environment.Exit(0); break;
            }
        }

        private void AddMeeting() {
            Console.SetCursorPosition(2, 2);
            Console.Write("Podaj nazwe spotkania: \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(2, 3);
            string meetingName = Console.ReadLine();
            meetingController.AddMeeting(meetingName);
            Console.ReadKey();
        }

        private void RemoveMeeting() {
            Console.SetCursorPosition(2,2);
            Console.Write("Podaj nazwe spotkania: \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(2, 3);
            string meetingName = Console.ReadLine();
            meetingController.RemoveMeeting(meetingName);
            Console.ReadKey();
        }

        private void GetMeetings() {
            Console.SetCursorPosition(2, 2);

            List<Meeting> meetings = meetingController.ReturnMeetings();

            Console.Write("Lista spotkań: \n");
            Console.WriteLine("");

            foreach (Meeting m in meetings) 
            {
                Console.WriteLine(m);
            }
            Console.ReadKey();
        }

        private void AddUser() {
            Console.SetCursorPosition(2, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Podaj nazwe spotkania: \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(2, 3);
            string meetingname = Console.ReadLine();

            Console.SetCursorPosition(2, 5);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Podaj imie uzytkownika: \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(2, 6);
            string name = Console.ReadLine();

            Console.SetCursorPosition(2, 8);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Podaj mail uzytkownika: \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(2, 9);
            string mail = Console.ReadLine();

            User newUser = new User(name, mail);
            meetingController.AddUser(newUser, meetingname);
            Console.ReadKey();
        }
    }
}