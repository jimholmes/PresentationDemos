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
    public class v3_waits_to_separate_method
    { 
        WebDriverWait wait;

        [Test]
        public void a_bit_easier_to_read()
        {
            var profile = new FirefoxProfile();
            var exe = new FirefoxBinary(@"D:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
            IWebDriver browser = new FirefoxDriver(exe, profile);

            wait = new WebDriverWait(browser,TimeSpan.FromSeconds(10));

            browser.Navigate().GoToUrl("http://www.asp.net/ajaxLibrary/AjaxControlToolkitSampleSite/CascadingDropDown/CascadingDropDown.aspx");

            wait_on_menu_item(1, "Acura");

            var selectionList = 
                browser.FindElement(
                    By.Id("ctl00_SampleContent_DropDownList1"));
            var optionsList = new SelectElement(selectionList);
            optionsList.SelectByText("Acura");

            wait_on_menu_item(2, "Integra");

            selectionList = 
                 browser.FindElement(
                    By.Id("ctl00_SampleContent_DropDownList2"));
            optionsList = new SelectElement(selectionList);
            optionsList.SelectByText("Integra");

            wait_on_menu_item(3, "Sea Green");

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

        private void wait_on_menu_item(int listNum, string text)
        {
            wait.Until(
                ExpectedConditions.ElementExists(
                    By.XPath("id('ctl00_SampleContent_DropDownList" + 
                        listNum+ "')/option[text()='"+
                        text+"']")));
        }
    }
}