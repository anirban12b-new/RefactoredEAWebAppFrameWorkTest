using EAWebAppFrameWorkClasses.Config;
using EAWebAppFrameWorkClasses.Driver;
using NewEAWebAppTestProject.Pages;
using WebDriverManager.DriverConfigs.Impl;

namespace NewEAWebAppTestProject;

public class SeleniumTest : IDisposable
{
    private readonly IDriverFixture _driverFixture;

    public SeleniumTest()
    {
        var testSettings = new TestSettings
        {
            BrowserType = DriverFixture.BrowserType.EdgeChromium,
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
        var HomePage = new HomePage(_driverFixture);
        var ProductPage = new ProductPage(_driverFixture);
        HomePage.ClickLnkProduct();
        ProductPage.CreateProduct("TestProduct1", "TestDescription1", 100, "CPU");
       }

    [Fact]
    public void Test2()
    {
        var HomePage = new HomePage(_driverFixture);
        var ProductPage = new ProductPage(_driverFixture);
        HomePage.ClickLnkProduct();
        ProductPage.CreateProduct("TestProduct2", "TestDescription2", 200, "MONITOR");
        
    }
}