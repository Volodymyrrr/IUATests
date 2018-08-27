//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using IUATests.Framework.Utils;
using IUATests.Framework;

namespace IUATests
{

    public class ClassTests
    {
        //scalatest
        //scala777
        //

        IWebDriver driver;
        //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);



        //[OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.Navigate().GoToUrl("http://i.ua");
            //driver.EWaitForPage(30);
        }


        //[OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        //[Test]
        public void TestLoginFormElementsDisplayed()
        {
            IWebElement LoginField = driver.FindElement(By.Name("login"));
            IWebElement PasswordField = driver.FindElement(By.Name("pass"));
            IWebElement RegisterLink = driver.FindElement(By.XPath("//div[@class='Left']//a[text()='Реєстрація']"));
            IWebElement LoginButton = driver.FindElement(By.XPath("//div[@class='content clear']//a[text()='Реєстрація']"));
            IWebElement DomainField = driver.FindElement(By.Name("domn"));
            IWebElement LoginForm = driver.FindElement(By.Name("lform"));
            IWebElement PostLink = driver.FindElement(By.XPath("//div[@class='Left']//a[text()='Пошта']"));
            IWebElement ForgotPasswordLink = driver.FindElement(By.LinkText("нагадати"));
            IWebElement RememberUserCheckbox = driver.FindElement(By.CssSelector("a.float_right"));
            Assert.Multiple(
                () =>
                {
                    Assert.IsTrue(LoginField.Displayed);
                    Assert.IsTrue(PasswordField.Displayed);
                    Assert.IsTrue(RegisterLink.Displayed);
                    Assert.IsTrue(LoginButton.Displayed);
                    Assert.IsTrue(DomainField.Displayed);
                    Assert.IsTrue(LoginForm.Displayed);
                    Assert.IsTrue(PostLink.Displayed);
                    Assert.IsTrue(ForgotPasswordLink.Displayed);
                    Assert.IsTrue(RememberUserCheckbox.Displayed);
                });
        }


