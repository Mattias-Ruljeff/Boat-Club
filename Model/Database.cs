using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;


namespace Jolly_Pirate_Yacht_Club.Model
{
    public class Database
    {
        //open file stream
        public Database ()
        {
            // database.Add(getDatabaseDocument());
            // foreach (var item in database)
            // {  
            //     foreach (var hej in item)
            //     {
            //         System.Console.WriteLine(hej.SSN);
            //     }                
            // }

        }
//--------------------------Read database-----------------------------------

        public dynamic getDatabaseDocument () 
        {
            try
            {
                var json = System.IO.File.ReadAllText("Boatclub.json");
                List<Member> list = JsonConvert.DeserializeObject<List<Member>>(json);
                return list;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }
        public void writeToDatabase (dynamic database) 
        {
            File.WriteAllText("BoatClub.json", JsonConvert.SerializeObject(database));
        }

        public void readMemberListFile()
        {
            throw new System.NotImplementedException();
        }


//--------------------------Member-----------------------------------

        public string checkSSNLength (string enteredSSN) 
        {
            while (enteredSSN.Length != 10){
                Console.WriteLine("===================");
                Console.WriteLine("Enter social security number, 10 numbers");

                enteredSSN = Console.ReadLine();
            };
            return enteredSSN;
        }

        public int checkMemberHighestIDNumber(dynamic db) 
        {
            int highestNumber = 0;
            foreach (var member in db)
            {
                if (highestNumber < member.ID)
                {
                    highestNumber = member.ID;
                } 
            }
            return highestNumber + 1;

        }

        public void createMember(string name, string ssn)
        {
            // string test = ssn;
            string enteredSSN = checkSSNLength(ssn);
            bool memberExist = true;
            var db = getDatabaseDocument();
            while (memberExist) {
                memberExist = searchUniqueMember(enteredSSN);
                if(memberExist)
                {
                    Console.WriteLine("Member already exist");
                    Console.WriteLine("Enter a valid SSN");
                    enteredSSN = Console.ReadLine();
                    enteredSSN = checkSSNLength(enteredSSN);
                } 
                else
                {
                    memberExist = false;
                }

            };
            var newMember = new Member {
                ID = checkMemberHighestIDNumber(db),
                Name = name,
                SSN = ssn

            };
            db.Add(newMember);


            writeToDatabase(db);
            Console.WriteLine("Member created, press any button to close");
            Console.WriteLine("===================");
            Console.ReadKey(true);
        }
        public bool searchUniqueMember(string ssn)
        {
            var db = getDatabaseDocument();
   
            bool memberFound = false;
            if(db.ToString().Length == 0){
                return memberFound;
            }
            foreach (var member in db)
            {
                System.Console.WriteLine(member);
                // if(member == ssn)
                // {
                //     memberFound = true;
                // }
            }
            return memberFound;    
        }

        public void changeMemberInformation(int id)
        {   
            var db = getDatabaseDocument();

            foreach (var member in db)
            {
                if (member.ID == id)
                {
                    string newName = "";
                    while(newName.Length <= 0) {
                        Console.WriteLine("Enter new name: ");
                        newName = Console.ReadLine(); 
                    }

                    member.Name = newName;
                    Console.WriteLine("Enter new SSN: ");
                    string newSSN = checkSSNLength(Console.ReadLine());
                    member.SSN = newSSN;
                }
            }
            writeToDatabase(db);

        }
        public void removeMember(int id)
        {
            var db = getDatabaseDocument();
            Member memberToBeRemoved = new Member();

            foreach (var member in db)
            {
                if (member.ID == id)
                {
                    memberToBeRemoved = member;
                }
            }
            db.Remove(memberToBeRemoved);
            writeToDatabase(db);
  
        }

//--------------------------Boat-----------------------------------

        public int checkBoatHighestIDNumber(dynamic db) 
        {
            int highestNumber = 0;
            foreach (var member in db)
            {
                foreach (var boat in member.boatList)
                {
                    if (highestNumber < boat.ID)
                    {
                        highestNumber = boat.ID;
                    } 
                }
            }
            return highestNumber + 1;

        }
        public void addBoat(int memberId, string type, int length)
        {
            // string test = ssn;
            var db = getDatabaseDocument();
            // System.Console.WriteLine("-----");
            // System.Console.WriteLine(db["ID:1"]);
            // System.Console.WriteLine("-----");
            
            foreach (var member in db)
            {
                if (member.ID == memberId) 
                {
                    member.boatList.Add(new Boat { ID = checkBoatHighestIDNumber(db), Type = type, Length = length });
                }
            }
            writeToDatabase(db);

        }

        public void searchUniqueBoat(int memberID, int boatID)
        {

        }

        public void changeBoatInformation(int memberID, int boatID, string boatType, int boatLength)
        {
            var db = getDatabaseDocument();

            foreach (var member in db)
            {
                if (member.ID == memberID)
                {
                    foreach (var boat in member.boatList)
                    {
                        if(boat.ID == boatID)
                        {
                            boat.Type = boatType;
                            boat.Length = boatLength; 
                        }
                    }

                    // member.Name = newName;
                    // Console.WriteLine("Enter new SSN: ");
                    // string newSSN = checkSSNLength(Console.ReadLine());
                    // member.SSN = newSSN;
                }
            }
            writeToDatabase(db);

        }

        public void removeBoat(int memberID, int boatID)
        {
            var db = getDatabaseDocument();
            Member memberFromDb = new Member();
            Boat boatToRemove = new Boat();

            foreach (var member in db)
            {
                if (member.ID == memberID)
                {
                    memberFromDb = member;
                    foreach (var boat in member.boatList)
                    {
                        if(boat.ID == boatID)
                        {
                            boatToRemove = boat;
                        }
                    }

                member.boatList.Remove(boatToRemove);
                }
            }
            writeToDatabase(db);
        }
    }

}