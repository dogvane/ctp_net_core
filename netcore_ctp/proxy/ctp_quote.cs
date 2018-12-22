

using System;
using System.IO;
using System.Runtime.InteropServices;
using PureCode.CtpCSharp;

namespace HaiFeng
{
	public class ctp_quote
	{
	    private AssembyLoader loader;
	    IntPtr _handle = IntPtr.Zero, _api = IntPtr.Zero, _spi = IntPtr.Zero;
	    delegate IntPtr Create();
	    delegate IntPtr DelegateRegisterSpi(IntPtr api, IntPtr pSpi);
	    public ctp_quote(string pFile)
	    {
	        loader = new AssembyLoader(pFile);
	        Directory.CreateDirectory("log");

	        _api = (loader.Invoke("CreateApi", typeof(Create)) as Create)();
	        _spi = (loader.Invoke("CreateSpi", typeof(Create)) as Create)();
	        (loader.Invoke("RegisterSpi", typeof(DelegateRegisterSpi)) as DelegateRegisterSpi)(_api, _spi);
	    }


        #region 声明REQ函数类型
        public delegate IntPtr DeleRelease(IntPtr api);
		public delegate IntPtr DeleInit(IntPtr api);
		public delegate IntPtr DeleJoin(IntPtr api);
		public delegate IntPtr DeleGetTradingDay(IntPtr api);
		public delegate IntPtr DeleRegisterFront(IntPtr api, string pszFrontAddress);
		public delegate IntPtr DeleRegisterNameServer(IntPtr api, string pszNsAddress);
		public delegate IntPtr DeleRegisterFensUserInfo(IntPtr api,ref CThostFtdcFensUserInfoField pFensUserInfo);
		public delegate IntPtr DeleSubscribeMarketData(IntPtr api, IntPtr pInstruments, int pCount);
		public delegate IntPtr DeleUnSubscribeMarketData(IntPtr api, IntPtr pInstruments, int pCount);
		public delegate IntPtr DeleSubscribeForQuoteRsp(IntPtr api, IntPtr pInstruments, int pCount);
		public delegate IntPtr DeleUnSubscribeForQuoteRsp(IntPtr api, IntPtr pInstruments, int pCount);
		public delegate IntPtr DeleReqUserLogin(IntPtr api, ref CThostFtdcReqUserLoginField pReqUserLoginField, int nRequestID);
		public delegate IntPtr DeleReqUserLogout(IntPtr api,ref CThostFtdcUserLogoutField pUserLogout, int nRequestID);

		#endregion
		#region REQ函数

		private int nRequestID = 0;

		public IntPtr Release()
		{
			return (loader.Invoke("Release", typeof(DeleRelease)) as DeleRelease)(_api);
		}

		public IntPtr Init()
		{
			return (loader.Invoke("Init", typeof(DeleInit)) as DeleInit)(_api);
		}

		public IntPtr Join()
		{
			return (loader.Invoke("Join", typeof(DeleJoin)) as DeleJoin)(_api);
		}

		public IntPtr GetTradingDay()
		{
			return (loader.Invoke("GetTradingDay", typeof(DeleGetTradingDay)) as DeleGetTradingDay)(_api);
		}

		public IntPtr RegisterFront(string pszFrontAddress)
		{
			return (loader.Invoke("RegisterFront", typeof(DeleRegisterFront)) as DeleRegisterFront)(_api, pszFrontAddress);
		}

		public IntPtr RegisterNameServer(string pszNsAddress)
		{
			return (loader.Invoke("RegisterNameServer", typeof(DeleRegisterNameServer)) as DeleRegisterNameServer)(_api, pszNsAddress);
		}

		public IntPtr RegisterFensUserInfo(string BrokerID = "", string UserID = "", TThostFtdcLoginModeType LoginMode = TThostFtdcLoginModeType.THOST_FTDC_LM_Trade)
		{
			CThostFtdcFensUserInfoField struc = new CThostFtdcFensUserInfoField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				LoginMode = LoginMode,
			};
			return (loader.Invoke("RegisterFensUserInfo", typeof(DeleRegisterFensUserInfo)) as DeleRegisterFensUserInfo)(_api, ref struc);
		}

		public IntPtr SubscribeMarketData(IntPtr pInstruments, int pCount)
		{
			return (loader.Invoke("SubscribeMarketData", typeof(DeleSubscribeMarketData)) as DeleSubscribeMarketData)(_api, pInstruments, pCount);
		}

