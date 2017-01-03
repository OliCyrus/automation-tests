using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
    class ProfilePage : AbstractPage
    {
        private const string BASE_URL = "http://rutracker-pro.org/profile.php";

        //[FindsBy(How = How.XPath, Using = "//IMG[@src='./styles/subsilver/theme/images/no_avatar.gif']")]
        //private IWebElement imgProfile;

        //[FindsBy(How = How.Name, Using = "delete")]
        //private IWebElement checkboxDeletePhoto;

        public void ProfileClick(string username)
        {
            driver.FindElement(By.LinkText(username)).Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void UserToSend()
        {
            driver.Navigate().GoToUrl("http://rutracker-pro.org/memberlist.php?mode=viewprofile&u=590103");
        } 
        public void CreateMessageClick()
        {
            driver.FindElement(By.LinkText("[Отправить ЛС]")).Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void OpenAllMessages()
        {
            driver.Navigate().GoToUrl("http://rutracker-pro.org/ucp.php?i=pm&folder=outbox");
        }

        public void SumbitMessageClick()
        {
            driver.FindElement(By.Name("post")).Click();
        }

        public void InputMessage(string test)
        {

            driver.FindElement(By.Name("subject")).SendKeys(test);
            driver.FindElement(By.Name("message")).SendKeys(test);

        }

        public ProfilePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public bool isCheckboxExists()
        {
            IWebElement checkboxDeletePhoto = driver.FindElement(By.Name("delete"));
            return checkboxDeletePhoto.Displayed;
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);

        }



        public void SubmitClick()
        {
            IWebElement buttonSubmit = driver.FindElement(By.Name("submit"));
            buttonSubmit.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void LoadPicture()
        {
            IWebElement inputChooseFile = driver.FindElement(By.Name("uploadfile"));
            inputChooseFile.SendKeys(System.IO.Path.GetFullPath(@"img/image.jpg"));
            System.Threading.Thread.Sleep(2000);


        }

        public void InputURL()
        {
            driver.FindElement(By.Name("uploadurl")).SendKeys("http://www.phpbbguru.net/community/download/file.php?avatar=45275_1458367006.jpg");
        }

        public bool isDefaultImg()
        {
            IWebElement imgProfile = driver.FindElement(By.XPath(".//*[@id='wrapcentre']/form/table/tbody/tr[43]/td/table/tbody/tr/td[2]/p[2]/img"));
            Console.WriteLine(imgProfile.GetAttribute("src"));
            return imgProfile.GetAttribute("src").Equals("http://rutracker-pro.org/styles/subsilver/theme/images/no_avatar.gif");
        }

        public void SetCheckboxDeletePhoto()
        {
            IWebElement checkboxDeletePhoto = driver.FindElement(By.Name("delete"));
            checkboxDeletePhoto.Click();
        }

        public void EnterNewPasswordInfo(string oldPassword, string newPassword)
        {
            IWebElement inputOldPassword = driver.FindElement(By.Name("cur_password"));
            inputOldPassword.SendKeys(oldPassword);
            IWebElement inputNewPassword = driver.FindElement(By.Name("new_password"));
            inputNewPassword.SendKeys(newPassword);
            IWebElement inputRepeat = driver.FindElement(By.Name("password_confirm"));
            inputRepeat.SendKeys(newPassword);
        }
    }
}
