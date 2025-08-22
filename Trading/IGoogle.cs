using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
namespace Trading
{
    public class IGoogle
    {
        //public ChromeDriver Driver;
        public RemoteWebDriver driver;
        object m_locker = new object();
        public IJavaScriptExecutor m_js;

        public object m_chr_data_dir = new object();
        public Guid m_guid;
        public string m_chr_user_data_dir = "";
       
        //Selenium
        public bool Start(bool bookieName = true)
        {
            lock (m_chr_data_dir)
            {
                m_guid = Guid.NewGuid();
                m_chr_user_data_dir = $"\\ChromeData\\checker_{Thread.CurrentThread.ManagedThreadId}" + m_guid.ToString();
                Directory.CreateDirectory(m_chr_user_data_dir);
            }

            try
            {
                ChromeDriverService defaultService = ChromeDriverService.CreateDefaultService();
                defaultService.HideCommandPromptWindow = true;
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--disable-popup-blocking");
                //chromeOptions.AddArguments("no-sandbox");
                //chromeOptions.AddArguments("headless");
                chromeOptions.AddArguments("--disable-gpu");
                chromeOptions.AddArgument("system-developer-mode");
                chromeOptions.AddArgument("no-first-run");
                chromeOptions.AddArgument("start-maximized");
                //chromeOptions.AddArgument("--disable-dev-shm-usage");
                chromeOptions.AddArgument("--disable-infobars");
                chromeOptions.AddArgument("--disable-extensions");


                //chromeOptions.AddArgument("--user-data-dir=" + m_chr_user_data_dir);
                //string randomUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36";
                //chromeOptions.AddArgument(string.Format("--user-agent={0}", (object)randomUserAgent));                
                string chr_path;
                if (Environment.Is64BitOperatingSystem)
                    chr_path = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
                else
                    chr_path = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";

                chromeOptions.BinaryLocation = chr_path;

                try
                {
                    driver = new ChromeDriver(defaultService, chromeOptions, TimeSpan.FromSeconds(180));
                    //driver = new ChromeDriver(chromeOptions);
                    //driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

                    if (bookieName)
                    {
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    }

                    driver.Manage().Window.Size = new Size(1920, 1080);
                    Console.WriteLine(driver.Manage().Window.Size);
                    driver.Manage().Window.Maximize();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return false;
                }

                m_js = (IJavaScriptExecutor)driver;

                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    driver.Quit();
                }
                catch
                {
                    MainApp.log_info($"Failed to quit driver. Exception:{ex.Message}");
                }
                return false;
            }
        }      

