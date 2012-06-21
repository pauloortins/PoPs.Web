using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PoPs.Specs
{
    public static class SeleniumUtility
    {
        private const int WaitTime = 10000;

        public static void Click(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTime));
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(by);
            });

            element.Click();
        }

        public static IWebElement FindElementWithWait(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTime));
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(by);
            });

            return element; 
        }
    }
}
