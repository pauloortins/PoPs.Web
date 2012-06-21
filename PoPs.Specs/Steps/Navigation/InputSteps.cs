using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace PoPs.Specs.Steps.Navigation
{
    [Binding]
    public class InputSteps
    {
        [Given("fill fields with following data")]
        public void FillFieldsWithFollowingData(TechTalk.SpecFlow.Table table)
        {
            IWebElement element;

            foreach (TechTalk.SpecFlow.TableRow row in table.Rows)
            {
                element = BrowserUtility.Browser.FindElementWithWait(By.CssSelector("input[id='" + row["id"] + "']"));
                element.SendKeys(row["value"]);
            }
        }

        [Given(@"Fill login fields with valid data")]
        public void PreencheCamposComDadosValidos()
        {
            IWebElement username = BrowserUtility.Browser.FindElementWithWait(By.Id("Login"));
            username.SendKeys("abcd");

            IWebElement password = BrowserUtility.Browser.FindElementWithWait(By.Id("Password"));
            password.SendKeys("1234");
        }
    }
}
