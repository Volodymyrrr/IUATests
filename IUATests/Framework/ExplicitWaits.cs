using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IUATests
{
    
    public static class Waits
    {
        

        public static void EWaitForDisplayed(this IWebDriver driver, int SecondsSpan, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsSpan));
            wait.Until(p => element.Displayed);
        }

        public static void EWaitForEnabled(this IWebDriver driver, int SecondsSpan, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsSpan));
            wait.Until(p => driver.FindElement(by).Enabled);


        }

        public static void EWaitForPage(this IWebDriver driver, int SecondsSpan)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsSpan));
            wait.Until(p => ((IJavaScriptExecutor)driver).
            ExecuteScript("return document.readyState").Equals("complete"));


        }

        public static void EWaitTextEqual(this IWebDriver driver, int SecondsSpan, string text, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsSpan));
            wait.Until(p => (element.Text==text));


        }





    }
}
