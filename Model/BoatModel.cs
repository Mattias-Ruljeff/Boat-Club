using System;

namespace Jolly_Pirate_Yacht_Club.Model
{
    class BoatModel
    {
        private int _id;
        private BoatType _type;
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

        public BoatType Type
        {
            get { return _type; }
            set { _type = value; }
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
