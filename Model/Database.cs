using System;
using System.IO;
using System.Linq;
using System.Xml;
using Jolly_Pirate_Yacht_Club.View;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using System.Xml.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Jolly_Pirate_Yacht_Club.Model
{
    public class Database
    {
        private XDocument databaseDocument;
        private string __databaseFile = "Members.xml";
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

            xmlDoc.Descendants("Members")
                    .FirstOrDefault()
                    .Add(new XElement("Member",
                    new XAttribute("memberId", memberId),
                    new XAttribute("name", name),
                    new XAttribute("SSN", SSN),
                    new XElement("Boats")));

            xmlDoc.Save(xmlFilePath);
        
        }

        public void readMemberListFile()
        {
            throw new System.NotImplementedException();
        }

        public void deleteMember(int memberId)
        {
            throw new System.NotImplementedException();
        }

        public void changeMemberInformation()
        {
            throw new System.NotImplementedException();
        }

        public void searchUniqueMember(int memberID)
        {
            throw new System.NotImplementedException();
        }

        public void addBoat(int memberId, string type, int length)
        {
            int boatId = ((from member in databaseDocument.Descendants("Boat")
                          select (int)member.Attribute("boatId")).DefaultIfEmpty(0).Max()) + 1;

            Console.WriteLine(databaseDocument);

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

        public void changeBoatInformation()
        {
            throw new System.NotImplementedException();
        }

    }
}