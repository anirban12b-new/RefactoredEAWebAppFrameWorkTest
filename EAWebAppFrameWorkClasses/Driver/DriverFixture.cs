using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace EAWebAppFrameWorkClasses.Driver;

public class DriverFixture
{
    public  IWebDriver Driver { get; }
    public DriverFixture()
    {
        Driver=GetDriverType(BrowserType.Chrome);
        Driver.Navigate().GoToUrl("http://localhost:8000");
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
    public  enum BrowserType
    {
        Chrome, 
        Firefox, 
        EdgeChromium
    }
    
   public  IWebDriver GetDriverType(BrowserType browserType)
    {
        Console.WriteLine(browserType.ToString().ToLowerInvariant());
        return browserType  switch
        {
            BrowserType.Chrome=> new ChromeDriver(),
            BrowserType.Firefox => new FirefoxDriver(),
            BrowserType.EdgeChromium => new EdgeDriver(),
       
            _ => throw new ArgumentException($"Browser '{browserType}' is not supported.", nameof(browserType))
        };
    }
   
}