using System;

namespace Jolly_Pirate_Yacht_Club.View
{
    class MainMenu
    {
        MemberView memberView = new MemberView();
        BoatView boatView = new BoatView();

        public void mainMenu()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Welcome to \"The Jolly Pirate Management System\".");
            Console.WriteLine("================================================");
            Console.WriteLine("What can I help you with today?");
            Console.WriteLine("1: Manage members");
            Console.WriteLine("2: Manage boats");
            Console.WriteLine("3: List member information");
            Console.WriteLine("4: Exit");
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
                    memberView.displayMembers();
                    break;
                case 4:
                    Console.WriteLine("Thank you for choosing \"The Jolly Pirate Boat Club\".");
                    Console.WriteLine("Console terminates...");
                    break;
                default:
                    throw new ArgumentException("Must select an option by entering a number 1 - 3.");
            }
        } 

    }
}
