using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiFeng
{
    class Program
    {
        static CtpQuote q = null;
        static CtpTrade t = null;
        static void Main(string[] args)
        {
            q = new CtpQuote("ctp_quote");
            t = new CtpTrade("ctp_trade");

            t.SetOnFrontConnected(t_connected);
            t.SetOnRspUserLogin(t_login);
            t.SetOnRtnTradingNotice(t_notice);

            q.SetOnFrontConnected(connected);
            q.SetOnRspUserLogin(login);

            t.RegisterFront("tcp://180.168.146.187:10000");
            q.RegisterFront("tcp://180.168.146.187:10010");

            t.Init();
            q.Init();
            Console.ReadLine();
        }

        private static void t_notice(ref CThostFtdcTradingNoticeInfoField pTradingNoticeInfo)
        {
            Console.WriteLine(pTradingNoticeInfo.SendTime + pTradingNoticeInfo.FieldContent);
        }

        private static void t_login(ref CThostFtdcRspUserLoginField pRspUserLogin, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("t:" + pRspInfo.ErrorMsg);
        }

        private static void t_connected()
        {
            Console.WriteLine("t:connected");
            t.ReqUserLogin(brokerId: "9999", userId: "008107", password: "1");
        }

        private static void login(ref CThostFtdcRspUserLoginField pRspUserLogin, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine(pRspInfo.ErrorMsg);
        }

        private static void connected()
        {
            Console.WriteLine("connected");
            q.ReqUserLogin(brokerId: "9999", userId: "008105", password: "1");
        }
    }
}
