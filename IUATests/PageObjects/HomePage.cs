using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using IUATests.Framework.Utils;

namespace IUATests.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver) => this.driver = driver;
        public IWebElement LoginInput => driver.FindElement(By.Name("login"));
        public IWebElement PasswordInput => driver.FindElement(By.Name("pass"));
        public IWebElement SendButton => driver.FindElement(By.XPath("//input[@value='Увійти']"));
        public IWebElement WebsiteLogo => driver.FindElement(By.XPath("//a[@class='ho_logo']"));
        public IWebElement RegisterLink => driver.FindElement(By.XPath("//div[@class='Left']//a[text()='Реєстрація']"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//div[@class='content clear']//a[text()='Реєстрація']"));
        public SelectElement domendropdown => new SelectElement(driver.FindElement(By.Name("domn")));
        public IWebElement LoginForm => driver.FindElement(By.Name("lform"));
        public IWebElement PostLink => driver.FindElement(By.XPath("//div[@class='Left']//a[text()='Пошта']"));
        public IWebElement ForgotPasswordLink => driver.FindElement(By.LinkText("нагадати"));
        public IWebElement RememberUserCheckbox => driver.FindElement(By.XPath("//input[@name='auth_type']"));
        public IWebElement SelectUkrLanguageButton => driver.FindElement(By.ClassName("lang1"));
        
        //public IWebElement 

        public PassportPage LoginToEmail()
        {
            HomePage homePage = new HomePage(driver);
            LoginInput.SendKeys(TestConfigurations.Username);
            PasswordInput.SendKeys(TestConfigurations.Password);
            SendButton.Click();
            return new PassportPage(driver);
        }



    }
}
