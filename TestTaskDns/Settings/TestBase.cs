using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestTaskDns
{
    public class TestBase
    {
        public ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument(headless);
            options.AddArgument("--start-maximized");
            options.AddArgument("--incognito");
            options.AddArgument("--window-size=1920x1080");
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(180));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);
        }

        [TearDown]
        protected void TearDown()
        {
           driver.Quit();
        }
    }
}
