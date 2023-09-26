﻿using SeleniumExtras.WaitHelpers;

namespace ArmorFeedTest.VehiclesTest;
// Generated by Selenium IDE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;
public class SuiteTests : IDisposable {
  public IWebDriver driver {get; private set;}
  public IDictionary<String, Object> vars {get; private set;}
  public IJavaScriptExecutor js {get; private set;}
  public SuiteTests()
  {
    var chromeDriverService = ChromeDriverService.CreateDefaultService(@"/Users/carlolucas/chrome-driver");
    driver = new ChromeDriver(chromeDriverService, new ChromeOptions());
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<String, Object>();
  }
  public void Dispose()
  {
    driver.Quit();
  }
  [Fact]
  public void ShipmentLogged() {
    driver.Navigate().GoToUrl("http://localhost:3000/sign-in");
    driver.Manage().Window.Size = new System.Drawing.Size(2560, 1340);
    driver.FindElement(By.Id("email")).Click();
    driver.FindElement(By.Id("email")).SendKeys("lolo@gmail.com");
    driver.FindElement(By.Id("password")).Click();
    driver.FindElement(By.Id("password")).SendKeys("lolo123@");
    driver.FindElement(By.CssSelector(".field > .p-button")).Click();
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    var elementoMenu = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#origin > .p-dropdown-label")));
    elementoMenu.Click();
    driver.FindElement(By.CssSelector("#origin > .p-dropdown-label")).Click();
    driver.FindElement(By.CssSelector(".p-dropdown-item:nth-child(1)")).Click();
    driver.FindElement(By.CssSelector(".p-placeholder")).Click();
    driver.FindElement(By.CssSelector(".p-dropdown-item:nth-child(3)")).Click();
    driver.FindElement(By.Id("quantity")).Click();
    driver.FindElement(By.Id("weight")).Click();
    driver.FindElement(By.Id("weight")).SendKeys("10");
    driver.FindElement(By.Id("large")).Click();
    driver.FindElement(By.Id("large")).SendKeys("5");
    driver.FindElement(By.Id("witch")).Click();
    driver.FindElement(By.Id("witch")).SendKeys("1");
    driver.FindElement(By.Id("height")).Click();
    driver.FindElement(By.Id("height")).SendKeys("3");
    driver.FindElement(By.CssSelector(".p-button-info")).Click();
    var elementoMenu1 = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("td:nth-child(2)")));
    elementoMenu1.Click();
    driver.FindElement(By.CssSelector("td:nth-child(2)")).Click();
    driver.FindElement(By.CssSelector(".p-button-info")).Click();
    driver.FindElement(By.CssSelector(".p-dropdown-label")).Click();
    driver.FindElement(By.CssSelector(".p-dropdown-item:nth-child(1)")).Click();
    driver.FindElement(By.Id("address")).Click();
    driver.FindElement(By.Id("address")).SendKeys("Lolos House");
    driver.FindElement(By.Id("urbanization")).Click();
    driver.FindElement(By.Id("urbanization")).SendKeys("Flores");
    driver.FindElement(By.Id("reference")).Click();
    driver.FindElement(By.Id("reference")).SendKeys("Parque");
    driver.FindElement(By.CssSelector(".p-button-info > .p-button-label")).Click();
    driver.FindElement(By.CssSelector(".p-dropdown-label")).Click();
    driver.FindElement(By.CssSelector(".p-dropdown-item:nth-child(3)")).Click();
    driver.FindElement(By.Id("address")).Click();
    driver.FindElement(By.Id("address")).SendKeys("Lolos Fabric");
    driver.FindElement(By.Id("urbanization")).Click();
    driver.FindElement(By.Id("urbanization")).SendKeys("Fabricas");
    driver.FindElement(By.Id("reference")).Click();
    driver.FindElement(By.Id("reference")).SendKeys("Primera fabrica");
    driver.FindElement(By.CssSelector(".p-button-info > .p-button-label")).Click();
    driver.FindElement(By.CssSelector(".p-fluid")).Click();
    driver.FindElement(By.CssSelector(".field:nth-child(1) > .p-inputtext")).Click();
    driver.FindElement(By.CssSelector(".field:nth-child(1) > .p-inputtext")).SendKeys("Paolo");
    driver.FindElement(By.CssSelector(".field > .p-inputmask")).Click();
    driver.FindElement(By.CssSelector(".field > .p-inputmask")).SendKeys("4537 2642 3136 7261");
    driver.FindElement(By.CssSelector(".p-inputnumber-input")).Click();
    driver.FindElement(By.CssSelector(".p-inputnumber-input")).SendKeys("312");
    driver.FindElement(By.CssSelector(".w-full > .p-inputmask")).Click();
    driver.FindElement(By.CssSelector(".w-full > .p-inputmask")).SendKeys("12/27");
    driver.FindElement(By.CssSelector(".p-button-info > .p-button-label")).Click();
    
    var elementoMenu2 = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".p-toast-summary")));
    elementoMenu2.Click();
    var successMessage = driver.FindElement(By.CssSelector(".p-toast-summary"));
    Assert.NotNull(successMessage);
    Assert.Equal("Order submitted", successMessage.Text);
  }
}