        public bool navigate(string target, string element_xpath, int timeout = 30000)
        {
            try
            {
                string url = driver.Url;
                driver.Navigate().GoToUrl(target);

                //Wait until element is visible
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
                //wait.Until(ElementIsVisible(driver.FindElement(By.XPath(element_xpath))));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(element_xpath)));
                return true;
            }
            catch (Exception ex)
            {
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Displayed && element.Enabled;
                }
                catch (Exception ex)
                {
                    // If element is null, stale or if it cannot be located
                    MainApp.log_info($"Exception:{ex.Message}");
                    return false;
                }
            };
        }

        public Func<IWebDriver, bool> waitForElementEnable(string xpath)
        {
            return (driver) =>
            {
                try
                {
                    IWebElement element = driver.FindElement(By.XPath(xpath));

                    if (!element.GetAttribute("class").ToLower().Contains("disabled"))
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    // If element is null, stale or if it cannot be located
                    MainApp.log_info($"Exception:{ex.Message}");
                    return false;
                }
            };
        }

        public bool waitForElementNotIncludeString(string xpath, string expected_string, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                return wait.Until(waitForElementTextNotContainsString(xpath, expected_string));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Func<IWebDriver, bool> waitForElementTextNotContainsString(string xpath, String expectedString)
        {
            return (driver) =>
            {
                try
                {
                    IWebElement element = driver.FindElement(By.XPath(xpath));

                    if (element.Text.Length != 0 && !element.Text.ToUpper().Contains(expectedString.ToUpper()))
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    // If element is null, stale or if it cannot be located
                    MainApp.log_info($"Exception:{ex.Message}");
                    return false;
                }
            };
        }

        //Enter the text
        public async Task<bool> TryEnterText(String xpath, string textToEnter, string atributeToEdit = "value", int TimeOut = 30000, bool manualyEnter = false)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));

                element.SendKeys((string)OpenQA.Selenium.Keys.Control + "a");

                if (manualyEnter)
                    element.SendKeys(textToEnter);
                else
                    driver.ExecuteScript($"arguments[0].value = '{textToEnter}';", element);

                for (int index = 0; index < 10; ++index)
                {
                    await TaskDelay(100);
                    if ((string)driver.ExecuteScript("return arguments[0].value;", element) == textToEnter)
                    {
                        return true;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MainApp.log_info($"Exception:{ex.Message} {ex.StackTrace}");
                return false;
            }
        }

        public async Task<bool> TaskDelay(int delay)
        {
            await Task.Delay(delay);
            return true;
        }

        public bool TryClick(String xpath, int mode = 0, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                wait.Until(ElementIsVisible(driver.FindElement(By.XPath(xpath))));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                wait.Until(waitForElementEnable(xpath));

                var element = driver.FindElement(By.XPath(xpath));
                if (mode == 0)
                {
                    driver.ExecuteScript("arguments[0].click('');", element);
                }
                else if (mode == 1)
                {
                    element.Click();
                }
                else if (mode == 2)
                {
                    Actions action = new Actions(driver);
                    action.MoveToElement(driver.FindElementByXPath(xpath)).Perform();
                    action.Click(driver.FindElementByXPath(xpath)).Perform();
                }
                return true;
            }
            catch (Exception ex)
            {
                MainApp.log_info(xpath);
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
            return false;
        }

        public void TryClickElement(IWebElement element, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var tElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                tElement.Click();
            }
            catch (Exception ex)
            {
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public string getText(string xpath, int TimeOut = 30000)
        {
            string result = "";

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                result = element.Text;                
            }
            catch (Exception ex)
            {
                MainApp.log_info("Get Text Error: " + xpath);
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }

            return result;
        }

        public string getAttribute(string xpath, string value, int TimeOut = 30000)
        {
            string result = "";

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                result = element.GetAttribute(value);
            }
            catch (Exception ex)
            {
                MainApp.log_info("Get Text Error: " + xpath);
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }

            return result;
        }

        public void runJavascript(string javascript)
        {
            try
            {
                driver.ExecuteScript(javascript);
            }
            catch (Exception ex)
            {
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public bool waitToElementVisible(string xpath, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                return true;
            }
            catch (Exception)
            {
                
            }
            return false;
        }

        public void waitToElementVisible(IWebElement ele, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                wait.Until(ElementIsVisible(ele));
            }
            catch (Exception)
            {

            }
        }

        public IWebElement getElementFromParent(IWebElement parent, string xpath, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var element = parent.FindElement(By.XPath(xpath));
                wait.Until(ElementIsVisible(element));
                return element;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> getElementsFromParent(IWebElement parent, string xpath, int TimeOut = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(TimeOut));
                var elements = parent.FindElements(By.XPath(xpath));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
                return elements;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> getElementsByXPath(string xpath, int timeout = 30000)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
                var elements = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));
                return elements;
            }
            catch (Exception ex)
            {
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
                return null;
            }
        }

        public void TakingHTML2CanvasFullPageScreenshot(string bookie_name)
        {
            try
            {
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string imageFoler = path + "\\images";
                if (!Directory.Exists(imageFoler))
                    Directory.CreateDirectory(imageFoler);

                string filename = String.Format("{0}\\images\\{1}_{2}.png", path, bookie_name, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
                //filename = Path.Combine(path, filename);

                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Png);
            }
            catch (Exception ex)
            {
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void refresh()
        {
            try
            {
                lock (m_locker)
                {
                    driver.Navigate().Refresh();
                }
            }
            catch (Exception ex)
            {
                MainApp.log_info(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
