using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IUATests.Framework.Utils
{
    class TestConfigurations
    {


        public static string Browser;
        public static string Username;
        public static string Password;
        public static string Environment;


        public static TestConfigurations configs;

        private static string GetFileConfigPath()
        {
            string executingAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = new DirectoryInfo(executingAssembly).Parent.Parent.Parent.FullName;
            return Path.Combine(path, "Configs.xml");


        }


        public static void GetConfigs()
        {
            XmlDocument xmlDoc = new XmlDocument();
            string path = GetFileConfigPath();
            xmlDoc.Load(GetFileConfigPath());
            Browser = xmlDoc.DocumentElement.SelectSingleNode("browser").InnerText;
            Username = xmlDoc.DocumentElement.SelectSingleNode("username").InnerText;
            Password = xmlDoc.DocumentElement.SelectSingleNode("password").InnerText;
            Environment = xmlDoc.DocumentElement.SelectSingleNode("environment").InnerText;


 


        }
        public static TestConfigurations GetInstance()
        {


            //lock (obj)
            {

                if (configs == null)
                {
                    //GetFileConfigPath();
                    GetConfigs();
                    configs = new TestConfigurations();




                }
            }
            return configs;
        }
    }
}
