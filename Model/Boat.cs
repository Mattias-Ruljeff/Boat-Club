using System;

namespace Jolly_Pirate_Yacht_Club.Model
{
    class Boat
    {
        private int _id;
        private string _type;
        private int _length;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Length cannot be less than zero");
                }
                _id = value;
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                // if (value == "")
                // {
                //     throw new Exception("Name cannot be empty");
                // }
                _type = value;
            }
        }

        public int Length
        {
            get { return _length; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Length cannot be less than zero");
                }
                _length = value;
            }
        }
    
    }

}
