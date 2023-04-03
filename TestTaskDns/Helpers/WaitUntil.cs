// Copyright © 2022 "Компьютерные Бизнес-Системы", Екатеринбург, www.kbspro.ru
//  All rights reserved.

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestTaskDns

{
  /// <summary>
  ///   Методы ожидания
  /// </summary>
  public static class WaitUntil
  {
    /// <summary>
    ///   Ожидание исчезновения элемента со страницы
    /// </summary>
    public static void WaitElementInvisible(IWebDriver driver, By element, int seconds) =>
      new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.InvisibilityOfElementLocated(element));

    /// <summary>
    ///   Ожидание появления элемента на странице у которого отсутствует параметр disable
    /// </summary>
    public static void WaitElementIsVisible(IWebDriver driver, By el, int seconds) =>
      new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(el));

  }
}

