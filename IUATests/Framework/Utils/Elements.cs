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
    public static class Elements
    {


        public static bool CheckElementPresent(IWebElement element)
        {
            bool isPresent = true;
            try
            {
                bool displayed = element.Displayed;
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
