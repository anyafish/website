using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestTaskDns
{
    public class SelectCityPageObject : BasePageObject
    {
        private readonly int waitElementSeconds = 60;
        public SelectCityPageObject(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        ///   Список больших городов
        /// </summary>
        public readonly By BigCities = By.CssSelector(".city-bubble");

        /// <summary>
        ///   Список Округов
        /// </summary>
        public readonly By Districs = By.XPath("//ul[@class='districts']/li");

        /// <summary>
        ///   Список Регионов
        /// </summary>
        public readonly By Regions =  By.XPath("//ul[@class='regions']/li");

        /// <summary>
        ///   Список Городов
        /// </summary>
        public readonly By Cities = By.XPath("//ul[@class='cities']/li");

        /// <summary>
        ///   Строка поиска
        /// </summary>
        public readonly By SearchString = By.CssSelector(".base-ui-input-search__input");
        /// <summary>
        ///   Результаты поиска
        /// </summary>
        public readonly By CitiesSearchingResults = By.CssSelector(".cities-search");

        /// <summary>
        ///   Первая строка в результатах поиска
        /// </summary>
        public readonly By FirstCitySearchingResults = By.XPath("//ul[@class='cities-search']/li");

        /// <summary>
        ///   Выбор из списка элемента по текстовому значению
        /// </summary>
        public void SelectFromList(By element, string nameCity)
        {
            WaitUntil.WaitElementIsVisible(driver, BigCities, 60);
            driver.FindElements(element).First(x => x.Text == nameCity).Click();
        }

        /// <summary>
        ///   Ввод текстового значения в строку поиска
        /// </summary>
        public void InputTextFindString(string text)
        {          
            WaitUntil.WaitElementIsVisible(driver, BigCities, waitElementSeconds);
            driver.FindElement(SearchString).SendKeys(text);
        }
    }
}
