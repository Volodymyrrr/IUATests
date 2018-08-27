using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;

namespace IUATests.PageObjects
{
    class TranslatePage
    {
        public IWebDriver driver;
        public TranslatePage(IWebDriver driver) => this.driver = driver;
        public IWebElement FromField => driver.FindElement(By.Id("first_textarea"));
        public IWebElement FirstLanguageSelector => driver.FindElement(By.Id("first_lang_selector"));
        public IWebElement SecondLanguageSelector => driver.FindElement(By.Id("second_lang_selector"));
        public IWebElement TranslateButton => driver.FindElement(By.XPath("//input[@name='commit']"));
        public IWebElement ToField => driver.FindElement(By.Id("second_textarea"));

        public string TranslateWord(string LangFrom, string LangTo, string FordFrom)
        {
            FirstLanguageSelector.Click();
            IWebElement LanguageFromItem = driver.FindElement(By.XPath("//div[@id='popup_language_menu_1']//li[contains(@data-lang,'"+LangFrom+"')]"));
            driver.WaitForDisplayed(5, LanguageFromItem);
            LanguageFromItem.Click();

            SecondLanguageSelector.Click();
            IWebElement LanguageToItem = driver.FindElement(By.XPath("//div[@id='popup_language_menu_2']//li[contains(@data-lang,'" + LangTo + "')]"));
            driver.WaitForDisplayed(5, LanguageToItem);
            LanguageToItem.Click();

            FromField.SendKeys(FordFrom);
            TranslateButton.Click();
            return ToField.GetAttribute("innerHTML");          
        }

    }
}
