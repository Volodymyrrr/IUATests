using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUATests.Framework.Utils
{
    static class Screenshots
    {


        public static void MakeScreenshot(IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            string title = TestContext.CurrentContext.Test.Name;
            string runName = title + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string filePath = @baseDirectory + @"Output\Screenshots\"+TestContext.CurrentContext.Test.ClassName+@"\";
            if (!System.IO.Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }

            ss.SaveAsFile(Path.Combine(filePath + runName + ".jpg"), ScreenshotImageFormat.Jpeg);


        }
    }
}
