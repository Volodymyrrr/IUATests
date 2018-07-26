using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.IO;

namespace IUATests.Framework.Utils
{
    class TestBase
    {
        public IWebDriver driver;


        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            IWebDriver d1 = WebDriverFactory.GetInstance();
            IWebDriver d2 = WebDriverFactory.GetInstance();

            WorkWithFiles.DeleteClassScreenshotsFolder();
            driver = WebDriverFactory.GetInstance();
            //driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            OneTimeSetUp();
            

        }


        public virtual void OneTimeSetUp()
        {



        }


        [SetUp]
        public void BaseSetUp()
        {
            Console.WriteLine("---------------");
            Console.WriteLine(TestContext.CurrentContext.Test.Name);
            SetUp();

        }


        

        public virtual void SetUp()
        {



        }

        [TearDown]
        public void BaseTearDown()
        {
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome.Status);
            Console.WriteLine("---------------");
            Screenshots.MakeScreenshot(driver);
            TearDown();

        }

        public virtual void TearDown()
        {



        }


 

        [OneTimeTearDown]
        public void BaseOneTimeTearDown()
        {
            OneTimeTearDown();
            driver.Quit();
            

        }

        public virtual void OneTimeTearDown()
        {



        }

    }
}
