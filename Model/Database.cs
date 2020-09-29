using System;
using System.IO;
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
        private string __databaseFile = "Members.xml";
        XDocument xmlDoc;

        public Database ()
        {
            xmlDoc = XDocument.Load(xmlFilePath);
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


        public void createMember(object member)
        {
            var test = getDdatabaseDocument();
            Console.WriteLine(test);
        }

        public void writeMemberListFile()
        {
            throw new System.NotImplementedException();
        }

        public void readMemberListFile()
        {
            throw new System.NotImplementedException();
        }

        public void deleteMember()
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

        public void addBoatToMember()
        {
            throw new System.NotImplementedException();
        }

        public void changeBoatInformation()
        {
            throw new System.NotImplementedException();
        }

    }
}