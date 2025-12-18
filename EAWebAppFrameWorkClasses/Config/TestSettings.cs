using EAWebAppFrameWorkClasses.Driver;

namespace EAWebAppFrameWorkClasses.Config;

public class TestSettings
{
    public DriverFixture.BrowserType  BrowserType { get; set; }
    public Uri?  ApplicationUri { get; set; }
    public float?  Timeout { get; set; }
 
    
}