

using PureCode.CtpCSharp;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HaiFeng
{
	public class ctp_trade
	{
	    private AssembyLoader loader;
	    IntPtr _handle = IntPtr.Zero, _api = IntPtr.Zero, _spi = IntPtr.Zero;
	    delegate IntPtr Create();
	    delegate IntPtr DelegateRegisterSpi(IntPtr api, IntPtr pSpi);
		public ctp_trade(string pAbsoluteFilePath)
		{
		    loader = new AssembyLoader(pAbsoluteFilePath);
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
		public delegate IntPtr DeleRegisterFensUserInfo(IntPtr api, ref CThostFtdcFensUserInfoField pFensUserInfo);
		public delegate IntPtr DeleSubscribePrivateTopic(IntPtr api,ref THOST_TE_RESUME_TYPE nResumeType);
		public delegate IntPtr DeleSubscribePublicTopic(IntPtr api, ref THOST_TE_RESUME_TYPE nResumeType);
		public delegate IntPtr DeleReqAuthenticate(IntPtr api, ref CThostFtdcReqAuthenticateField pReqAuthenticateField, int nRequestID);
		public delegate IntPtr DeleReqUserLogin(IntPtr api, ref CThostFtdcReqUserLoginField pReqUserLoginField, int nRequestID);
		public delegate IntPtr DeleReqUserLogout(IntPtr api, ref CThostFtdcUserLogoutField pUserLogout, int nRequestID);
		public delegate IntPtr DeleReqUserPasswordUpdate(IntPtr api, ref CThostFtdcUserPasswordUpdateField pUserPasswordUpdate, int nRequestID);
		public delegate IntPtr DeleReqTradingAccountPasswordUpdate(IntPtr api, ref CThostFtdcTradingAccountPasswordUpdateField pTradingAccountPasswordUpdate, int nRequestID);
		public delegate IntPtr DeleReqUserLogin2(IntPtr api, ref CThostFtdcReqUserLoginField pReqUserLogin, int nRequestID);
		public delegate IntPtr DeleReqUserPasswordUpdate2(IntPtr api, ref CThostFtdcUserPasswordUpdateField pUserPasswordUpdate, int nRequestID);
		public delegate IntPtr DeleReqOrderInsert(IntPtr api, ref CThostFtdcInputOrderField pInputOrder, int nRequestID);
		public delegate IntPtr DeleReqParkedOrderInsert(IntPtr api, ref CThostFtdcParkedOrderField pParkedOrder, int nRequestID);
		public delegate IntPtr DeleReqParkedOrderAction(IntPtr api, ref CThostFtdcParkedOrderActionField pParkedOrderAction, int nRequestID);
		public delegate IntPtr DeleReqOrderAction(IntPtr api, ref CThostFtdcInputOrderActionField pInputOrderAction, int nRequestID);
		public delegate IntPtr DeleReqQueryMaxOrderVolume(IntPtr api, ref CThostFtdcQueryMaxOrderVolumeField pQueryMaxOrderVolume, int nRequestID);
		public delegate IntPtr DeleReqSettlementInfoConfirm(IntPtr api, ref CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, int nRequestID);
		public delegate IntPtr DeleReqRemoveParkedOrder(IntPtr api, ref CThostFtdcRemoveParkedOrderField pRemoveParkedOrder, int nRequestID);
		public delegate IntPtr DeleReqRemoveParkedOrderAction(IntPtr api, ref CThostFtdcRemoveParkedOrderActionField pRemoveParkedOrderAction, int nRequestID);
		public delegate IntPtr DeleReqExecOrderInsert(IntPtr api, ref CThostFtdcInputExecOrderField pInputExecOrder, int nRequestID);
		public delegate IntPtr DeleReqExecOrderAction(IntPtr api, ref CThostFtdcInputExecOrderActionField pInputExecOrderAction, int nRequestID);
		public delegate IntPtr DeleReqForQuoteInsert(IntPtr api, ref CThostFtdcInputForQuoteField pInputForQuote, int nRequestID);
		public delegate IntPtr DeleReqQuoteInsert(IntPtr api, ref CThostFtdcInputQuoteField pInputQuote, int nRequestID);
		public delegate IntPtr DeleReqQuoteAction(IntPtr api, ref CThostFtdcInputQuoteActionField pInputQuoteAction, int nRequestID);
		public delegate IntPtr DeleReqBatchOrderAction(IntPtr api, ref CThostFtdcInputBatchOrderActionField pInputBatchOrderAction, int nRequestID);
		public delegate IntPtr DeleReqOptionSelfCloseInsert(IntPtr api, ref CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose, int nRequestID);
		public delegate IntPtr DeleReqOptionSelfCloseAction(IntPtr api, ref CThostFtdcInputOptionSelfCloseActionField pInputOptionSelfCloseAction, int nRequestID);
		public delegate IntPtr DeleReqCombActionInsert(IntPtr api, ref CThostFtdcInputCombActionField pInputCombAction, int nRequestID);
		public delegate IntPtr DeleReqQryOrder(IntPtr api, ref CThostFtdcQryOrderField pQryOrder, int nRequestID);
		public delegate IntPtr DeleReqQryTrade(IntPtr api, ref CThostFtdcQryTradeField pQryTrade, int nRequestID);
		public delegate IntPtr DeleReqQryInvestorPosition(IntPtr api, ref CThostFtdcQryInvestorPositionField pQryInvestorPosition, int nRequestID);
		public delegate IntPtr DeleReqQryTradingAccount(IntPtr api, ref CThostFtdcQryTradingAccountField pQryTradingAccount, int nRequestID);
		public delegate IntPtr DeleReqQryInvestor(IntPtr api, ref CThostFtdcQryInvestorField pQryInvestor, int nRequestID);
		public delegate IntPtr DeleReqQryTradingCode(IntPtr api, ref CThostFtdcQryTradingCodeField pQryTradingCode, int nRequestID);
		public delegate IntPtr DeleReqQryInstrumentMarginRate(IntPtr api, ref CThostFtdcQryInstrumentMarginRateField pQryInstrumentMarginRate, int nRequestID);
		public delegate IntPtr DeleReqQryInstrumentCommissionRate(IntPtr api, ref CThostFtdcQryInstrumentCommissionRateField pQryInstrumentCommissionRate, int nRequestID);
		public delegate IntPtr DeleReqQryExchange(IntPtr api, ref CThostFtdcQryExchangeField pQryExchange, int nRequestID);
		public delegate IntPtr DeleReqQryProduct(IntPtr api, ref CThostFtdcQryProductField pQryProduct, int nRequestID);
		public delegate IntPtr DeleReqQryInstrument(IntPtr api, ref CThostFtdcQryInstrumentField pQryInstrument, int nRequestID);
		public delegate IntPtr DeleReqQryDepthMarketData(IntPtr api, ref CThostFtdcQryDepthMarketDataField pQryDepthMarketData, int nRequestID);
		public delegate IntPtr DeleReqQrySettlementInfo(IntPtr api, ref CThostFtdcQrySettlementInfoField pQrySettlementInfo, int nRequestID);
		public delegate IntPtr DeleReqQryTransferBank(IntPtr api, ref CThostFtdcQryTransferBankField pQryTransferBank, int nRequestID);
		public delegate IntPtr DeleReqQryInvestorPositionDetail(IntPtr api, ref CThostFtdcQryInvestorPositionDetailField pQryInvestorPositionDetail, int nRequestID);
		public delegate IntPtr DeleReqQryNotice(IntPtr api, ref CThostFtdcQryNoticeField pQryNotice, int nRequestID);
		public delegate IntPtr DeleReqQrySettlementInfoConfirm(IntPtr api, ref CThostFtdcQrySettlementInfoConfirmField pQrySettlementInfoConfirm, int nRequestID);
		public delegate IntPtr DeleReqQryInvestorPositionCombineDetail(IntPtr api, ref CThostFtdcQryInvestorPositionCombineDetailField pQryInvestorPositionCombineDetail, int nRequestID);
		public delegate IntPtr DeleReqQryCFMMCTradingAccountKey(IntPtr api, ref CThostFtdcQryCFMMCTradingAccountKeyField pQryCFMMCTradingAccountKey, int nRequestID);
		public delegate IntPtr DeleReqQryEWarrantOffset(IntPtr api, ref CThostFtdcQryEWarrantOffsetField pQryEWarrantOffset, int nRequestID);
		public delegate IntPtr DeleReqQryInvestorProductGroupMargin(IntPtr api, ref CThostFtdcQryInvestorProductGroupMarginField pQryInvestorProductGroupMargin, int nRequestID);
		public delegate IntPtr DeleReqQryExchangeMarginRate(IntPtr api, ref CThostFtdcQryExchangeMarginRateField pQryExchangeMarginRate, int nRequestID);
		public delegate IntPtr DeleReqQryExchangeMarginRateAdjust(IntPtr api, ref CThostFtdcQryExchangeMarginRateAdjustField pQryExchangeMarginRateAdjust, int nRequestID);
		public delegate IntPtr DeleReqQryExchangeRate(IntPtr api, ref CThostFtdcQryExchangeRateField pQryExchangeRate, int nRequestID);
		public delegate IntPtr DeleReqQrySecAgentACIDMap(IntPtr api, ref CThostFtdcQrySecAgentACIDMapField pQrySecAgentACIDMap, int nRequestID);
		public delegate IntPtr DeleReqQryProductExchRate(IntPtr api, ref CThostFtdcQryProductExchRateField pQryProductExchRate, int nRequestID);
		public delegate IntPtr DeleReqQryProductGroup(IntPtr api, ref CThostFtdcQryProductGroupField pQryProductGroup, int nRequestID);
		public delegate IntPtr DeleReqQryMMInstrumentCommissionRate(IntPtr api, ref CThostFtdcQryMMInstrumentCommissionRateField pQryMMInstrumentCommissionRate, int nRequestID);
		public delegate IntPtr DeleReqQryMMOptionInstrCommRate(IntPtr api, ref CThostFtdcQryMMOptionInstrCommRateField pQryMMOptionInstrCommRate, int nRequestID);
		public delegate IntPtr DeleReqQryInstrumentOrderCommRate(IntPtr api, ref CThostFtdcQryInstrumentOrderCommRateField pQryInstrumentOrderCommRate, int nRequestID);
		public delegate IntPtr DeleReqQrySecAgentTradingAccount(IntPtr api, ref CThostFtdcQryTradingAccountField pQryTradingAccount, int nRequestID);
		public delegate IntPtr DeleReqQrySecAgentCheckMode(IntPtr api, ref CThostFtdcQrySecAgentCheckModeField pQrySecAgentCheckMode, int nRequestID);
		public delegate IntPtr DeleReqQryOptionInstrTradeCost(IntPtr api, ref CThostFtdcQryOptionInstrTradeCostField pQryOptionInstrTradeCost, int nRequestID);
		public delegate IntPtr DeleReqQryOptionInstrCommRate(IntPtr api, ref CThostFtdcQryOptionInstrCommRateField pQryOptionInstrCommRate, int nRequestID);
		public delegate IntPtr DeleReqQryExecOrder(IntPtr api, ref CThostFtdcQryExecOrderField pQryExecOrder, int nRequestID);
		public delegate IntPtr DeleReqQryForQuote(IntPtr api, ref CThostFtdcQryForQuoteField pQryForQuote, int nRequestID);
		public delegate IntPtr DeleReqQryQuote(IntPtr api, ref CThostFtdcQryQuoteField pQryQuote, int nRequestID);
		public delegate IntPtr DeleReqQryOptionSelfClose(IntPtr api, ref CThostFtdcQryOptionSelfCloseField pQryOptionSelfClose, int nRequestID);
		public delegate IntPtr DeleReqQryInvestUnit(IntPtr api, ref CThostFtdcQryInvestUnitField pQryInvestUnit, int nRequestID);
		public delegate IntPtr DeleReqQryCombInstrumentGuard(IntPtr api, ref CThostFtdcQryCombInstrumentGuardField pQryCombInstrumentGuard, int nRequestID);
		public delegate IntPtr DeleReqQryCombAction(IntPtr api, ref CThostFtdcQryCombActionField pQryCombAction, int nRequestID);
		public delegate IntPtr DeleReqQryTransferSerial(IntPtr api, ref CThostFtdcQryTransferSerialField pQryTransferSerial, int nRequestID);
		public delegate IntPtr DeleReqQryAccountregister(IntPtr api, ref CThostFtdcQryAccountregisterField pQryAccountregister, int nRequestID);
		public delegate IntPtr DeleReqQryContractBank(IntPtr api, ref CThostFtdcQryContractBankField pQryContractBank, int nRequestID);
		public delegate IntPtr DeleReqQryParkedOrder(IntPtr api, ref CThostFtdcQryParkedOrderField pQryParkedOrder, int nRequestID);
		public delegate IntPtr DeleReqQryParkedOrderAction(IntPtr api, ref CThostFtdcQryParkedOrderActionField pQryParkedOrderAction, int nRequestID);
		public delegate IntPtr DeleReqQryTradingNotice(IntPtr api, ref CThostFtdcQryTradingNoticeField pQryTradingNotice, int nRequestID);
		public delegate IntPtr DeleReqQryBrokerTradingParams(IntPtr api, ref CThostFtdcQryBrokerTradingParamsField pQryBrokerTradingParams, int nRequestID);
		public delegate IntPtr DeleReqQryBrokerTradingAlgos(IntPtr api, ref CThostFtdcQryBrokerTradingAlgosField pQryBrokerTradingAlgos, int nRequestID);
		public delegate IntPtr DeleReqQueryCFMMCTradingAccountToken(IntPtr api, ref CThostFtdcQueryCFMMCTradingAccountTokenField pQueryCFMMCTradingAccountToken, int nRequestID);
		public delegate IntPtr DeleReqFromBankToFutureByFuture(IntPtr api, ref CThostFtdcReqTransferField pReqTransfer, int nRequestID);
		public delegate IntPtr DeleReqFromFutureToBankByFuture(IntPtr api, ref CThostFtdcReqTransferField pReqTransfer, int nRequestID);
		public delegate IntPtr DeleReqQueryBankAccountMoneyByFuture(IntPtr api, ref CThostFtdcReqQueryAccountField pReqQueryAccount, int nRequestID);

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

		public IntPtr SubscribePrivateTopic(THOST_TE_RESUME_TYPE nResumeType)
		{
			return (loader.Invoke("SubscribePrivateTopic", typeof(DeleSubscribePrivateTopic)) as DeleSubscribePrivateTopic)(_api, ref nResumeType);
		}

		public IntPtr SubscribePublicTopic(THOST_TE_RESUME_TYPE nResumeType)
		{
			return (loader.Invoke("SubscribePublicTopic", typeof(DeleSubscribePublicTopic)) as DeleSubscribePublicTopic)(_api, ref nResumeType);
		}

		public IntPtr ReqAuthenticate(string BrokerID = "", string UserID = "", string UserProductInfo = "", string AuthCode = "")
		{
			CThostFtdcReqAuthenticateField struc = new CThostFtdcReqAuthenticateField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				UserProductInfo = UserProductInfo,
				AuthCode = AuthCode,
			};
			return (loader.Invoke("ReqAuthenticate", typeof(DeleReqAuthenticate)) as DeleReqAuthenticate)(_api, ref struc, this.nRequestID++);
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

		public IntPtr ReqUserPasswordUpdate(string BrokerID = "", string UserID = "", string OldPassword = "", string NewPassword = "")
		{
			CThostFtdcUserPasswordUpdateField struc = new CThostFtdcUserPasswordUpdateField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				OldPassword = OldPassword,
				NewPassword = NewPassword,
			};
			return (loader.Invoke("ReqUserPasswordUpdate", typeof(DeleReqUserPasswordUpdate)) as DeleReqUserPasswordUpdate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqTradingAccountPasswordUpdate(string BrokerID = "", string AccountID = "", string OldPassword = "", string NewPassword = "", string CurrencyID = "")
		{
			CThostFtdcTradingAccountPasswordUpdateField struc = new CThostFtdcTradingAccountPasswordUpdateField
			{
				BrokerID = BrokerID,
				AccountID = AccountID,
				OldPassword = OldPassword,
				NewPassword = NewPassword,
				CurrencyID = CurrencyID,
			};
			return (loader.Invoke("ReqTradingAccountPasswordUpdate", typeof(DeleReqTradingAccountPasswordUpdate)) as DeleReqTradingAccountPasswordUpdate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqUserLogin2(string TradingDay = "", string BrokerID = "", string UserID = "", string Password = "", string UserProductInfo = "", string InterfaceProductInfo = "", string ProtocolInfo = "", string MacAddress = "", string OneTimePassword = "", string ClientIPAddress = "", string LoginRemark = "")
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
			return (loader.Invoke("ReqUserLogin2", typeof(DeleReqUserLogin2)) as DeleReqUserLogin2)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqUserPasswordUpdate2(string BrokerID = "", string UserID = "", string OldPassword = "", string NewPassword = "")
		{
			CThostFtdcUserPasswordUpdateField struc = new CThostFtdcUserPasswordUpdateField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				OldPassword = OldPassword,
				NewPassword = NewPassword,
			};
			return (loader.Invoke("ReqUserPasswordUpdate2", typeof(DeleReqUserPasswordUpdate2)) as DeleReqUserPasswordUpdate2)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqOrderInsert(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string OrderRef = "", string UserID = "", TThostFtdcOrderPriceTypeType OrderPriceType = TThostFtdcOrderPriceTypeType.THOST_FTDC_OPT_AnyPrice, TThostFtdcDirectionType Direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy, string CombOffsetFlag = "", string CombHedgeFlag = "", double LimitPrice = 0, int VolumeTotalOriginal = 0, TThostFtdcTimeConditionType TimeCondition = TThostFtdcTimeConditionType.THOST_FTDC_TC_IOC, string GTDDate = "", TThostFtdcVolumeConditionType VolumeCondition = TThostFtdcVolumeConditionType.THOST_FTDC_VC_AV, int MinVolume = 0, TThostFtdcContingentConditionType ContingentCondition = TThostFtdcContingentConditionType.THOST_FTDC_CC_Immediately, double StopPrice = 0, TThostFtdcForceCloseReasonType ForceCloseReason = TThostFtdcForceCloseReasonType.THOST_FTDC_FCC_NotForceClose, int IsAutoSuspend = 0, string BusinessUnit = "", int RequestID = 0, int UserForceClose = 0, int IsSwapOrder = 0, string ExchangeID = "", string InvestUnitID = "", string AccountID = "", string CurrencyID = "", string ClientID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputOrderField struc = new CThostFtdcInputOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				OrderRef = OrderRef,
				UserID = UserID,
				OrderPriceType = OrderPriceType,
				Direction = Direction,
				CombOffsetFlag = CombOffsetFlag,
				CombHedgeFlag = CombHedgeFlag,				LimitPrice = LimitPrice,
				VolumeTotalOriginal = VolumeTotalOriginal,

				TimeCondition = TimeCondition,
				GTDDate = GTDDate,
				VolumeCondition = VolumeCondition,				MinVolume = MinVolume,

				ContingentCondition = ContingentCondition,				StopPrice = StopPrice,

				ForceCloseReason = ForceCloseReason,				IsAutoSuspend = IsAutoSuspend,

				BusinessUnit = BusinessUnit,				RequestID = RequestID,
				UserForceClose = UserForceClose,
				IsSwapOrder = IsSwapOrder,

				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
				ClientID = ClientID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqOrderInsert", typeof(DeleReqOrderInsert)) as DeleReqOrderInsert)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqParkedOrderInsert(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string OrderRef = "", string UserID = "", TThostFtdcOrderPriceTypeType OrderPriceType = TThostFtdcOrderPriceTypeType.THOST_FTDC_OPT_AnyPrice, TThostFtdcDirectionType Direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy, string CombOffsetFlag = "", string CombHedgeFlag = "", double LimitPrice = 0, int VolumeTotalOriginal = 0, TThostFtdcTimeConditionType TimeCondition = TThostFtdcTimeConditionType.THOST_FTDC_TC_IOC, string GTDDate = "", TThostFtdcVolumeConditionType VolumeCondition = TThostFtdcVolumeConditionType.THOST_FTDC_VC_AV, int MinVolume = 0, TThostFtdcContingentConditionType ContingentCondition = TThostFtdcContingentConditionType.THOST_FTDC_CC_Immediately, double StopPrice = 0, TThostFtdcForceCloseReasonType ForceCloseReason = TThostFtdcForceCloseReasonType.THOST_FTDC_FCC_NotForceClose, int IsAutoSuspend = 0, string BusinessUnit = "", int RequestID = 0, int UserForceClose = 0, string ExchangeID = "", string ParkedOrderID = "", TThostFtdcUserTypeType UserType = TThostFtdcUserTypeType.THOST_FTDC_UT_Investor, TThostFtdcParkedOrderStatusType Status = TThostFtdcParkedOrderStatusType.THOST_FTDC_PAOS_NotSend, int ErrorID = 0, string ErrorMsg = "", int IsSwapOrder = 0, string AccountID = "", string CurrencyID = "", string ClientID = "", string InvestUnitID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcParkedOrderField struc = new CThostFtdcParkedOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				OrderRef = OrderRef,
				UserID = UserID,
				OrderPriceType = OrderPriceType,
				Direction = Direction,
				CombOffsetFlag = CombOffsetFlag,
				CombHedgeFlag = CombHedgeFlag,				LimitPrice = LimitPrice,
				VolumeTotalOriginal = VolumeTotalOriginal,

				TimeCondition = TimeCondition,
				GTDDate = GTDDate,
				VolumeCondition = VolumeCondition,				MinVolume = MinVolume,

				ContingentCondition = ContingentCondition,				StopPrice = StopPrice,

				ForceCloseReason = ForceCloseReason,				IsAutoSuspend = IsAutoSuspend,

				BusinessUnit = BusinessUnit,				RequestID = RequestID,
				UserForceClose = UserForceClose,

				ExchangeID = ExchangeID,
				ParkedOrderID = ParkedOrderID,
				UserType = UserType,
				Status = Status,				ErrorID = ErrorID,

				ErrorMsg = ErrorMsg,				IsSwapOrder = IsSwapOrder,

				AccountID = AccountID,
				CurrencyID = CurrencyID,
				ClientID = ClientID,
				InvestUnitID = InvestUnitID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqParkedOrderInsert", typeof(DeleReqParkedOrderInsert)) as DeleReqParkedOrderInsert)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqParkedOrderAction(string BrokerID = "", string InvestorID = "", int OrderActionRef = 0, string OrderRef = "", int RequestID = 0, int FrontID = 0, int SessionID = 0, string ExchangeID = "", string OrderSysID = "", TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, double LimitPrice = 0, int VolumeChange = 0, string UserID = "", string InstrumentID = "", string ParkedOrderActionID = "", TThostFtdcUserTypeType UserType = TThostFtdcUserTypeType.THOST_FTDC_UT_Investor, TThostFtdcParkedOrderStatusType Status = TThostFtdcParkedOrderStatusType.THOST_FTDC_PAOS_NotSend, int ErrorID = 0, string ErrorMsg = "", string InvestUnitID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcParkedOrderActionField struc = new CThostFtdcParkedOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,				OrderActionRef = OrderActionRef,

				OrderRef = OrderRef,				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,

				ExchangeID = ExchangeID,
				OrderSysID = OrderSysID,
				ActionFlag = ActionFlag,				LimitPrice = LimitPrice,
				VolumeChange = VolumeChange,

				UserID = UserID,
				InstrumentID = InstrumentID,
				ParkedOrderActionID = ParkedOrderActionID,
				UserType = UserType,
				Status = Status,				ErrorID = ErrorID,

				ErrorMsg = ErrorMsg,
				InvestUnitID = InvestUnitID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqParkedOrderAction", typeof(DeleReqParkedOrderAction)) as DeleReqParkedOrderAction)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqOrderAction(string BrokerID = "", string InvestorID = "", int OrderActionRef = 0, string OrderRef = "", int RequestID = 0, int FrontID = 0, int SessionID = 0, string ExchangeID = "", string OrderSysID = "", TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, double LimitPrice = 0, int VolumeChange = 0, string UserID = "", string InstrumentID = "", string InvestUnitID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputOrderActionField struc = new CThostFtdcInputOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,				OrderActionRef = OrderActionRef,

				OrderRef = OrderRef,				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,

				ExchangeID = ExchangeID,
				OrderSysID = OrderSysID,
				ActionFlag = ActionFlag,				LimitPrice = LimitPrice,
				VolumeChange = VolumeChange,

				UserID = UserID,
				InstrumentID = InstrumentID,
				InvestUnitID = InvestUnitID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqOrderAction", typeof(DeleReqOrderAction)) as DeleReqOrderAction)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQueryMaxOrderVolume(string BrokerID = "", string InvestorID = "", string InstrumentID = "", TThostFtdcDirectionType Direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy, TThostFtdcOffsetFlagType OffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open, TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, int MaxVolume = 0, string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQueryMaxOrderVolumeField struc = new CThostFtdcQueryMaxOrderVolumeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				Direction = Direction,
				OffsetFlag = OffsetFlag,
				HedgeFlag = HedgeFlag,				MaxVolume = MaxVolume,

				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQueryMaxOrderVolume", typeof(DeleReqQueryMaxOrderVolume)) as DeleReqQueryMaxOrderVolume)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqSettlementInfoConfirm(string BrokerID = "", string InvestorID = "", string ConfirmDate = "", string ConfirmTime = "", int SettlementID = 0, string AccountID = "", string CurrencyID = "")
		{
			CThostFtdcSettlementInfoConfirmField struc = new CThostFtdcSettlementInfoConfirmField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ConfirmDate = ConfirmDate,
				ConfirmTime = ConfirmTime,				SettlementID = SettlementID,

				AccountID = AccountID,
				CurrencyID = CurrencyID,
			};
			return (loader.Invoke("ReqSettlementInfoConfirm", typeof(DeleReqSettlementInfoConfirm)) as DeleReqSettlementInfoConfirm)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqRemoveParkedOrder(string BrokerID = "", string InvestorID = "", string ParkedOrderID = "", string InvestUnitID = "")
		{
			CThostFtdcRemoveParkedOrderField struc = new CThostFtdcRemoveParkedOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ParkedOrderID = ParkedOrderID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqRemoveParkedOrder", typeof(DeleReqRemoveParkedOrder)) as DeleReqRemoveParkedOrder)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqRemoveParkedOrderAction(string BrokerID = "", string InvestorID = "", string ParkedOrderActionID = "", string InvestUnitID = "")
		{
			CThostFtdcRemoveParkedOrderActionField struc = new CThostFtdcRemoveParkedOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ParkedOrderActionID = ParkedOrderActionID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqRemoveParkedOrderAction", typeof(DeleReqRemoveParkedOrderAction)) as DeleReqRemoveParkedOrderAction)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqExecOrderInsert(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExecOrderRef = "", string UserID = "", int Volume = 0, int RequestID = 0, string BusinessUnit = "", TThostFtdcOffsetFlagType OffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open, TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, TThostFtdcActionTypeType ActionType = TThostFtdcActionTypeType.THOST_FTDC_ACTP_Exec, TThostFtdcPosiDirectionType PosiDirection = TThostFtdcPosiDirectionType.THOST_FTDC_PD_Net, TThostFtdcExecOrderPositionFlagType ReservePositionFlag = TThostFtdcExecOrderPositionFlagType.THOST_FTDC_EOPF_Reserve, TThostFtdcExecOrderCloseFlagType CloseFlag = TThostFtdcExecOrderCloseFlagType.THOST_FTDC_EOCF_AutoClose, string ExchangeID = "", string InvestUnitID = "", string AccountID = "", string CurrencyID = "", string ClientID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputExecOrderField struc = new CThostFtdcInputExecOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExecOrderRef = ExecOrderRef,
				UserID = UserID,				Volume = Volume,
				RequestID = RequestID,

				BusinessUnit = BusinessUnit,
				OffsetFlag = OffsetFlag,
				HedgeFlag = HedgeFlag,
				ActionType = ActionType,
				PosiDirection = PosiDirection,
				ReservePositionFlag = ReservePositionFlag,
				CloseFlag = CloseFlag,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
				ClientID = ClientID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqExecOrderInsert", typeof(DeleReqExecOrderInsert)) as DeleReqExecOrderInsert)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqExecOrderAction(string BrokerID = "", string InvestorID = "", int ExecOrderActionRef = 0, string ExecOrderRef = "", int RequestID = 0, int FrontID = 0, int SessionID = 0, string ExchangeID = "", string ExecOrderSysID = "", TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, string UserID = "", string InstrumentID = "", string InvestUnitID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputExecOrderActionField struc = new CThostFtdcInputExecOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,				ExecOrderActionRef = ExecOrderActionRef,

				ExecOrderRef = ExecOrderRef,				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,

				ExchangeID = ExchangeID,
				ExecOrderSysID = ExecOrderSysID,
				ActionFlag = ActionFlag,
				UserID = UserID,
				InstrumentID = InstrumentID,
				InvestUnitID = InvestUnitID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqExecOrderAction", typeof(DeleReqExecOrderAction)) as DeleReqExecOrderAction)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqForQuoteInsert(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ForQuoteRef = "", string UserID = "", string ExchangeID = "", string InvestUnitID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputForQuoteField struc = new CThostFtdcInputForQuoteField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ForQuoteRef = ForQuoteRef,
				UserID = UserID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqForQuoteInsert", typeof(DeleReqForQuoteInsert)) as DeleReqForQuoteInsert)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQuoteInsert(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string QuoteRef = "", string UserID = "", double AskPrice = 0, double BidPrice = 0, int AskVolume = 0, int BidVolume = 0, int RequestID = 0, string BusinessUnit = "", TThostFtdcOffsetFlagType AskOffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open, TThostFtdcOffsetFlagType BidOffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open, TThostFtdcHedgeFlagType AskHedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, TThostFtdcHedgeFlagType BidHedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string AskOrderRef = "", string BidOrderRef = "", string ForQuoteSysID = "", string ExchangeID = "", string InvestUnitID = "", string ClientID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputQuoteField struc = new CThostFtdcInputQuoteField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				QuoteRef = QuoteRef,
				UserID = UserID,				AskPrice = AskPrice,
				BidPrice = BidPrice,
				AskVolume = AskVolume,
				BidVolume = BidVolume,
				RequestID = RequestID,

				BusinessUnit = BusinessUnit,
				AskOffsetFlag = AskOffsetFlag,
				BidOffsetFlag = BidOffsetFlag,
				AskHedgeFlag = AskHedgeFlag,
				BidHedgeFlag = BidHedgeFlag,
				AskOrderRef = AskOrderRef,
				BidOrderRef = BidOrderRef,
				ForQuoteSysID = ForQuoteSysID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				ClientID = ClientID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqQuoteInsert", typeof(DeleReqQuoteInsert)) as DeleReqQuoteInsert)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQuoteAction(string BrokerID = "", string InvestorID = "", int QuoteActionRef = 0, string QuoteRef = "", int RequestID = 0, int FrontID = 0, int SessionID = 0, string ExchangeID = "", string QuoteSysID = "", TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, string UserID = "", string InstrumentID = "", string InvestUnitID = "", string ClientID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputQuoteActionField struc = new CThostFtdcInputQuoteActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,				QuoteActionRef = QuoteActionRef,

				QuoteRef = QuoteRef,				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,

				ExchangeID = ExchangeID,
				QuoteSysID = QuoteSysID,
				ActionFlag = ActionFlag,
				UserID = UserID,
				InstrumentID = InstrumentID,
				InvestUnitID = InvestUnitID,
				ClientID = ClientID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqQuoteAction", typeof(DeleReqQuoteAction)) as DeleReqQuoteAction)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqBatchOrderAction(string BrokerID = "", string InvestorID = "", int OrderActionRef = 0, int RequestID = 0, int FrontID = 0, int SessionID = 0, string ExchangeID = "", string UserID = "", string InvestUnitID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputBatchOrderActionField struc = new CThostFtdcInputBatchOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,				OrderActionRef = OrderActionRef,
				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,

				ExchangeID = ExchangeID,
				UserID = UserID,
				InvestUnitID = InvestUnitID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqBatchOrderAction", typeof(DeleReqBatchOrderAction)) as DeleReqBatchOrderAction)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqOptionSelfCloseInsert(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string OptionSelfCloseRef = "", string UserID = "", int Volume = 0, int RequestID = 0, string BusinessUnit = "", TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, TThostFtdcOptSelfCloseFlagType OptSelfCloseFlag = TThostFtdcOptSelfCloseFlagType.THOST_FTDC_OSCF_CloseSelfOptionPosition, string ExchangeID = "", string InvestUnitID = "", string AccountID = "", string CurrencyID = "", string ClientID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputOptionSelfCloseField struc = new CThostFtdcInputOptionSelfCloseField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				OptionSelfCloseRef = OptionSelfCloseRef,
				UserID = UserID,				Volume = Volume,
				RequestID = RequestID,

				BusinessUnit = BusinessUnit,
				HedgeFlag = HedgeFlag,
				OptSelfCloseFlag = OptSelfCloseFlag,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
				ClientID = ClientID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqOptionSelfCloseInsert", typeof(DeleReqOptionSelfCloseInsert)) as DeleReqOptionSelfCloseInsert)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqOptionSelfCloseAction(string BrokerID = "", string InvestorID = "", int OptionSelfCloseActionRef = 0, string OptionSelfCloseRef = "", int RequestID = 0, int FrontID = 0, int SessionID = 0, string ExchangeID = "", string OptionSelfCloseSysID = "", TThostFtdcActionFlagType ActionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, string UserID = "", string InstrumentID = "", string InvestUnitID = "", string IPAddress = "", string MacAddress = "")
		{
			CThostFtdcInputOptionSelfCloseActionField struc = new CThostFtdcInputOptionSelfCloseActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,				OptionSelfCloseActionRef = OptionSelfCloseActionRef,

				OptionSelfCloseRef = OptionSelfCloseRef,				RequestID = RequestID,
				FrontID = FrontID,
				SessionID = SessionID,

				ExchangeID = ExchangeID,
				OptionSelfCloseSysID = OptionSelfCloseSysID,
				ActionFlag = ActionFlag,
				UserID = UserID,
				InstrumentID = InstrumentID,
				InvestUnitID = InvestUnitID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
			};
			return (loader.Invoke("ReqOptionSelfCloseAction", typeof(DeleReqOptionSelfCloseAction)) as DeleReqOptionSelfCloseAction)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqCombActionInsert(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string CombActionRef = "", string UserID = "", TThostFtdcDirectionType Direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy, int Volume = 0, TThostFtdcCombDirectionType CombDirection = TThostFtdcCombDirectionType.THOST_FTDC_CMDR_Comb, TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string ExchangeID = "", string IPAddress = "", string MacAddress = "", string InvestUnitID = "")
		{
			CThostFtdcInputCombActionField struc = new CThostFtdcInputCombActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				CombActionRef = CombActionRef,
				UserID = UserID,
				Direction = Direction,				Volume = Volume,

				CombDirection = CombDirection,
				HedgeFlag = HedgeFlag,
				ExchangeID = ExchangeID,
				IPAddress = IPAddress,
				MacAddress = MacAddress,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqCombActionInsert", typeof(DeleReqCombActionInsert)) as DeleReqCombActionInsert)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryOrder(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string OrderSysID = "", string InsertTimeStart = "", string InsertTimeEnd = "", string InvestUnitID = "")
		{
			CThostFtdcQryOrderField struc = new CThostFtdcQryOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				OrderSysID = OrderSysID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryOrder", typeof(DeleReqQryOrder)) as DeleReqQryOrder)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryTrade(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string TradeID = "", string TradeTimeStart = "", string TradeTimeEnd = "", string InvestUnitID = "")
		{
			CThostFtdcQryTradeField struc = new CThostFtdcQryTradeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				TradeID = TradeID,
				TradeTimeStart = TradeTimeStart,
				TradeTimeEnd = TradeTimeEnd,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryTrade", typeof(DeleReqQryTrade)) as DeleReqQryTrade)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInvestorPosition(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryInvestorPositionField struc = new CThostFtdcQryInvestorPositionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryInvestorPosition", typeof(DeleReqQryInvestorPosition)) as DeleReqQryInvestorPosition)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryTradingAccount(string BrokerID = "", string InvestorID = "", string CurrencyID = "", TThostFtdcBizTypeType BizType = TThostFtdcBizTypeType.THOST_FTDC_BZTP_Future, string AccountID = "")
		{
			CThostFtdcQryTradingAccountField struc = new CThostFtdcQryTradingAccountField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				CurrencyID = CurrencyID,
				BizType = BizType,
				AccountID = AccountID,
			};
			return (loader.Invoke("ReqQryTradingAccount", typeof(DeleReqQryTradingAccount)) as DeleReqQryTradingAccount)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInvestor(string BrokerID = "", string InvestorID = "")
		{
			CThostFtdcQryInvestorField struc = new CThostFtdcQryInvestorField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
			};
			return (loader.Invoke("ReqQryInvestor", typeof(DeleReqQryInvestor)) as DeleReqQryInvestor)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryTradingCode(string BrokerID = "", string InvestorID = "", string ExchangeID = "", string ClientID = "", TThostFtdcClientIDTypeType ClientIDType = TThostFtdcClientIDTypeType.THOST_FTDC_CIDT_Speculation, string InvestUnitID = "")
		{
			CThostFtdcQryTradingCodeField struc = new CThostFtdcQryTradingCodeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ExchangeID = ExchangeID,
				ClientID = ClientID,
				ClientIDType = ClientIDType,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryTradingCode", typeof(DeleReqQryTradingCode)) as DeleReqQryTradingCode)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInstrumentMarginRate(string BrokerID = "", string InvestorID = "", string InstrumentID = "", TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryInstrumentMarginRateField struc = new CThostFtdcQryInstrumentMarginRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				HedgeFlag = HedgeFlag,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryInstrumentMarginRate", typeof(DeleReqQryInstrumentMarginRate)) as DeleReqQryInstrumentMarginRate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInstrumentCommissionRate(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryInstrumentCommissionRateField struc = new CThostFtdcQryInstrumentCommissionRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryInstrumentCommissionRate", typeof(DeleReqQryInstrumentCommissionRate)) as DeleReqQryInstrumentCommissionRate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryExchange(string ExchangeID = "")
		{
			CThostFtdcQryExchangeField struc = new CThostFtdcQryExchangeField
			{
				ExchangeID = ExchangeID,
			};
			return (loader.Invoke("ReqQryExchange", typeof(DeleReqQryExchange)) as DeleReqQryExchange)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryProduct(string ProductID = "", TThostFtdcProductClassType ProductClass = TThostFtdcProductClassType.THOST_FTDC_PC_Futures, string ExchangeID = "")
		{
			CThostFtdcQryProductField struc = new CThostFtdcQryProductField
			{
				ProductID = ProductID,
				ProductClass = ProductClass,
				ExchangeID = ExchangeID,
			};
			return (loader.Invoke("ReqQryProduct", typeof(DeleReqQryProduct)) as DeleReqQryProduct)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInstrument(string InstrumentID = "", string ExchangeID = "", string ExchangeInstID = "", string ProductID = "")
		{
			CThostFtdcQryInstrumentField struc = new CThostFtdcQryInstrumentField
			{
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				ExchangeInstID = ExchangeInstID,
				ProductID = ProductID,
			};
			return (loader.Invoke("ReqQryInstrument", typeof(DeleReqQryInstrument)) as DeleReqQryInstrument)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryDepthMarketData(string InstrumentID = "", string ExchangeID = "")
		{
			CThostFtdcQryDepthMarketDataField struc = new CThostFtdcQryDepthMarketDataField
			{
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
			};
			return (loader.Invoke("ReqQryDepthMarketData", typeof(DeleReqQryDepthMarketData)) as DeleReqQryDepthMarketData)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQrySettlementInfo(string BrokerID = "", string InvestorID = "", string TradingDay = "", string AccountID = "", string CurrencyID = "")
		{
			CThostFtdcQrySettlementInfoField struc = new CThostFtdcQrySettlementInfoField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				TradingDay = TradingDay,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
			};
			return (loader.Invoke("ReqQrySettlementInfo", typeof(DeleReqQrySettlementInfo)) as DeleReqQrySettlementInfo)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryTransferBank(string BankID = "", string BankBrchID = "")
		{
			CThostFtdcQryTransferBankField struc = new CThostFtdcQryTransferBankField
			{
				BankID = BankID,
				BankBrchID = BankBrchID,
			};
			return (loader.Invoke("ReqQryTransferBank", typeof(DeleReqQryTransferBank)) as DeleReqQryTransferBank)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInvestorPositionDetail(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryInvestorPositionDetailField struc = new CThostFtdcQryInvestorPositionDetailField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryInvestorPositionDetail", typeof(DeleReqQryInvestorPositionDetail)) as DeleReqQryInvestorPositionDetail)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryNotice(string BrokerID = "")
		{
			CThostFtdcQryNoticeField struc = new CThostFtdcQryNoticeField
			{
				BrokerID = BrokerID,
			};
			return (loader.Invoke("ReqQryNotice", typeof(DeleReqQryNotice)) as DeleReqQryNotice)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQrySettlementInfoConfirm(string BrokerID = "", string InvestorID = "", string AccountID = "", string CurrencyID = "")
		{
			CThostFtdcQrySettlementInfoConfirmField struc = new CThostFtdcQrySettlementInfoConfirmField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
			};
			return (loader.Invoke("ReqQrySettlementInfoConfirm", typeof(DeleReqQrySettlementInfoConfirm)) as DeleReqQrySettlementInfoConfirm)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInvestorPositionCombineDetail(string BrokerID = "", string InvestorID = "", string CombInstrumentID = "", string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryInvestorPositionCombineDetailField struc = new CThostFtdcQryInvestorPositionCombineDetailField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				CombInstrumentID = CombInstrumentID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryInvestorPositionCombineDetail", typeof(DeleReqQryInvestorPositionCombineDetail)) as DeleReqQryInvestorPositionCombineDetail)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryCFMMCTradingAccountKey(string BrokerID = "", string InvestorID = "")
		{
			CThostFtdcQryCFMMCTradingAccountKeyField struc = new CThostFtdcQryCFMMCTradingAccountKeyField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
			};
			return (loader.Invoke("ReqQryCFMMCTradingAccountKey", typeof(DeleReqQryCFMMCTradingAccountKey)) as DeleReqQryCFMMCTradingAccountKey)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryEWarrantOffset(string BrokerID = "", string InvestorID = "", string ExchangeID = "", string InstrumentID = "", string InvestUnitID = "")
		{
			CThostFtdcQryEWarrantOffsetField struc = new CThostFtdcQryEWarrantOffsetField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ExchangeID = ExchangeID,
				InstrumentID = InstrumentID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryEWarrantOffset", typeof(DeleReqQryEWarrantOffset)) as DeleReqQryEWarrantOffset)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInvestorProductGroupMargin(string BrokerID = "", string InvestorID = "", string ProductGroupID = "", TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryInvestorProductGroupMarginField struc = new CThostFtdcQryInvestorProductGroupMarginField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				ProductGroupID = ProductGroupID,
				HedgeFlag = HedgeFlag,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryInvestorProductGroupMargin", typeof(DeleReqQryInvestorProductGroupMargin)) as DeleReqQryInvestorProductGroupMargin)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryExchangeMarginRate(string BrokerID = "", string InstrumentID = "", TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string ExchangeID = "")
		{
			CThostFtdcQryExchangeMarginRateField struc = new CThostFtdcQryExchangeMarginRateField
			{
				BrokerID = BrokerID,
				InstrumentID = InstrumentID,
				HedgeFlag = HedgeFlag,
				ExchangeID = ExchangeID,
			};
			return (loader.Invoke("ReqQryExchangeMarginRate", typeof(DeleReqQryExchangeMarginRate)) as DeleReqQryExchangeMarginRate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryExchangeMarginRateAdjust(string BrokerID = "", string InstrumentID = "", TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation)
		{
			CThostFtdcQryExchangeMarginRateAdjustField struc = new CThostFtdcQryExchangeMarginRateAdjustField
			{
				BrokerID = BrokerID,
				InstrumentID = InstrumentID,
				HedgeFlag = HedgeFlag,
			};
			return (loader.Invoke("ReqQryExchangeMarginRateAdjust", typeof(DeleReqQryExchangeMarginRateAdjust)) as DeleReqQryExchangeMarginRateAdjust)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryExchangeRate(string BrokerID = "", string FromCurrencyID = "", string ToCurrencyID = "")
		{
			CThostFtdcQryExchangeRateField struc = new CThostFtdcQryExchangeRateField
			{
				BrokerID = BrokerID,
				FromCurrencyID = FromCurrencyID,
				ToCurrencyID = ToCurrencyID,
			};
			return (loader.Invoke("ReqQryExchangeRate", typeof(DeleReqQryExchangeRate)) as DeleReqQryExchangeRate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQrySecAgentACIDMap(string BrokerID = "", string UserID = "", string AccountID = "", string CurrencyID = "")
		{
			CThostFtdcQrySecAgentACIDMapField struc = new CThostFtdcQrySecAgentACIDMapField
			{
				BrokerID = BrokerID,
				UserID = UserID,
				AccountID = AccountID,
				CurrencyID = CurrencyID,
			};
			return (loader.Invoke("ReqQrySecAgentACIDMap", typeof(DeleReqQrySecAgentACIDMap)) as DeleReqQrySecAgentACIDMap)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryProductExchRate(string ProductID = "", string ExchangeID = "")
		{
			CThostFtdcQryProductExchRateField struc = new CThostFtdcQryProductExchRateField
			{
				ProductID = ProductID,
				ExchangeID = ExchangeID,
			};
			return (loader.Invoke("ReqQryProductExchRate", typeof(DeleReqQryProductExchRate)) as DeleReqQryProductExchRate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryProductGroup(string ProductID = "", string ExchangeID = "")
		{
			CThostFtdcQryProductGroupField struc = new CThostFtdcQryProductGroupField
			{
				ProductID = ProductID,
				ExchangeID = ExchangeID,
			};
			return (loader.Invoke("ReqQryProductGroup", typeof(DeleReqQryProductGroup)) as DeleReqQryProductGroup)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryMMInstrumentCommissionRate(string BrokerID = "", string InvestorID = "", string InstrumentID = "")
		{
			CThostFtdcQryMMInstrumentCommissionRateField struc = new CThostFtdcQryMMInstrumentCommissionRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
			};
			return (loader.Invoke("ReqQryMMInstrumentCommissionRate", typeof(DeleReqQryMMInstrumentCommissionRate)) as DeleReqQryMMInstrumentCommissionRate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryMMOptionInstrCommRate(string BrokerID = "", string InvestorID = "", string InstrumentID = "")
		{
			CThostFtdcQryMMOptionInstrCommRateField struc = new CThostFtdcQryMMOptionInstrCommRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
			};
			return (loader.Invoke("ReqQryMMOptionInstrCommRate", typeof(DeleReqQryMMOptionInstrCommRate)) as DeleReqQryMMOptionInstrCommRate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInstrumentOrderCommRate(string BrokerID = "", string InvestorID = "", string InstrumentID = "")
		{
			CThostFtdcQryInstrumentOrderCommRateField struc = new CThostFtdcQryInstrumentOrderCommRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
			};
			return (loader.Invoke("ReqQryInstrumentOrderCommRate", typeof(DeleReqQryInstrumentOrderCommRate)) as DeleReqQryInstrumentOrderCommRate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQrySecAgentTradingAccount(string BrokerID = "", string InvestorID = "", string CurrencyID = "", TThostFtdcBizTypeType BizType = TThostFtdcBizTypeType.THOST_FTDC_BZTP_Future, string AccountID = "")
		{
			CThostFtdcQryTradingAccountField struc = new CThostFtdcQryTradingAccountField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				CurrencyID = CurrencyID,
				BizType = BizType,
				AccountID = AccountID,
			};
			return (loader.Invoke("ReqQrySecAgentTradingAccount", typeof(DeleReqQrySecAgentTradingAccount)) as DeleReqQrySecAgentTradingAccount)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQrySecAgentCheckMode(string BrokerID = "", string InvestorID = "")
		{
			CThostFtdcQrySecAgentCheckModeField struc = new CThostFtdcQrySecAgentCheckModeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
			};
			return (loader.Invoke("ReqQrySecAgentCheckMode", typeof(DeleReqQrySecAgentCheckMode)) as DeleReqQrySecAgentCheckMode)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryOptionInstrTradeCost(string BrokerID = "", string InvestorID = "", string InstrumentID = "", TThostFtdcHedgeFlagType HedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, double InputPrice = 0, double UnderlyingPrice = 0, string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryOptionInstrTradeCostField struc = new CThostFtdcQryOptionInstrTradeCostField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				HedgeFlag = HedgeFlag,				InputPrice = InputPrice,
				UnderlyingPrice = UnderlyingPrice,

				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryOptionInstrTradeCost", typeof(DeleReqQryOptionInstrTradeCost)) as DeleReqQryOptionInstrTradeCost)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryOptionInstrCommRate(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryOptionInstrCommRateField struc = new CThostFtdcQryOptionInstrCommRateField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryOptionInstrCommRate", typeof(DeleReqQryOptionInstrCommRate)) as DeleReqQryOptionInstrCommRate)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryExecOrder(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string ExecOrderSysID = "", string InsertTimeStart = "", string InsertTimeEnd = "")
		{
			CThostFtdcQryExecOrderField struc = new CThostFtdcQryExecOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				ExecOrderSysID = ExecOrderSysID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
			};
			return (loader.Invoke("ReqQryExecOrder", typeof(DeleReqQryExecOrder)) as DeleReqQryExecOrder)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryForQuote(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string InsertTimeStart = "", string InsertTimeEnd = "", string InvestUnitID = "")
		{
			CThostFtdcQryForQuoteField struc = new CThostFtdcQryForQuoteField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryForQuote", typeof(DeleReqQryForQuote)) as DeleReqQryForQuote)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryQuote(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string QuoteSysID = "", string InsertTimeStart = "", string InsertTimeEnd = "", string InvestUnitID = "")
		{
			CThostFtdcQryQuoteField struc = new CThostFtdcQryQuoteField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				QuoteSysID = QuoteSysID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryQuote", typeof(DeleReqQryQuote)) as DeleReqQryQuote)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryOptionSelfClose(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string OptionSelfCloseSysID = "", string InsertTimeStart = "", string InsertTimeEnd = "")
		{
			CThostFtdcQryOptionSelfCloseField struc = new CThostFtdcQryOptionSelfCloseField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				OptionSelfCloseSysID = OptionSelfCloseSysID,
				InsertTimeStart = InsertTimeStart,
				InsertTimeEnd = InsertTimeEnd,
			};
			return (loader.Invoke("ReqQryOptionSelfClose", typeof(DeleReqQryOptionSelfClose)) as DeleReqQryOptionSelfClose)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryInvestUnit(string BrokerID = "", string InvestorID = "", string InvestUnitID = "")
		{
			CThostFtdcQryInvestUnitField struc = new CThostFtdcQryInvestUnitField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryInvestUnit", typeof(DeleReqQryInvestUnit)) as DeleReqQryInvestUnit)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryCombInstrumentGuard(string BrokerID = "", string InstrumentID = "", string ExchangeID = "")
		{
			CThostFtdcQryCombInstrumentGuardField struc = new CThostFtdcQryCombInstrumentGuardField
			{
				BrokerID = BrokerID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
			};
			return (loader.Invoke("ReqQryCombInstrumentGuard", typeof(DeleReqQryCombInstrumentGuard)) as DeleReqQryCombInstrumentGuard)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryCombAction(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryCombActionField struc = new CThostFtdcQryCombActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryCombAction", typeof(DeleReqQryCombAction)) as DeleReqQryCombAction)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryTransferSerial(string BrokerID = "", string AccountID = "", string BankID = "", string CurrencyID = "")
		{
			CThostFtdcQryTransferSerialField struc = new CThostFtdcQryTransferSerialField
			{
				BrokerID = BrokerID,
				AccountID = AccountID,
				BankID = BankID,
				CurrencyID = CurrencyID,
			};
			return (loader.Invoke("ReqQryTransferSerial", typeof(DeleReqQryTransferSerial)) as DeleReqQryTransferSerial)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryAccountregister(string BrokerID = "", string AccountID = "", string BankID = "", string BankBranchID = "", string CurrencyID = "")
		{
			CThostFtdcQryAccountregisterField struc = new CThostFtdcQryAccountregisterField
			{
				BrokerID = BrokerID,
				AccountID = AccountID,
				BankID = BankID,
				BankBranchID = BankBranchID,
				CurrencyID = CurrencyID,
			};
			return (loader.Invoke("ReqQryAccountregister", typeof(DeleReqQryAccountregister)) as DeleReqQryAccountregister)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryContractBank(string BrokerID = "", string BankID = "", string BankBrchID = "")
		{
			CThostFtdcQryContractBankField struc = new CThostFtdcQryContractBankField
			{
				BrokerID = BrokerID,
				BankID = BankID,
				BankBrchID = BankBrchID,
			};
			return (loader.Invoke("ReqQryContractBank", typeof(DeleReqQryContractBank)) as DeleReqQryContractBank)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryParkedOrder(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryParkedOrderField struc = new CThostFtdcQryParkedOrderField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryParkedOrder", typeof(DeleReqQryParkedOrder)) as DeleReqQryParkedOrder)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryParkedOrderAction(string BrokerID = "", string InvestorID = "", string InstrumentID = "", string ExchangeID = "", string InvestUnitID = "")
		{
			CThostFtdcQryParkedOrderActionField struc = new CThostFtdcQryParkedOrderActionField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InstrumentID = InstrumentID,
				ExchangeID = ExchangeID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryParkedOrderAction", typeof(DeleReqQryParkedOrderAction)) as DeleReqQryParkedOrderAction)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryTradingNotice(string BrokerID = "", string InvestorID = "", string InvestUnitID = "")
		{
			CThostFtdcQryTradingNoticeField struc = new CThostFtdcQryTradingNoticeField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQryTradingNotice", typeof(DeleReqQryTradingNotice)) as DeleReqQryTradingNotice)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryBrokerTradingParams(string BrokerID = "", string InvestorID = "", string CurrencyID = "", string AccountID = "")
		{
			CThostFtdcQryBrokerTradingParamsField struc = new CThostFtdcQryBrokerTradingParamsField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				CurrencyID = CurrencyID,
				AccountID = AccountID,
			};
			return (loader.Invoke("ReqQryBrokerTradingParams", typeof(DeleReqQryBrokerTradingParams)) as DeleReqQryBrokerTradingParams)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQryBrokerTradingAlgos(string BrokerID = "", string ExchangeID = "", string InstrumentID = "")
		{
			CThostFtdcQryBrokerTradingAlgosField struc = new CThostFtdcQryBrokerTradingAlgosField
			{
				BrokerID = BrokerID,
				ExchangeID = ExchangeID,
				InstrumentID = InstrumentID,
			};
			return (loader.Invoke("ReqQryBrokerTradingAlgos", typeof(DeleReqQryBrokerTradingAlgos)) as DeleReqQryBrokerTradingAlgos)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQueryCFMMCTradingAccountToken(string BrokerID = "", string InvestorID = "", string InvestUnitID = "")
		{
			CThostFtdcQueryCFMMCTradingAccountTokenField struc = new CThostFtdcQueryCFMMCTradingAccountTokenField
			{
				BrokerID = BrokerID,
				InvestorID = InvestorID,
				InvestUnitID = InvestUnitID,
			};
			return (loader.Invoke("ReqQueryCFMMCTradingAccountToken", typeof(DeleReqQueryCFMMCTradingAccountToken)) as DeleReqQueryCFMMCTradingAccountToken)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqFromBankToFutureByFuture(string TradeCode = "", string BankID = "", string BankBranchID = "", string BrokerID = "", string BrokerBranchID = "", string TradeDate = "", string TradeTime = "", string BankSerial = "", string TradingDay = "", int PlateSerial = 0, TThostFtdcLastFragmentType LastFragment = TThostFtdcLastFragmentType.THOST_FTDC_LF_Yes, int SessionID = 0, string CustomerName = "", TThostFtdcIdCardTypeType IdCardType = TThostFtdcIdCardTypeType.THOST_FTDC_ICT_EID, string IdentifiedCardNo = "", TThostFtdcCustTypeType CustType = TThostFtdcCustTypeType.THOST_FTDC_CUSTT_Person, string BankAccount = "", string BankPassWord = "", string AccountID = "", string Password = "", int InstallID = 0, int FutureSerial = 0, string UserID = "", TThostFtdcYesNoIndicatorType VerifyCertNoFlag = TThostFtdcYesNoIndicatorType.THOST_FTDC_YNI_Yes, string CurrencyID = "", double TradeAmount = 0, double FutureFetchAmount = 0, TThostFtdcFeePayFlagType FeePayFlag = TThostFtdcFeePayFlagType.THOST_FTDC_FPF_BEN, double CustFee = 0, double BrokerFee = 0, string Message = "", string Digest = "", TThostFtdcBankAccTypeType BankAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string DeviceID = "", TThostFtdcBankAccTypeType BankSecuAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string BrokerIDByBank = "", string BankSecuAcc = "", TThostFtdcPwdFlagType BankPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, TThostFtdcPwdFlagType SecuPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, string OperNo = "", int RequestID = 0, int TID = 0, TThostFtdcTransferStatusType TransferStatus = TThostFtdcTransferStatusType.THOST_FTDC_TRFS_Normal, string LongCustomerName = "")
		{
			CThostFtdcReqTransferField struc = new CThostFtdcReqTransferField
			{
				TradeCode = TradeCode,
				BankID = BankID,
				BankBranchID = BankBranchID,
				BrokerID = BrokerID,
				BrokerBranchID = BrokerBranchID,
				TradeDate = TradeDate,
				TradeTime = TradeTime,
				BankSerial = BankSerial,
				TradingDay = TradingDay,				PlateSerial = PlateSerial,

				LastFragment = LastFragment,				SessionID = SessionID,

				CustomerName = CustomerName,
				IdCardType = IdCardType,
				IdentifiedCardNo = IdentifiedCardNo,
				CustType = CustType,
				BankAccount = BankAccount,
				BankPassWord = BankPassWord,
				AccountID = AccountID,
				Password = Password,				InstallID = InstallID,
				FutureSerial = FutureSerial,

				UserID = UserID,
				VerifyCertNoFlag = VerifyCertNoFlag,
				CurrencyID = CurrencyID,				TradeAmount = TradeAmount,
				FutureFetchAmount = FutureFetchAmount,

				FeePayFlag = FeePayFlag,				CustFee = CustFee,
				BrokerFee = BrokerFee,

				Message = Message,
				Digest = Digest,
				BankAccType = BankAccType,
				DeviceID = DeviceID,
				BankSecuAccType = BankSecuAccType,
				BrokerIDByBank = BrokerIDByBank,
				BankSecuAcc = BankSecuAcc,
				BankPwdFlag = BankPwdFlag,
				SecuPwdFlag = SecuPwdFlag,
				OperNo = OperNo,				RequestID = RequestID,
				TID = TID,

				TransferStatus = TransferStatus,
				LongCustomerName = LongCustomerName,
			};
			return (loader.Invoke("ReqFromBankToFutureByFuture", typeof(DeleReqFromBankToFutureByFuture)) as DeleReqFromBankToFutureByFuture)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqFromFutureToBankByFuture(string TradeCode = "", string BankID = "", string BankBranchID = "", string BrokerID = "", string BrokerBranchID = "", string TradeDate = "", string TradeTime = "", string BankSerial = "", string TradingDay = "", int PlateSerial = 0, TThostFtdcLastFragmentType LastFragment = TThostFtdcLastFragmentType.THOST_FTDC_LF_Yes, int SessionID = 0, string CustomerName = "", TThostFtdcIdCardTypeType IdCardType = TThostFtdcIdCardTypeType.THOST_FTDC_ICT_EID, string IdentifiedCardNo = "", TThostFtdcCustTypeType CustType = TThostFtdcCustTypeType.THOST_FTDC_CUSTT_Person, string BankAccount = "", string BankPassWord = "", string AccountID = "", string Password = "", int InstallID = 0, int FutureSerial = 0, string UserID = "", TThostFtdcYesNoIndicatorType VerifyCertNoFlag = TThostFtdcYesNoIndicatorType.THOST_FTDC_YNI_Yes, string CurrencyID = "", double TradeAmount = 0, double FutureFetchAmount = 0, TThostFtdcFeePayFlagType FeePayFlag = TThostFtdcFeePayFlagType.THOST_FTDC_FPF_BEN, double CustFee = 0, double BrokerFee = 0, string Message = "", string Digest = "", TThostFtdcBankAccTypeType BankAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string DeviceID = "", TThostFtdcBankAccTypeType BankSecuAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string BrokerIDByBank = "", string BankSecuAcc = "", TThostFtdcPwdFlagType BankPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, TThostFtdcPwdFlagType SecuPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, string OperNo = "", int RequestID = 0, int TID = 0, TThostFtdcTransferStatusType TransferStatus = TThostFtdcTransferStatusType.THOST_FTDC_TRFS_Normal, string LongCustomerName = "")
		{
			CThostFtdcReqTransferField struc = new CThostFtdcReqTransferField
			{
				TradeCode = TradeCode,
				BankID = BankID,
				BankBranchID = BankBranchID,
				BrokerID = BrokerID,
				BrokerBranchID = BrokerBranchID,
				TradeDate = TradeDate,
				TradeTime = TradeTime,
				BankSerial = BankSerial,
				TradingDay = TradingDay,				PlateSerial = PlateSerial,

				LastFragment = LastFragment,				SessionID = SessionID,

				CustomerName = CustomerName,
				IdCardType = IdCardType,
				IdentifiedCardNo = IdentifiedCardNo,
				CustType = CustType,
				BankAccount = BankAccount,
				BankPassWord = BankPassWord,
				AccountID = AccountID,
				Password = Password,				InstallID = InstallID,
				FutureSerial = FutureSerial,

				UserID = UserID,
				VerifyCertNoFlag = VerifyCertNoFlag,
				CurrencyID = CurrencyID,				TradeAmount = TradeAmount,
				FutureFetchAmount = FutureFetchAmount,

				FeePayFlag = FeePayFlag,				CustFee = CustFee,
				BrokerFee = BrokerFee,

				Message = Message,
				Digest = Digest,
				BankAccType = BankAccType,
				DeviceID = DeviceID,
				BankSecuAccType = BankSecuAccType,
				BrokerIDByBank = BrokerIDByBank,
				BankSecuAcc = BankSecuAcc,
				BankPwdFlag = BankPwdFlag,
				SecuPwdFlag = SecuPwdFlag,
				OperNo = OperNo,				RequestID = RequestID,
				TID = TID,

				TransferStatus = TransferStatus,
				LongCustomerName = LongCustomerName,
			};
			return (loader.Invoke("ReqFromFutureToBankByFuture", typeof(DeleReqFromFutureToBankByFuture)) as DeleReqFromFutureToBankByFuture)(_api, ref struc, this.nRequestID++);
		}

		public IntPtr ReqQueryBankAccountMoneyByFuture(string TradeCode = "", string BankID = "", string BankBranchID = "", string BrokerID = "", string BrokerBranchID = "", string TradeDate = "", string TradeTime = "", string BankSerial = "", string TradingDay = "", int PlateSerial = 0, TThostFtdcLastFragmentType LastFragment = TThostFtdcLastFragmentType.THOST_FTDC_LF_Yes, int SessionID = 0, string CustomerName = "", TThostFtdcIdCardTypeType IdCardType = TThostFtdcIdCardTypeType.THOST_FTDC_ICT_EID, string IdentifiedCardNo = "", TThostFtdcCustTypeType CustType = TThostFtdcCustTypeType.THOST_FTDC_CUSTT_Person, string BankAccount = "", string BankPassWord = "", string AccountID = "", string Password = "", int FutureSerial = 0, int InstallID = 0, string UserID = "", TThostFtdcYesNoIndicatorType VerifyCertNoFlag = TThostFtdcYesNoIndicatorType.THOST_FTDC_YNI_Yes, string CurrencyID = "", string Digest = "", TThostFtdcBankAccTypeType BankAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string DeviceID = "", TThostFtdcBankAccTypeType BankSecuAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string BrokerIDByBank = "", string BankSecuAcc = "", TThostFtdcPwdFlagType BankPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, TThostFtdcPwdFlagType SecuPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, string OperNo = "", int RequestID = 0, int TID = 0, string LongCustomerName = "")
		{
			CThostFtdcReqQueryAccountField struc = new CThostFtdcReqQueryAccountField
			{
				TradeCode = TradeCode,
				BankID = BankID,
				BankBranchID = BankBranchID,
				BrokerID = BrokerID,
				BrokerBranchID = BrokerBranchID,
				TradeDate = TradeDate,
				TradeTime = TradeTime,
				BankSerial = BankSerial,
				TradingDay = TradingDay,				PlateSerial = PlateSerial,

				LastFragment = LastFragment,				SessionID = SessionID,

				CustomerName = CustomerName,
				IdCardType = IdCardType,
				IdentifiedCardNo = IdentifiedCardNo,
				CustType = CustType,
				BankAccount = BankAccount,
				BankPassWord = BankPassWord,
				AccountID = AccountID,
				Password = Password,				FutureSerial = FutureSerial,
				InstallID = InstallID,

				UserID = UserID,
				VerifyCertNoFlag = VerifyCertNoFlag,
				CurrencyID = CurrencyID,
				Digest = Digest,
				BankAccType = BankAccType,
				DeviceID = DeviceID,
				BankSecuAccType = BankSecuAccType,
				BrokerIDByBank = BrokerIDByBank,
				BankSecuAcc = BankSecuAcc,
				BankPwdFlag = BankPwdFlag,
				SecuPwdFlag = SecuPwdFlag,
				OperNo = OperNo,				RequestID = RequestID,
				TID = TID,

				LongCustomerName = LongCustomerName,
			};
			return (loader.Invoke("ReqQueryBankAccountMoneyByFuture", typeof(DeleReqQueryBankAccountMoneyByFuture)) as DeleReqQueryBankAccountMoneyByFuture)(_api, ref struc, this.nRequestID++);
		}

		#endregion
		delegate void DeleSet(IntPtr spi, Delegate func);

		public delegate void DeleOnFrontConnected();
		public void SetOnFrontConnected(DeleOnFrontConnected func) { (loader.Invoke("SetOnFrontConnected", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnFrontDisconnected(int nReason);
		public void SetOnFrontDisconnected(DeleOnFrontDisconnected func) { (loader.Invoke("SetOnFrontDisconnected", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnHeartBeatWarning(int nTimeLapse);
		public void SetOnHeartBeatWarning(DeleOnHeartBeatWarning func) { (loader.Invoke("SetOnHeartBeatWarning", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspAuthenticate(ref CThostFtdcRspAuthenticateField pRspAuthenticateField, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspAuthenticate(DeleOnRspAuthenticate func) { (loader.Invoke("SetOnRspAuthenticate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspUserLogin(ref CThostFtdcRspUserLoginField pRspUserLogin, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspUserLogin(DeleOnRspUserLogin func) { (loader.Invoke("SetOnRspUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspUserLogout(ref CThostFtdcUserLogoutField pUserLogout, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspUserLogout(DeleOnRspUserLogout func) { (loader.Invoke("SetOnRspUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspUserPasswordUpdate(ref CThostFtdcUserPasswordUpdateField pUserPasswordUpdate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspUserPasswordUpdate(DeleOnRspUserPasswordUpdate func) { (loader.Invoke("SetOnRspUserPasswordUpdate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspTradingAccountPasswordUpdate(ref CThostFtdcTradingAccountPasswordUpdateField pTradingAccountPasswordUpdate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspTradingAccountPasswordUpdate(DeleOnRspTradingAccountPasswordUpdate func) { (loader.Invoke("SetOnRspTradingAccountPasswordUpdate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspOrderInsert(ref CThostFtdcInputOrderField pInputOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspOrderInsert(DeleOnRspOrderInsert func) { (loader.Invoke("SetOnRspOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspParkedOrderInsert(ref CThostFtdcParkedOrderField pParkedOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspParkedOrderInsert(DeleOnRspParkedOrderInsert func) { (loader.Invoke("SetOnRspParkedOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspParkedOrderAction(ref CThostFtdcParkedOrderActionField pParkedOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspParkedOrderAction(DeleOnRspParkedOrderAction func) { (loader.Invoke("SetOnRspParkedOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspOrderAction(ref CThostFtdcInputOrderActionField pInputOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspOrderAction(DeleOnRspOrderAction func) { (loader.Invoke("SetOnRspOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQueryMaxOrderVolume(ref CThostFtdcQueryMaxOrderVolumeField pQueryMaxOrderVolume, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQueryMaxOrderVolume(DeleOnRspQueryMaxOrderVolume func) { (loader.Invoke("SetOnRspQueryMaxOrderVolume", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspSettlementInfoConfirm(ref CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspSettlementInfoConfirm(DeleOnRspSettlementInfoConfirm func) { (loader.Invoke("SetOnRspSettlementInfoConfirm", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspRemoveParkedOrder(ref CThostFtdcRemoveParkedOrderField pRemoveParkedOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspRemoveParkedOrder(DeleOnRspRemoveParkedOrder func) { (loader.Invoke("SetOnRspRemoveParkedOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspRemoveParkedOrderAction(ref CThostFtdcRemoveParkedOrderActionField pRemoveParkedOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspRemoveParkedOrderAction(DeleOnRspRemoveParkedOrderAction func) { (loader.Invoke("SetOnRspRemoveParkedOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspExecOrderInsert(ref CThostFtdcInputExecOrderField pInputExecOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspExecOrderInsert(DeleOnRspExecOrderInsert func) { (loader.Invoke("SetOnRspExecOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspExecOrderAction(ref CThostFtdcInputExecOrderActionField pInputExecOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspExecOrderAction(DeleOnRspExecOrderAction func) { (loader.Invoke("SetOnRspExecOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspForQuoteInsert(ref CThostFtdcInputForQuoteField pInputForQuote, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspForQuoteInsert(DeleOnRspForQuoteInsert func) { (loader.Invoke("SetOnRspForQuoteInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQuoteInsert(ref CThostFtdcInputQuoteField pInputQuote, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQuoteInsert(DeleOnRspQuoteInsert func) { (loader.Invoke("SetOnRspQuoteInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQuoteAction(ref CThostFtdcInputQuoteActionField pInputQuoteAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQuoteAction(DeleOnRspQuoteAction func) { (loader.Invoke("SetOnRspQuoteAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspBatchOrderAction(ref CThostFtdcInputBatchOrderActionField pInputBatchOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspBatchOrderAction(DeleOnRspBatchOrderAction func) { (loader.Invoke("SetOnRspBatchOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspOptionSelfCloseInsert(ref CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspOptionSelfCloseInsert(DeleOnRspOptionSelfCloseInsert func) { (loader.Invoke("SetOnRspOptionSelfCloseInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspOptionSelfCloseAction(ref CThostFtdcInputOptionSelfCloseActionField pInputOptionSelfCloseAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspOptionSelfCloseAction(DeleOnRspOptionSelfCloseAction func) { (loader.Invoke("SetOnRspOptionSelfCloseAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspCombActionInsert(ref CThostFtdcInputCombActionField pInputCombAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspCombActionInsert(DeleOnRspCombActionInsert func) { (loader.Invoke("SetOnRspCombActionInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryOrder(ref CThostFtdcOrderField pOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryOrder(DeleOnRspQryOrder func) { (loader.Invoke("SetOnRspQryOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryTrade(ref CThostFtdcTradeField pTrade, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryTrade(DeleOnRspQryTrade func) { (loader.Invoke("SetOnRspQryTrade", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInvestorPosition(ref CThostFtdcInvestorPositionField pInvestorPosition, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInvestorPosition(DeleOnRspQryInvestorPosition func) { (loader.Invoke("SetOnRspQryInvestorPosition", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryTradingAccount(ref CThostFtdcTradingAccountField pTradingAccount, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryTradingAccount(DeleOnRspQryTradingAccount func) { (loader.Invoke("SetOnRspQryTradingAccount", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInvestor(ref CThostFtdcInvestorField pInvestor, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInvestor(DeleOnRspQryInvestor func) { (loader.Invoke("SetOnRspQryInvestor", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryTradingCode(ref CThostFtdcTradingCodeField pTradingCode, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryTradingCode(DeleOnRspQryTradingCode func) { (loader.Invoke("SetOnRspQryTradingCode", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInstrumentMarginRate(ref CThostFtdcInstrumentMarginRateField pInstrumentMarginRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInstrumentMarginRate(DeleOnRspQryInstrumentMarginRate func) { (loader.Invoke("SetOnRspQryInstrumentMarginRate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInstrumentCommissionRate(ref CThostFtdcInstrumentCommissionRateField pInstrumentCommissionRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInstrumentCommissionRate(DeleOnRspQryInstrumentCommissionRate func) { (loader.Invoke("SetOnRspQryInstrumentCommissionRate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryExchange(ref CThostFtdcExchangeField pExchange, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryExchange(DeleOnRspQryExchange func) { (loader.Invoke("SetOnRspQryExchange", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryProduct(ref CThostFtdcProductField pProduct, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryProduct(DeleOnRspQryProduct func) { (loader.Invoke("SetOnRspQryProduct", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInstrument(ref CThostFtdcInstrumentField pInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInstrument(DeleOnRspQryInstrument func) { (loader.Invoke("SetOnRspQryInstrument", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryDepthMarketData(DeleOnRspQryDepthMarketData func) { (loader.Invoke("SetOnRspQryDepthMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQrySettlementInfo(ref CThostFtdcSettlementInfoField pSettlementInfo, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQrySettlementInfo(DeleOnRspQrySettlementInfo func) { (loader.Invoke("SetOnRspQrySettlementInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryTransferBank(ref CThostFtdcTransferBankField pTransferBank, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryTransferBank(DeleOnRspQryTransferBank func) { (loader.Invoke("SetOnRspQryTransferBank", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInvestorPositionDetail(ref CThostFtdcInvestorPositionDetailField pInvestorPositionDetail, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInvestorPositionDetail(DeleOnRspQryInvestorPositionDetail func) { (loader.Invoke("SetOnRspQryInvestorPositionDetail", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryNotice(ref CThostFtdcNoticeField pNotice, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryNotice(DeleOnRspQryNotice func) { (loader.Invoke("SetOnRspQryNotice", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQrySettlementInfoConfirm(ref CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQrySettlementInfoConfirm(DeleOnRspQrySettlementInfoConfirm func) { (loader.Invoke("SetOnRspQrySettlementInfoConfirm", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInvestorPositionCombineDetail(ref CThostFtdcInvestorPositionCombineDetailField pInvestorPositionCombineDetail, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInvestorPositionCombineDetail(DeleOnRspQryInvestorPositionCombineDetail func) { (loader.Invoke("SetOnRspQryInvestorPositionCombineDetail", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryCFMMCTradingAccountKey(ref CThostFtdcCFMMCTradingAccountKeyField pCFMMCTradingAccountKey, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryCFMMCTradingAccountKey(DeleOnRspQryCFMMCTradingAccountKey func) { (loader.Invoke("SetOnRspQryCFMMCTradingAccountKey", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryEWarrantOffset(ref CThostFtdcEWarrantOffsetField pEWarrantOffset, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryEWarrantOffset(DeleOnRspQryEWarrantOffset func) { (loader.Invoke("SetOnRspQryEWarrantOffset", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInvestorProductGroupMargin(ref CThostFtdcInvestorProductGroupMarginField pInvestorProductGroupMargin, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInvestorProductGroupMargin(DeleOnRspQryInvestorProductGroupMargin func) { (loader.Invoke("SetOnRspQryInvestorProductGroupMargin", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryExchangeMarginRate(ref CThostFtdcExchangeMarginRateField pExchangeMarginRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryExchangeMarginRate(DeleOnRspQryExchangeMarginRate func) { (loader.Invoke("SetOnRspQryExchangeMarginRate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryExchangeMarginRateAdjust(ref CThostFtdcExchangeMarginRateAdjustField pExchangeMarginRateAdjust, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryExchangeMarginRateAdjust(DeleOnRspQryExchangeMarginRateAdjust func) { (loader.Invoke("SetOnRspQryExchangeMarginRateAdjust", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryExchangeRate(ref CThostFtdcExchangeRateField pExchangeRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryExchangeRate(DeleOnRspQryExchangeRate func) { (loader.Invoke("SetOnRspQryExchangeRate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQrySecAgentACIDMap(ref CThostFtdcSecAgentACIDMapField pSecAgentACIDMap, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQrySecAgentACIDMap(DeleOnRspQrySecAgentACIDMap func) { (loader.Invoke("SetOnRspQrySecAgentACIDMap", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryProductExchRate(ref CThostFtdcProductExchRateField pProductExchRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryProductExchRate(DeleOnRspQryProductExchRate func) { (loader.Invoke("SetOnRspQryProductExchRate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryProductGroup(ref CThostFtdcProductGroupField pProductGroup, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryProductGroup(DeleOnRspQryProductGroup func) { (loader.Invoke("SetOnRspQryProductGroup", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryMMInstrumentCommissionRate(ref CThostFtdcMMInstrumentCommissionRateField pMMInstrumentCommissionRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryMMInstrumentCommissionRate(DeleOnRspQryMMInstrumentCommissionRate func) { (loader.Invoke("SetOnRspQryMMInstrumentCommissionRate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryMMOptionInstrCommRate(ref CThostFtdcMMOptionInstrCommRateField pMMOptionInstrCommRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryMMOptionInstrCommRate(DeleOnRspQryMMOptionInstrCommRate func) { (loader.Invoke("SetOnRspQryMMOptionInstrCommRate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInstrumentOrderCommRate(ref CThostFtdcInstrumentOrderCommRateField pInstrumentOrderCommRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInstrumentOrderCommRate(DeleOnRspQryInstrumentOrderCommRate func) { (loader.Invoke("SetOnRspQryInstrumentOrderCommRate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQrySecAgentTradingAccount(ref CThostFtdcTradingAccountField pTradingAccount, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQrySecAgentTradingAccount(DeleOnRspQrySecAgentTradingAccount func) { (loader.Invoke("SetOnRspQrySecAgentTradingAccount", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQrySecAgentCheckMode(ref CThostFtdcSecAgentCheckModeField pSecAgentCheckMode, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQrySecAgentCheckMode(DeleOnRspQrySecAgentCheckMode func) { (loader.Invoke("SetOnRspQrySecAgentCheckMode", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryOptionInstrTradeCost(ref CThostFtdcOptionInstrTradeCostField pOptionInstrTradeCost, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryOptionInstrTradeCost(DeleOnRspQryOptionInstrTradeCost func) { (loader.Invoke("SetOnRspQryOptionInstrTradeCost", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryOptionInstrCommRate(ref CThostFtdcOptionInstrCommRateField pOptionInstrCommRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryOptionInstrCommRate(DeleOnRspQryOptionInstrCommRate func) { (loader.Invoke("SetOnRspQryOptionInstrCommRate", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryExecOrder(ref CThostFtdcExecOrderField pExecOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryExecOrder(DeleOnRspQryExecOrder func) { (loader.Invoke("SetOnRspQryExecOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryForQuote(ref CThostFtdcForQuoteField pForQuote, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryForQuote(DeleOnRspQryForQuote func) { (loader.Invoke("SetOnRspQryForQuote", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryQuote(ref CThostFtdcQuoteField pQuote, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryQuote(DeleOnRspQryQuote func) { (loader.Invoke("SetOnRspQryQuote", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryOptionSelfClose(ref CThostFtdcOptionSelfCloseField pOptionSelfClose, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryOptionSelfClose(DeleOnRspQryOptionSelfClose func) { (loader.Invoke("SetOnRspQryOptionSelfClose", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryInvestUnit(ref CThostFtdcInvestUnitField pInvestUnit, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryInvestUnit(DeleOnRspQryInvestUnit func) { (loader.Invoke("SetOnRspQryInvestUnit", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryCombInstrumentGuard(ref CThostFtdcCombInstrumentGuardField pCombInstrumentGuard, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryCombInstrumentGuard(DeleOnRspQryCombInstrumentGuard func) { (loader.Invoke("SetOnRspQryCombInstrumentGuard", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryCombAction(ref CThostFtdcCombActionField pCombAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryCombAction(DeleOnRspQryCombAction func) { (loader.Invoke("SetOnRspQryCombAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryTransferSerial(ref CThostFtdcTransferSerialField pTransferSerial, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryTransferSerial(DeleOnRspQryTransferSerial func) { (loader.Invoke("SetOnRspQryTransferSerial", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryAccountregister(ref CThostFtdcAccountregisterField pAccountregister, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryAccountregister(DeleOnRspQryAccountregister func) { (loader.Invoke("SetOnRspQryAccountregister", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspError(ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspError(DeleOnRspError func) { (loader.Invoke("SetOnRspError", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnOrder(ref CThostFtdcOrderField pOrder);
		public void SetOnRtnOrder(DeleOnRtnOrder func) { (loader.Invoke("SetOnRtnOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnTrade(ref CThostFtdcTradeField pTrade);
		public void SetOnRtnTrade(DeleOnRtnTrade func) { (loader.Invoke("SetOnRtnTrade", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnOrderInsert(ref CThostFtdcInputOrderField pInputOrder, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnOrderInsert(DeleOnErrRtnOrderInsert func) { (loader.Invoke("SetOnErrRtnOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnOrderAction(ref CThostFtdcOrderActionField pOrderAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnOrderAction(DeleOnErrRtnOrderAction func) { (loader.Invoke("SetOnErrRtnOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnInstrumentStatus(ref CThostFtdcInstrumentStatusField pInstrumentStatus);
		public void SetOnRtnInstrumentStatus(DeleOnRtnInstrumentStatus func) { (loader.Invoke("SetOnRtnInstrumentStatus", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnBulletin(ref CThostFtdcBulletinField pBulletin);
		public void SetOnRtnBulletin(DeleOnRtnBulletin func) { (loader.Invoke("SetOnRtnBulletin", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnTradingNotice(ref CThostFtdcTradingNoticeInfoField pTradingNoticeInfo);
		public void SetOnRtnTradingNotice(DeleOnRtnTradingNotice func) { (loader.Invoke("SetOnRtnTradingNotice", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnErrorConditionalOrder(ref CThostFtdcErrorConditionalOrderField pErrorConditionalOrder);
		public void SetOnRtnErrorConditionalOrder(DeleOnRtnErrorConditionalOrder func) { (loader.Invoke("SetOnRtnErrorConditionalOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnExecOrder(ref CThostFtdcExecOrderField pExecOrder);
		public void SetOnRtnExecOrder(DeleOnRtnExecOrder func) { (loader.Invoke("SetOnRtnExecOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnExecOrderInsert(ref CThostFtdcInputExecOrderField pInputExecOrder, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnExecOrderInsert(DeleOnErrRtnExecOrderInsert func) { (loader.Invoke("SetOnErrRtnExecOrderInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnExecOrderAction(ref CThostFtdcExecOrderActionField pExecOrderAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnExecOrderAction(DeleOnErrRtnExecOrderAction func) { (loader.Invoke("SetOnErrRtnExecOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnForQuoteInsert(ref CThostFtdcInputForQuoteField pInputForQuote, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnForQuoteInsert(DeleOnErrRtnForQuoteInsert func) { (loader.Invoke("SetOnErrRtnForQuoteInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnQuote(ref CThostFtdcQuoteField pQuote);
		public void SetOnRtnQuote(DeleOnRtnQuote func) { (loader.Invoke("SetOnRtnQuote", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnQuoteInsert(ref CThostFtdcInputQuoteField pInputQuote, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnQuoteInsert(DeleOnErrRtnQuoteInsert func) { (loader.Invoke("SetOnErrRtnQuoteInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnQuoteAction(ref CThostFtdcQuoteActionField pQuoteAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnQuoteAction(DeleOnErrRtnQuoteAction func) { (loader.Invoke("SetOnErrRtnQuoteAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnForQuoteRsp(ref CThostFtdcForQuoteRspField pForQuoteRsp);
		public void SetOnRtnForQuoteRsp(DeleOnRtnForQuoteRsp func) { (loader.Invoke("SetOnRtnForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnCFMMCTradingAccountToken(ref CThostFtdcCFMMCTradingAccountTokenField pCFMMCTradingAccountToken);
		public void SetOnRtnCFMMCTradingAccountToken(DeleOnRtnCFMMCTradingAccountToken func) { (loader.Invoke("SetOnRtnCFMMCTradingAccountToken", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnBatchOrderAction(ref CThostFtdcBatchOrderActionField pBatchOrderAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnBatchOrderAction(DeleOnErrRtnBatchOrderAction func) { (loader.Invoke("SetOnErrRtnBatchOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnOptionSelfClose(ref CThostFtdcOptionSelfCloseField pOptionSelfClose);
		public void SetOnRtnOptionSelfClose(DeleOnRtnOptionSelfClose func) { (loader.Invoke("SetOnRtnOptionSelfClose", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnOptionSelfCloseInsert(ref CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnOptionSelfCloseInsert(DeleOnErrRtnOptionSelfCloseInsert func) { (loader.Invoke("SetOnErrRtnOptionSelfCloseInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnOptionSelfCloseAction(ref CThostFtdcOptionSelfCloseActionField pOptionSelfCloseAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnOptionSelfCloseAction(DeleOnErrRtnOptionSelfCloseAction func) { (loader.Invoke("SetOnErrRtnOptionSelfCloseAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnCombAction(ref CThostFtdcCombActionField pCombAction);
		public void SetOnRtnCombAction(DeleOnRtnCombAction func) { (loader.Invoke("SetOnRtnCombAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnCombActionInsert(ref CThostFtdcInputCombActionField pInputCombAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnCombActionInsert(DeleOnErrRtnCombActionInsert func) { (loader.Invoke("SetOnErrRtnCombActionInsert", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryContractBank(ref CThostFtdcContractBankField pContractBank, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryContractBank(DeleOnRspQryContractBank func) { (loader.Invoke("SetOnRspQryContractBank", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryParkedOrder(ref CThostFtdcParkedOrderField pParkedOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryParkedOrder(DeleOnRspQryParkedOrder func) { (loader.Invoke("SetOnRspQryParkedOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryParkedOrderAction(ref CThostFtdcParkedOrderActionField pParkedOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryParkedOrderAction(DeleOnRspQryParkedOrderAction func) { (loader.Invoke("SetOnRspQryParkedOrderAction", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryTradingNotice(ref CThostFtdcTradingNoticeField pTradingNotice, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryTradingNotice(DeleOnRspQryTradingNotice func) { (loader.Invoke("SetOnRspQryTradingNotice", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryBrokerTradingParams(ref CThostFtdcBrokerTradingParamsField pBrokerTradingParams, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryBrokerTradingParams(DeleOnRspQryBrokerTradingParams func) { (loader.Invoke("SetOnRspQryBrokerTradingParams", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQryBrokerTradingAlgos(ref CThostFtdcBrokerTradingAlgosField pBrokerTradingAlgos, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQryBrokerTradingAlgos(DeleOnRspQryBrokerTradingAlgos func) { (loader.Invoke("SetOnRspQryBrokerTradingAlgos", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQueryCFMMCTradingAccountToken(ref CThostFtdcQueryCFMMCTradingAccountTokenField pQueryCFMMCTradingAccountToken, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQueryCFMMCTradingAccountToken(DeleOnRspQueryCFMMCTradingAccountToken func) { (loader.Invoke("SetOnRspQueryCFMMCTradingAccountToken", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnFromBankToFutureByBank(ref CThostFtdcRspTransferField pRspTransfer);
		public void SetOnRtnFromBankToFutureByBank(DeleOnRtnFromBankToFutureByBank func) { (loader.Invoke("SetOnRtnFromBankToFutureByBank", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnFromFutureToBankByBank(ref CThostFtdcRspTransferField pRspTransfer);
		public void SetOnRtnFromFutureToBankByBank(DeleOnRtnFromFutureToBankByBank func) { (loader.Invoke("SetOnRtnFromFutureToBankByBank", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnRepealFromBankToFutureByBank(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromBankToFutureByBank(DeleOnRtnRepealFromBankToFutureByBank func) { (loader.Invoke("SetOnRtnRepealFromBankToFutureByBank", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnRepealFromFutureToBankByBank(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromFutureToBankByBank(DeleOnRtnRepealFromFutureToBankByBank func) { (loader.Invoke("SetOnRtnRepealFromFutureToBankByBank", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnFromBankToFutureByFuture(ref CThostFtdcRspTransferField pRspTransfer);
		public void SetOnRtnFromBankToFutureByFuture(DeleOnRtnFromBankToFutureByFuture func) { (loader.Invoke("SetOnRtnFromBankToFutureByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnFromFutureToBankByFuture(ref CThostFtdcRspTransferField pRspTransfer);
		public void SetOnRtnFromFutureToBankByFuture(DeleOnRtnFromFutureToBankByFuture func) { (loader.Invoke("SetOnRtnFromFutureToBankByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnRepealFromBankToFutureByFutureManual(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromBankToFutureByFutureManual(DeleOnRtnRepealFromBankToFutureByFutureManual func) { (loader.Invoke("SetOnRtnRepealFromBankToFutureByFutureManual", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnRepealFromFutureToBankByFutureManual(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromFutureToBankByFutureManual(DeleOnRtnRepealFromFutureToBankByFutureManual func) { (loader.Invoke("SetOnRtnRepealFromFutureToBankByFutureManual", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnQueryBankBalanceByFuture(ref CThostFtdcNotifyQueryAccountField pNotifyQueryAccount);
		public void SetOnRtnQueryBankBalanceByFuture(DeleOnRtnQueryBankBalanceByFuture func) { (loader.Invoke("SetOnRtnQueryBankBalanceByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnBankToFutureByFuture(ref CThostFtdcReqTransferField pReqTransfer, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnBankToFutureByFuture(DeleOnErrRtnBankToFutureByFuture func) { (loader.Invoke("SetOnErrRtnBankToFutureByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnFutureToBankByFuture(ref CThostFtdcReqTransferField pReqTransfer, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnFutureToBankByFuture(DeleOnErrRtnFutureToBankByFuture func) { (loader.Invoke("SetOnErrRtnFutureToBankByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnRepealBankToFutureByFutureManual(ref CThostFtdcReqRepealField pReqRepeal, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnRepealBankToFutureByFutureManual(DeleOnErrRtnRepealBankToFutureByFutureManual func) { (loader.Invoke("SetOnErrRtnRepealBankToFutureByFutureManual", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnRepealFutureToBankByFutureManual(ref CThostFtdcReqRepealField pReqRepeal, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnRepealFutureToBankByFutureManual(DeleOnErrRtnRepealFutureToBankByFutureManual func) { (loader.Invoke("SetOnErrRtnRepealFutureToBankByFutureManual", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnErrRtnQueryBankBalanceByFuture(ref CThostFtdcReqQueryAccountField pReqQueryAccount, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnQueryBankBalanceByFuture(DeleOnErrRtnQueryBankBalanceByFuture func) { (loader.Invoke("SetOnErrRtnQueryBankBalanceByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnRepealFromBankToFutureByFuture(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromBankToFutureByFuture(DeleOnRtnRepealFromBankToFutureByFuture func) { (loader.Invoke("SetOnRtnRepealFromBankToFutureByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnRepealFromFutureToBankByFuture(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromFutureToBankByFuture(DeleOnRtnRepealFromFutureToBankByFuture func) { (loader.Invoke("SetOnRtnRepealFromFutureToBankByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspFromBankToFutureByFuture(ref CThostFtdcReqTransferField pReqTransfer, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspFromBankToFutureByFuture(DeleOnRspFromBankToFutureByFuture func) { (loader.Invoke("SetOnRspFromBankToFutureByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspFromFutureToBankByFuture(ref CThostFtdcReqTransferField pReqTransfer, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspFromFutureToBankByFuture(DeleOnRspFromFutureToBankByFuture func) { (loader.Invoke("SetOnRspFromFutureToBankByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRspQueryBankAccountMoneyByFuture(ref CThostFtdcReqQueryAccountField pReqQueryAccount, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
		public void SetOnRspQueryBankAccountMoneyByFuture(DeleOnRspQueryBankAccountMoneyByFuture func) { (loader.Invoke("SetOnRspQueryBankAccountMoneyByFuture", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnOpenAccountByBank(ref CThostFtdcOpenAccountField pOpenAccount);
		public void SetOnRtnOpenAccountByBank(DeleOnRtnOpenAccountByBank func) { (loader.Invoke("SetOnRtnOpenAccountByBank", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnCancelAccountByBank(ref CThostFtdcCancelAccountField pCancelAccount);
		public void SetOnRtnCancelAccountByBank(DeleOnRtnCancelAccountByBank func) { (loader.Invoke("SetOnRtnCancelAccountByBank", typeof(DeleSet)) as DeleSet)(_spi, func); }
		public delegate void DeleOnRtnChangeAccountByBank(ref CThostFtdcChangeAccountField pChangeAccount);
		public void SetOnRtnChangeAccountByBank(DeleOnRtnChangeAccountByBank func) { (loader.Invoke("SetOnRtnChangeAccountByBank", typeof(DeleSet)) as DeleSet)(_spi, func); }
	}
}