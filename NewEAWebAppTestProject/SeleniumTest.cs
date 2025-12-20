using EAWebAppFrameWorkClasses.Config;
using EAWebAppFrameWorkClasses.Driver;
using NewEAWebAppTestProject.Pages;
using NewEAWebAppTestProject.TableOperations;



namespace NewEAWebAppTestProject;

public class SeleniumTest : IDisposable
{
    private readonly DriverFixture _driverFixture;
    public SeleniumTest()
    {
        
        var testSettings = new TestSettings 
        {
            BrowserType = DriverFixture.BrowserType.EdgeChromium,
            ApplicationUri = new Uri("http://localhost:8000/"),
            Timeout = 10
        };
        _driverFixture = new DriverFixture(testSettings);

       
        _driverFixture.Driver.Navigate().GoToUrl(testSettings.ApplicationUri);
        _driverFixture.Driver.Manage().Window.Maximize();
        _driverFixture.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(testSettings.Timeout ?? 10);
    }

  
    public void Dispose()
    {
        _driverFixture.Driver.Quit();
        _driverFixture.Driver.Dispose();
    }
   

        [Fact]
        public void EaWebAppTest()
        {
            var homePage = new HomePage(_driverFixture);
            var productPage = new ProductPage(_driverFixture);
            homePage.ClickLnkProduct();
            productPage.CreateProduct("TestProduct1", "TestDescription1", 100, "CPU");
            productPage.SeeProductDetails();
            var tableOps = new GenericOperations( _driverFixture);
            tableOps.DeleteAllProducts();
            _driverFixture.Driver.Navigate().Refresh();
            
        }
        
        
    }
    

   
