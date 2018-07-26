using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace IUATests.Framework.Utils
{
    static class Elements
    {


        public static bool CheckElementPresent(this IWebDriver driver, IWebElement element)
        {
            bool isPresent = true;
            try
            {
                bool Displayed = element.Displayed;
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                isPresent = false;
            }
            return isPresent;
        }

        public static void HoverElement(this IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
        }

        


     }

    
}
