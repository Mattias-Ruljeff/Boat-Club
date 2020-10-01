using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Jolly_Pirate_Yacht_Club.Model
{
    public class Database
    {
        private dynamic database;
        public Database ()
        {
            database = getDatabaseDocument();
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
            string enteredSSN = checkSSNLength(ssn);
            bool memberExist = true;
            while (memberExist) {
                memberExist = checkIfUserExist(enteredSSN);
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
                ID = checkMemberHighestIDNumber(database),
                Name = name,
                SSN = ssn

            };
            database.Add(newMember);


            writeToDatabase(database);
            Console.WriteLine("Member created, press any button to close");
            Console.WriteLine("===================");
            Console.ReadKey(true);
        }

        public dynamic findMemberInDb(int id)
        {
            Member memberFromDb = new Member();
            foreach (var member in database)
            {
                if (member.ID == id)
                {
                   memberFromDb = member;
                }
            }
            return memberFromDb;
        }

        public bool checkIfUserExist(string ssn)
        {
            bool memberFound = false;
            if(database.ToString().Length == 0){
                return memberFound;
            }
            return memberFound;    
        }

        public void changeMemberInformation(int id)
        {   

            foreach (var member in database)
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
            writeToDatabase(database);

        }
        public void removeMember(int id)
        {
            Member memberToBeRemoved = new Member();

            foreach (var member in database)
            {
                if (member.ID == id)
                {
                    memberToBeRemoved = member;
                }
            }
            database.Remove(memberToBeRemoved);
            writeToDatabase(database);
  
        }

        public void displayAllMembers(string displayChoice)
        {
            foreach (var member in database)
            {
                member.ToString(displayChoice);
            }
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
            
            foreach (var member in database)
            {
                if (member.ID == memberId) 
                {
                    member.boatList.Add(new Boat { ID = checkBoatHighestIDNumber(database), Type = type, Length = length });
                }
            }
            writeToDatabase(database);

        }

        public void searchUniqueBoat(int memberID, int boatID)
        {

        }

        public void changeBoatInformation(int memberID, int boatID, string boatType, int boatLength)
        {

            foreach (var member in database)
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
                }
            }
            writeToDatabase(database);

        }

        public void removeBoat(int memberID, int boatID)
        {
            Member memberFromDb = new Member();
            Boat boatToRemove = new Boat();

            foreach (var member in database)
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
            writeToDatabase(database);
        }
    }

}