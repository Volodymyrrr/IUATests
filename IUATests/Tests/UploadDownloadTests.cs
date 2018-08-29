using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using IUATests.Tests;
using IUATests.Framework;
using IUATests.PageObjects;
using IUATests.Framework.Utils;
using System.Threading;
using System.IO;

namespace IUATests.Tests
{

    [TestFixture]
    class UploadDownloadTests:TestBase
    {

        PassportPage passportPage;
        
        public override void OneTimeSetUp()
        {
            passportPage = Navigator.OpenPassportPage(driver);
        }

        [SetUp]
        public void SetUp()
        { 


        }

        
        [Test]
        public void UploadDownloadFile()
        {
            passportPage.UploadFile(@"C:\temp\", @"2017-12-05_Zircon_15248.log");
            passportPage.SaveDraftButton.Click();
            passportPage.DraftsButton.Click();
            passportPage.FindMailBySubject("Upload").Click();
            passportPage.DownloadFileByNameLink().Click();
            Assert.IsTrue(File.Exists(@"C:\Users\User\Downloads\2017-12-05_Zircon_15248.log"));
        }



        [TearDown]
        public override void TearDown()
        {
            


        }

    
    public override void OneTimeTearDown()
        {
            


        }




    }
}
