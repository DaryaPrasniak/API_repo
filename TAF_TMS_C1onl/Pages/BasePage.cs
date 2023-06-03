using OpenQA.Selenium;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver;
    protected WaitService WaitService;

    public BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;
        WaitService = new WaitService(Driver);

        if (openPageByUrl)
        {
            OpenPageByUrl();
        }
    }

    public abstract bool IsPageOpened();
    protected abstract string GetEndpoint();

    private void OpenPageByUrl()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + GetEndpoint());
    }
}