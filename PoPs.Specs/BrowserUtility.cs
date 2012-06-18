using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using PoPs.Repository.Migrations;

namespace PoPs.Specs
{
    [Binding]
    public class BrowserUtility
    {
        public static IWebDriver Browser { get; set; }

        [BeforeScenario(@"ResetForEachTest")]
        public void InitTest()
        {
            Browser = new FirefoxDriver();
            Browser.Manage().Cookies.DeleteAllCookies();

            RestartDB.RestartDataBase();
        }

        [AfterScenario(@"ResetForEachTest")]
        public void FinishTest()
        {
            Browser.Close();
        }
    }
}
