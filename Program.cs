using System.IO;
using Jolly_Pirate_Yacht_Club.View;

namespace Jolly_pirate_Yacht_Club
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"C:\Users\JollyPirate\");
            MainMenu run = new MainMenu();
            run.mainMenu();
        }
    }
}