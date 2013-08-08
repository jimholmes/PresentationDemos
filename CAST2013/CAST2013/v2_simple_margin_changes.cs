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
    public class v2_simple_margin_changes
    { 
        [Test]
        public void a_bit_easier_to_read()
        {
            var profile = new FirefoxProfile();
            var exe = new FirefoxBinary(@"D:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
            IWebDriver browser = new FirefoxDriver(exe, profile);

            WebDriverWait wait = new WebDriverWait(browser,TimeSpan.FromSeconds(10));
            browser.Navigate().GoToUrl("http://localhost/AJAXDemos/CascadingDropDown/CascadingDropDown.aspx");
            //browser.Navigate().GoToUrl("http://www.asp.net/ajaxLibrary/AjaxControlToolkitSampleSite/CascadingDropDown/CascadingDropDown.aspx");

            wait.Until(
                ExpectedConditions.ElementExists(
                    By.XPath("id('ctl00_SampleContent_DropDownList1')/option[text()='Acura']")));

            var selectionList = 
                browser.FindElement(
                    By.Id("ctl00_SampleContent_DropDownList1"));
            var optionsList = new SelectElement(selectionList);
            optionsList.SelectByText("Acura");

            wait.Until(
                    ExpectedConditions.ElementExists(
                        By.XPath("id('ctl00_SampleContent_DropDownList2')/option[text()='Integra']")));

            selectionList = 
                 browser.FindElement(
                    By.Id("ctl00_SampleContent_DropDownList2"));
            optionsList = new SelectElement(selectionList);
            optionsList.SelectByText("Integra");

            wait.Until(
                ExpectedConditions.ElementExists(
                    By.XPath("id('ctl00_SampleContent_DropDownList3')/option[text()='Sea Green']")));

            selectionList = 
                browser.FindElement(
                    By.Id("ctl00_SampleContent_DropDownList3"));
            optionsList = new SelectElement(selectionList);
            optionsList.SelectByText("Sea Green");

            wait.Until(
                ExpectedConditions.ElementExists(
                    By.XPath("//span[@id='ctl00_SampleContent_Label1' and text()='You have chosen a Sea Green Acura Integra. Nice car!']")));

            browser.Quit();
        }
    }
}