using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IUATests
{
    
    public static class Waits
    {
        

        public static void WaitForDisplayed(this IWebDriver driver, int SecondsSpan, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsSpan));
            wait.Until(p => element.Displayed);
        }

        public static void WaitForEnabled(this IWebDriver driver, int SecondsSpan, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsSpan));
            wait.Until(p => driver.FindElement(by).Enabled);


        }

        public static void WaitForPage(this IWebDriver driver, int SecondsSpan)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsSpan));
            wait.Until(p => ((IJavaScriptExecutor)driver).
            ExecuteScript("return document.readyState").Equals("complete"));


        }

        public static void WaitTextEqual(this IWebDriver driver, int SecondsSpan, string text, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsSpan));
            wait.Until(p => (element.Text==text));


        }





    }
}
