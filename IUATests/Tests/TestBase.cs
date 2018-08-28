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
using NUnit.Framework.Interfaces;

namespace IUATests.Framework.Utils
{
    class TestBase
    {
        public IWebDriver driver;


        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {

            WorkWithFiles.DeleteClassScreenshotsFolder();
            driver = WebDriverFactory.GetInstance();
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
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshots.MakeScreenshot(driver);
            }
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
