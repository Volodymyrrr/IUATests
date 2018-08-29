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


        public static string browser;
        public static string username;
        public static string password;
        public static string environment;


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
            browser = xmlDoc.DocumentElement.SelectSingleNode("browser").InnerText;
            username = xmlDoc.DocumentElement.SelectSingleNode("username").InnerText;
            password = xmlDoc.DocumentElement.SelectSingleNode("password").InnerText;
            environment = xmlDoc.DocumentElement.SelectSingleNode("environment").InnerText;
        }



        public static TestConfigurations GetInstance()
        {
            {
                if (configs == null)
                {
                    GetConfigs();
                    configs = new TestConfigurations();
                }
            }
            return configs;
        }
    }
}
