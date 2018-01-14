using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Shipit.Transaction
{
    public static class Actionlog
    {
        public static void actiondone(String ActionType, String Action)
        {
            try
            {
                string filename = Program.OurLogSource + "Actions.xmllog";
                StringBuilder sbuilder = new StringBuilder();
                using (StringWriter sw = new StringWriter(sbuilder))
                {
                    using (XmlTextWriter w = new XmlTextWriter(sw))
                    {
                        w.WriteStartElement("LogInfo");
                        w.WriteElementString("Time", DateTime.Now.ToString());
                        w.WriteElementString("Type", ActionType);
                        w.WriteElementString("User", Program.uername);
                        w.WriteElementString("Info", Action);
                        w.WriteEndElement();
                    }
                }
                using (StreamWriter w = new StreamWriter(filename, true, Encoding.UTF8))
                {
                    w.WriteLine(sbuilder.ToString());
                }
            }
            catch (Exception)
            {
                
                
            }

        }
    }




  




}
