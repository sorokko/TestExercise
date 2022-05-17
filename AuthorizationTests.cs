using NUnit.Framework;
using OpenQA.Selenium;

namespace MantisPageTests
{
    public class Tests
    {
        private IWebDriver _webDriver;

        [SetUp]

        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.mantisbt.org/bugs/my_view_page.php");
            _webDriver.Manage().Window.Maximize();
        }
        
        [Test]
        public void AuthorizationTest()
        {
            var mainMenu = new MyViewPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(UserCredentials.UserName, UserCredentials.UserPassword);

            var myViewPage = mainMenu.GetMyViewPage(); 
            Assert.IsTrue(myViewPage.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}