		public IntPtr UnSubscribeMarketData(IntPtr pInstruments, int pCount)
		{
			return (loader.Invoke("UnSubscribeMarketData", typeof(DeleUnSubscribeMarketData)) as DeleUnSubscribeMarketData)(_api, pInstruments, pCount);
		}

		public IntPtr SubscribeForQuoteRsp(IntPtr pInstruments, int pCount)
		{
			return (loader.Invoke("SubscribeForQuoteRsp", typeof(DeleSubscribeForQuoteRsp)) as DeleSubscribeForQuoteRsp)(_api, pInstruments, pCount);
		}

		public IntPtr UnSubscribeForQuoteRsp(IntPtr pInstruments, int pCount)
		{
			return (loader.Invoke("UnSubscribeForQuoteRsp", typeof(DeleUnSubscribeForQuoteRsp)) as DeleUnSubscribeForQuoteRsp)(_api, pInstruments, pCount);
		}

		public IntPtr ReqUserLogin(string TradingDay = "", string BrokerID = "", string UserID = "", string Password = "", string UserProductInfo = "", string InterfaceProductInfo = "", string ProtocolInfo = "", string MacAddress = "", string OneTimePassword = "", string ClientIPAddress = "", string LoginRemark = "")
		{
			CThostFtdcReqUserLoginField struc = new CThostFtdcReqUserLoginField
			{
				TradingDay = TradingDay,
				BrokerID = BrokerID,
				UserID = UserID,
				Password = Password,
				UserProductInfo = UserProductInfo,
				InterfaceProductInfo = InterfaceProductInfo,
				ProtocolInfo = ProtocolInfo,
				MacAddress = MacAddress,
				OneTimePassword = OneTimePassword,
				ClientIPAddress = ClientIPAddress,
				LoginRemark = LoginRemark,
			};
			return (loader.Invoke("ReqUserLogin", typeof(DeleReqUserLogin)) as DeleReqUserLogin)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqUserLogout(string BrokerID = "", string UserID = "")
		{
			CThostFtdcUserLogoutField struc = new CThostFtdcUserLogoutField
			{
				BrokerID = BrokerID,
				UserID = UserID,
			};
			return (loader.Invoke("ReqUserLogout", typeof(DeleReqUserLogout)) as DeleReqUserLogout)(_api, ref struc, this.nRequestID++);
		}

		#endregion
		delegate void DeleSet(IntPtr spi, Delegate func);

		public delegate void DeleOnFrontConnected();
		public void SetOnFrontConnected(DeleOnFrontConnected func) { (loader.Invoke("SetOnFrontConnected", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnFrontDisconnected(int nReason);
		public void SetOnFrontDisconnected(DeleOnFrontDisconnected func) { (loader.Invoke("SetOnFrontDisconnected", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnHeartBeatWarning(int nTimeLapse);
		public void SetOnHeartBeatWarning(DeleOnHeartBeatWarning func) { (loader.Invoke("SetOnHeartBeatWarning", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspUserLogin(ref CThostFtdcRspUserLoginField pRspUserLogin, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspUserLogin(DeleOnRspUserLogin func) { (loader.Invoke("SetOnRspUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspUserLogout(ref CThostFtdcUserLogoutField pUserLogout, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspUserLogout(DeleOnRspUserLogout func) { (loader.Invoke("SetOnRspUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspError(ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspError(DeleOnRspError func) { (loader.Invoke("SetOnRspError", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspSubMarketData(DeleOnRspSubMarketData func) { (loader.Invoke("SetOnRspSubMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspUnSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspUnSubMarketData(DeleOnRspUnSubMarketData func) { (loader.Invoke("SetOnRspUnSubMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspSubForQuoteRsp(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspSubForQuoteRsp(DeleOnRspSubForQuoteRsp func) { (loader.Invoke("SetOnRspSubForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspUnSubForQuoteRsp(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspUnSubForQuoteRsp(DeleOnRspUnSubForQuoteRsp func) { (loader.Invoke("SetOnRspUnSubForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData);
		public void SetOnRtnDepthMarketData(DeleOnRtnDepthMarketData func) { (loader.Invoke("SetOnRtnDepthMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnForQuoteRsp(ref CThostFtdcForQuoteRspField pForQuoteRsp);
		public void SetOnRtnForQuoteRsp(DeleOnRtnForQuoteRsp func) { (loader.Invoke("SetOnRtnForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func); }
	}
}