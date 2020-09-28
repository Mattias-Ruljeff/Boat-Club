using Jolly_Pirate_Yacht_Club.View;
using System;
using System.Threading.Channels;

namespace Jolly_pirate_Yacht_Club
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu run = new MainMenu();
            run.mainMenu();
        }
    }
}