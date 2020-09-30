using System;
using Jolly_Pirate_Yacht_Club.Model;
using System.Xml.Linq;

namespace Jolly_Pirate_Yacht_Club.View
{
    public class BoatView
    {
        Boat boat = new Boat();
        Database database = new Database();

        public void boatMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Manage boats");
            Console.WriteLine("=========================");
            Console.WriteLine("What can I help you with today?");
            Console.WriteLine("1. Register new boat");
            Console.WriteLine("2. Edit boat");
            Console.WriteLine("3. Delete boat");
            Console.WriteLine("4. Implement go back");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {

                case 1:
                    registerBoat();
                    break;
                case 2:
                    editBoat();
                    break;
                case 3:
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
            int memberID;
            int boatID;

            Console.WriteLine("=========================");
            Console.WriteLine("Enter your member ID.");

            memberID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("===================");
            Console.WriteLine("Enter your boat ID.");
            boatID = Int32.Parse(Console.ReadLine());

            try
            {
                database.changeBoatInformation(memberID, boatID);        
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw new Exception("Error when editing boat");
            }

        }

        public void deleteBoat()
        {
            int memberID;
            int boatID;
            XAttribute uniqueBoat;

            Console.WriteLine("=========================");
            Console.WriteLine("Enter your member ID.");

            memberID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("===================");
            Console.WriteLine("Enter your boat ID.");
            boatID = Int32.Parse(Console.ReadLine());

            try
            {
               uniqueBoat = database.searchUniqueBoat(memberID, boatID);
            }
            catch
            {
                throw new Exception("Error while deleting member");
            }
            
            Console.WriteLine("=========================");
            Console.WriteLine($"Do you want to delete boat ID {uniqueBoat.Value}?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            switch (Console.ReadLine())
            {
                case "1":
                    try
                    {
                        database.removeBoat(memberID, boatID);        
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e);
                        throw new Exception("Error when removing boat");
                    }
                    break;

                case "2":
                    break;
                
                default:
                    break;
            }
        }
    }
}