        //[Test]
        public void LoginToEmail()
        {
            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));
            IWebElement SendButton = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            LoginInput.SendKeys("scalatest");
            PassInput.SendKeys("scala777");
            SendButton.Click();
            Assert.AreEqual("Вхідні - I.UA ", driver.Title);
        }

        //[Test]
        public void CheckLoginFormFilled()
        {
            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));
            IWebElement SendButton = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            LoginInput.SendKeys("scalatest");
            PassInput.SendKeys("scala777");
            IWebElement RememberUserCheckbox = driver.FindElement(By.Name("auth_type"));
            RememberUserCheckbox.Click();
            SelectElement domendropdown = new SelectElement(driver.FindElement(By.Id("auth_type")));
            //domendropdown.SelectByValue("i.ua");            
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual("scalatest", LoginInput.GetAttribute("value"));
                    Assert.AreEqual("scala777", PassInput.GetAttribute("value"));
                    Assert.IsTrue(RememberUserCheckbox.Displayed);
                    Assert.AreEqual(domendropdown.SelectedOption.Text, "i.ua");
                }
                );
        }

        public void DeleteEmailThatContains(string ContainsText)
        {
            IWebElement FirstLetterCheckbox = driver.FindElement(By.XPath("//span[contains(text(),'" + ContainsText + "')]/parent::span/parent::a/preceding-sibling::span/input"));
            FirstLetterCheckbox.Click();
            IWebElement DeleteMailButton = driver.FindElement(By.XPath("//span[@class='button l_r del']"));
            DeleteMailButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.AreEqual("Видалити листи?", alert.Text);
            alert.Accept();
            //IWebElement Letter1Warning = driver.FindElement(By.XPath("//span[contains(text(),'" + ContainsText + "')]/parent::span/parent::a/preceding-sibling::span/input"));
            IWebElement CheckBox = driver.FindElement(By.XPath("//span[contains(text(),'" + ContainsText + "')]/parent::span/parent::a/preceding-sibling::span/input"));
            Assert.IsFalse(Elements.CheckElementPresent(CheckBox));
        }

        //[Test]
        public void CheckMailIsTrue()
        {
            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));
            IWebElement SendButton = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            LoginInput.SendKeys("scalatest");
            PassInput.SendKeys("scala777");
            SendButton.Click();
            //Assert.AreEqual("Вхідні - I.UA ", driver.Title);
            //Thread.Sleep(3000);
            IWebElement MyEmailOnMailbox = driver.FindElement(By.CssSelector(".sn_menu_title"));
            //IWebElement Letter1Warning = driver.FindElement(By.XPath("//span[text()='Обережно шахраї!']"));
            IWebElement Letter2recommendations = driver.FindElement(By.XPath("//span[text()='Рекомендації по безпеці Вашого акаунту']"));
            IWebElement letter3help = driver.FindElement(By.XPath("//span[text()='Невелика довідка про можливості пошти']"));
            IWebElement letter4welcome = driver.FindElement(By.XPath("//span[text()='Ласкаво просимо на I.UA!']"));
            //Email popup
            Actions action = new Actions(driver);
            action.MoveToElement(letter4welcome).Build().Perform();
            //Thread.Sleep(1000);
            IWebElement Letter4Popup = driver.FindElement(By.Id("prflpudvmbox_userInfoPopUp"));
            //Thread.Sleep(1000);
            IWebElement PopupText = driver.FindElement(By.XPath("//div[@id='prflpudvmbox_userInfoPopUp']//li[contains(., 'Добрий день, Scalatest')]"));
            string s = PopupText.Text;
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual("scalatest@i.ua", MyEmailOnMailbox.GetAttribute("innerHTML"));
                    //Assert.IsTrue(Letter1Warning.Displayed);
                    Assert.IsTrue(Letter2recommendations.Displayed);
                    Assert.IsTrue(letter3help.Displayed);
                    Assert.IsTrue(letter4welcome.Displayed);
                    Assert.IsTrue(s.Contains("Добрий день, Scalatest."));
                    Assert.IsTrue(PopupText.Displayed);
                }
                );
        }
    

        //[Test]
        public void DeleteMailShahrai()
        {
            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));
            IWebElement SendButton = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            LoginInput.SendKeys("scalatest");
            PassInput.SendKeys("scala777");
            SendButton.Click();
            //Assert.AreEqual("Вхідні - I.UA ", driver.Title);
            //Thread.Sleep(3000);
            //IWebElement MyEmailOnMailbox = driver.FindElement(By.CssSelector(".sn_menu_title"));
            DeleteEmailThatContains("Обережно шахраї");
        }

        //[Test]
        public void MultipleWindows(){
            string FirstWindow = driver.CurrentWindowHandle;
            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));
            IWebElement SendButton = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            LoginInput.SendKeys("scalatest");
            PassInput.SendKeys("scala777");
            SendButton.Click();

            IWebElement WebsiteLogo = driver.FindElement(By.XPath("//a[@class='ho_logo']"));
            //String selectLinkOpeninNewTab = Keys.(Keys.Control, Keys.Return);
            //IWebElement WebsiteLogo = driver.FindElement(By.LinkText("Пошта"));
            WebsiteLogo.SendKeys(Keys.Control + Keys.Return);
            driver.Manage().Window.Maximize();
            driver.SwitchToOpenedWindow();
            //IWebElement UserMenu = driver.FindElement(By.XPath("//span[@class='icon-ho ho_settings ho_i_settings']"));
            //UserMenu.Click();
            //IWebElement ExitItem = driver.FindElement(By.XPath("//div[@id='accountSettingsPopup']//a[text()='Вийти']"));
            //ExitItem.Click();
            IWebElement ExitButton = driver.FindElement(By.LinkText("Вихід"));
            ExitButton.Click();
            driver.SwitchTo().Window(FirstWindow);
            driver.Navigate().Refresh();
            IWebElement Settings = driver.FindElement(By.XPath("//span[@class='icon-ho ho_settings ho_i_settings']"));
            Assert.IsFalse(Elements.CheckElementPresent(Settings));
            driver.SwitchToWindowByTitle("І.UA - твоя пошта ");
        }
    }

    //public class MultipleWindows
    //{
    //}

}
