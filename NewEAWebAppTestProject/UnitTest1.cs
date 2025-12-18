using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace NewEAWebAppTestProject;

public class UnitTest1:IDisposable
{
    private readonly IWebDriver _driver;

    public UnitTest1()
    { 
        
        _driver=GetDriverType(BrowserType.Chrome);
        _driver.Navigate().GoToUrl("http://localhost:8000");
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    private  enum BrowserType
    {
        Chrome, 
        Firefox, 
        EdgeChromium
       }
    
    
    private IWebDriver GetDriverType(BrowserType browserType)
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