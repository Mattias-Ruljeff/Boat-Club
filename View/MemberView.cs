using System;
using Jolly_Pirate_Yacht_Club.Model;
using System.Xml.Linq;



namespace Jolly_Pirate_Yacht_Club.View
{
    public class MemberView
    {
        Database database = new Database();
        Member member = new Member();
        public void memberMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Member-page.");
            Console.WriteLine("Choose a number!");
            Console.WriteLine("1. Register new member");
            Console.WriteLine("2. Edit member");
            Console.WriteLine("3. Delete member");
            Console.WriteLine("4. List of all members");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {
                case 1:
                    registerMember();
                    break;
                case 2:
                    editMember();
                    break;
                case 3:
                    removeMember();
                    break;
                case 4:
                    Console.WriteLine("4 valt");
                    break;
                default:
                    Console.WriteLine("Default valt");
                    break;
            }
        }

        public void registerMember()
        {
            string name;
            do
            {
                Console.WriteLine("=========================");
                Console.WriteLine("Enter new name.");

                name = Console.ReadLine();


            } while (name == "");

            string socialSecurityNumber;
            //Regex r = new Regex("[0-9]{10,10}?", RegexOptions.None);
            //Match m;

            do
            {
                Console.WriteLine("===================");
                Console.WriteLine("Enter social security number, 10 numbers");

                socialSecurityNumber = Console.ReadLine();
                //m = r.Match(socialSecurityNumber);


            } while (socialSecurityNumber.Length == 11);
            try
            {
                database.createMember(name, socialSecurityNumber);
                Console.WriteLine("===================");
                System.Console.WriteLine("Member created, press any button to close");
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
                var test = database.searchUniqueMember(id);

                database.changeMemberInformation(test, id);
            }
            catch
            {
                throw new Exception("Error while editing member");
            }
        }

        public void removeMember()
        {
            int id;
            XAttribute uniqueMember;
            do
            {
                Console.WriteLine("=========================");
                Console.WriteLine("Enter member ID.");
                id = Convert.ToInt32(Console.ReadLine());


            } while (id.ToString().Length < 0);
            try
            {
               uniqueMember = database.searchUniqueMember(id);
            }
            catch
            {
                throw new Exception("Error while deleting member");
            }
            
            Console.WriteLine("=========================");
            Console.WriteLine($"Do you want to delete {uniqueMember.Value}?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            switch (Console.ReadLine())
            {
                case "1":
                    database.removeMember(id);
                    break;

                case "2":
                    break;
                
                default:
                    break;

            }
        }
    }
}
