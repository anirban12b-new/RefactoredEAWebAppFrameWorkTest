using EAWebAppFrameWorkClasses.Driver;
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
   // public void ClickBtnCreate() => btnCreate.Click();
    public void CreateProduct(string name, string description, int price, string productType)
    {
        lnkCreateProduct.Click();
        prdName.SendKeys(name);
        txtDescription.SendKeys(description);
        txtPrice.SendKeys(price.ToString());
        SelectElement select=new  SelectElement(selectProductType);
        select.SelectByText(productType);
      btnCreate.Click();
    }
  }
