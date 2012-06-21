using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Web;
using OpenQA.Selenium;

namespace PoPs.Specs.Steps.Navigation
{
    [Binding]
    public class NavigationSteps : TechTalk.SpecFlow.Steps
    {
        [Given("navigate to (.*)")]
        public void NavigateTo(string path)
        {
            BrowserUtility.Browser.Navigate().GoToUrl("http://localhost:10228");
        }

        [Given("click in the link (.*)")]
        [When("click in the link (.*)")]
        public void ClickInLink(string linkName)
        {
            BrowserUtility.Browser.Click(By.LinkText(linkName));
        }

        [Given("click in the button (.*)")]
        [When("click in the button (.*)")]
        public void ClickInButton(string buttonName)
        {
            BrowserUtility.Browser.Click(By.CssSelector("input[Value='" + buttonName + "']"));
        }

        [Given(@"user is logged")]
        public void UserLogsIn()
        {
            Given(@"navigate to ''");
            Given(@"click in the link login");
            Given(@"Fill login fields with valid data");
            Given(@"click in the button login");
        }
    }
}
