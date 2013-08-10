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
    public class v9_SRP_and_abstraction
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
        public void data_driven_car_choices()
        {
            CarLoader loader = new CarLoader();
            IList<Car> cars = loader.load_list();
            foreach (var car in cars)
            {
                CarMenu page = new CarMenu(browser);
                var message = page.select_a_car(car);
                Assert.AreEqual(car.Message, message);
            }
            
        }
    }
}