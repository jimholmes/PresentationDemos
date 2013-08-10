using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CAST2013.PageObjects
{
    class CarMenu
    {
        IWebDriver browser;
 
        [FindsBy(How = How.Id, Using = "ctl00_SampleContent_DropDownList1")]
        IWebElement Make { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_SampleContent_DropDownList2")]
        IWebElement Model { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_SampleContent_DropDownList3")]
        IWebElement Color { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_SampleContent_Label1")]
        IWebElement Message { get; set; }

         public CarMenu(IWebDriver browser)
        {
            this.browser = browser;

            if (browser.Title !=
                "CascadingDropDown Sample")
            {
                throw new ElementNotVisibleException(
                                                     "Current page's title doesn't match expected. Current page: " +
                                                     browser.Title);
            }
        }

        public string select_a_car(Car car)
        {
            select_menu_item(1, car.Make);
            select_menu_item(2, car.Model);
            select_menu_item(3, car.Color); 
            extract_message(car.Message);
            return this.Message.Text;
        }

        private void select_menu_item(int listNum, string item)
        {
            wait_on_menu_item(listNum, item);
            var selectionList =
                            browser.FindElement(
                                By.Id("ctl00_SampleContent_DropDownList" + listNum));
            var optionsList = new SelectElement(selectionList);
            optionsList.SelectByText(item);
        }

        private void wait_on_menu_item(int listNum, string text)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(10));

            wait.Until(
                ExpectedConditions.ElementExists( By.XPath("id('ctl00_SampleContent_DropDownList" + listNum + "')/option[text()='" + text + "']")));
        }

        private void extract_message(string message)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(10));

            var return_message = wait.Until(
                ExpectedConditions.ElementExists(
                    By.XPath("//span[@id='ctl00_SampleContent_Label1' and text()='" + message +"']")));

            this.Message = return_message;
        }
    }
}
