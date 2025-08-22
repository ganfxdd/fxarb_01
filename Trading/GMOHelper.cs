using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading
{
    class GMOHelper : IGoogle
    {
        public string url = "https://sec-sso.click-sec.com/loginweb/sso-redirect";

        System.Timers.Timer m_timer = new System.Timers.Timer();

        public async Task<bool> Login(string username, string password)
        {
            try
            {
                //Start the Browser
                if (!Start(false))
                    return false;

                string xpath = "//form[@name='loginForm']//input[@id='j_username']";
                
                //Navigate
                if (!navigate(url, xpath))
                    return false;

                //Enter the username
                xpath = "//form[@name='loginForm']//input[@id='j_username']";
              
                if (!await TryEnterText(xpath, username, "value", 3000, true))
                    return false;

                //Enter the password
                xpath = "//form[@name='loginForm']//input[@name='j_password']";
                
                if (!await TryEnterText(xpath, password, "value", 3000, true))
                    return false;

                //Click the Login Button
                xpath = "//form[@name='loginForm']//button[@name='LoginForm']";
                
                if (!TryClick(xpath, 1))
                    return false;

                await Task.Delay(2000);

                xpath = "//input[@id='mypage']";
                waitToElementVisible(xpath, 10000);
                TryClick(xpath, 1, 2000);

                await Task.Delay(3000);

                xpath = "//header//ul//li[@id='fxneoMenu']//a";
                waitToElementVisible(xpath, 20000);

                TryClick(xpath, 1, 4000);
                await Task.Delay(3000);

                xpath = "//section[@id='rateTab']//div//label[@for='rateTab2']";
                TryClick(xpath, 1, 30000);

                //await Task.Delay(2000);

                xpath = "//div[@class='rate-counts']//label[@for='rateList3']";
                TryClick(xpath, 1, 30000);

                //await Task.Delay(2000);

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


        public void M_KeepSession(object sender, System.Timers.ElapsedEventArgs e)
        {
            while (true)
            {
                var xpath = "(//table[@class='rateList-table']//tbody//tr[@class='rateList-tbody'])";                

                List<GMO> _result = new List<GMO>();

                for (var k = 1; k <= 20; k++)
                {
                    try
                    {
                        GMO _g = new GMO();
                        xpath = $"(//table[@class='rateList-table']//tbody//tr[@class='rateList-tbody'])[{k.ToString()}]//span[@class='product-pulldown-name']";
                        _g.product = getText(xpath);

                        xpath = $"(//table[@class='rateList-table']//tbody//tr[@class='rateList-tbody'])[{k.ToString()}]//span[@class='rateList-bid']";
                        _g.bid = getText(xpath);

                        xpath = $"(//table[@class='rateList-table']//tbody//tr[@class='rateList-tbody'])[{k.ToString()}]//span[@class='rateList-ask']";
                        _g.ask = getText(xpath);

                        _result.Add(_g);
                    }
                    catch (Exception)
                    {

                    }
                }
                
                MainApp.UpdateDom(_result);
            }
        }

        public void quitBrowser()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception) { }
        }
    }
}
