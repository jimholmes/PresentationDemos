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
    public class v10_using_centralized_settings
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

            string target = Settings.Car_menu_url;

            browser.Navigate().GoToUrl(target);
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
  
    public static class Settings
    {
        private static string car_menu_url = "http://localhost/AJAXDemos/CascadingDropDown/CascadingDropDown.aspx";
        //private static string car_menu_url = "http://www.asp.net/ajaxLibrary/AjaxControlToolkitSampleSite/CascadingDropDown/CascadingDropDown.aspx";

        public static string Car_menu_url
        {
            get
            {
                return car_menu_url;
            }            
        }
    }
}