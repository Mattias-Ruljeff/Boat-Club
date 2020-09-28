using System;
using System.Collections.Generic;
using System.Text;

namespace Jolly_Pirate_Yacht_Club.Model
{
    class Member
    {
        public int socialSecurityNumber
        {
            get => default;
            set
            {
                if (value.ToString() == "")
                {
                    Console.WriteLine("Enter a number");
                }
            }
        }

        public string name
        {
            get => default;
            set
            {
                if(value == "")
                {
                    Console.WriteLine("Enter a name");
                }
            }
        }

        public int ID
        {
            get => default;
            private set
            {
                // leta i databas efter ID på sista medlem i medlemslistan, ta det och lägg på 1 för att skapa unikt ID.
            }
        }

        public void getName()
        {
            throw new System.NotImplementedException();
        }
    }

}
