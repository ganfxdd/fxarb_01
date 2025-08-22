using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trading
{
    static class MainApp
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static MainFrm mainFrm;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainFrm = new MainFrm();
            Application.Run(mainFrm);
        }

        public static void log_info(string msg, bool msgbox = false)
        {
            try
            {
                mainFrm.InvokeOnUiThreadIfRequired(() =>
                {
                    logger.Info(msg);
                    if (msgbox)
                        MessageBox.Show(msg);
                });
            }
            catch (Exception) {}
        }

        public static void UpdateDMM(string currency, string orderQuantity, string bid, string ask)
        {
            mainFrm.updateDMM(currency, orderQuantity, bid, ask);
        }

        public static void UpdateDom(List<GMO> dom)
        {
            mainFrm.updateGMOValue(dom);            
        }

        public static void AddLog(string log)
        {
            mainFrm.AddLog(log);
        }

        public static void UpdateMT4Quote(string symbol, double askPrice, double bidPrice, int digit)
        {
            mainFrm.updateMT4Quote(symbol, askPrice, bidPrice, digit);
        }

        public static void ChangeLoadingVisible(bool state)
        {
            mainFrm.ChangeLoadingVisible(state);
        }

        public static bool TryBuy()
        {
            return mainFrm.TryBuy();
        }

        public static bool TrySell()
        {
            return mainFrm.TrySell();
        }

        public static bool TryClose()
        {
            return mainFrm.TryClose();
        }

    }
}
