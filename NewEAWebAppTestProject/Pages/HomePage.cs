using EAWebAppFrameWorkClasses.Driver;
using OpenQA.Selenium;

namespace NewEAWebAppTestProject.Pages;

public class HomePage
{
    private readonly IDriverFixture _driverFixture;
    public HomePage(IDriverFixture driverFixture)
    {
        _driverFixture = driverFixture;
        
    }
    private IWebElement  LnkHome => _driverFixture.Driver.FindElement(By.LinkText("Home"));
}