using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisPageTests
{
    public class ReportIssuePageObjects
    {
        private IWebDriver _webDriver;

        public readonly By _selectProjectButton = By.XPath("//input[@type = 'submit']");
        public readonly By _categoryDropdown = By.XPath("//select[@id = 'category_id']");
        public readonly By _categoryValue = By.XPath("//option[@value = '3']");
        public readonly By _summaryInputButton = By.XPath("//input[@tabindex = '9']");
        public readonly By _descriptionInputButton = By.XPath("//textarea[@name = 'description']");
        public readonly By _submitIssueButton = By.XPath("//input[@tabindex = '17']");
        private readonly By _viewIssuePage = By.XPath("//body[@class = 'skin-3']");

        private const string _summary = "Test Summary";
        private const string _description = "Test Description";

        public ReportIssuePageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ReportIssuePageObjects SelectProject()
        {
            _webDriver.FindElement(_selectProjectButton).Click();
            return new ReportIssuePageObjects(_webDriver);
        }

        public IWebElement GetViewIssuePage()
        {
            var viewIssuePage = _webDriver.FindElement(_viewIssuePage);
            return viewIssuePage;
        }

        public ReportIssuePageObjects ReportAndSubmitIssue()
        {
            _webDriver.FindElement(_categoryDropdown).Click();
            _webDriver.FindElement(_categoryValue).Click();
            _webDriver.FindElement(_categoryDropdown).Click();

            _webDriver.FindElement(_summaryInputButton).SendKeys(_summary);
            _webDriver.FindElement(_descriptionInputButton).SendKeys(_description);

            _webDriver.FindElement(_submitIssueButton).Click();

            return new ReportIssuePageObjects(_webDriver);
        }


    }
}
