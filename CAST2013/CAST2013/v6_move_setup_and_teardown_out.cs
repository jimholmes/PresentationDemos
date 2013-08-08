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
    public class v6_move_setup_and_teardown_out
    { 
        IWebDriver browser;
        WebDriverWait wait;
        IWebElement selectionList;

        [TestFixtureSetUp]
        public void run_once_before_anything()
        {
            var profile = new FirefoxProfile();
            var exe = new FirefoxBinary(@"D:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
            browser = new FirefoxDriver(exe, profile);

            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(10));

            //browser.Navigate().GoToUrl("http://www.asp.net/ajaxLibrary/AjaxControlToolkitSampleSite/CascadingDropDown/CascadingDropDown.aspx");
            browser.Navigate().GoToUrl("http://localhost/AJAXDemos/CascadingDropDown/CascadingDropDown.aspx");
        }

        [TestFixtureTearDown]
        public void run_once_after_everything_else()
        {
            browser.Quit();
        }

        [Test]
        public void move_setup_out()
        {
            select_menu_item(1, "Acura");
            select_menu_item(2, "Integra");
            select_menu_item(3, "Sea Green");
            
            wait.Until(
                ExpectedConditions.ElementExists(
                    By.XPath("//span[@id='ctl00_SampleContent_Label1' and text()='You have chosen a Sea Green Acura Integra. Nice car!']")));
        }

        private void select_menu_item(int listNum, string item)
        {
            wait_on_menu_item(listNum, item);
            selectionList =
                            browser.FindElement(
                                By.Id("ctl00_SampleContent_DropDownList" + listNum));
            var optionsList = new SelectElement(selectionList);
            optionsList.SelectByText(item);
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