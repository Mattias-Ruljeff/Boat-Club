using System;
using System.Collections.Generic;

namespace Jolly_Pirate_Yacht_Club.Model
{
    class Member
    {
        private int _id;
        private string _name;
        private string _ssn;
        public List<Boat> boatList = new List<Boat>();
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string SSN
        {
            get { return _ssn; }
            set { _ssn = value; }
        }

    }

}