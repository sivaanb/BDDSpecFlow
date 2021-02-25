using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOnTest
{
    public class BrowserManager
    {
        public static IWebDriver webDriver;
        public static void LaunchWebdriver(string strBrowser)
        {
            //string browser = ConfigurationManager.AppSettings["Browser"].ToString();

            try
            {
                switch (strBrowser.ToString().ToLower())
                {
                    case "chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("-no-sandbox");
                        chromeOptions.AddArgument("--test-type");
                        webDriver = new ChromeDriver(chromeOptions);
                        break;
                    case "firefox":
                        //FirefoxDriver firefox = new FirefoxDriver();
                        //System.setProperty("webdriver.gecko.driver", @"C:\Users\sivakumara\Downloads\geckodriver-v0.29.0-win64");
                        //DesiredCapabilities capabilities = DesiredCapabilities.firefox();
                        //capabilities.setCapability("marionette", true);
                        //driver = new FirefoxDriver(capabilities);
                        webDriver = new FirefoxDriver();
                        break;
                    case "ie":
                        InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                        GenericUtility.KillObjectInstances("IEDriverServer");
                        ieoptions.EnsureCleanSession = true;
                        ieoptions.EnableNativeEvents = true;
                        //ieoptions.EnsureCleanSession = true;
                        //ieoptions.EnableNativeEvents = true;
                        webDriver = new InternetExplorerDriver(ieoptions);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
