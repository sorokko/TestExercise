using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisPageTests
{
    public class AuthorizationPageObject
    {
        private IWebDriver _webdriver;

        public readonly By _loginInputButton = By.XPath("//input[@id = 'username']");
        public readonly By _loginButton = By.XPath("//input[@type = 'submit']");
        public readonly By _passwordInputButton = By.XPath("//input[@id = 'password']");
        public readonly By _enterButton = By.XPath("//input[@type = 'submit']");

        public AuthorizationPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public MyViewPageObject Login(string login, string password)
        {
            _webdriver.FindElement(_loginInputButton).SendKeys(login);
            _webdriver.FindElement(_loginButton).Click();
            _webdriver.FindElement(_passwordInputButton).SendKeys(password);
            _webdriver.FindElement(_enterButton).Click();

            return new MyViewPageObject(_webdriver);
        }
    }
}
