using EAWebAppFrameWorkClasses.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace EAWebAppFrameWorkClasses.Driver;

public class DriverFixture : IDriverFixture
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        EdgeChromium
    }

    private readonly TestSettings _testSettings;

    public DriverFixture(TestSettings testSettings)
    {
        _testSettings = testSettings;
        Driver = GetDriverType(_testSettings.BrowserType);
        if (_testSettings.ApplicationUri != null) Driver.Navigate().GoToUrl(_testSettings.ApplicationUri);
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    public IWebDriver Driver { get; }

    public IWebDriver GetDriverType(BrowserType browserType)
    {
        Console.WriteLine(browserType.ToString().ToLowerInvariant());
        return browserType switch
        {
            BrowserType.Chrome => new ChromeDriver(),
            BrowserType.Firefox => new FirefoxDriver(),
            BrowserType.EdgeChromium => new EdgeDriver(),

            _ => throw new ArgumentException($"Browser '{browserType}' is not supported.", nameof(browserType))
        };
    }
}