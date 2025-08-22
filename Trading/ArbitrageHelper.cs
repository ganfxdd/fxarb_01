using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading
{
    class ArbitrageHelper : IGoogle
    {
        public string demoURL = "https://demotrade.fx.dmm.com/fxcrichpresen/webrich/direct/login";
        public string realURL = "https://trade.fx.dmm.com/comportal/Login.do?type=1";

        System.Timers.Timer m_timer = new System.Timers.Timer();

        public async Task<bool> Login(string username, string password, bool isDemo = true)
        {
            string url = demoURL;
            if (!isDemo) url = realURL;

            try
            {                
                //Start the Browser
                if (!Start(false))
                    return false;

                string xpath = "//div[@id='LoginWindow']";

                if (!isDemo)
                    xpath = "//div[@id='LoginWindowFx']";

                //Navigate
                if (!navigate(url, xpath))
                    return false;

                //Enter the username
                xpath = "//form//input[@name='accountId']";

                if (!isDemo)
                    xpath = "//form//input[@name='username']";

                if (!await TryEnterText(xpath, username, "value", 3000, true))
                    return false;

                //Enter the password
                xpath = "//form//input[@id='password']";
                if (!isDemo)
                    xpath = "//form//input[@name='passwordShow']";

                if (!await TryEnterText(xpath, password, "value", 3000, true))
                    return false;

                //Click the Login Button
                xpath = "//form//a[@class='flaHandleLogin']";
                if (!isDemo)
                    xpath = "//p[@id='LoginWindowBtn']//a";
                if (!TryClick(xpath, 1))
                    return false;

                await Task.Delay(3000);
                if (!isDemo)
                {
                    //check if the password is correct
                    xpath = "//div[@id='status']//font[@class='error-message']";
                    if (getText(xpath, 2000) != "")
                        return false;

                    xpath = "//header//a//img";
                    waitToElementVisible(xpath,20000);

                    xpath = "//div[@id='LoginNavi']//section//ul//li[2]//a";
                    TryClick(xpath, 1);

                    await Task.Delay(1000);
                }
                    

                if (driver.WindowHandles.Count > 1)
                    driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);

                if (isDemo)
                {
                    if (waitToElementVisible("//table[@class='rmbgtable']//td[@class='redtext']", 10000))
                        return false;
                }

                xpath = "//div[@class='productDemoIcon']";
                if (!isDemo)
                    xpath = "//div[@class='productIcon']";

                if (!waitToElementVisible(xpath))
                    return false;

                xpath = "//button[@uifield='openButton']";
                TryClick(xpath, 1, 2000);

                xpath = "//button[@uifield='closeButton']";
                TryClick(xpath, 1, 2000);

                m_timer.Elapsed += M_KeepSession;
                m_timer.AutoReset = false;
                m_timer.Start();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void M_KeepSession(object sender, System.Timers.ElapsedEventArgs e)
        {
            while (true)
            {
                var currency = getText("//div[@uifield='currencyPairSelect']//span");
                var orderQuantity = getAttribute("//input[@uifield='orderQuantity']","value");
                var bid = getText("//div[@uifield='bidStreamingButton']/div");
                var ask = getText("//div[@uifield='askStreamingButton']/div");
                MainApp.UpdateDMM(currency, orderQuantity, bid, ask);
            }
        }

        public string bidClick()
        {
            string xpath = "//div[@uifield='bidStreamingButton']";

            if (!TryClick(xpath, 2, 1000))
                return "Can Not Click.";

            //Detect the errors;
            xpath = "//div[@uifield='errorArea']";
            string errors = getText(xpath, 3000);
            if (errors != "")
            {
                TryClick(xpath, 1, 2000);
                return errors;
            }

            xpath = "//div[@uifield='mainPanel']//div[@class='streamingOrderPanel']/div[@uifield='errorArea']";
            errors = getText(xpath, 3000);

            if (errors != "")
                TryClick(xpath, 1, 2000);
            return errors;            
        }

        public string askClick()
        {
            string xpath = "//div[@uifield='askStreamingButton']";

            if (!TryClick(xpath, 2, 1000))
                return "Can Not Click.";

            //Detect the errors;
            xpath = "//div[@uifield='errorArea']";
            string errors = getText(xpath, 3000);
            if (errors != "")
            {
                TryClick(xpath, 1, 2000);
                return errors;
            }
            xpath = "//div[@uifield='mainPanel']//div[@class='streamingOrderPanel']/div[@uifield='errorArea']";
            errors = getText(xpath, 3000);

            if (errors != "")
                TryClick(xpath, 1, 2000);
            return errors;
        }

        public string closeClick(int index)
        {
            string xpath = $"(//tr[@class='contractLineView']//td//button[@uifield='quickCloseOrderButton'])[{(index + 1).ToString()}]";

            if (!TryClick(xpath, 1, 1000))
                return "Can Not Click.";

            xpath = "//div[@class='footer']//button[@uifield='executeButton']";
            if (!TryClick(xpath, 1, 1000))
                return ""; // "Can Not Click.";

            xpath = "(//div[contains(@class,'ui-dialog-content')]//div[contains(@class,'contractQuickCloseOrder')]/div[@class='footer']/button[@uifield='closeButton'])[2]";
            if (!TryClick(xpath, 1, 3000))
                return ""; // "Can Not Click.";

            return "";
        }
        
        public void quitBrowser()
        {
            try
            {
                driver.Quit();
            } catch(Exception) { }
        }
    }
}
