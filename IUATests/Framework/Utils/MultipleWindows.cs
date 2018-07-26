using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace IUATests.Framework
{
    static class MultipleWindows
    {


        public static void SwitchToOpenedWindow(this IWebDriver driver)
        {
            var Windows = driver.WindowHandles;
            string FirstWindow = driver.CurrentWindowHandle;
            string SecondWindow = "";
            foreach (var Window in Windows)
            {
                if (Window != FirstWindow)
                    SecondWindow = Window;
                driver.SwitchTo().Window(SecondWindow);
            }

        }


        public static void SwitchToWindowByTitle(this IWebDriver driver, string title)
        {
            var Windows = driver.WindowHandles;
            foreach (var Window in Windows)
            {
                if (driver.SwitchTo().Window(Window).Title == title)
                {
                    driver.SwitchTo().Window(Window);
                    break;
                }
            }
        }
    }
}
