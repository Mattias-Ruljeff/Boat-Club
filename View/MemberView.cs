using System;
using Jolly_Pirate_Yacht_Club.Model;

namespace Jolly_Pirate_Yacht_Club.View
{
    public class MemberView
    {
        DatabaseModel database = new DatabaseModel();
        MemberModel member = new MemberModel();
        public void memberMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Manage members");
            Console.WriteLine("=========================");
            Console.WriteLine("Choose a number!");
            Console.WriteLine("1. Register new member");
            Console.WriteLine("2. Edit member");
            Console.WriteLine("3. Delete member");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {
                case 1:
                    createMember();
                    break;
                case 2:
                    editMember();
                    break;
                case 3:
                    removeMember();
                    break;
                default:
                    break;
            }
        }

        public void displayMembers() 
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Show list of all members");
            Console.WriteLine("=========================");
            Console.WriteLine("Choose a number!");
            Console.WriteLine($"1. {ListType.Compact} list");
            Console.WriteLine($"2. {ListType.Verbose} list");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {
                case 1:
                    database.displayAllMembers(ListType.Compact);
                    break;
                case 2:
                    database.displayAllMembers(ListType.Verbose);
                    break;
                default:
                    break;
            }
        }

        public void createMember()
        {
            string name;
            do
            {
                Console.WriteLine("=========================");
                Console.WriteLine("Enter new name.");
                name = Console.ReadLine();
            } while (name == "");

            string enteredSSN;
            Console.WriteLine("===================");
            Console.WriteLine("Enter social security number, 10 numbers");
            enteredSSN = Console.ReadLine();

            try
            {
                database.createMember(name, enteredSSN);
                System.Console.WriteLine("Member was added");
                System.Console.WriteLine("Press any button to exit");
                Console.ReadKey(true);
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e);
                throw new Exception("Error while creating new member");
            }
        }

        public void editMember()
        {
            int id;
            do
            {
                Console.WriteLine("=========================");
                Console.WriteLine("Enter member ID.");
                id = Convert.ToInt32(Console.ReadLine());
            } while (id.ToString().Length < 0);

            try
            {
                database.editMember(id);
                System.Console.WriteLine("Member information was changed");
                System.Console.WriteLine("Press any button to exit");
                Console.ReadKey(true);
            }
            catch
            {
                throw new Exception("Error while editing member");
            }
        }

        public void removeMember()
        {
            int id;
            MemberModel uniqueMember = new MemberModel();
            do
            {
                Console.WriteLine("=========================");
                Console.WriteLine("Enter member ID.");
                id = Convert.ToInt32(Console.ReadLine());

            } while (id.ToString().Length < 0);

            try
            {
               uniqueMember = database.findMemberInDb(id);
            }
            catch
            {
                throw new Exception("Error while deleting member");
            }
            
            Console.WriteLine("=========================");
            Console.WriteLine($"Do you want to delete {uniqueMember.Name}?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            switch (Console.ReadLine())
            {
                case "1":
                    database.removeMember(id);
                    System.Console.WriteLine("Member was removed");
                    System.Console.WriteLine("Press any button to exit");
                    Console.ReadKey(true);
                    break;

                case "2":
                    memberMenu();
                    break;
                
                default:
                    break;
            }
        }
    }
}
