using System;
using OpenQA.Selenium;

namespace automatic_tests.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }

        public void Login(string username, string password)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Login(username, password);

        }

        public void LogOff()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.LogOff();
        }

        public bool IsLoggedIn(string username)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Console.WriteLine(mainPage.GetLoggedInUserName());
            return (mainPage.GetLoggedInUserName().Equals(username));
        }

        public bool IsLoggedOff()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.isEnterButtonExists();
        }

        public bool IsPhotoUploaded()
        {
            //Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);

            //return profilePage.isCheckboxExists();
           // checkboxDeletePhoto = driver.FindElement(By.Name("delete"));
            By checkboxDeletePhoto = By.Name("delete");
            ////  Console.WriteLine(pageHeader.Text);
            ////  return pageHeader.Text;

            //return pageHeader.Displayed;

            if (Exists(checkboxDeletePhoto))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SearchSoft(string softName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Search(softName);
        }

        public bool IsSoftFounded(string softName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.GetFindFilm(softName).Trim().ToLower().Equals(softName.Trim().ToLower());
        }

        public void GoThroughPanel(string input)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.GoThroughPanel(input);
        }

        public bool IsHistoryPage(string input)
        {
            IWebElement pageHeader = driver.FindElement(By.LinkText(input));
            return pageHeader.Text.Equals(input);
        }

        public void ChangeAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.LoadPicture();
            profilePage.SubmitClick();
            driver.FindElement(By.LinkText("Вернуться в личный раздел")).Click();

        }
        public void ChangeAvatarByURL()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.InputURL();
            profilePage.SubmitClick();
            driver.FindElement(By.LinkText("Вернуться в личный раздел")).Click();

        }

        public void DeleteAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.SetCheckboxDeletePhoto();
            profilePage.SubmitClick();
            driver.FindElement(By.LinkText("Вернуться в личный раздел")).Click();
        }

        public bool IsDefaultAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isDefaultImg();
        }

        public void AddComment(string changeTest, string testComment)
        {
            Pages.TestForumPage testForumPage = new Pages.TestForumPage(driver);
            testForumPage.OpenPage();
            testForumPage.OpenDistr(changeTest);
            testForumPage.InputComment(testComment);
            testForumPage.ButtonSumbit();
            System.Threading.Thread.Sleep(3000);

        }

        public void DeleteComment(string changeTest)
        {
            Pages.TestForumPage testForumPage = new Pages.TestForumPage(driver);
            testForumPage.OpenPage();
            testForumPage.OpenDistr(changeTest);
            testForumPage.DeleteComment();
            //  testForumPage.ButtonSumbit();
            System.Threading.Thread.Sleep(3000);
        }

        public bool IsAddComment(string testComment)
        {
            IWebElement pageHeader = driver.FindElement(By.XPath("//DIV[@class='postbody'][text()='Test comment']"));
            //  Console.WriteLine(pageHeader.Text);
            return (pageHeader.Text.Equals(testComment));
        }

        public bool Exists(By by)
        {
            if (driver.FindElements(by).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsDeleteComment()
        {
            By pageHeader = By.XPath("//a[starts-with(@href,'./posting.php?mode=delete&f=')][last()]");

            if(Exists(pageHeader))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();

            // profilePage.EditProfileClick();
            profilePage.EnterNewPasswordInfo(oldPassword, newPassword);
            profilePage.SubmitClick();
            mainPage.OpenPage();
        }

        public void CreateMessage(string test, string username)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            // profilePage.ProfileClick(username);
            profilePage.UserToSend();
            profilePage.CreateMessageClick();
           // profilePage.AddUser();
            profilePage.InputMessage(test);
            profilePage.SumbitMessageClick();
            profilePage.ProfileClick(username);
            profilePage.OpenAllMessages();
            System.Threading.Thread.Sleep(5000);
            //    driver.FindElement(By.LinkText("Перейти к просмотру профиля")).Click();
        }

        public bool IsCreateMessage(string test)
        {
            IWebElement pageHeader = driver.FindElement(By.LinkText(test));
            //  Console.WriteLine(pageHeader.Text);
            return pageHeader.Text.Equals(test);
        }




    }
}
