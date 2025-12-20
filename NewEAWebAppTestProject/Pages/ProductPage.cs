using EAWebAppFrameWorkClasses.Driver;
using EAWebAppFrameWorkClasses.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI; 
namespace NewEAWebAppTestProject.Pages;

public class ProductPage(IDriverFixture driverFixture)
{
    private IWebElement lnkCreateProduct => driverFixture.Driver.FindElement(By.LinkText("Create"));
    private IWebElement prdName => driverFixture.Driver.FindElement(By.Id("Name"));
    private IWebElement txtDescription => driverFixture.Driver.FindElement(By.Id("Description"));
    private IWebElement txtPrice => driverFixture.Driver.FindElement(By.Id("Price"));
    private IWebElement selectProductType => driverFixture.Driver.FindElement(By.Id("ProductType"));
    private IWebElement btnCreate => driverFixture.Driver.FindElement(By.Id("Create"));

    HomePage HomePage { get; } = new HomePage(driverFixture);

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

    public void SeeProductDetails()
    {
        driverFixture.Driver.FindElement(By.XPath($"//a[text()='Details']")).Click();
        driverFixture.Driver.FindElement(By.XPath($"//a[text()='Back to List']")).Click();
      
    }
    
  }
