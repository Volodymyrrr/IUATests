using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace IUATests.Framework.Utils
{
    class WorkWithFiles
    {
        public string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

        public static void DeleteClassScreenshotsFolder()
        {
            string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            if (System.IO.Directory.Exists(@baseDirectory + @"Output\Screenshots\" + TestContext.CurrentContext.Test.ClassName + @"\"))
            {
                System.IO.Directory.Delete(@baseDirectory + @"Output\Screenshots\" + TestContext.CurrentContext.Test.ClassName + @"\", true);
            }
        }
    }
}
