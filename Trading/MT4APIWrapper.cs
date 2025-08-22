using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAPI.MT4Server;
using System.Threading;

namespace Trading
{
    public class MT4APIWrapper
    {
        private QuoteClient qc = null;
        public uint userId;
        public string password;
        public string server;

        public void Init()
        {
            userId = 0;
            password = "";
            server = "";
        }

        public void ConnectAsync()
        {
            Thread thread = new Thread(Connect);
            thread.Start();
        }

        public void Connect()
        {
            Disconnect();

            if (server == "")
            {
                MainApp.AddLog("Failed to login MT4. Please select MT4 server.");
                return;
            }

            MainApp.ChangeLoadingVisible(true);

            try
            {
                server = "Server\\" + server + ".srv";
                MainServer srv = QuoteClient.LoadSrv(server);
                qc = new QuoteClient(userId, password, srv.Host, srv.Port);
                qc.Connect();

                MainApp.AddLog("Success to login MT4.");

                qc.OnQuote += new QuoteEventHandler(qc_OnQuote);
                //qc.OnConnect += new ConnectEventHandler(qc_OnConnect);

                SubscribeSymbols();
            }
            catch (Exception ex)
            {
                MainApp.AddLog("Failed to login MT4: " + ex.ToString());
            }

            MainApp.ChangeLoadingVisible(false);
        }

        public void Disconnect()
        {
            UnsubscribeSymbols();
            if (qc != null)
                qc.Disconnect();
        }

        public void SubscribeSymbols()
        {
            if (qc == null) return;

            try
            {
                var symbolList = qc.Symbols;
                foreach (var symbol in symbolList)
                {
                    if (qc.IsSubscribed(symbol) == false) qc.Subscribe(symbol);
                }
            }
            catch (Exception) { }
        }

        public void UnsubscribeSymbols()
        {
            if (qc == null) return;

            try
            {
                var symbolList = qc.Symbols;
                foreach (var symbol in symbolList)
                {
                    if (qc.IsSubscribed(symbol) == true) qc.Unsubscribe(symbol);
                }
            }
            catch (Exception) { }
        }

        void qc_OnQuote(object sender, QuoteEventArgs args)
        {
            int digit = ((QuoteClient)sender).GetSymbolInfo(args.Symbol).Digits;

            MainApp.UpdateMT4Quote(args.Symbol, args.Ask, args.Bid, digit);
        }

        void qc_OnConnect(object sender, ConnectEventArgs args)
        {
        }
    }
}
