using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
//using IUATests.Utils;
using IUATests.Framework.Utils;

namespace IUATests.PageObjects
{
    class PassportPage
    {
        private IWebDriver driver;
        public PassportPage(IWebDriver driver) => this.driver = driver;
        public IWebElement MyEmailOnMailbox => driver.FindElement(By.CssSelector(".sn_menu_title"));
        public IWebElement Letter2recommendations => driver.FindElement(By.XPath("//span[text()='Рекомендації по безпеці Вашого акаунту']"));
        public IWebElement Letter3help => driver.FindElement(By.XPath("//span[text()='Невелика довідка про можливості пошти']"));
        public IWebElement Letter4welcome => driver.FindElement(By.XPath("//span[text()='Ласкаво просимо на I.UA!']"));
        public IWebElement Letter4Popup => driver.FindElement(By.Id("prflpudvmbox_userInfoPopUp"));
        public IWebElement PopupText => driver.FindElement(By.XPath("//div[@id='prflpudvmbox_userInfoPopUp']//li[contains(., 'Добрий день, Scalatest')]"));
        public IWebElement CreateMailButtonUKR => driver.FindElement(By.LinkText("Створити листа"));
        public IWebElement CreateMailButtonRUS => driver.FindElement(By.LinkText("Создать письмо"));
        public IWebElement DeleteMailButton => driver.FindElement(By.XPath("//span[@class='button l_r del']"));
        public IWebElement WebsiteLogo => driver.FindElement(By.XPath("//a[@class='ho_logo']"));
        public IWebElement ExitButton => driver.FindElement(By.LinkText("Вихід"));
        public IWebElement SettingsButton => driver.FindElement(By.XPath("//span[@class='icon-ho ho_settings ho_i_settings']"));
        public IWebElement SaveDraftButton => driver.FindElement(By.XPath("//input[@name='save_in_drafts']"));
        public IWebElement DraftsButton => driver.FindElement(By.XPath("//a[contains(text(),'Чернетки')]"));
        public IWebElement FirstDraft => driver.FindElement(By.XPath("//div[@class='row new']/a/span[@class='sbj']/span"));
        public IWebElement ToField => driver.FindElement(By.Id("to"));
        public IWebElement SubjectField => driver.FindElement(By.Name("subject"));
        public IWebElement MessageField => driver.FindElement(By.Id("text"));
        public IWebElement ExitItem => driver.FindElement(By.LinkText("Вийти"));
        public IWebElement AttachFileButton => driver.FindElement(By.XPath("//span[@swclass='link cancel']"));
        public IWebElement FileNameInput => driver.FindElement(By.XPath("//input[@type='file']"));
        public IWebElement FileLoadedLabel => driver.FindElement(By.XPath("//span[@class='upload_status']"));

        public IWebElement SelectUkrLanguageButton => driver.FindElement(By.ClassName("lang1"));

        public void DeleteEmailThatContains(string ContainsText)
        {
            IWebElement FirstLetterCheckbox = driver.FindElement(By.XPath("//span[contains(text(),'" + ContainsText + "')]/parent::span/parent::a/preceding-sibling::span/input"));
            FirstLetterCheckbox.Click();
            DeleteMailButton.Click();
            IAlert alert = driver.SwitchTo().Alert();
            Assert.AreEqual("Видалити листи?", alert.Text);
            alert.Accept();
            IWebElement EmailCheckBox = driver.FindElement(By.XPath("//span[contains(text(),'" + ContainsText + "')]/parent::span/parent::a/preceding-sibling::span/input"));
            Assert.IsFalse(Elements.CheckElementPresent(EmailCheckBox));


        }

        public void OldUploadFile(string FilePath, string FileName)
        {
            



        }

        public IWebElement FindMailBySubject(string Subject)
        {
            return driver.FindElement(By.XPath("//span[text()='" + Subject + "']"));


        }

        public IWebElement DownloadFileByNameLink()
        {
            return driver.FindElement(By.XPath("//b/a"));
        }

        public void LogOut()
        {
            SettingsButton.Click();
            ExitItem.Click();


        }


        public void OpenFirstDraft()
        {
            DraftsButton.Click();
            FirstDraft.Click();
        }


        public void SaveToDrafts()
        {
            SaveDraftButton.Click();
        }

        public void UploadFile(string filepath, string filename)
        {
            driver.WaitForDisplayed(7, AttachFileButton);
            AttachFileButton.Click();
            driver.WaitForDisplayed(7, FileNameInput);
            FileNameInput.SendKeys(@filepath + @filename);
            driver.WaitForDisplayed(7, FileLoadedLabel);
            SubjectField.SendKeys("Upload");

        }
    }
}
