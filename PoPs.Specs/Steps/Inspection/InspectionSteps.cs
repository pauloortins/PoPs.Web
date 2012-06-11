using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PoPs.Specs.Steps.Inspection
{
    [Binding]
    public class InspectionSteps
    {
        [Then("should show the following error messages")]
        public void ShouldShowFollowingErrorMessages(TechTalk.SpecFlow.Table table)
        {
            IWebElement element;

            foreach (TechTalk.SpecFlow.TableRow row in table.Rows)
            {
                element = BrowserUtility.Browser.FindElement(By.CssSelector("input[data-valmsg-for='" + row["id"] + "']"));
                Assert.AreEqual(row["value"], element.Text);
            }
        }

        [Then("should be redirected to '(.*)'")]
        public void ShouldBeRedirectedTo(string path)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
