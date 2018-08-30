using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using IUATests.PageObjects;
using OpenQA.Selenium.Interactions;
using IUATests.Framework.Utils;
using IUATests.Framework;

namespace IUATests.Tests
{

    
    [TestFixture]
    class EmailTests:TestBase {

        PassportPage passportPage;
    
    public override void OneTimeSetUp()
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        passportPage = Navigator.OpenPassportPage(driver);
     }


    [OneTimeTearDown]
    public override void TearDown()
    {
        
    }

    
        [Test]
        public void CheckMailIsTrue()
        {
            
            driver.HoverElement(passportPage.Letter4welcome);
            string popupText = passportPage.PopupText.Text;
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual("scalatest@i.ua", passportPage.MyEmailOnMailbox.GetAttribute("innerHTML"));
                    Assert.IsTrue(passportPage.Letter2recommendations.Displayed);
                    Assert.IsTrue(passportPage.Letter3help.Displayed);
                    //Assert.IsTrue(passportPage.Letter4welcome.Displayed);
                    Assert.IsTrue(popupText.Contains("Добрий день, Scalatest."));
                    Assert.IsTrue(passportPage.PopupText.Displayed);
                }
                );
            
        }

        [Test]
        public void DeleteMailShahrai()
        {
            passportPage.DeleteEmailThatContains("Обережно шахраї");
            Assert.IsFalse(Elements.CheckElementPresent(passportPage.Letter4welcome));
            driver.Navigate().Refresh();
            Assert.IsFalse(Elements.CheckElementPresent(passportPage.Letter4welcome));
        }


        [Test]
        public void MultipleWindows()
        {
            string FirstWindow = driver.CurrentWindowHandle;
            passportPage.WebsiteLogo.SendKeys(Keys.Control + Keys.Return);
            driver.Manage().Window.Maximize();
            driver.SwitchToOpenedWindow();
            passportPage.ExitButton.Click();
            driver.SwitchTo().Window(FirstWindow);
            driver.Navigate().Refresh();
            bool isSettingsButtonPresent = Elements.CheckElementPresent(passportPage.SettingsButton);
            Assert.IsFalse(isSettingsButtonPresent);
            driver.SwitchToWindowByTitle("І.UA - твоя пошта ");
            driver.Close();
        }


        
    }
}
