using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Linq;


namespace DaviesAutomation
{
    [TestClass]
    public class DaveAutomation
    {
        Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");


        IWebDriver driver;//= new FirefoxDriver();
        [TestInitialize]
        public void Init()
        {
            try
            {
                var browsers = key.GetSubKeyNames();

                if (browsers[0].ToLower().Contains("firefox"))
                {
                    driver = new FirefoxDriver();
                }
                else if (browsers[0].ToLower().Contains("chrome"))
                {
                    driver = new ChromeDriver();
                }
                else if (browsers[0].ToLower().Contains("ieexplorer"))
                {
                    driver = new InternetExplorerDriver();
                }
                else if (browsers[0].ToLower().Contains("edge"))
                {
                    driver = new EdgeDriver();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }
        [TestMethod]
        public void DaviesGroupTwitterValidation()
        {
            try
            {
                //Set Web Driver based on Browser

                string expectedresult = "https://twitter.com/Davies_Group";
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://davies-group.com/");
                Thread.Sleep(10000);
                HandlingCookies();
                driver.FindElement(By.Id("dg-mouse-icon")).Click();
                Thread.Sleep(5000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,5000)");
                driver.FindElement(By.XPath("//ul[@class='footer__socials']/li/a")).Click();
                List<string> listWindow = new List<string>(driver.WindowHandles);
                driver.SwitchTo().Window(listWindow[1]);

                string currentULR = driver.Url;
                if (expectedresult != currentULR)
                {
                    Assert.Fail();
                }
                WindowClose();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }
        [TestMethod]
        public void DaviesGroupLinkedinValidation()
        {
            try
            {
                string expectedresult = "https://www.linkedin.com/company/daviesgroup/";
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://davies-group.com/");
                Thread.Sleep(10000);
                HandlingCookies();
                driver.FindElement(By.Id("dg-mouse-icon")).Click();
                Thread.Sleep(5000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,5000)");
                driver.FindElement(By.XPath("//ul[@class='footer__socials']/li[2]/a")).Click();
                List<string> listWindow = new List<string>(driver.WindowHandles);
                driver.SwitchTo().Window(listWindow[1]);

                string currentULR = driver.Url;
                if (expectedresult != currentULR)
                {
                    Assert.Fail();
                }

                WindowClose();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        [TestMethod]
        public void DaviesGroupSolutions()
        {
            try
            {
                string expectedresult = "https://davies-group.com/case-study/fire-investigation/";
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://davies-group.com/");
                Thread.Sleep(10000);
                HandlingCookies();
                driver.FindElement(By.XPath("//ul[@id='menu-hero-header-menu']/li/a")).Click();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,1200)");
                driver.FindElement(By.XPath("//div[@class='cta-button__circle view-all__circle']/span")).Click();
                js.ExecuteScript("window.scrollBy(0,2500)");
                driver.FindElement(By.XPath("//div[@class='cta-button__circle learn-more__circle']/span")).Click();
                js.ExecuteScript("window.scrollBy(0,2500)");
                driver.FindElement(By.XPath("//div[@class='cta-button__circle learn-more__circle']/span")).Click();
                js.ExecuteScript("window.scrollBy(0,2500)");
                driver.FindElement(By.XPath("//div[@class='case-archive__post-list position-relative']/ul[3]/li/a")).Click();
                string currentULR = driver.Url;
                if (expectedresult != currentULR)
                {
                    Assert.Fail();
                }

                WindowClose();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void DaviesGroupFireInvestigationResult()
        {
            try
            {
                string expectedresult = "The dealership accepted fault and with an outlay to us of £1,495 made a recovery of £46,353.";
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://davies-group.com/");
                Thread.Sleep(10000);
                HandlingCookies();
                driver.FindElement(By.XPath("//ul[@id='menu-hero-header-menu']/li/a")).Click();
                Thread.Sleep(5000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,1200)");
                driver.FindElement(By.XPath("//div[@class='cta-button__circle view-all__circle']/span")).Click();
                js.ExecuteScript("window.scrollBy(0,2500)");
                driver.FindElement(By.XPath("//div[@class='cta-button__circle learn-more__circle']/span")).Click();
                js.ExecuteScript("window.scrollBy(0,2500)");
                driver.FindElement(By.XPath("//div[@class='cta-button__circle learn-more__circle']/span")).Click();
                js.ExecuteScript("window.scrollBy(0,2500)");
                driver.FindElement(By.XPath("//div[@class='case-archive__post-list position-relative']/ul[3]/li/a")).Click();


                string Result = driver.FindElement(By.XPath("//div[@class='case-single-desc__flex--full no-testimonial-case']/p[2]")).Text;

                Console.WriteLine("Result : " + Result);

                if (expectedresult.ToLower().ToString() != Result.ToLower().ToString())
                {
                    Assert.Fail();
                }

                WindowClose();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        
        [TestMethod]
        public void DaviesGroupStokeOfficeAddress()
        {
            try
            {

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://davies-group.com/");
                Thread.Sleep(10000);
                HandlingCookies();
                var element = driver.FindElement(By.XPath("//ul[@id='menu-hero-header-menu']/li[2]"));
                Actions action = new Actions(driver);
                action.MoveToElement(element).Perform();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//ul[@class='items']/li[4]/a")).Click();
                Thread.Sleep(5000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,800)");
                driver.FindElement(By.XPath("//div[@class='location__markers']/div[12]")).Click();
                Thread.Sleep(5000);
                string StokeAddress = driver.FindElement(By.XPath("//ul[@class='no-dots location__descriptions overflow-hidden bg--dark-blue text-white text-regular']/li[12]/p")).Text;
                Thread.Sleep(5000);
                Console.WriteLine(StokeAddress);
                if (StokeAddress == null)
                {
                    Assert.Fail();
                }
                WindowClose();
            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        public void WindowClose()
        {
            driver.Quit();
        }
        public void HandlingCookies()
        {
            try
            {
                driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinDeclineAll")).Click();
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }

}
