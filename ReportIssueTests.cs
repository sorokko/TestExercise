using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisPageTests
{
    public class ReportIssueTests
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
        public void ReportIssueTest()
        {
            var mainMenu = new MyViewPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(UserCredentials.UserName, UserCredentials.UserPassword)
                .ReportIssue();

            var reportIssue = new ReportIssuePageObjects(_webDriver);
            reportIssue
                .SelectProject()
                .ReportAndSubmitIssue();

            var viewIssuePage = reportIssue.GetViewIssuePage();
            Assert.IsTrue(viewIssuePage.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
            
    }
}
