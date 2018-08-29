using System;
using NUnit.Framework;
using IUATests.PageObjects;
using IUATests.Framework.Utils;
using IUATests.Framework;

namespace IUATests
{
    [TestFixture]
    class TestEditing: TestBase
    {
        PassportPage passportPage;
        string Text;
        string Subject;
        string Receiver;

        
        public override void OneTimeSetUp()
        {
            HomePage homePage = Navigator.OpenHomePage(driver);
            homePage.SelectUkrLanguageButton.Click();
            passportPage = homePage.LoginToEmail();
            if (Elements.CheckElementPresent(passportPage.CreateMailButtonUKR))
            {
                passportPage.CreateMailButtonUKR.Click();
            }
            else
            {
                passportPage.CreateMailButtonRUS.Click();

            };
            Subject = "Subject_" + DateTime.Now.ToShortTimeString();
            Text = "MessageText";
            Receiver = "oldmail@mail.com";
            passportPage.SubjectField.SendKeys(Subject);
            passportPage.MessageField.SendKeys(Text);
            passportPage.ToField.SendKeys(Receiver);
            passportPage.SaveDraftButton.Click();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3600);



        }




        [SetUp]
        public void Setup()
        {
            passportPage.DraftsButton.Click();
            passportPage.FindMailBySubject(Subject).Click();
        }


        [TearDown]
        public override void TearDown()
        {
            passportPage.SaveDraftButton.Click();
        }

        [Test]
        public void EditTo()
        {
            passportPage.ToField.Clear();
            passportPage.ToField.SendKeys("newmail@mail.com");
            passportPage.SaveToDrafts();
            passportPage.FindMailBySubject(Subject).Click();
            Assert.AreEqual("newmail@mail.com", passportPage.ToField.GetAttribute("value"));
        }

        [Test]
        public void EditSubject()
        {
            Subject = "Subject_" + DateTime.Now.ToString();
            passportPage.SubjectField.Clear();
            passportPage.SubjectField.SendKeys(Subject);
            passportPage.SaveToDrafts();
            passportPage.DraftsButton.Click();
            passportPage.FindMailBySubject(Subject).Click();
            Assert.AreEqual(Subject, passportPage.SubjectField.GetAttribute("value"));


        }

        [Test]
        public void FillText()
        {
            passportPage.MessageField.Clear();
            passportPage.MessageField.SendKeys("Message");
            passportPage.SaveToDrafts();
            passportPage.FindMailBySubject(Subject).Click();
            Assert.AreEqual("Message\r\n", passportPage.MessageField.GetAttribute("value"));

        }


        

        


            
    }
}
