using NUnit.Framework;
using IUATests.PageObjects;
using IUATests.Framework.Utils;
using IUATests.Framework;

namespace IUATests.Tests
{
    [TestFixture]
    [Category("C_HomePage")]
    class HomePageTests:TestBase
    {


        HomePage homePage;

        
        public override void OneTimeSetUp()
        {
            Navigator.OpenHomePage(driver);
            homePage = new HomePage(driver);
            driver.Manage().Window.Maximize();
            homePage.SelectUkrLanguageButton.Click();
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            


        }


        
        public override void OneTimeTearDown()
        {

        }

        [Test]
        public void TestLoginFormElementsDisplayed()
        {

            Assert.Multiple(
                () =>
                {
                    Assert.IsTrue(homePage.LoginInput.Displayed);
                    Assert.IsTrue(homePage.PasswordInput.Displayed);
                    Assert.IsTrue(homePage.RegisterLink.Displayed);
                    Assert.IsTrue(homePage.LoginButton.Displayed);
                    Assert.IsTrue(homePage.LoginForm.Displayed);
                    Assert.IsTrue(homePage.PostLink.Displayed);
                    Assert.IsTrue(homePage.RememberUserCheckbox.Displayed);
                });
        }

        


        [Test]
        public void CheckLoginFormFilled()
        {
            homePage = new HomePage(driver);
            homePage.LoginInput.SendKeys("scalatest");
            homePage.PasswordInput.SendKeys("scala777");
            homePage.RememberUserCheckbox.Click();      
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual("scalatest", homePage.LoginInput.GetAttribute("value"));
                    Assert.AreEqual("scala777", homePage.PasswordInput.GetAttribute("value"));
                    Assert.IsTrue(homePage.RememberUserCheckbox.Displayed);
                    Assert.AreEqual(homePage.domendropdown.SelectedOption.Text, "i.ua");
                }
                );
        }


    }
}

