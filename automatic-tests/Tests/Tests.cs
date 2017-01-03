using NUnit.Framework;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace automatic_tests.Tests
{

  // [TestClass]
    class Tests
    {

        private Steps.Steps steps = new Steps.Steps();
        private const string USERNAME = "oli_cyrus";
        private const string PASSWORD = "starki11er";
        private const string NEW_PASSWORD = "starki11er";
        private const string TEXT_TO_SEARCH = "Windows 10 Professional x86 PIRATES (2016) [Ru]";
        private const string WRONG_LOGIN = "qwerty";
        private const string WRONG_PASSWORD = "123456";
        private const string NAVIGATION_LINK = "RPG";
        private const string CHANGE_TEST = "Дмитрий Глуховский - Метро 2035 (2015) FB2";
        private const string COMMENT_TEST = "Test comment";
        private const string TEST = "oli_cyrus1";
        private const string empty = "";
        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]

        public void Cleanup()
        {
            steps.CloseBrowser();
        }
        //[Test]
        //public void Login()
        //{
        //    steps.Login(USERNAME, PASSWORD);
        //    Assert.True(steps.IsLoggedIn(USERNAME));
        //}

        //[Test]
        //public void LogOff()
        //{
        //    steps.Login(USERNAME, PASSWORD);
        //    steps.LogOff();
        //    Assert.True(steps.IsLoggedOff());
        //}

        //[Test]
        //public void Search()
        //{
        //    steps.Login(USERNAME, PASSWORD);
        //    steps.SearchSoft(TEXT_TO_SEARCH);
        //    Assert.True(steps.IsSoftFounded(TEXT_TO_SEARCH));
        //}
        //[Test]
        //public void WrongLogin()
        //{
        //    steps.Login(WRONG_LOGIN, PASSWORD);
        //    Assert.True(steps.IsLoggedOff());
        //}

        //[Test]
        //public void WrongPassword()
        //{
        //    steps.Login(USERNAME, WRONG_PASSWORD);
        //    Assert.True(steps.IsLoggedOff());
        //}

        //[Test]
        //public void EmptyLoginPassword()
        //{
        //    steps.Login(empty, empty);
        //    Assert.True(steps.IsLoggedOff());
        //}



        //[Test]
        //public void NavigationPanelTest()
        //{
        //    steps.GoThroughPanel(NAVIGATION_LINK);
        //    Assert.True(steps.IsHistoryPage(NAVIGATION_LINK));
        //}
        //[Test]
        //public void AddAvatar()
        //{
        //    steps.Login(USERNAME, PASSWORD);
        //    steps.ChangeAvatar();
        //    Assert.False(steps.IsDefaultAvatar());
        //}

        //[Test]
        //public void DeleteAvatar()
        //{
        //    steps.Login(USERNAME, PASSWORD);
        //    steps.ChangeAvatar();
        //    steps.DeleteAvatar();
        //    Assert.False(steps.IsPhotoUploaded());

        //}
        //[Test]
        //public void AddComment()
        //{
        //    steps.Login(USERNAME, PASSWORD);
        //    steps.AddComment(CHANGE_TEST, COMMENT_TEST);
        //    Assert.True(steps.IsAddComment(COMMENT_TEST));
        //}

        //[Test]
        //public void DeleteComment()
        //{
        //    steps.Login(USERNAME, PASSWORD);
        //    steps.AddComment(CHANGE_TEST, COMMENT_TEST);
        //    steps.DeleteComment(CHANGE_TEST);
        //    Assert.False(steps.IsDeleteComment());
        //}

        //[Test]
        //public void ChangePassword()
        //{
        //    steps.Login(USERNAME, PASSWORD);
        //    steps.ChangePassword(PASSWORD, NEW_PASSWORD);
        //    steps.LogOff();
        //    System.Threading.Thread.Sleep(5000);
        //    steps.Login(USERNAME, NEW_PASSWORD);
        //    Assert.True(steps.IsLoggedIn(USERNAME));

        //}

        //[Test]
        //public void CreateMessage()
        //{
        //    steps.Login(USERNAME, PASSWORD);
        //    steps.CreateMessage(TEST, USERNAME);

        //    Assert.True(steps.IsCreateMessage(TEST));
        //}
        [Test]
        public void AddAvatarByURL()
        {
            steps.Login(USERNAME, PASSWORD);
            steps.ChangeAvatarByURL();
            Assert.False(steps.IsDefaultAvatar());
        }

    }
}
