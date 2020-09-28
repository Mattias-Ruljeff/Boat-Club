using System;
using System.Collections.Generic;
using System.Text;

namespace Jolly_Pirate_Yacht_Club.View
{
    class CalendarView
    {
        public void calendarMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Choose a number!");
            Console.WriteLine("1. Register new member");
            Console.WriteLine("2. Register new boat");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");
            Console.WriteLine("7. ");
            Console.WriteLine("8. ");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {

                case 1:
                    Console.WriteLine("1 valt");
                    break;
                case 2:
                    Console.WriteLine("2 valt");
                    break;
                case 3:
                    Console.WriteLine("3 valt");
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
