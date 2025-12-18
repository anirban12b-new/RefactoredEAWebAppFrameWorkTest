using OpenQA.Selenium;

namespace EAWebAppFrameWorkClasses.Driver;

public interface IDriverFixture
{
    public IWebDriver Driver { get; }
}