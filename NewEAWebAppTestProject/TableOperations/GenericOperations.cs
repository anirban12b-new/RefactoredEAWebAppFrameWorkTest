
using EAWebAppFrameWorkClasses.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NewEAWebAppTestProject.TableOperations;

public class GenericOperations()
{
    private readonly DriverFixture? _driverFixture;

    public GenericOperations(DriverFixture driverFixture) : this()
    {
        _driverFixture = driverFixture;
    }

    public void DeleteAllProducts()
    {
        while (true)
        {
            var table = _driverFixture!.Driver.FindElement(By.CssSelector(".table"));

            var rows = table.FindElements(By.XPath(".//tbody/tr"));

            if (rows.Count == 0)
                break; // ✅ hard stop

            var firstRow = rows[0];
            var deleteLink = firstRow.FindElement(By.LinkText("Delete"));

            deleteLink.Click();
            
            // ✅ Wait until THAT row disappears
            var isRowStale = ExpectedConditions.StalenessOf(firstRow);
            new WebDriverWait(_driverFixture.Driver, TimeSpan.FromSeconds(10))
                .Until(isRowStale);
            
            
            IWebElement confirmDeleteButton = _driverFixture.Driver.FindElement(By.XPath("//input[@type='submit']"));
            confirmDeleteButton.Click();
            
            var isRowStaleNext = ExpectedConditions.StalenessOf(firstRow);
            new WebDriverWait(_driverFixture.Driver, TimeSpan.FromSeconds(10))
                .Until(isRowStaleNext);
            
          
        }
    }
}