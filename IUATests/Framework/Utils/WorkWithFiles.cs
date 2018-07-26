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


        public static void DeleteClassScreenshotsFolder()
        {
            if (System.IO.Directory.Exists(@"C:\temp\screenshots\" + TestContext.CurrentContext.Test.ClassName + @"\"))
            {
                System.IO.Directory.Delete(@"C:\temp\screenshots\" + TestContext.CurrentContext.Test.ClassName + @"\", true);
            }
        }
    }
}
