using System;

namespace Jolly_Pirate_Yacht_Club.View
{
    class MainMenu
    {
        MemberView memberView = new MemberView();
        BoatView boatView = new BoatView();

        public void mainMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Welcome to The Jolly Pirate!");
            Console.WriteLine("Choose a category");
            Console.WriteLine("1. Member");
            Console.WriteLine("2. Boat");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {

                case 1:
                    memberView.memberMenu();
                    break;
                case 2:
                    boatView.boatMenu();
                    break;
                default:
                    Console.WriteLine("Default valt");
                    break;
            }
        } 

    }
}
