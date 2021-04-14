using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;

namespace Cadastro_de_Usuarios.utils
{
    public static class Browser
    {
        public enum Type
        {
            FIREFOX,
            CHROME
        }

        private static IWebDriver driver;
        private static Type currentType;
        private static bool isHeadless = false;

        public static void SetCurrentBrowser(Type type, bool enableHeadless = false)
        {
            currentType = type;
            isHeadless = enableHeadless;
        }

        public static Type GetCurrentBrowser()
        {
            return currentType;
        }

        public static IWebDriver GetCurrentDriver()
        {
            if (driver == null)
            {
                try
                {
                    switch (GetCurrentBrowser())
                    {
                        case Type.CHROME:
                            ChromeOptions chromeOptions = new ChromeOptions();
                            if (isHeadless) chromeOptions.AddArguments("--headless");
                            chromeOptions.AddUserProfilePreference("download.default_directory", Directory.GetCurrentDirectory() + "\\Downloads");
                            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                            driver = new ChromeDriver(chromeOptions);
                            break;

                        default:
                            FirefoxOptions optionsFirefox = new FirefoxOptions();
                            if (isHeadless) optionsFirefox.AddArguments("--headless");
                            optionsFirefox.SetPreference("browser.download.folderList", 2);
                            optionsFirefox.SetPreference("browser.download.dir", Directory.GetCurrentDirectory() + "\\Downloads");
                            optionsFirefox.SetPreference("browser.download.useDownloadDir", true);
                            optionsFirefox.SetPreference("browser.download.viewableInternally.enabledTypes", "");
                            optionsFirefox.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/json;application/pdf;text/plain;application/text;text/xml;application/xml;application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                            optionsFirefox.SetPreference("pdfjs.disabled", true); 
                            driver = new FirefoxDriver(optionsFirefox);
                            break;
                    }

                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                }
                catch (UriFormatException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return driver;
        }

        public static void LoadApplication(string url)
        {
            GetCurrentDriver().Navigate().GoToUrl(url);
        }


        public static void QuitDriver()
        {
            GetCurrentDriver().Quit();
            driver = null;
        }

    }
}
