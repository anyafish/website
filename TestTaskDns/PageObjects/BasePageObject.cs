using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace TestTaskDns
{
    public class BasePageObject
    {
        public IWebDriver driver;

        public BasePageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        ///   Город
        /// </summary>
        public readonly By City = By.CssSelector(".city-select_l4y");

        /// <summary>
        /// Возвращает текст элемента
        /// </summary>
        /// <returns>Текст элемента</returns>
        public string GetTextOfElement(By el)
        {
            return driver.FindElement(el).Text;
        }
    }
}
