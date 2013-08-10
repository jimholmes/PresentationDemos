using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAST2013.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CAST2013
{
    [TestFixture]
    public class v8_page_objects
    { 
        IWebDriver browser;
        WebDriverWait wait;

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
        public void page_objects()
        {
            Car acura = new Car("Acura", "Integra", "Sea Green", "You have chosen a Sea Green Acura Integra. Nice car!");
            CarMenu page = new CarMenu(browser);
            var message = page.select_a_car(acura);
            Assert.AreEqual(acura.Message, message);
        }

       
    }
}