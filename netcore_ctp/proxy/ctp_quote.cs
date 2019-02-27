using System;
using System.IO;
using PureCode.CtpCSharp;

namespace HaiFeng
{
	public class CtpQuote
	{
		private readonly AssembyLoader loader;
	    private readonly IntPtr _api;
		private readonly IntPtr _spi;
	    private delegate IntPtr Create();
	    private delegate IntPtr DelegateRegisterSpi(IntPtr api, IntPtr pSpi);

		public CtpQuote(string pAbsoluteFilePath)
		{
		    loader = new AssembyLoader(pAbsoluteFilePath);
		    Directory.CreateDirectory("log");

		    _api = ((Create) loader.Invoke("CreateApi", typeof(Create)))();
		    _spi = ((Create) loader.Invoke("CreateSpi", typeof(Create)))();
		    (loader.Invoke("RegisterSpi", typeof(DelegateRegisterSpi)) as DelegateRegisterSpi)?.Invoke(_api, _spi);
		}


		#region 声明REQ函数类型

		public delegate IntPtr DelegateRelease(IntPtr api);
		public delegate IntPtr DelegateInit(IntPtr api);
		public delegate IntPtr DelegateJoin(IntPtr api);
		public delegate IntPtr DelegateGetTradingDay(IntPtr api);
		public delegate IntPtr DelegateRegisterFront(IntPtr api, string pszFrontAddress);
		public delegate IntPtr DelegateRegisterNameServer(IntPtr api, string pszNsAddress);
		public delegate IntPtr DelegateRegisterFensUserInfo(IntPtr api, ref CThostFtdcFensUserInfoField pFensUserInfo);
		public delegate IntPtr DeleSubscribeMarketData(IntPtr api, IntPtr pInstruments, int pCount);
		public delegate IntPtr DeleUnSubscribeMarketData(IntPtr api, IntPtr pInstruments, int pCount);
		public delegate IntPtr DeleSubscribeForQuoteRsp(IntPtr api, IntPtr pInstruments, int pCount);
		public delegate IntPtr DeleUnSubscribeForQuoteRsp(IntPtr api, IntPtr pInstruments, int pCount);
		public delegate IntPtr DelegateReqUserLogin(IntPtr api, ref CThostFtdcReqUserLoginField pReqUserLoginField, int nRequestId);
		public delegate IntPtr DelegateReqUserLogout(IntPtr api, ref CThostFtdcUserLogoutField pUserLogout, int nRequestId);

		#endregion


		#region REQ函数

		private int nRequestId;

		public IntPtr Release()
		{
			return ((DelegateRelease)loader.Invoke("Release", typeof(DelegateRelease)))(_api);
		}

		public IntPtr Init()
		{
			return ((DelegateInit)loader.Invoke("Init", typeof(DelegateInit)))(_api);
		}

		public IntPtr Join()
		{
			return ((DelegateJoin)loader.Invoke("Join", typeof(DelegateJoin)))(_api);
		}

		public IntPtr GetTradingDay()
		{
			return ((DelegateGetTradingDay)loader.Invoke("GetTradingDay", typeof(DelegateGetTradingDay)))(_api);
		}

		public IntPtr RegisterFront(string pszFrontAddress)
		{
			return ((DelegateRegisterFront)loader.Invoke("RegisterFront", typeof(DelegateRegisterFront)))(_api, pszFrontAddress);
		}

		public IntPtr RegisterNameServer(string pszNsAddress)
		{
			return ((DelegateRegisterNameServer)loader.Invoke("RegisterNameServer", typeof(DelegateRegisterNameServer)))(_api, pszNsAddress);
		}

		public IntPtr RegisterFensUserInfo(string brokerId = "", string userId = "", TThostFtdcLoginModeType loginMode = TThostFtdcLoginModeType.THOST_FTDC_LM_Trade)
		{
			CThostFtdcFensUserInfoField struc = new CThostFtdcFensUserInfoField
			{
				BrokerID = brokerId,
				UserID = userId,
				LoginMode = loginMode,
			};
			return ((DelegateRegisterFensUserInfo)loader.Invoke("RegisterFensUserInfo", typeof(DelegateRegisterFensUserInfo)))(_api, ref struc);
		}

		public IntPtr SubscribeMarketData(IntPtr pInstruments, int pCount)
		{
			return ((DeleSubscribeMarketData) loader.Invoke("SubscribeMarketData", typeof(DeleSubscribeMarketData)))(_api, pInstruments, pCount);
		}

		public IntPtr UnSubscribeMarketData(IntPtr pInstruments, int pCount)
		{
			return ((DeleUnSubscribeMarketData) loader.Invoke("UnSubscribeMarketData", typeof(DeleUnSubscribeMarketData)))(_api, pInstruments, pCount);
		}

