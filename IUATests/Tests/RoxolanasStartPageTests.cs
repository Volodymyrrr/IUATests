using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

using System.Xml;
using System.IO;
using System.Configuration;
using IUATests.PageObjects;

namespace IUATests.Tests
{
    class RoxolanasStartPageTests
    {
        [TestFixture]
        public class LoginPage
        {
            IWebDriver driver;
            private object webdriver;
            HomePage homePage;
            //InboxPage inboxPage;

            public object WebDriverFactory { get; private set; }

            [OneTimeSetUp]
            public void SetUp()
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://www.i.ua/");
            }


            [Test]
            public void DisplayedLogin()

            {
                HomePage homePage = new HomePage(driver);
                Assert.IsTrue(homePage.LoginInput.Displayed);
            }



            [Test]
            public void DisplayedPassword()
            {
                HomePage homePage = new HomePage(driver);
                Assert.IsTrue(homePage.PasswordInput.Displayed);
            }

            [Test]
            public void DisplayedSendButton()
            {
                HomePage homePage = new HomePage(driver);
                Assert.IsTrue(homePage.SendButton.Displayed);
            }

        }
    }
}
