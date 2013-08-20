using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CAST2013
{
    [TestFixture]
    public class v1_starting_test
    {
        [Test]
        public void one_method_to_rule_them_all()
        {
            var profile = new FirefoxProfile();
            var exe = new FirefoxBinary(@"D:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
            IWebDriver browser = new FirefoxDriver(exe, profile);

            WebDriverWait w = new WebDriverWait(browser,TimeSpan.FromSeconds(10));

            browser.Navigate().GoToUrl("http://localhost/AJAXDemos/CascadingDropDown/CascadingDropDown.aspx");
            //browser.Navigate().GoToUrl("http://www.asp.net/ajaxLibrary/AjaxControlToolkitSampleSite/CascadingDropDown/CascadingDropDown.aspx");

            w.Until(ExpectedConditions.ElementExists(By.XPath("id('ctl00_SampleContent_DropDownList1')/option[text()='Acura']")));

            var sl =browser.FindElement(By.Id("ctl00_SampleContent_DropDownList1"));
            var l = new SelectElement(sl);
            l.SelectByText("Acura");

            w.Until(ExpectedConditions.ElementExists(By.XPath("id('ctl00_SampleContent_DropDownList2')/option[text()='Integra']")));

            sl = browser.FindElement(By.Id("ctl00_SampleContent_DropDownList2"));
            l = new SelectElement(sl);
            l.SelectByText("Integra");

            w.Until(ExpectedConditions.ElementExists(By.XPath("id('ctl00_SampleContent_DropDownList3')/option[text()='Sea Green']")));

            sl = browser.FindElement(By.Id("ctl00_SampleContent_DropDownList3"));
            l = new SelectElement(sl);
            l.SelectByText("Sea Green");

            w.Until(ExpectedConditions.ElementExists(By.XPath("//span[@id='ctl00_SampleContent_Label1' and text()='You have chosen a Sea Green Acura Integra. Nice car!']")));

            browser.Quit();
        }
    }
}
