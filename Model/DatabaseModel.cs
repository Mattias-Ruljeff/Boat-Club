using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Jolly_Pirate_Yacht_Club.Model
{
    public class DatabaseModel
    {
        private dynamic data;
        public DatabaseModel ()
        {
            data = getDatabaseDocument();
        }
//--------------------------Read database-----------------------------------

        public dynamic getDatabaseDocument() 
        {
            try
            {
                var json = System.IO.File.ReadAllText("Boatclub.json");
                List<MemberModel> list = JsonConvert.DeserializeObject<List<MemberModel>>(json);
                return list;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }
        public void writeToDatabase(dynamic database) 
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
            }
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
            while (memberExist)
            {
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

            }

            var newMember = new MemberModel {
                ID = checkMemberHighestIDNumber(data),
                Name = name,
                SSN = ssn

            };

            data.Add(newMember);
            writeToDatabase(data);

        }

        public dynamic findMemberInDb(int id)
        {
            MemberModel memberFromDb = new MemberModel();
            foreach (var member in data)
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
            if(data.ToString().Length == 0)
            {
                return memberFound;
            }
            return memberFound;    
        }

        public void editMember(int id)
        {   
            foreach (var member in data)
            {
                if (member.ID == id)
                {
                    string newName = "";
                    while(newName.Length <= 0)
                    {
                        Console.WriteLine("Enter new name: ");
                        newName = Console.ReadLine(); 
                    }

                    member.Name = newName;
                    Console.WriteLine("Enter new SSN: ");
                    string newSSN = checkSSNLength(Console.ReadLine());
                    member.SSN = newSSN;
                }
            }
            writeToDatabase(data);

        }

        public void removeMember(int id)
        {
            MemberModel memberToBeRemoved = new MemberModel();

            foreach (var member in data)
            {
                if (member.ID == id)
                {
                    memberToBeRemoved = member;
                }
            }
            data.Remove(memberToBeRemoved);
            writeToDatabase(data);

        }

        public void displayAllMembers(ListType displayChoice)
        {
            foreach (var member in data)
            {
                member.ToString(displayChoice);
            }
            System.Console.WriteLine("Press any button to exit");
            Console.ReadKey(true);
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

        public void addBoat(int memberId, BoatType boatType, int length)
        {
            foreach (var member in data)
            {
                if (member.ID == memberId) 
                {
                    member.boatList.Add(new BoatModel 
                    {
                        ID = checkBoatHighestIDNumber(data), Type = boatType, Length = length
                    });
                }
            }
            writeToDatabase(data);
        }

        public dynamic searchUniqueBoat(int memberID, int boatID)
        {
            BoatModel boatFromDb = new BoatModel();
            foreach (var member in data)
            {
                if (member.ID == memberID)
                {
                    foreach (var boat in member.boatList)
                    {
                        if(boat.ID == boatID)
                        {
                            boatFromDb = boat;
                        }
                    }
                }
            }
            return boatFromDb;
        }

        public void editBoat(int memberID, int boatID, BoatType boatType, int boatLength)
        {
            foreach (var member in data)
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
            writeToDatabase(data);
        }

        public void deleteBoat(int memberID, int boatID)
        {
            MemberModel memberFromDb = new MemberModel();
            BoatModel boatToRemove = new BoatModel();

            foreach (var member in data)
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
            writeToDatabase(data);
        }
    }
}