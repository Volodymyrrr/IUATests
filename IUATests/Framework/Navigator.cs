using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using IUATests.PageObjects;

namespace IUATests.Framework
{
    static class Navigator
    {


        //static IWebDriver driver;

        public static HomePage OpenHomePage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://i.ua");
            HomePage homePage = new HomePage(driver);
            return homePage;


        }

        public static PassportPage OpenPassportPage(IWebDriver driver)
        {
            HomePage homePage = OpenHomePage(driver);
            PassportPage passportPage = homePage.LoginToEmail();
            return passportPage;
            


        }

        public static TranslatePage OpenTranslatePage(IWebDriver driver)
        {
            driver = WebDriverFactory.GetInstance();
            driver.Navigate().GoToUrl("https://perevod.i.ua/");
            TranslatePage translatePage = new TranslatePage(driver);
            return translatePage;


        }
    }
}
