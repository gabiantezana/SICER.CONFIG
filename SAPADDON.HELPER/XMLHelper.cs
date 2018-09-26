using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPADDON.HELPER
{
    public class XMLHelper
    {
        //TODO:
        public static String GetXMLString(System.Reflection.Assembly assembly, EmbebbedFileName xmlFile)
        {
            var resourceFullName = assembly.GetManifestResourceNames().ToList().Where(x => x.Contains(xmlFile.ToString())).FirstOrDefault();
            if (String.IsNullOrEmpty(resourceFullName))
                throw new Exception("ResourceName not found: " + xmlFile.ToString());

            using (Stream stream = assembly.GetManifestResourceStream(resourceFullName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
