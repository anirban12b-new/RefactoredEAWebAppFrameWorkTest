using EAWebAppFrameWorkClasses.Driver;
using EAWebAppFrameWorkClasses.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI; 
namespace NewEAWebAppTestProject.Pages;

public class ProductPage
{
    private readonly IDriverFixture _driverFixture;

    public ProductPage(IDriverFixture driverFixture)
    {
        _driverFixture = driverFixture;
        
    }

    private IWebElement lnkCreateProduct => _driverFixture.Driver.FindElement(By.LinkText("Create"));
    private IWebElement prdName => _driverFixture.Driver.FindElement(By.Id("Name"));
    private IWebElement txtDescription => _driverFixture.Driver.FindElement(By.Id("Description"));
    private IWebElement txtPrice => _driverFixture.Driver.FindElement(By.Id("Price"));
    private IWebElement selectProductType => _driverFixture.Driver.FindElement(By.Id("ProductType"));
    private IWebElement btnCreate => _driverFixture.Driver.FindElement(By.Id("Create"));

    private IWebElement tblList => _driverFixture.Driver.FindElement(By.ClassName("table"));

    public void CreateProduct(string name, string description, int price, string productType)
    {
        lnkCreateProduct.Click();
        prdName.SendKeys(name);
        txtDescription.ClearAndEnterText(description);
        txtPrice.SendKeys(price.ToString());
        selectProductType.SelectDropDownByText(productType);
        selectProductType.SelectDropDownByIndex(1);
        selectProductType.SelectDropDownByValue("2");
        
      btnCreate.Click();
    }
  }
