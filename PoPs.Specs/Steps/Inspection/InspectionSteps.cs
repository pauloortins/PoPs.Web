using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

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
                element = BrowserUtility.Browser.FindElementWithWait(By.CssSelector("span[data-valmsg-for='" + row["id"] + "']"));
                element.Text.Should().Be(row["value"]);
            }
        }

        [Then("should be redirected to '(.*)'")]
        public void ShouldBeRedirectedTo(string path)
        {
            BrowserUtility.Browser.Url.Should().Be("http://localhost:10228/" + path);
        }

        [Then("should show text '(.*)' at '(.*)'")]
        public void ShouldFindTextAtTag(string text, string tag)
        {
            BrowserUtility.Browser.FindElementWithWait(By.TagName(tag)).Text.Should().Be(text);
        }
    }
}
