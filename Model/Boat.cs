using System;

namespace Jolly_Pirate_Yacht_Club.Model
{
    class Boat
    {
        public string type
        {
            get => default;
            set
            {
                if (value == "")
                {
                    throw new Exception("Name cannot be empty");
                }
            }
        }

        public int length
        {
            get => default;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Length cannot be less than zero");
                }
            }
        }

        public int ID
        {
            get => default;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Length cannot be less than zero");
                }
            }
        }
    }
}
