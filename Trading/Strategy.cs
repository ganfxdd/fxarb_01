using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAPI.MT4Server;

namespace Trading
{ 
    public class Strategy
    {
        public string symbol;
        public string symbolSuffix;
        public double lot;
        public int digit;
        public double point;

        public double fastAsk;
        public double fastBid;
        public double slowAsk;
        public double slowBid;

        public bool isStarted;
        public double TP;
        public double SL;
        public double maxSpread;
        public double priceDiff;

        public Op curDirection;
        public Op lastSignal;
        public double openPrice;

        public bool isChecking;

        public void Init()
        {
            symbol = "";
            symbolSuffix = "";
            lot = digit = 0;
            fastAsk = fastBid = 0;
            slowAsk = slowBid = 0;

            isStarted = false;
            TP = SL = 0;
            maxSpread = priceDiff = 0;

            InitStrategy();
        }

        public void InitFastQuotes()
        {
            fastAsk = fastBid = 0;
        }

        public void InitStrategy()
        {
            curDirection = Op.Balance;
            lastSignal = Op.Balance;
            isChecking = false;
        }

        public bool isValidSetting()
        {
            //if (TP == 0) return false;
            //if (SL == 0) return false;
            if (maxSpread == 0) return false;
            if (point == 0) return false;

            return true;
        }

        public void CheckStrategy()
        {
            if (!isStarted) return;

            if (fastAsk + fastBid == 0) return;
            if (slowAsk + slowBid == 0) return;
            if (!isValidSetting()) return;

            if (maxSpread > 0 && slowAsk - slowBid >= maxSpread * point) return;
            if (maxSpread > 0 && fastAsk - fastBid >= maxSpread * point) return;

            if (isChecking) return;
            isChecking = true;

            if (fastBid >= slowAsk + priceDiff * point) //Buy
            {
                if (lastSignal == Op.Buy)
                {
                    isChecking = false;
                    return;
                }
                lastSignal = Op.Buy;

                if (curDirection == Op.Sell)
                {
                    if (MainApp.TryClose())
                    {
                        curDirection = Op.Balance;
                        openPrice = 0;
                    }
                    else
                    {
                        lastSignal = Op.Balance;
                    }
                }
                else if (curDirection == Op.Balance)
                {
                    if (MainApp.TryBuy())
                    {
                        curDirection = Op.Buy;
                        openPrice = slowAsk;
                    }
                    else
                    {
                        lastSignal = Op.Balance;
                    }
                }
            }
            else if (fastAsk <= slowBid - priceDiff * point) //Sell
            {
                if (lastSignal == Op.Sell)
                {
                    isChecking = false;
                    return;
                }
                lastSignal = Op.Sell;

                if (curDirection == Op.Buy)
                {
                    if (MainApp.TryClose())
                    {
                        curDirection = Op.Balance;
                        openPrice = 0;
                    }
                    else
                    {
                        lastSignal = Op.Balance;
                    }
                }
                else if (curDirection == Op.Balance)
                {
                    if (MainApp.TrySell())
                    {
                        curDirection = Op.Sell;
                        openPrice = slowBid;
                    }
                    else
                    {
                        lastSignal = Op.Balance;
                    }
                }
            }
            else
            {
                lastSignal = Op.Balance;
            }

            //Check TP/SL
            if(curDirection == Op.Buy && openPrice > 0)
            {
                if(TP > 0 && slowBid >= openPrice + TP * point)
                {
                    if(MainApp.TryClose())
                    {
                        MainApp.AddLog("Close Buy order by TP");
                        curDirection = Op.Balance;
                        openPrice = 0;
                    }
                }
                else if(SL > 0 && slowBid <= openPrice - SL * point)
                {
                    if(MainApp.TryClose())
                    {
                        MainApp.AddLog("Close Buy order by SL");
                        curDirection = Op.Balance;
                        openPrice = 0;
                    }
                }
            }
            else if(curDirection == Op.Sell && openPrice > 0)
            {
                if(TP > 0 && slowAsk <= openPrice - TP * point)
                {
                    if(MainApp.TryClose())
                    {
                        MainApp.AddLog("Close Sell order by TP");
                        curDirection = Op.Balance;
                        openPrice = 0;
                    }
                }
                else if(SL > 0 && slowBid >= openPrice + SL * point)
                {
                    if(MainApp.TryClose())
                    {
                        MainApp.AddLog("Close Sell order by SL");
                        curDirection = Op.Balance;
                        openPrice = 0;
                    }
                }
            }

            isChecking = false;
        }

        public void updateSetting(double p_TP, double p_SL, double p_maxSpread, double p_priceDiff)
        {
            TP = p_TP;
            SL = p_SL;
            maxSpread = p_maxSpread;
            priceDiff = p_priceDiff;
        }

        public void updateDMM(string p_symbol, double p_lot, double p_ask, double p_bid)
        {
            if(symbol != p_symbol)
            {
                fastAsk = fastBid = 0;
                digit = 0;
                point = 0;
            }

            symbol = p_symbol;
            lot = p_lot;
            slowAsk = p_ask;
            slowBid = p_bid;

            CheckStrategy();
        }

        public void updateFastQuote(string p_symbol, double p_ask, double p_bid, int p_digit)
        {
            if (symbol == "") return;

            p_symbol = p_symbol.ToUpper();
            symbol = symbol.ToUpper();

            //symbolSuffix = symbolSuffix.ToUpper();
            //string realStr = getRealString(symbol);
            //if (symbolSuffix != "" && !p_symbol.Contains(symbolSuffix)) return;
            //if (!p_symbol.Contains(realStr)) return;

            fastAsk = p_ask;
            fastBid = p_bid;

            digit = p_digit;
            point = getPointFromDigit();

            CheckStrategy();
        }

        private double getPointFromDigit()
        {
            if (digit == 0) return 0;

            double res = 1;
            for(int i = 0; i < digit; i++)
            {
                res /= 10.0;
            }
            return res;
        }

        public string getSymbol()
        {
            return symbol;
        }

        public double getSlowAsk()
        {
            return slowAsk;
        }

        public double getSlowBid()
        {
            return slowBid;
        }

        public double getFastAsk()
        {
            return fastAsk;
        }

        public double getFastBid()
        {
            return fastBid;
        }

        public int getDigit()
        {
            return digit;
        }

        public double getPoint()
        {
            return point;
        }

        private string getRealString(string str)
        {
            string result = "";
            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] >= 'A' && str[i] <= 'Z')
                {
                    result += str[i];
                }
            }
            return result;
        }
    }
}
