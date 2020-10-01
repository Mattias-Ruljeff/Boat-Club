using Jolly_Pirate_Yacht_Club.View;
using System.IO;

namespace Jolly_pirate_Yacht_Club
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"C:\Users\oscar\Desktop\TEST 2\jolly-pirate-yacht-club");
            MainMenu run = new MainMenu();
            run.mainMenu();
        }
    }
}