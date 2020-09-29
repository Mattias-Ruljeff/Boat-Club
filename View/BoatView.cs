using System;
using Jolly_Pirate_Yacht_Club.Model;
using System.Collections.Generic;
using System.Text;

namespace Jolly_Pirate_Yacht_Club.View
{
    public class BoatView
    {
        Boat boat = new Boat();
        Database database = new Database();

        public void boatMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Boat-page.");
            Console.WriteLine("Choose a number!");
            Console.WriteLine("1. Register new boat");
            Console.WriteLine("2. Edit boat");
            Console.WriteLine("3. Delete boat");
            Console.WriteLine("4. Kebabrulle");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");
            Console.WriteLine("7. ");
            Console.WriteLine("8. ");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {

                case 1:
                    Console.WriteLine("1 valt");
                    registerBoat();
                    break;
                case 2:
                    Console.WriteLine("2 valt");
                    editBoat();
                    break;
                case 3:
                    Console.WriteLine("3 valt");
                    deleteBoat();
                    break;
                case 4:
                    Console.WriteLine("4 valt");
                    break;
                default:
                    Console.WriteLine("Default valt");
                    break;
            }
        }

        public void registerBoat()
        {
            int memberID;
            string type;
            int length;

            Console.WriteLine("=========================");
            Console.WriteLine("Enter your member ID.");

            memberID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("===================");
            Console.WriteLine("Select your boat type.");
            Console.WriteLine("1. Sailboat");
            Console.WriteLine("2. Motorsailer");
            Console.WriteLine("3. Kayak/Canoe");
            Console.WriteLine("4. Other");

            type = Console.ReadLine();

            if (type == "1")
            {
                type = "Sailboat";
            }
            else if (type == "2")
            {
                type = "Motorsailer";
            }
            else if (type == "3")
            {
                type = "Kayak/Canoe";
            }
            else if (type == "4")
            {
                type = "Other";
            }
            else
            {
                Console.WriteLine("Not a valid type");
            }

            Console.WriteLine("Enter length");
            length = Int32.Parse(Console.ReadLine());

            try
            {
                database.addBoat(memberID, type, length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error while creating new member");
            }

        }

        public void editBoat()
        {
            throw new System.NotImplementedException();
        }

        public void deleteBoat()
        {
            throw new System.NotImplementedException();
        }
    }
}