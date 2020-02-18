using System;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;

namespace WebService.Controllers
{
    public class XmlController : ApiController
    {
        public String Post([FromBody] XElement xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.ToString());
            XmlNode declaration = doc.DocumentElement.SelectSingleNode("/InputDocument/DeclarationList/Declaration");
            string command = declaration.Attributes["Command"]?.InnerText;

            if (command != "DEFAULT")
            {
                //I'm returning strings since the requested Status Codes are not HTTP Status Codes
                return "Status Code -1: Invalid Command Specified";
            }

            XmlNode siteId = doc.DocumentElement.SelectSingleNode("/InputDocument/DeclarationList/Declaration/DeclarationHeader/SiteID");

            if (siteId.InnerText != "DUB")
            {
                return "Status Code -1: Invalid Site Specified";
            }

            return "Status Code 0: Document Structured Correctly";
        }
    }
}
