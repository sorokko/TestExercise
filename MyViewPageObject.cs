using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisPageTests
{
    public class MyViewPageObject
    {
        private IWebDriver _webDriver;


        private readonly By _signInButton = By.XPath("//a[text()= 'Login']");
        private readonly By _myViewPage = By.XPath("//body[@class = 'skin-3']");
        private readonly By _reportIssue = By.XPath("//div[@class = 'btn-group btn-corner padding-right-8 padding-left-8']/a[@class = 'btn btn-primary btn-sm']");

        public MyViewPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorizationPageObject SignIn()
        {
            _webDriver.FindElement(_signInButton).Click();
            return new AuthorizationPageObject(_webDriver); 
        }

        public IWebElement GetMyViewPage()
        {
            var myViewPage = _webDriver.FindElement(_myViewPage);
            return myViewPage;
        }

        public MyViewPageObject ReportIssue()
        {
            _webDriver.FindElement(_reportIssue).Click();
            return new MyViewPageObject(_webDriver);
        }
    }
}
