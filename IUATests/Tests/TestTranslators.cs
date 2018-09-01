using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit;
using IUATests.PageObjects;
using IUATests.Framework.Utils;
using IUATests.Framework;

namespace IUATests
{
    [TestFixture]
    class TestTranslators : TestBase
    {

        
        
        HomePage homePage;
        TranslatePage translatePage;
        
        override public void  OneTimeSetUp()
        {
            TestConfigurations configs = TestConfigurations.GetInstance();
            homePage = Navigator.OpenHomePage(driver);
            homePage.SelectUkrLanguageButton.Click();
            translatePage = Navigator.OpenTranslatePage(driver);
        }


        [TestCase("Eng", "Ukr", "cat","кіт")]
        [TestCase("Eng", "Ukr", "dog", "собака")]
        [TestCase("Eng", "Ukr", "father", "батько")]
        [TestCase("Ukr", "Eng", "кіт", "cat")]
        [TestCase("Ukr", "Eng", "собака", "dog")]
        [TestCase("Ukr", "Eng", "батько", "father")]
        [TestCase("Fre", "Eng", "un chat", "cat")]
        [TestCase("Fre", "Eng", "un chien", "dog")]
        [TestCase("Fre", "Eng", "un père", "father")]
        public void TranslateWord(string FromLang, string ToLang, string Word, string TrWord)
        {
            string TranslatedWord = translatePage.TranslateWord(FromLang, ToLang, Word);
            Assert.AreEqual(TrWord, TranslatedWord);
        }



        [TearDown]
        override public void TearDown()
        {
            TranslatePage translatePage = new TranslatePage(driver);
            translatePage.FromField.Clear();
            translatePage.ToField.Clear();
        }





    }
}
