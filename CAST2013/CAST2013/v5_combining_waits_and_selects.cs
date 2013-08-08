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
    public class v5_combining_waits_and_selects
    { 
        IWebDriver browser;
        WebDriverWait wait;
        IWebElement selectionList;

        [Test]
        public void waits_and_selects_combined()
        {
            var profile = new FirefoxProfile();
            var exe = new FirefoxBinary(@"D:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
            browser = new FirefoxDriver(exe, profile);

            wait = new WebDriverWait(browser,TimeSpan.FromSeconds(10));

            //browser.Navigate().GoToUrl("http://www.asp.net/ajaxLibrary/AjaxControlToolkitSampleSite/CascadingDropDown/CascadingDropDown.aspx");
            browser.Navigate().GoToUrl("http://localhost/AJAXDemos/CascadingDropDown/CascadingDropDown.aspx");

            select_menu_item(1, "Acura");
            select_menu_item(2, "Integra");
            select_menu_item(3, "Sea Green");
            
            wait.Until(
                ExpectedConditions.ElementExists(
                    By.XPath("//span[@id='ctl00_SampleContent_Label1' and text()='You have chosen a Sea Green Acura Integra. Nice car!']")));

            browser.Quit();
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