using System;
using Jolly_Pirate_Yacht_Club.Model;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

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
            Console.WriteLine("3. List of all members");
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
            string name;
            do
            {
            Console.WriteLine("=========================");
            Console.WriteLine("Enter new name.");

            name = Console.ReadLine();


            } while (name == "");

            member.name = name;

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
            member.socialSecurityNumber = socialSecurityNumber;
            try
            {
                database.createMember(socialSecurityNumber);
            } 
            catch
            {
                throw new Exception("Enter a valid social security number");
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
                database.searchUniqueMember(id);
            }
            catch
            {
                Console.WriteLine("Enter a name");
            }
            throw new System.NotImplementedException();
        }

        public void deleteMember()
        {
            throw new System.NotImplementedException();
        }
    }
}
