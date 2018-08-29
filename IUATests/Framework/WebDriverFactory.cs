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
