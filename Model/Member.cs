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
        
        public void ToString(string listType) {
            string returnString = $"Name: {Name} ID: {ID}\n";

            if (listType == "compact") {
                returnString += $"Number of boats {boatList.Count}";
            } else {
                foreach (var boat in boatList)
                {
                    returnString += $"Boat ID: {boat.ID} Boat type: {boat.Type} Boat Length: {boat.Length}\n";
                }
            }
            
            System.Console.WriteLine(returnString);
        }
        
    }

}