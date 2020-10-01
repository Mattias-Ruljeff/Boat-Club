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
                ID = 1,
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

        public void changeMemberInformation()
        {   

        }
        public void removeMember(int memberID)
        {
  
        }

//--------------------------Boat-----------------------------------

        public void addBoat(int memberId, string type, int length)
        {

        }
        public void searchUniqueBoat(int memberID, int boatID)
        {

        }
        public void changeBoatInformation(int memberID, int boatID)
        {

        }
        public void removeBoat(int memberID, int boatID)
        {

        }
    }

}