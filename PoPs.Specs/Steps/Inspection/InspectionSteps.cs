using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PoPs.Specs.Steps.Inspection
{
    [Binding]
    public class InspectionSteps
    {
        [Then("should show the following error messages")]
        public void ShouldShowFollowingErrorMessages(TechTalk.SpecFlow.Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then("should be redirected to '(.*)'")]
        public void ShouldBeRedirectedTo(string path)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
