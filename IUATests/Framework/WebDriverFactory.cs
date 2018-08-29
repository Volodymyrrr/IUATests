using System;
using OpenQA.Selenium;
using IUATests.Framework.Utils;
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

                if (TestConfigurations.browser == chrome)
                {


                    driver = new ChromeDriver();
                }
                else if (TestConfigurations.browser == firefox)
                {


                    driver = new FirefoxDriver();
                }
                else if (TestConfigurations.browser == internetExplorer)
                {
                    //InternetExplorerOptions internetExplorerOptions = new InternetExplorerOptions();
                    //internetExplorerOptions.IgnoreZoomLevel = true;
                    //internetExplorerOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    //internetExplorerOptions.ForceCreateProcessApi = true;
                    //internetExplorerOptions.BrowserCommandLineArguments = "--port=5555";
                    //internetExplorerOptions.EnsureCleanSession = true;
                    //driver = new InternetExplorerDriver(@"C:\Sources\");

                    //InternetExplorerDriverService internetExplorerDriverService = InternetExplorerDriverService.CreateDefaultService();
                    //internetExplorerDriverService.Port = 5555;
                    //return new InternetExplorerDriver(@"C:\Sources\");
                    driver = new InternetExplorerDriver();


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
