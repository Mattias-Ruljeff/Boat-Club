using System;
using Jolly_Pirate_Yacht_Club.Model;
using System.Collections.Generic;
using System.Text;

namespace Jolly_Pirate_Yacht_Club.View
{
    public class BoatView
    {
        Boat boat = new Boat();

        public void boatMenu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Boat-page.");
            Console.WriteLine("Choose a number!");
            Console.WriteLine("1. Register new boat");
            Console.WriteLine("2. Edit boat");
            Console.WriteLine("3. Delete boat");
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
            throw new System.NotImplementedException();
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