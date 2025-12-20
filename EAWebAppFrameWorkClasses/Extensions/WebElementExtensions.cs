using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EAWebAppFrameWorkClasses.Extensions;

public static class WebElementExtensions
{
    extension(IWebElement element)
    {
        public void SelectDropDownByText(string text)
        {
            SelectElement select=new SelectElement(element);
            select.SelectByText(text);
        }

        public void SelectDropDownByIndex(int index)
        {
            SelectElement select=new SelectElement(element);
            select.SelectByIndex(index);
      
        }

        public void SelectDropDownByValue(string value)
        {
            SelectElement select=new SelectElement(element);
            select.SelectByValue(value);
        }

        public void ClearAndEnterText(string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}