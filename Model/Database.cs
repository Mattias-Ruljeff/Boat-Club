using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jolly_Pirate_Yacht_Club.Model
{
    public class Database
    {
        private XDocument databaseDocument;
        private string __databaseFile = "BoatClub.xml";
        XDocument xmlDoc;

        public Database ()
        {
            xmlDoc = XDocument.Load(xmlFilePath);
            databaseDocument = getDdatabaseDocument();
        }
        private string xmlFilePath
        {
            get { return __databaseFile; }
            set { }
        }

        public XDocument getDdatabaseDocument () 
        {
            return xmlDoc;
        }


        public void createMember(string name, string SSN)
        {
            int memberId = ((from member in databaseDocument.Descendants("Member")
                          select (int)member.Attribute("memberId")).DefaultIfEmpty(0).Max()) + 1;

            Console.WriteLine(databaseDocument);

            databaseDocument.Descendants("BoatClub")
                    .FirstOrDefault()
                    .Add(new XElement("Member",
                    new XAttribute("memberId", memberId),
                    new XAttribute("name", name),
                    new XAttribute("SSN", SSN),
                    new XElement("Boats")));

            xmlDoc.Save(xmlFilePath);
        
        }

        public XElement searchUniqueMember(int memberID)
        {
            var member = databaseDocument.Descendants("Member")
                                    .Where(id => (int)id
                                    .Attribute("memberId") == memberID)
                                    .Single();
            return member;
    
        }
        public void changeMemberInformation(XElement name, int memberID)
        {   
            string controlledName = "";
            do
            {
                Console.WriteLine($"Enter new name for {name.Value}");
                controlledName = Console.ReadLine();
                
            } while (controlledName.Length < 1);
            databaseDocument.Descendants("Member")
                                    .Where(id => (int)id.Attribute("memberId") == memberID).Single().SetAttributeValue("name", controlledName);
                                    
            xmlDoc.Save(xmlFilePath);
        }

        public void removeMember(int memberID)
        {
            databaseDocument.Descendants("Member")
                .Where(id => (int)id.Attribute("memberId") == memberID)
                .Remove();
                            
            xmlDoc.Save(xmlFilePath);   
        }
        public void readMemberListFile()
        {
            throw new System.NotImplementedException();
        }

        public dynamic searchUniqueBoat(int memberID, int boatID)
        {
            return databaseDocument.Descendants("Member")
                                    .Where(member => (int)member.Attribute("memberId") == memberID)
                                    .Descendants("Boat")
                                    .Where(boat => (int)boat.Attribute("boatId") == boatID)
                                    .Single()
                                    .Attribute("boatId");
             

        }

        public void addBoat(int memberId, string type, int length)
        {
            int boatId = ((from member in databaseDocument.Descendants("Boat")
                          select (int)member.Attribute("boatId")).DefaultIfEmpty(0).Max()) + 1;

            xmlDoc.Descendants("Member")
                    .Where(x => (int)x.Attribute("memberId") == memberId).FirstOrDefault()
                    .Descendants("Boats")
                    .FirstOrDefault()
                    .Add(new XElement("Boat",
                    new XAttribute("boatId", boatId),
                    new XAttribute("type", type),
                    new XAttribute("length", length)));

            xmlDoc.Save(xmlFilePath);
        
        }

        public void changeBoatInformation(int memberID, int boatID)
        {
            // XAttribute memberInformation = searchUniqueMember(memberID);

            string newType;
            do
            {
                Console.WriteLine($"Choose new boat type");
                Console.WriteLine($"1. Sailboat");
                Console.WriteLine($"2. Motorsailer?");
                Console.WriteLine($"3. Kayak/Canoe");
                Console.WriteLine($"4. Other");
                
                newType = Console.ReadLine();
                
                if (newType == "1")
                {
                    newType = "Sailboat";
                }
                else if (newType == "2")
                {
                    newType = "Motorsailer";
                }
                else if (newType == "3")
                {
                    newType = "Kayak/Canoe";
                }
                else if (newType == "4")
                {
                    newType = "Other";
                }
                else
                {
                    Console.WriteLine("Not a valid boat type");
                }
                
            } while (newType.Length < 1);

            databaseDocument.Descendants("Member")
                            .Where(id => (int)id.Attribute("memberId") == memberID)
                            .Descendants("Boat")
                            .Where(x => (int)x.Attribute("boatId") == boatID)
                            .Single()
                            .SetAttributeValue("type", newType);
               

            string newLength;
            do
            {
                Console.WriteLine($"Enter new length");
                newLength = Console.ReadLine();
                
            } while (newLength.Length < 1);
            databaseDocument.Descendants("Member")
                            .Where(id => (int)id.Attribute("memberId") == memberID)
                            .Descendants("Boat")
                            .Where(x => (int)x.Attribute("boatId") == boatID)
                            .Single()
                            .SetAttributeValue("length", newLength);
               
            xmlDoc.Save(xmlFilePath);
        }

        public void removeBoat(int memberID, int boatID)
        {
            databaseDocument.Descendants("Member")
                            .Where(id => (int)id.Attribute("memberId") == memberID)
                            .Descendants("Boat")
                            .Where(x => (int)x.Attribute("boatId") == boatID)
                            .Remove();
                            
            xmlDoc.Save(xmlFilePath);
            
        }

    }
}