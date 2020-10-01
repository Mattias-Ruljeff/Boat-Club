using System;
using Jolly_Pirate_Yacht_Club.Model;

namespace Jolly_Pirate_Yacht_Club.View
{
    public class BoatView
    {
        DatabaseModel database = new DatabaseModel();

        public void boatMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Manage boats");
            Console.WriteLine("=========================");
            Console.WriteLine("What can I help you with today?");
            Console.WriteLine("1. Register new boat");
            Console.WriteLine("2. Edit boat");
            Console.WriteLine("3. Delete boat");
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
                default:
                    throw new ArgumentException("Must select an option by entering a number 1 - 3.");
            }
        }

        public void registerBoat()
        {
            int memberID;
            BoatType type = BoatType.Sailboat;
            int length;
            int menuChoice;
            bool continueLoop = true;

            Console.WriteLine("=========================");
            Console.WriteLine("Enter your member ID.");
            memberID = Int32.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("===================");
                Console.WriteLine("Select your boat type.");
                Console.WriteLine($"1. {BoatType.Sailboat}");
                Console.WriteLine($"2. {BoatType.Motorsailer}");
                Console.WriteLine($"3. {BoatType.Kayak}");
                Console.WriteLine($"4. {BoatType.Other}");

                menuChoice = Int32.Parse(Console.ReadLine());
                if (menuChoice == 1)
                {
                    type = BoatType.Sailboat;
                    continueLoop = false;
                }
                else if (menuChoice == 2)
                {
                    type = BoatType.Motorsailer;
                    continueLoop = false;
                }
                else if (menuChoice == 3)
                {
                    type = BoatType.Kayak;
                    continueLoop = false;
                }
                else if (menuChoice == 4)
                {
                    type = BoatType.Other;
                    continueLoop = false;
                }
                else
                {
                    Console.WriteLine("Not a valid type");
                }
            } while (continueLoop);


            Console.WriteLine("Enter length");
            length = Convert.ToInt32(Console.ReadLine());

            try
            {
                database.addBoat(memberID, type, length);
                System.Console.WriteLine("Boat was added");
                System.Console.WriteLine("Press any button to exit");
                Console.ReadKey(true);
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
            BoatType boatType = BoatType.Sailboat;
            int boatLength = 0;
            int menuChoice;
            bool continueLoop = true;

            Console.WriteLine("=========================");
            Console.WriteLine("Enter your member ID.");

            memberID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("===================");
            Console.WriteLine("Enter your boat ID.");
            boatID = Int32.Parse(Console.ReadLine());

             do
            {
                Console.WriteLine("===================");
                Console.WriteLine("Select your boat type.");
                Console.WriteLine($"1. {BoatType.Sailboat}");
                Console.WriteLine($"2. {BoatType.Motorsailer}");
                Console.WriteLine($"3. {BoatType.Kayak}");
                Console.WriteLine($"4. {BoatType.Other}");

                menuChoice = Int32.Parse(Console.ReadLine());
                if (menuChoice == 1)
                {
                    boatType = BoatType.Sailboat;
                    continueLoop = false;
                }
                else if (menuChoice == 2)
                {
                    boatType = BoatType.Motorsailer;
                    continueLoop = false;
                }
                else if (menuChoice == 3)
                {
                    boatType = BoatType.Kayak;
                    continueLoop = false;
                }
                else if (menuChoice == 4)
                {
                    boatType = BoatType.Other;
                    continueLoop = false;
                }
                else
                {
                    Console.WriteLine("Not a valid type");
                }
            } while (continueLoop);


                Console.WriteLine("Enter new boat-length");
                boatLength = Int32.Parse(Console.ReadLine());    
            
            
            try
            {
                database.editBoat(memberID, boatID, boatType, boatLength);
                System.Console.WriteLine("Boat information was changed");
                System.Console.WriteLine("Press any button to exit");
                Console.ReadKey(true);       
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
            BoatModel uniqueBoat = new BoatModel();

            Console.WriteLine("=========================");
            Console.WriteLine("Enter your member ID.");

            memberID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("===================");
            Console.WriteLine("Enter your boat ID.");
            boatID = Int32.Parse(Console.ReadLine());

            try
            {
               uniqueBoat = database.searchUniqueBoat(memberID, boatID);
                System.Console.WriteLine("Boat was removed");
                System.Console.WriteLine("Press any button to exit");
                Console.ReadKey(true);
               
            }
            catch
            {
                throw new Exception("Error while deleting member");
            }
            
            Console.WriteLine("=========================");
            Console.WriteLine($"Do you want to delete boat ID {uniqueBoat.ID}?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            switch (Console.ReadLine())
            {
                case "1":
                    try
                    {
                        database.deleteBoat(memberID, boatID);
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