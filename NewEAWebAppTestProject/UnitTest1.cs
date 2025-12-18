
using EAWebAppFrameWorkClasses.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit.Sdk;

namespace NewEAWebAppTestProject;

public class UnitTest1:IDisposable
{
    private readonly IWebDriver _driver;

    public UnitTest1()
    {
        _driver = new DriverFixture().Driver;
    }

[Fact]
    public void Test1()
    {
        _driver.FindElement(By.LinkText("Product")).Click();
        _driver.FindElement(By.LinkText("Create")).Click();
        _driver.FindElement(By.Id("Name")).SendKeys("CorrectTestProduct");
        _driver.FindElement(By.Id("Description")).SendKeys("Simple Framework Code");
        _driver.FindElement(By.Id("Price")).SendKeys("5000");
        _driver.FindElement(By.Id("ProductType")).Click();
        SelectElement productName = new SelectElement(_driver.FindElement(By.Id("ProductType")));
        productName.SelectByText("EXTERNAL");
        _driver.FindElement(By.Id("Create")).Click();
    }
    [Fact]
    public void Test2()
    {
        _driver.FindElement(By.LinkText("Product")).Click();
        _driver.FindElement(By.LinkText("Create")).Click();
        _driver.FindElement(By.Id("Name")).SendKeys("CorrectSecondTestProduct");
        _driver.FindElement(By.Id("Description")).SendKeys("Simple Framework Code For Second Test");
        _driver.FindElement(By.Id("Price")).SendKeys("9000");
        _driver.FindElement(By.Id("ProductType")).Click();
        SelectElement productName = new SelectElement(_driver.FindElement(By.Id("ProductType")));
        productName.SelectByText("CPU");
        _driver.FindElement(By.Id("Create")).Click();
    } 
    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}