		public IntPtr SubscribeForQuoteRsp(IntPtr pInstruments, int pCount)
		{
			return ((DeleSubscribeForQuoteRsp) loader.Invoke("SubscribeForQuoteRsp", typeof(DeleSubscribeForQuoteRsp)))(_api, pInstruments, pCount);
		}

		public IntPtr UnSubscribeForQuoteRsp(IntPtr pInstruments, int pCount)
		{
			return ((DeleUnSubscribeForQuoteRsp) loader.Invoke("UnSubscribeForQuoteRsp", typeof(DeleUnSubscribeForQuoteRsp)))(_api, pInstruments, pCount);
		}

		public IntPtr ReqUserLogin(string tradingDay = "", string brokerId = "", string userId = "", string password = "", string userProductInfo = "", string interfaceProductInfo = "", string protocolInfo = "", string macAddress = "", string oneTimePassword = "", string clientIPAddress = "", string loginRemark = "")
		{
			CThostFtdcReqUserLoginField struc = new CThostFtdcReqUserLoginField
			{
				TradingDay = tradingDay,
				BrokerID = brokerId,
				UserID = userId,
				Password = password,
				UserProductInfo = userProductInfo,
				InterfaceProductInfo = interfaceProductInfo,
				ProtocolInfo = protocolInfo,
				MacAddress = macAddress,
				OneTimePassword = oneTimePassword,
				ClientIPAddress = clientIPAddress,
				LoginRemark = loginRemark,
			};
			return ((DelegateReqUserLogin)loader.Invoke("ReqUserLogin", typeof(DelegateReqUserLogin)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqUserLogout(string brokerId = "", string userId = "")
		{
			CThostFtdcUserLogoutField struc = new CThostFtdcUserLogoutField
			{
				BrokerID = brokerId,
				UserID = userId,
			};
			return ((DelegateReqUserLogout)loader.Invoke("ReqUserLogout", typeof(DelegateReqUserLogout)))(_api, ref struc, nRequestId++);
		}

		#endregion

		delegate void DelegateSet(IntPtr spi, Delegate func);

		public delegate void DelegateOnFrontConnected();
		public void SetOnFrontConnected(DelegateOnFrontConnected func) { ((DelegateSet)loader.Invoke("SetOnFrontConnected", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnFrontDisconnected(int nReason);
		public void SetOnFrontDisconnected(DelegateOnFrontDisconnected func) { ((DelegateSet)loader.Invoke("SetOnFrontDisconnected", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnHeartBeatWarning(int nTimeLapse);
		public void SetOnHeartBeatWarning(DelegateOnHeartBeatWarning func) { ((DelegateSet)loader.Invoke("SetOnHeartBeatWarning", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspUserLogin(ref CThostFtdcRspUserLoginField pRspUserLogin, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspUserLogin(DelegateOnRspUserLogin func) { ((DelegateSet)loader.Invoke("SetOnRspUserLogin", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspUserLogout(ref CThostFtdcUserLogoutField pUserLogout, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspUserLogout(DelegateOnRspUserLogout func) { ((DelegateSet)loader.Invoke("SetOnRspUserLogout", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspError(ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspError(DelegateOnRspError func) { ((DelegateSet)loader.Invoke("SetOnRspError", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspSubMarketData(DelegateOnRspSubMarketData func) { ((DelegateSet)loader.Invoke("SetOnRspSubMarketData", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspUnSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspUnSubMarketData(DelegateOnRspUnSubMarketData func) { ((DelegateSet)loader.Invoke("SetOnRspUnSubMarketData", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspSubForQuoteRsp(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspSubForQuoteRsp(DelegateOnRspSubForQuoteRsp func) { ((DelegateSet)loader.Invoke("SetOnRspSubForQuoteRsp", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspUnSubForQuoteRsp(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspUnSubForQuoteRsp(DelegateOnRspUnSubForQuoteRsp func) { ((DelegateSet)loader.Invoke("SetOnRspUnSubForQuoteRsp", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData);
		public void SetOnRtnDepthMarketData(DelegateOnRtnDepthMarketData func) { ((DelegateSet)loader.Invoke("SetOnRtnDepthMarketData", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnForQuoteRsp(ref CThostFtdcForQuoteRspField pForQuoteRsp);
		public void SetOnRtnForQuoteRsp(DelegateOnRtnForQuoteRsp func) { ((DelegateSet)loader.Invoke("SetOnRtnForQuoteRsp", typeof(DelegateSet)))(_spi, func); }
	}
}