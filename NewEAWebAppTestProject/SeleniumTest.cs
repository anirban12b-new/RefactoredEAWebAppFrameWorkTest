using EAWebAppFrameWorkClasses.Config;
using EAWebAppFrameWorkClasses.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NewEAWebAppTestProject;

public class SeleniumTest : IDisposable
{
    private readonly IDriverFixture _driverFixture;

    public SeleniumTest()
    {
        var testSettings = new TestSettings
        {
            BrowserType = DriverFixture.BrowserType.Chrome,
            ApplicationUri = new Uri("http://localhost:8000/"),
            Timeout = 10
        };
        _driverFixture = new DriverFixture(testSettings);


        _driverFixture.Driver.Navigate().GoToUrl(testSettings.ApplicationUri);
        _driverFixture.Driver.Manage().Window.Maximize();
        _driverFixture.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(testSettings.Timeout ?? 10);
    }

    public void Dispose()
    {
        _driverFixture.Driver.Quit();
        _driverFixture.Driver.Dispose();
    }

    [Fact]
    public void Test1()
    {
        _driverFixture.Driver.FindElement(By.LinkText("Product")).Click();
        _driverFixture.Driver.FindElement(By.LinkText("Create")).Click();
        _driverFixture.Driver.FindElement(By.Id("Name")).SendKeys("CorrectTestProduct");
        _driverFixture.Driver.FindElement(By.Id("Description")).SendKeys("Simple Framework Code");
        _driverFixture.Driver.FindElement(By.Id("Price")).SendKeys("5000");
        _driverFixture.Driver.FindElement(By.Id("ProductType")).Click();
        var productName = new SelectElement(_driverFixture.Driver.FindElement(By.Id("ProductType")));
        productName.SelectByText("EXTERNAL");
        _driverFixture.Driver.FindElement(By.Id("Create")).Click();
    }

    [Fact]
    public void Test2()
    {
        _driverFixture.Driver.FindElement(By.LinkText("Product")).Click();
        _driverFixture.Driver.FindElement(By.LinkText("Create")).Click();
        _driverFixture.Driver.FindElement(By.Id("Name")).SendKeys("CorrectSecondTestProduct");
        _driverFixture.Driver.FindElement(By.Id("Description")).SendKeys("Simple Framework Code For Second Test");
        _driverFixture.Driver.FindElement(By.Id("Price")).SendKeys("9000");
        _driverFixture.Driver.FindElement(By.Id("ProductType")).Click();
        var productName = new SelectElement(_driverFixture.Driver.FindElement(By.Id("ProductType")));
        productName.SelectByText("CPU");
        _driverFixture.Driver.FindElement(By.Id("Create")).Click();
    }
}