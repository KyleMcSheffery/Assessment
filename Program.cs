using System;
using System.Collections.Generic;
using System.Xml;

namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            //NOTE: There was a missing </Declaration> tag in the xml which was causing an error so I added it.

            XmlTextReader reader = new XmlTextReader("question2.xml");
            string refCode = "";
            bool readRefText = false;
            string refTextMwb = "", refTextTrv = "", refTextCar = "";
            
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name.Equals("Reference"))
                        {
                            refCode = reader.GetAttribute("RefCode");
                        }
                        else if (reader.Name == "RefText")
                        {
                            readRefText = true;
                        }
                        break;
                    case XmlNodeType.Text: 
                        if (readRefText) {
                            if (refCode.Equals("MWB")) { refTextMwb = reader.Value; }
                            else if (refCode == "TRV") { refTextTrv = reader.Value; }
                            else if (refCode == "CAR") { refTextCar = reader.Value; }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name == "Reference")
                        {
                            refCode = "";
                        }
                        else if (reader.Name == "RefText")
                        {
                            readRefText = false;
                        }
                        break;
                }
            }

            Console.WriteLine("The RefText for MWB is " + refTextMwb + ", the RefText for TRV is " + refTextTrv + " and the RefText for CAR is " + refTextCar  + ".");
        }
    }
}
