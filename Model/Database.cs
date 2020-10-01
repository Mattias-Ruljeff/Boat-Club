using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
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
        private MemberRegister database = new MemberRegister();
        public Database ()
        {
            database.members.Add(getDatabaseDocument());
            foreach (var item in database.members)
            {  
                System.Console.WriteLine(item);                
            }

            // Member newMember = new Member {
            //     ID = "1",
            //     Name = "Hitler",
            //     SSN = "8888884444"
            // };
            // System.Console.WriteLine(newMember.ID);
            // memberRegister.memberList.Add(newMember);
            // memberRegister.memberList.Add(new Member {
            //     ID = "2",
            //     Name = "Dan RC",
            //     SSN = "88888844444"
            // });
            // memberRegister.memberList.Add(new Member {
            //     ID = "3",
            //     Name = "Hitler Farfar",
            //     SSN = "88888844444"
            // });
            // memberRegister.memberList.Add(new Member {
            //     ID = "4",
            //     Name = "Hitlers Morsa",
            //     SSN = "88888844444"
            // });
            // File.WriteAllText("BoatClub.json", JsonConvert.SerializeObject(memberRegister));


        }
//--------------------------Read database-----------------------------------

        public Newtonsoft.Json.Linq.JArray getDatabaseDocument () 
        {
            try
            {
                using (StreamReader r = new StreamReader("BoatClub.json"))
                {
                    string json = r.ReadToEnd();
                    dynamic array = JsonConvert.DeserializeObject(json);
                    return array;
                }    
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public void readMemberListFile()
        {
            throw new System.NotImplementedException();
        }

//--------------------------Member-----------------------------------
        public void createMember(string name, string ssn)
        {
            string enteredSSN = ssn;
            bool memberExist = true;
            var test = false;

                while (memberExist) {
                    test = searchUniqueMember(enteredSSN);
                    if(test)
                    {
                        Console.WriteLine("Member already exist");
                        Console.WriteLine("Enter a valid SSN");
                        enteredSSN = Console.ReadLine();
                    } 
                    else
                    {
                        memberExist = false;
                    }

                };
                
                Console.WriteLine("Member created, press any button to close");

                Member newMember = new Member {
                                        ID = 1,
                                        Name = name,
                                        SSN = ssn
                                    };

                Console.WriteLine("===================");
                Console.ReadKey(true);

   
        }
        public bool searchUniqueMember(string ssn)
        {
            bool memberFound = false;
            var dbDocument = getDatabaseDocument();
            foreach (var list in dbDocument)
            {
                foreach (var member in list["members"])
                {
                    if(member["SSN"].ToString() == ssn)
                    {
                        memberFound = true;
                    }
                }
                
            }
            return memberFound;

        }
        public void changeMemberInformation(XElement name, int memberID)
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