using System;
using Jolly_Pirate_Yacht_Club.Model;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

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
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");
            Console.WriteLine("7. ");
            Console.WriteLine("8. ");
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
                    deleteMember();
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
            Console.WriteLine("=========================");
            Console.WriteLine("Enter new name.");

            string name = Console.ReadLine();

            member.name = name;

            Console.WriteLine("===================");
            Console.WriteLine("Enter social security number");

            int socialSecurityNumber = Convert.ToInt32(Console.ReadLine());
            member.socialSecurityNumber = socialSecurityNumber;
            try
            {
            database.createMember(member);
            } 
            catch
            {
                Console.WriteLine("Enter a name");
            }

        }

        public void editMember()
        {
            throw new System.NotImplementedException();
        }

        public void deleteMember()
        {
            throw new System.NotImplementedException();
        }
    }
}
