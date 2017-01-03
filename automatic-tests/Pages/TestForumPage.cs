using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace automatic_tests.Pages
{
    class TestForumPage : AbstractPage
    {
        private const string BASE_URL = "http://rutracker-pro.org/viewforum.php?f=598";

        [FindsBy(How = How.XPath, Using = "(//IMG[@src='./styles/subsilver/imageset/ru/button_topic_new.gif'])[1]")]
        private IWebElement createDistr;

        [FindsBy(How = How.Name, Using = "subject")]
        private IWebElement inputName;

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement inputMessage;

        [FindsBy(How = How.Name, Using = "message")]
        private IWebElement message;

        [FindsBy(How = How.Name, Using = "post")]
        private IWebElement buttonSumbit;

        public TestForumPage(IWebDriver driver)
          : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void CreateDistr()
        {
            createDistr.Click();
        }

        public void InputDistr(string test)
        {
            inputName.Clear();
            inputMessage.Clear();
            inputName.SendKeys(test);
            inputMessage.SendKeys(test);

        }

        public void OpenDistr(string test)
        {
            driver.FindElement(By.LinkText(test)).Click();

        }

        public void InputComment(string testComment)
        {

            message.SendKeys(testComment);

        }

        public void ButtonSumbit()
        {
            buttonSumbit.Click();

        }

        public void DeleteComment()
        {
            System.Threading.Thread.Sleep(2000);
            //driver.FindElement(By.CssSelector("img[alt=\"[x]\"]")).Click();
            driver.FindElement(By.XPath("//a[starts-with(@href,'./posting.php?mode=delete&f=')][last()]")).Click();
            System.Threading.Thread.Sleep(4000);
            driver.FindElement(By.XPath("(//INPUT[@type='submit'])[2]")).Click();
        }



    }
}
