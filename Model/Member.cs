using System;

namespace Jolly_Pirate_Yacht_Club.Model
{
    class Member
    {
        public string socialSecurityNumber
        {
            get => default;
            set
            {
                if (value == "")
                {
                    throw new Exception("Social security number cannot be empty");
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
                    throw new Exception("Name cannot be empty");
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
