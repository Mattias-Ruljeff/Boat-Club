using System;

namespace Jolly_Pirate_Yacht_Club.Model
{
    class Member
    {
        private int _id;
        private string _name;
        private string _ssn;

        public string SSN
        {
            get { return _ssn;}
            set
            {
               _ssn = value;
            }
        }

        public string Name
        {
            get { return _name;}
            set
            {
                _name = value;
            }
        }

        public int ID
        {
            get { return _id;}
            set
            {
                _id = value;
            }
        }

        public dynamic getName()
        {
            return _name;
        }
    }

}
