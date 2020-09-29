using Jolly_Pirate_Yacht_Club.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jolly_Pirate_Yacht_Club.View
{
    class MainMenu
    {
        MemberView memberView = new MemberView();
        BoatView boatView = new BoatView();
        CalendarView calendaView = new CalendarView();

        public void mainMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Welcome to The Jolly Pirate!");
            Console.WriteLine("Choose a category");
            Console.WriteLine("1. Member");
            Console.WriteLine("2. Boat");
            Console.WriteLine("3. Calendar");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {

                case 1:
                    memberView.memberMenu();
                    break;
                case 2:
                    boatView.boatMenu();
                    break;
                case 3:
                    calendaView.calendarMenu();
                    break;
                case 4:
                    Console.WriteLine("4 valt");
                    break;
                default:
                    Console.WriteLine("Default valt");
                    break;
            }
        } 

    }
}
