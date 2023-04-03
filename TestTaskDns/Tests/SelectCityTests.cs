using NUnit.Framework;
using OpenQA.Selenium;

namespace TestTaskDns
{
    /// <summary>
    ///   Тестовый класс проверок функционала выбора города
    /// </summary>
    public class Tests : TestBase
    {

        readonly string BaseUrl = "https://www.dns-shop.ru/";

        public SelectCityPageObject SelectCity()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            return new SelectCityPageObject(driver);
        }

        /// <summary>
        ///   Проверка выбора города из списка крупных городов
        /// </summary>
        [TestCase("Москва")]
        [TestCase("Екатеринбург")]
        [TestCase("Санкт-Петербург")]
        [TestCase("Новосибирск")]
        [TestCase("Нижний Новгород")]
        [TestCase("Казань")]
        [TestCase("Самара")]
        [TestCase("Владивосток")]
        public void SelectBigCity_SelectCity_ElementEuals(string name)
        {
            SelectCityPageObject s = SelectCity();

            driver.FindElement(s.City).Click();
            s.SelectFromList(s.BigCities, name);
            string exture = name;
            string actual = s.GetTextOfElement(s.City);

            Assert.AreEqual(exture, actual);
        }

        /// <summary>
        ///   Проверка выбора Округа
        /// </summary>
        [TestCase("Дальневосточный", "Амурская область")]
        [TestCase("Приволжский", "Башкортостан")]
        [TestCase("Северо-Западный", "Архангельская область")]
        [TestCase("Северо-Кавказский", "Ингушетия")]
        [TestCase("Сибирский", "Алтай")]
        [TestCase("Уральский", "Курганская область")]
        [TestCase("Центральный", "Белгородская область")]
        [TestCase("Южный", "Астраханская область")]
        public void SelectDistrict_DistrictClick_ElementEuals(string nameDistrict, string nameRegion)
        {
            SelectCityPageObject s = SelectCity();

            driver.FindElement(s.City).Click();
            s.SelectFromList(s.Districs, nameDistrict);
            string exture = nameRegion;
            string actual = s.GetTextOfElement(s.Regions);

            Assert.AreEqual(exture, actual);
        }

        /// <summary>
        ///   Проверка выбора Региона
        /// </summary>
        [TestCase("Дальневосточный", "Амурская область", "Белогорск")]
        [TestCase("Приволжский", "Кировская область", "Арбаж")]
        [TestCase("Северо-Западный", "Калининградская область", "Багратионовск")]
        [TestCase("Северо-Кавказский", "Республика Дагестан", "Буйнакск")]
        [TestCase("Сибирский", "Красноярский край", "Ачинск")]
        [TestCase("Уральский", "Курганская область", "Далматово")]
        [TestCase("Центральный", "Брянская область", "Белая Березка")]
        [TestCase("Южный", "Крым", "Алупка")]
        public void SelectRegion_RegionClick_ElementEuals(string nameDistrict, string nameRegion, string nameCity)
        {
            SelectCityPageObject s = SelectCity();
            driver.FindElement(s.City).Click();
            s.SelectFromList(s.Districs, nameDistrict);
            s.SelectFromList(s.Regions, nameRegion);
            string exture = nameCity;
            string actual = s.GetTextOfElement(s.Cities);

            Assert.AreEqual(exture, actual);
        }

        /// <summary>
        ///   Проверка выбора Города
        /// </summary>
        [TestCase("Дальневосточный", "Амурская область", "Возжаевка")]
        [TestCase("Дальневосточный", "Камчатский край", "Елизово")]
        [TestCase("Приволжский", "Кировская область", "Вахруши")]
        [TestCase("Приволжский", "Оренбургская область", "Акбулак")]
        [TestCase("Северо-Западный", "Город Санкт-Петербург", "Петергоф")]
        [TestCase("Северо-Западный", "Мурманская область", "Ковдор")]
        [TestCase("Северо-Кавказский", "Республика Дагестан", "Буйнакск")]
        [TestCase("Северо-Кавказский", "Чеченская Республика", "Аргун")]
        [TestCase("Сибирский", "Красноярский край", "Ачинск")]
        [TestCase("Сибирский", "Омская область", "Артын")]
        [TestCase("Уральский", "Тюменская область", "Ишим")]
        [TestCase("Уральский", "Челябинская область", "Бакал")]
        [TestCase("Центральный", "Город Москва", "Москва")]
        [TestCase("Центральный", "Калужская область", "Боровск")]
        [TestCase("Южный", "Крым", "Алупка")]
        [TestCase("Южный", "Краснодарский край", "Краснодар")]
        public void SelectCity_CityClick_ElementEuals(string nameDistrict, string nameRegion, string nameCity)
        {
            SelectCityPageObject s = SelectCity();

            driver.FindElement(s.City).Click();
            s.SelectFromList(s.Districs, nameDistrict);
            s.SelectFromList(s.Regions, nameRegion);
            s.SelectFromList(s.Cities, nameCity);
            string exture = nameCity;
            string actual = s.GetTextOfElement(s.City);

            Assert.AreEqual(exture, actual);
        }

        /// <summary>
        ///   Проверка поиска городов через текстовое поле
        /// </summary>
        [TestCase("Москва", "Москва\r\nдля выбора нажмите Enter")]
        [TestCase("москва", "Москва\r\nдля выбора нажмите Enter")]
        [TestCase("trfnthby,ehu", "Екатеринбург\r\nдля выбора нажмите Enter")]
        [TestCase("Катав-Ивановск", "Катав-Ивановск\r\nдля выбора нажмите Enter")]
        [TestCase("санкт петербург", "Санкт-Петербург\r\nдля выбора нажмите Enter")]
        [TestCase("мос", "Московское\r\nМоскаленки (Омская область)\r\nМосква\r\nМосковский\r\nМосальск\r\nМостовской")]
        [TestCase("1", "1-я Моква\r\nГорки-10\r\nПоселок 1-й\r\nШаталово 1-е")]
        [TestCase("КРАСНОДАР", "Краснодар\r\nКраснодарский")]
        public void FindCity_NameСityInput_ElementEuals(string text, string resultFind)
        {
            SelectCityPageObject s = SelectCity();

            driver.FindElement(s.City).Click();
            s.InputTextFindString(text);
            string actual = $"{resultFind}";
            string expected = s.GetTextOfElement(s.CitiesSearchingResults);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///   Проверка выбора города через поиск
        /// </summary>
        [TestCase("Москва")]
        [TestCase("Ачинск")]
        public void SelectFindCity_NameСityInput_ElementEuals(string text)
        {
            SelectCityPageObject s = SelectCity();

            driver.FindElement(s.City).Click();
            s.InputTextFindString(text);
            driver.FindElement(s.FirstCitySearchingResults).Click();
            string expected = text;

            string actual = s.GetTextOfElement(s.City);

            Assert.AreEqual(expected, actual);
        }
    }

}

