using EAWebAppFrameWorkClasses.Driver;
using OpenQA.Selenium;

namespace NewEAWebAppTestProject.Pages;

public class HomePage()

{
    private readonly IDriverFixture?  _driverFixture;
    public HomePage(IDriverFixture driverFixture) : this()
    {
        _driverFixture = driverFixture;
        
    }
    private IWebElement?  LnkHome => _driverFixture!.Driver.FindElement(By.LinkText("Home"));
    private IWebElement?  LnkProduct => _driverFixture!.Driver.FindElement(By.LinkText("Product"));
    
    public void ClickLnkProduct() => LnkProduct!.Click();
    
 
    
}