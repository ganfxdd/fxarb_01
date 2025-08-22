using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace Trading
{
    public partial class MainFrm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private ArbitrageHelper arbitrageHelper;
        private GMOHelper gmoHelper;
        private MT4APIWrapper apiWrapper;
        private Strategy strategy;

        public MainFrm()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.BlueGrey800,
                        Primary.BlueGrey900,
                        Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);

            DrawerUseColors = true;

            Init();
        }

        private void Init()
        {
            arbitrageHelper = new ArbitrageHelper();
            gmoHelper = new GMOHelper();

            apiWrapper = new MT4APIWrapper();
            apiWrapper.Init();

            strategy = new Strategy();
            strategy.Init();
            strategy.symbolSuffix = txt_symbol_suffix.Text;

            LoadAccountInfo();
            LoadSetting();
            LoadServers();
        }

        public void LoadServers()
        {
            try
            {
                cb_server.Items.Clear();

                string folderWithServers = Path.Combine(Directory.GetCurrentDirectory(), "Server");

                DirectoryInfo d = new DirectoryInfo(folderWithServers);
                FileInfo[] Files = d.GetFiles("*.srv"); //Getting Text files

                foreach (FileInfo file in Files)
                {
                    string serverStr = file.Name;
                    serverStr = serverStr.Substring(0, serverStr.Length - 4);
                    cb_server.Items.Add(serverStr);
                }

                if (cb_server.Items.Count > 0)
                    cb_server.SelectedIndex = 0;
                else
                    cb_server.SelectedIndex = -1;
            }
            catch (Exception)
            {}
        }

        private void LoadAccountInfo()
        {
            string fileName = "Setting\\AccountInfo.txt";
            if (!File.Exists(fileName)) return;

            try
            {
                var lines = File.ReadLines(fileName).ToList();

                txt_mt_username.Text = lines[0];
                txt_mt_passwd.Text = lines[1];
                txt_symbol_suffix.Text = lines[2];
                txt_dmm_username.Text = lines[3];
                txt_dmm_passwd.Text = lines[4];

                if (lines[5].Contains("1")) sw_real.Checked = true;
                else sw_real.Checked = false;
            }
            catch (Exception) {}
        }

        private void SaveAccountInfo()
        {
            try
            {
                string fileName = "Setting\\AccountInfo.txt";
                string result = txt_mt_username.Text + "\n";
                result += txt_mt_passwd.Text + "\n";
                result += txt_symbol_suffix.Text + "\n";
                result += txt_dmm_username.Text + "\n";
                result += txt_dmm_passwd.Text + "\n";

                if (sw_real.Checked) result += "1\n";
                else result += "0\n";

                File.WriteAllText(fileName, result);
            }
            catch(Exception)
            {

            }
        }

        private void LoadSetting()
        {
            string fileName = "Setting\\StrategySetting.txt";
            if (!File.Exists(fileName)) return;

            try
            {
                var lines = File.ReadLines(fileName).ToList();

                tb_tp.Text = lines[0];
                tb_sl.Text = lines[1];
                tb_maxspread.Text = lines[2];
                tb_pricediff.Text = lines[3];
            }
            catch (Exception) { }
        }

        private void SaveSetting()
        {
            try
            {
                string fileName = "Setting\\StrategySetting.txt";
                string result = tb_tp.Text + "\n";
                result += tb_sl.Text + "\n";
                result += tb_maxspread.Text + "\n";
                result += tb_pricediff.Text + "\n";

                File.WriteAllText(fileName, result);
            }
            catch (Exception)
            {

            }
        }

        private void btn_dmm_login_Click(object sender, EventArgs e)
        {
            var user = txt_dmm_username.Text;
            var pass = txt_dmm_passwd.Text;

            ChangeLoadingVisible(true);
            ChangeButtonState(false);

            new Task(async () =>
            {
                bool isDemo = !sw_real.Checked;

                bool result = await arbitrageHelper.Login(user, pass, isDemo);
                if (!result)
                {
                    MessageBox.Show("Cannot login. Incorrect the username or password.");
                    AddLog("Failed to login DMM.");

                    arbitrageHelper.quitBrowser();
                }
                else
                {
                    AddLog("Success to login DMM.");
                }

                ChangeLoadingVisible(false);
                ChangeButtonState(true);
            }).Start();
        }

        public void updateGMOValue(List<GMO> dom)
        {            
            try
            {
                if (dom.Count > 0)
                {
                    var product = lb_symbol.Text;
                    var index = 0;
                    for(var k=0; k<dom.Count; k++)
                    {
                        if (dom[k].product == product)
                        {
                            index = k;
                            break;
                        }                            
                    }

                    int digit = GetDigitFromQuote(dom[index].ask);

                    double ask = 0;
                    double bid = 0;
                    if(!Double.TryParse(dom[index].ask, out ask)) ask = 0;
                    if(!Double.TryParse(dom[index].bid, out bid)) bid = 0;
                    if (ask == 0) digit = 3;

                    strategy.updateFastQuote(dom[index].product, ask, bid, digit);

                    this.InvokeOnUiThreadIfRequired(() =>
                    {
                        lb_fast_bid.Text = dom[index].bid;
                        lb_fast_ask.Text = dom[index].ask;
                    });
                }
            }
            catch (Exception) { }
        }

        private int GetDigitFromQuote(string priceStr)
        {
            int len = priceStr.Length;
            for(int i = 0; i < len; i++)
            {
                if(priceStr[i] == '.')
                {
                    return len - i - 1;
                }
            }
            return 3;
        }

        public void updateDMM(string currency, string orderQuantity, string bid, string ask)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                lb_slow_ask.Text = ask;
                lb_slow_bid.Text = bid;
                lb_symbol.Text = currency;
                lb_lot.Text = orderQuantity;
            });

            double lot, bidPrice, askPrice;
            if (!Double.TryParse(orderQuantity, out lot)) lot = 0;
            if (!Double.TryParse(bid, out bidPrice)) bidPrice = 0;
            if (!Double.TryParse(ask, out askPrice)) askPrice = 0;

            if (lot > 0 && bidPrice > 0 && askPrice > 0)
            {
                strategy.updateDMM(currency, lot, askPrice, bidPrice);
            }
        }

        private void btn_sell_Click(object sender, EventArgs e)
        {
            ChangeButtonState(false);

            TrySell();

            ChangeButtonState(true);
        }

        public bool TrySell()
        {
            bool isSuccess = true;

            Thread thread = new Thread(() =>
            {
                string error = arbitrageHelper.bidClick();

                if (error != "")
                {
                    AddLog("Failed to open Sell: " + error);
                    isSuccess = false;
                }
                else
                {
                    AddLog("Success to open Sell");
                }
            });

            thread.Start();
            thread.Join();

            return isSuccess;
        }

        private void btn_buy_Click(object sender, EventArgs e)
        {
            ChangeButtonState(false);

            TryBuy();

            ChangeButtonState(true);
        }

        public bool TryBuy()
        {
            bool isSuccess = true;

            Thread thread = new Thread(() =>
            {
                string error = arbitrageHelper.askClick();

                if (error != "")
                {
                    AddLog("Failed to open Buy: " + error);
                    isSuccess = false;
                }
                else
                {
                    AddLog("Success to open Buy");
                }

            });

            thread.Start();
            thread.Join();

            return isSuccess;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            ChangeButtonState(false);

            TryClose();

            ChangeButtonState(true);
        }

        public bool TryClose()
        {
            bool isSuccess = true;

            Thread thread = new Thread(() =>
            {
                string error = arbitrageHelper.closeClick(0);

                if (error != "")
                {
                    AddLog("Failed to close: " + error);
                    isSuccess = false;
                }
                else
                {
                    AddLog("Success to close");
                }
            });

            thread.Start();
            thread.Join();

            return isSuccess;
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            arbitrageHelper.quitBrowser();
            gmoHelper.quitBrowser();
            apiWrapper.Disconnect();

            SaveAccountInfo();
            SaveSetting();
        }

        public void AddLog(string str)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                rtb_log.Text = rtb_log.Text + str + "\n";
            });
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            rtb_log.Text = "";
        }

        private void btn_mt_login_Click(object sender, EventArgs e)
        {
            var user = txt_mt_username.Text;
            var pass = txt_mt_passwd.Text;

            ChangeLoadingVisible(true);
            ChangeButtonState(false);

            new Task(async () =>
            {
               
                bool result = await gmoHelper.Login(user, pass);
                if (!result)
                {
                    MessageBox.Show("Cannot login. Incorrect the username or password.");
                    AddLog("Failed to login GMO.");

                    gmoHelper.quitBrowser();
                }
                else
                {
                    AddLog("Success to login GMO.");
                }

                ChangeLoadingVisible(false);
                ChangeButtonState(true);
            }).Start();

            //strategy.InitFastQuotes();

            //uint userId = 0;

            //UInt32.TryParse(txt_mt_username.Text, out userId);
            //string password = txt_mt_passwd.Text;
            //string server = cb_server.SelectedItem.ToString();

            //apiWrapper.userId = userId;
            //apiWrapper.password = password;
            //apiWrapper.server = server;
            //apiWrapper.ConnectAsync();
        }

        public void updateMT4Quote(string symbol, double askPrice, double bidPrice, int digit)
        {
            strategy.updateFastQuote(symbol, askPrice, bidPrice, digit);

            this.InvokeOnUiThreadIfRequired(() =>
            {
                askPrice = strategy.getFastAsk();
                bidPrice = strategy.getFastBid();
                double point = strategy.getPoint();

                digit = strategy.getDigit();

                lb_fast_ask.Text = DoubleToString(askPrice, digit);
                lb_fast_bid.Text = DoubleToString(bidPrice, digit);
                lb_point.Text = DoubleToString(point, digit);
            });
        }

        private string DoubleToString(double val, int digit)
        {
            if (val == 0) return "N/A";

            string str = "0.";
            for(int i = 0; i < digit; i++)
            {
                str += "0";
            }

            return val.ToString(str);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if(strategy.isStarted) //Started already
            {
                ChangeTextBoxState(true);
                ChangeButtonState(true, false);
                ChangeLoadingVisible(false);

                strategy.isStarted = false;
                btn_start.Text = "Start Bot";
            }
            else
            {
                ReadStrategyParam();
                if(strategy.isValidSetting() == false)
                {
                    MessageBox.Show("Invalid setting or you didn't login");
                    return;
                }

                ChangeTextBoxState(false);
                ChangeButtonState(false, false);
                ChangeLoadingVisible(true);

                strategy.InitStrategy();
                strategy.isStarted = true;
                btn_start.Text = "Stop Bot";
            }
        }

        private void ReadStrategyParam()
        {
            double TP, SL, maxSpread, priceDiff;

            if(!Double.TryParse(tb_tp.Text, out TP)) TP = 0;
            if (!Double.TryParse(tb_sl.Text, out SL)) SL = 0;
            if (!Double.TryParse(tb_maxspread.Text, out maxSpread)) maxSpread = 0;
            if (!Double.TryParse(tb_pricediff.Text, out priceDiff)) priceDiff = 0;

            strategy.updateSetting(TP, SL, maxSpread, priceDiff);
        }

        void key_press(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void ChangeButtonState(bool state, bool forAll = true)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                if (forAll)
                {
                    btn_dmm_login.Enabled = state;
                    btn_mt_login.Enabled = state;
                    btn_start.Enabled = state;
                }

                btn_buy.Enabled = state;
                btn_sell.Enabled = state;
                btn_close.Enabled = state;
            });
        }

        private void ChangeTextBoxState(bool state)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                tb_maxspread.Enabled = state;
                tb_pricediff.Enabled = state;
                tb_sl.Enabled = state;
                tb_tp.Enabled = state;
            });
        }

        public void ChangeLoadingVisible(bool state)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                btn_loading.Visible = state;
            });
        }

        private void txt_symbol_suffix_TextChanged(object sender, EventArgs e)
        {
            string symbolSuffix = txt_symbol_suffix.Text;
            if(strategy.symbolSuffix != symbolSuffix)
            {
                strategy.InitFastQuotes();
                strategy.symbolSuffix = symbolSuffix;
            }
        }
    }
}
