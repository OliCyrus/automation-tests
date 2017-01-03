using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace automatic_tests.Pages
{
    class MainPage : AbstractPage
    {
        private const string BASE_URL = "http://rutracker-pro.org/index.php";
        private bool acceptNextAlert = true;

        [FindsBy(How = How.Name, Using = "login")]
        private IWebElement buttonEnter;

        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "(//A[@href='./memberlist.php?mode=viewprofile&u=211432'][text()='oli_cyrus'])[1]")]
        private IWebElement linkLoggedInUser;

        [FindsBy(How = How.Id, Using = "keywords")]
        private IWebElement inputSearch;

        [FindsBy(How = How.CssSelector, Using = "input.med")]
        private IWebElement buttonStartSearch;




        public MainPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }
        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);

        }

        public void Login(string username, string password)
        {
         
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonEnter.Click();          
            System.Threading.Thread.Sleep(1000);
        }

        public void LogOff()
        {
            IWebElement buttonExit = driver.FindElement(By.LinkText("Выход"));
            buttonExit.Click();
            buttonExit.Click();
            Thread.Sleep(2000);

        }

        public string GetLoggedInUserName()
        {
            return linkLoggedInUser.Text;
        }

        public bool isEnterButtonExists()
        {
            return buttonEnter.Displayed;
        }

        public void Search(string text)
        {
            inputSearch.SendKeys(text);
            buttonStartSearch.Click();
        }

        public string GetFindFilm(string soft_name)
        {
            IWebElement linkSoft = driver.FindElement(By.LinkText(soft_name));
            Console.WriteLine(linkSoft.Text);
            return linkSoft.Text;
        }

        public void GoThroughPanel(string input)
        {
            driver.FindElement(By.LinkText("Игры для PC")).Click();
            Thread.Sleep(2000);
            IWebElement linkPanel = driver.FindElement(By.LinkText(input));
            linkPanel.Click();
            Console.WriteLine(linkPanel.Text);
            Thread.Sleep(5000);
        }

    }
}
