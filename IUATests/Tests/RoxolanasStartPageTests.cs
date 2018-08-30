using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            public HomePage homePage;

            //public object WebDriverFactory { get; private set; }

            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://www.i.ua/");
                homePage = new HomePage(driver);
                homePage.SelectUkrLanguageButton.Click();
            }



            [Test]
            public void CheckThatLoginDispalyed()

            {
                Assert.IsTrue(homePage.LoginInput.Displayed);
            }



            [Test]
            public void CheckThatPasswordDisplayed()
            {

                Assert.IsTrue(homePage.PasswordInput.Displayed);
            }

            [Test]
            public void CheckThatSendButtonDisplayed()
            {

                Assert.IsTrue(homePage.SendButton.Displayed);
            }

        }
    }
}
