using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using IUATests.Framework.Utils;
using IUATests.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;


namespace IUATests.Framework
{
    class WebDriverFactory
    {


        public const string chrome = "CH";
        public const string firefox = "FF";
        public const string internetExplorer = "IE";
        public static IWebDriver driver = null;
        public static IWebDriver GetInstance()
        {
            //driver = TestConfigurations.Browser;

            if (driver == null)
            {
                TestConfigurations configs = TestConfigurations.GetInstance();

                if (TestConfigurations.Browser == chrome)
                {


                    driver = new ChromeDriver();
                }
                else if (TestConfigurations.Browser == firefox)
                {


                    driver = new FirefoxDriver();
                }
                else if (TestConfigurations.Browser == internetExplorer)
                {
                    //InternetExplorerOptions internetExplorerOptions = new InternetExplorerOptions();
                    //internetExplorerOptions.IgnoreZoomLevel = true;
                    //internetExplorerOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    //internetExplorerOptions.ForceCreateProcessApi = true;
                    //internetExplorerOptions.BrowserCommandLineArguments = "--port=5555";
                    //internetExplorerOptions.EnsureCleanSession = true;
                    driver = new InternetExplorerDriver(@"C:\Sources\");

                    //InternetExplorerDriverService internetExplorerDriverService = InternetExplorerDriverService.CreateDefaultService();
                    //internetExplorerDriverService.Port = 5555;
                    //return new InternetExplorerDriver(@"C:\Sources\");



                }
                else
                {


                    throw new Exception("Not valid browser in configss");

                }
            }
                return driver;
            
            }
            


        



    }
}
