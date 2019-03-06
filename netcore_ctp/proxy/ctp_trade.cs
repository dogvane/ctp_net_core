using System;
using System.IO;
using PureCode.CtpCSharp;

namespace HaiFeng
{
	public class CtpTrade
	{
		private readonly AssembyLoader loader;
	    private readonly IntPtr _api;
		private readonly IntPtr _spi;
	    private delegate IntPtr Create();
	    private delegate IntPtr DelegateRegisterSpi(IntPtr api, IntPtr pSpi);

		public CtpTrade(string pAbsoluteFilePath)
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
		public delegate IntPtr DelegateSubscribePrivateTopic(IntPtr api, THOST_TE_RESUME_TYPE nResumeType);
		public delegate IntPtr DelegateSubscribePublicTopic(IntPtr api, THOST_TE_RESUME_TYPE nResumeType);
		public delegate IntPtr DelegateReqAuthenticate(IntPtr api, ref CThostFtdcReqAuthenticateField pReqAuthenticateField, int nRequestId);
		public delegate IntPtr DelegateReqUserLogin(IntPtr api, ref CThostFtdcReqUserLoginField pReqUserLoginField, int nRequestId);
		public delegate IntPtr DelegateReqUserLogout(IntPtr api, ref CThostFtdcUserLogoutField pUserLogout, int nRequestId);
		public delegate IntPtr DelegateReqUserPasswordUpdate(IntPtr api, ref CThostFtdcUserPasswordUpdateField pUserPasswordUpdate, int nRequestId);
		public delegate IntPtr DelegateReqTradingAccountPasswordUpdate(IntPtr api, ref CThostFtdcTradingAccountPasswordUpdateField pTradingAccountPasswordUpdate, int nRequestId);
		public delegate IntPtr DelegateReqUserLogin2(IntPtr api, ref CThostFtdcReqUserLoginField pReqUserLogin, int nRequestId);
		public delegate IntPtr DelegateReqUserPasswordUpdate2(IntPtr api, ref CThostFtdcUserPasswordUpdateField pUserPasswordUpdate, int nRequestId);
		public delegate IntPtr DelegateReqOrderInsert(IntPtr api, ref CThostFtdcInputOrderField pInputOrder, int nRequestId);
		public delegate IntPtr DelegateReqParkedOrderInsert(IntPtr api, ref CThostFtdcParkedOrderField pParkedOrder, int nRequestId);
		public delegate IntPtr DelegateReqParkedOrderAction(IntPtr api, ref CThostFtdcParkedOrderActionField pParkedOrderAction, int nRequestId);
		public delegate IntPtr DelegateReqOrderAction(IntPtr api, ref CThostFtdcInputOrderActionField pInputOrderAction, int nRequestId);
		public delegate IntPtr DelegateReqQueryMaxOrderVolume(IntPtr api, ref CThostFtdcQueryMaxOrderVolumeField pQueryMaxOrderVolume, int nRequestId);
		public delegate IntPtr DelegateReqSettlementInfoConfirm(IntPtr api, ref CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, int nRequestId);
		public delegate IntPtr DelegateReqRemoveParkedOrder(IntPtr api, ref CThostFtdcRemoveParkedOrderField pRemoveParkedOrder, int nRequestId);
		public delegate IntPtr DelegateReqRemoveParkedOrderAction(IntPtr api, ref CThostFtdcRemoveParkedOrderActionField pRemoveParkedOrderAction, int nRequestId);
		public delegate IntPtr DelegateReqExecOrderInsert(IntPtr api, ref CThostFtdcInputExecOrderField pInputExecOrder, int nRequestId);
		public delegate IntPtr DelegateReqExecOrderAction(IntPtr api, ref CThostFtdcInputExecOrderActionField pInputExecOrderAction, int nRequestId);
		public delegate IntPtr DelegateReqForQuoteInsert(IntPtr api, ref CThostFtdcInputForQuoteField pInputForQuote, int nRequestId);
		public delegate IntPtr DelegateReqQuoteInsert(IntPtr api, ref CThostFtdcInputQuoteField pInputQuote, int nRequestId);
		public delegate IntPtr DelegateReqQuoteAction(IntPtr api, ref CThostFtdcInputQuoteActionField pInputQuoteAction, int nRequestId);
		public delegate IntPtr DelegateReqBatchOrderAction(IntPtr api, ref CThostFtdcInputBatchOrderActionField pInputBatchOrderAction, int nRequestId);
		public delegate IntPtr DelegateReqOptionSelfCloseInsert(IntPtr api, ref CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose, int nRequestId);
		public delegate IntPtr DelegateReqOptionSelfCloseAction(IntPtr api, ref CThostFtdcInputOptionSelfCloseActionField pInputOptionSelfCloseAction, int nRequestId);
		public delegate IntPtr DelegateReqCombActionInsert(IntPtr api, ref CThostFtdcInputCombActionField pInputCombAction, int nRequestId);
		public delegate IntPtr DelegateReqQryOrder(IntPtr api, ref CThostFtdcQryOrderField pQryOrder, int nRequestId);
		public delegate IntPtr DelegateReqQryTrade(IntPtr api, ref CThostFtdcQryTradeField pQryTrade, int nRequestId);
		public delegate IntPtr DelegateReqQryInvestorPosition(IntPtr api, ref CThostFtdcQryInvestorPositionField pQryInvestorPosition, int nRequestId);
		public delegate IntPtr DelegateReqQryTradingAccount(IntPtr api, ref CThostFtdcQryTradingAccountField pQryTradingAccount, int nRequestId);
		public delegate IntPtr DelegateReqQryInvestor(IntPtr api, ref CThostFtdcQryInvestorField pQryInvestor, int nRequestId);
		public delegate IntPtr DelegateReqQryTradingCode(IntPtr api, ref CThostFtdcQryTradingCodeField pQryTradingCode, int nRequestId);
		public delegate IntPtr DelegateReqQryInstrumentMarginRate(IntPtr api, ref CThostFtdcQryInstrumentMarginRateField pQryInstrumentMarginRate, int nRequestId);
		public delegate IntPtr DelegateReqQryInstrumentCommissionRate(IntPtr api, ref CThostFtdcQryInstrumentCommissionRateField pQryInstrumentCommissionRate, int nRequestId);
		public delegate IntPtr DelegateReqQryExchange(IntPtr api, ref CThostFtdcQryExchangeField pQryExchange, int nRequestId);
		public delegate IntPtr DelegateReqQryProduct(IntPtr api, ref CThostFtdcQryProductField pQryProduct, int nRequestId);
		public delegate IntPtr DelegateReqQryInstrument(IntPtr api, ref CThostFtdcQryInstrumentField pQryInstrument, int nRequestId);
		public delegate IntPtr DelegateReqQryDepthMarketData(IntPtr api, ref CThostFtdcQryDepthMarketDataField pQryDepthMarketData, int nRequestId);
		public delegate IntPtr DelegateReqQrySettlementInfo(IntPtr api, ref CThostFtdcQrySettlementInfoField pQrySettlementInfo, int nRequestId);
		public delegate IntPtr DelegateReqQryTransferBank(IntPtr api, ref CThostFtdcQryTransferBankField pQryTransferBank, int nRequestId);
		public delegate IntPtr DelegateReqQryInvestorPositionDetail(IntPtr api, ref CThostFtdcQryInvestorPositionDetailField pQryInvestorPositionDetail, int nRequestId);
		public delegate IntPtr DelegateReqQryNotice(IntPtr api, ref CThostFtdcQryNoticeField pQryNotice, int nRequestId);
		public delegate IntPtr DelegateReqQrySettlementInfoConfirm(IntPtr api, ref CThostFtdcQrySettlementInfoConfirmField pQrySettlementInfoConfirm, int nRequestId);
		public delegate IntPtr DelegateReqQryInvestorPositionCombineDetail(IntPtr api, ref CThostFtdcQryInvestorPositionCombineDetailField pQryInvestorPositionCombineDetail, int nRequestId);
		public delegate IntPtr DelegateReqQryCFMMCTradingAccountKey(IntPtr api, ref CThostFtdcQryCFMMCTradingAccountKeyField pQryCFMMCTradingAccountKey, int nRequestId);
		public delegate IntPtr DelegateReqQryEWarrantOffset(IntPtr api, ref CThostFtdcQryEWarrantOffsetField pQryEWarrantOffset, int nRequestId);
		public delegate IntPtr DelegateReqQryInvestorProductGroupMargin(IntPtr api, ref CThostFtdcQryInvestorProductGroupMarginField pQryInvestorProductGroupMargin, int nRequestId);
		public delegate IntPtr DelegateReqQryExchangeMarginRate(IntPtr api, ref CThostFtdcQryExchangeMarginRateField pQryExchangeMarginRate, int nRequestId);
		public delegate IntPtr DelegateReqQryExchangeMarginRateAdjust(IntPtr api, ref CThostFtdcQryExchangeMarginRateAdjustField pQryExchangeMarginRateAdjust, int nRequestId);
		public delegate IntPtr DelegateReqQryExchangeRate(IntPtr api, ref CThostFtdcQryExchangeRateField pQryExchangeRate, int nRequestId);
		public delegate IntPtr DelegateReqQrySecAgentACIDMap(IntPtr api, ref CThostFtdcQrySecAgentACIDMapField pQrySecAgentACIdMap, int nRequestId);
		public delegate IntPtr DelegateReqQryProductExchRate(IntPtr api, ref CThostFtdcQryProductExchRateField pQryProductExchRate, int nRequestId);
		public delegate IntPtr DelegateReqQryProductGroup(IntPtr api, ref CThostFtdcQryProductGroupField pQryProductGroup, int nRequestId);
		public delegate IntPtr DelegateReqQryMMInstrumentCommissionRate(IntPtr api, ref CThostFtdcQryMMInstrumentCommissionRateField pQryMMInstrumentCommissionRate, int nRequestId);
		public delegate IntPtr DelegateReqQryMMOptionInstrCommRate(IntPtr api, ref CThostFtdcQryMMOptionInstrCommRateField pQryMMOptionInstrCommRate, int nRequestId);
		public delegate IntPtr DelegateReqQryInstrumentOrderCommRate(IntPtr api, ref CThostFtdcQryInstrumentOrderCommRateField pQryInstrumentOrderCommRate, int nRequestId);
		public delegate IntPtr DelegateReqQrySecAgentTradingAccount(IntPtr api, ref CThostFtdcQryTradingAccountField pQryTradingAccount, int nRequestId);
		public delegate IntPtr DelegateReqQrySecAgentCheckMode(IntPtr api, ref CThostFtdcQrySecAgentCheckModeField pQrySecAgentCheckMode, int nRequestId);
		public delegate IntPtr DelegateReqQryOptionInstrTradeCost(IntPtr api, ref CThostFtdcQryOptionInstrTradeCostField pQryOptionInstrTradeCost, int nRequestId);
		public delegate IntPtr DelegateReqQryOptionInstrCommRate(IntPtr api, ref CThostFtdcQryOptionInstrCommRateField pQryOptionInstrCommRate, int nRequestId);
		public delegate IntPtr DelegateReqQryExecOrder(IntPtr api, ref CThostFtdcQryExecOrderField pQryExecOrder, int nRequestId);
		public delegate IntPtr DelegateReqQryForQuote(IntPtr api, ref CThostFtdcQryForQuoteField pQryForQuote, int nRequestId);
		public delegate IntPtr DelegateReqQryQuote(IntPtr api, ref CThostFtdcQryQuoteField pQryQuote, int nRequestId);
		public delegate IntPtr DelegateReqQryOptionSelfClose(IntPtr api, ref CThostFtdcQryOptionSelfCloseField pQryOptionSelfClose, int nRequestId);
		public delegate IntPtr DelegateReqQryInvestUnit(IntPtr api, ref CThostFtdcQryInvestUnitField pQryInvestUnit, int nRequestId);
		public delegate IntPtr DelegateReqQryCombInstrumentGuard(IntPtr api, ref CThostFtdcQryCombInstrumentGuardField pQryCombInstrumentGuard, int nRequestId);
		public delegate IntPtr DelegateReqQryCombAction(IntPtr api, ref CThostFtdcQryCombActionField pQryCombAction, int nRequestId);
		public delegate IntPtr DelegateReqQryTransferSerial(IntPtr api, ref CThostFtdcQryTransferSerialField pQryTransferSerial, int nRequestId);
		public delegate IntPtr DelegateReqQryAccountregister(IntPtr api, ref CThostFtdcQryAccountregisterField pQryAccountregister, int nRequestId);
		public delegate IntPtr DelegateReqQryContractBank(IntPtr api, ref CThostFtdcQryContractBankField pQryContractBank, int nRequestId);
		public delegate IntPtr DelegateReqQryParkedOrder(IntPtr api, ref CThostFtdcQryParkedOrderField pQryParkedOrder, int nRequestId);
		public delegate IntPtr DelegateReqQryParkedOrderAction(IntPtr api, ref CThostFtdcQryParkedOrderActionField pQryParkedOrderAction, int nRequestId);
		public delegate IntPtr DelegateReqQryTradingNotice(IntPtr api, ref CThostFtdcQryTradingNoticeField pQryTradingNotice, int nRequestId);
		public delegate IntPtr DelegateReqQryBrokerTradingParams(IntPtr api, ref CThostFtdcQryBrokerTradingParamsField pQryBrokerTradingParams, int nRequestId);
		public delegate IntPtr DelegateReqQryBrokerTradingAlgos(IntPtr api, ref CThostFtdcQryBrokerTradingAlgosField pQryBrokerTradingAlgos, int nRequestId);
		public delegate IntPtr DelegateReqQueryCFMMCTradingAccountToken(IntPtr api, ref CThostFtdcQueryCFMMCTradingAccountTokenField pQueryCFMMCTradingAccountToken, int nRequestId);
		public delegate IntPtr DelegateReqFromBankToFutureByFuture(IntPtr api, ref CThostFtdcReqTransferField pReqTransfer, int nRequestId);
		public delegate IntPtr DelegateReqFromFutureToBankByFuture(IntPtr api, ref CThostFtdcReqTransferField pReqTransfer, int nRequestId);
		public delegate IntPtr DelegateReqQueryBankAccountMoneyByFuture(IntPtr api, ref CThostFtdcReqQueryAccountField pReqQueryAccount, int nRequestId);

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

		public IntPtr SubscribePrivateTopic(THOST_TE_RESUME_TYPE nResumeType)
		{
			return ((DelegateSubscribePrivateTopic)loader.Invoke("SubscribePrivateTopic", typeof(DelegateSubscribePrivateTopic)))(_api, nResumeType);
		}

		public IntPtr SubscribePublicTopic(THOST_TE_RESUME_TYPE nResumeType)
		{
			return ((DelegateSubscribePublicTopic)loader.Invoke("SubscribePublicTopic", typeof(DelegateSubscribePublicTopic)))(_api, nResumeType);
		}

		public IntPtr ReqAuthenticate(string brokerId = "", string userId = "", string userProductInfo = "", string authCode = "")
		{
            
			CThostFtdcReqAuthenticateField struc = new CThostFtdcReqAuthenticateField
			{
				BrokerID = brokerId,
				UserID = userId,
				UserProductInfo = userProductInfo,
				AuthCode = authCode,
			};
			return ((DelegateReqAuthenticate)loader.Invoke("ReqAuthenticate", typeof(DelegateReqAuthenticate)))(_api, ref struc, nRequestId++);
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

		public IntPtr ReqUserPasswordUpdate(string brokerId = "", string userId = "", string oldPassword = "", string newPassword = "")
		{
            
			CThostFtdcUserPasswordUpdateField struc = new CThostFtdcUserPasswordUpdateField
			{
				BrokerID = brokerId,
				UserID = userId,
				OldPassword = oldPassword,
				NewPassword = newPassword,
			};
			return ((DelegateReqUserPasswordUpdate)loader.Invoke("ReqUserPasswordUpdate", typeof(DelegateReqUserPasswordUpdate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqTradingAccountPasswordUpdate(string brokerId = "", string accountId = "", string oldPassword = "", string newPassword = "", string currencyId = "")
		{
            
			CThostFtdcTradingAccountPasswordUpdateField struc = new CThostFtdcTradingAccountPasswordUpdateField
			{
				BrokerID = brokerId,
				AccountID = accountId,
				OldPassword = oldPassword,
				NewPassword = newPassword,
				CurrencyID = currencyId,
			};
			return ((DelegateReqTradingAccountPasswordUpdate)loader.Invoke("ReqTradingAccountPasswordUpdate", typeof(DelegateReqTradingAccountPasswordUpdate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqUserLogin2(string tradingDay = "", string brokerId = "", string userId = "", string password = "", string userProductInfo = "", string interfaceProductInfo = "", string protocolInfo = "", string macAddress = "", string oneTimePassword = "", string clientIPAddress = "", string loginRemark = "")
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
			return ((DelegateReqUserLogin2)loader.Invoke("ReqUserLogin2", typeof(DelegateReqUserLogin2)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqUserPasswordUpdate2(string brokerId = "", string userId = "", string oldPassword = "", string newPassword = "")
		{
            
			CThostFtdcUserPasswordUpdateField struc = new CThostFtdcUserPasswordUpdateField
			{
				BrokerID = brokerId,
				UserID = userId,
				OldPassword = oldPassword,
				NewPassword = newPassword,
			};
			return ((DelegateReqUserPasswordUpdate2)loader.Invoke("ReqUserPasswordUpdate2", typeof(DelegateReqUserPasswordUpdate2)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqOrderInsert(string brokerId = "", string investorId = "", string instrumentId = "", string orderRef = "", string userId = "", TThostFtdcOrderPriceTypeType orderPriceType = TThostFtdcOrderPriceTypeType.THOST_FTDC_OPT_AnyPrice, TThostFtdcDirectionType direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy, string combOffsetFlag = "", string combHedgeFlag = "", double limitPrice = 0, int volumeTotalOriginal = 0, TThostFtdcTimeConditionType timeCondition = TThostFtdcTimeConditionType.THOST_FTDC_TC_IOC, string gTDDate = "", TThostFtdcVolumeConditionType volumeCondition = TThostFtdcVolumeConditionType.THOST_FTDC_VC_AV, int minVolume = 0, TThostFtdcContingentConditionType contingentCondition = TThostFtdcContingentConditionType.THOST_FTDC_CC_Immediately, double stopPrice = 0, TThostFtdcForceCloseReasonType forceCloseReason = TThostFtdcForceCloseReasonType.THOST_FTDC_FCC_NotForceClose, int isAutoSuspend = 0, string businessUnit = "", int requestId = 0, int userForceClose = 0, int isSwapOrder = 0, string exchangeId = "", string investUnitId = "", string accountId = "", string currencyId = "", string clientId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputOrderField struc = new CThostFtdcInputOrderField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				OrderRef = orderRef,
				UserID = userId,
				OrderPriceType = orderPriceType,
				Direction = direction,
				CombOffsetFlag = combOffsetFlag,
				CombHedgeFlag = combHedgeFlag,
				LimitPrice = limitPrice,
				VolumeTotalOriginal = volumeTotalOriginal,
				TimeCondition = timeCondition,
				GTDDate = gTDDate,
				VolumeCondition = volumeCondition,
				MinVolume = minVolume,
				ContingentCondition = contingentCondition,
				StopPrice = stopPrice,
				ForceCloseReason = forceCloseReason,
				IsAutoSuspend = isAutoSuspend,
				BusinessUnit = businessUnit,
				RequestID = requestId,
				UserForceClose = userForceClose,
				IsSwapOrder = isSwapOrder,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
				AccountID = accountId,
				CurrencyID = currencyId,
				ClientID = clientId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqOrderInsert)loader.Invoke("ReqOrderInsert", typeof(DelegateReqOrderInsert)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqParkedOrderInsert(string brokerId = "", string investorId = "", string instrumentId = "", string orderRef = "", string userId = "", TThostFtdcOrderPriceTypeType orderPriceType = TThostFtdcOrderPriceTypeType.THOST_FTDC_OPT_AnyPrice, TThostFtdcDirectionType direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy, string combOffsetFlag = "", string combHedgeFlag = "", double limitPrice = 0, int volumeTotalOriginal = 0, TThostFtdcTimeConditionType timeCondition = TThostFtdcTimeConditionType.THOST_FTDC_TC_IOC, string gTDDate = "", TThostFtdcVolumeConditionType volumeCondition = TThostFtdcVolumeConditionType.THOST_FTDC_VC_AV, int minVolume = 0, TThostFtdcContingentConditionType contingentCondition = TThostFtdcContingentConditionType.THOST_FTDC_CC_Immediately, double stopPrice = 0, TThostFtdcForceCloseReasonType forceCloseReason = TThostFtdcForceCloseReasonType.THOST_FTDC_FCC_NotForceClose, int isAutoSuspend = 0, string businessUnit = "", int requestId = 0, int userForceClose = 0, string exchangeId = "", string parkedOrderId = "", TThostFtdcUserTypeType userType = TThostFtdcUserTypeType.THOST_FTDC_UT_Investor, TThostFtdcParkedOrderStatusType status = TThostFtdcParkedOrderStatusType.THOST_FTDC_PAOS_NotSend, int errorId = 0, string errorMsg = "", int isSwapOrder = 0, string accountId = "", string currencyId = "", string clientId = "", string investUnitId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcParkedOrderField struc = new CThostFtdcParkedOrderField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				OrderRef = orderRef,
				UserID = userId,
				OrderPriceType = orderPriceType,
				Direction = direction,
				CombOffsetFlag = combOffsetFlag,
				CombHedgeFlag = combHedgeFlag,
				LimitPrice = limitPrice,
				VolumeTotalOriginal = volumeTotalOriginal,
				TimeCondition = timeCondition,
				GTDDate = gTDDate,
				VolumeCondition = volumeCondition,
				MinVolume = minVolume,
				ContingentCondition = contingentCondition,
				StopPrice = stopPrice,
				ForceCloseReason = forceCloseReason,
				IsAutoSuspend = isAutoSuspend,
				BusinessUnit = businessUnit,
				RequestID = requestId,
				UserForceClose = userForceClose,
				ExchangeID = exchangeId,
				ParkedOrderID = parkedOrderId,
				UserType = userType,
				Status = status,
				ErrorID = errorId,
				ErrorMsg = errorMsg,
				IsSwapOrder = isSwapOrder,
				AccountID = accountId,
				CurrencyID = currencyId,
				ClientID = clientId,
				InvestUnitID = investUnitId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqParkedOrderInsert)loader.Invoke("ReqParkedOrderInsert", typeof(DelegateReqParkedOrderInsert)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqParkedOrderAction(string brokerId = "", string investorId = "", int orderActionRef = 0, string orderRef = "", int requestId = 0, int frontId = 0, int sessionId = 0, string exchangeId = "", string orderSysId = "", TThostFtdcActionFlagType actionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, double limitPrice = 0, int volumeChange = 0, string userId = "", string instrumentId = "", string parkedOrderActionId = "", TThostFtdcUserTypeType userType = TThostFtdcUserTypeType.THOST_FTDC_UT_Investor, TThostFtdcParkedOrderStatusType status = TThostFtdcParkedOrderStatusType.THOST_FTDC_PAOS_NotSend, int errorId = 0, string errorMsg = "", string investUnitId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcParkedOrderActionField struc = new CThostFtdcParkedOrderActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				OrderActionRef = orderActionRef,
				OrderRef = orderRef,
				RequestID = requestId,
				FrontID = frontId,
				SessionID = sessionId,
				ExchangeID = exchangeId,
				OrderSysID = orderSysId,
				ActionFlag = actionFlag,
				LimitPrice = limitPrice,
				VolumeChange = volumeChange,
				UserID = userId,
				InstrumentID = instrumentId,
				ParkedOrderActionID = parkedOrderActionId,
				UserType = userType,
				Status = status,
				ErrorID = errorId,
				ErrorMsg = errorMsg,
				InvestUnitID = investUnitId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqParkedOrderAction)loader.Invoke("ReqParkedOrderAction", typeof(DelegateReqParkedOrderAction)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqOrderAction(string brokerId = "", string investorId = "", int orderActionRef = 0, string orderRef = "", int requestId = 0, int frontId = 0, int sessionId = 0, string exchangeId = "", string orderSysId = "", TThostFtdcActionFlagType actionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, double limitPrice = 0, int volumeChange = 0, string userId = "", string instrumentId = "", string investUnitId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputOrderActionField struc = new CThostFtdcInputOrderActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				OrderActionRef = orderActionRef,
				OrderRef = orderRef,
				RequestID = requestId,
				FrontID = frontId,
				SessionID = sessionId,
				ExchangeID = exchangeId,
				OrderSysID = orderSysId,
				ActionFlag = actionFlag,
				LimitPrice = limitPrice,
				VolumeChange = volumeChange,
				UserID = userId,
				InstrumentID = instrumentId,
				InvestUnitID = investUnitId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqOrderAction)loader.Invoke("ReqOrderAction", typeof(DelegateReqOrderAction)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQueryMaxOrderVolume(string brokerId = "", string investorId = "", string instrumentId = "", TThostFtdcDirectionType direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy, TThostFtdcOffsetFlagType offsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open, TThostFtdcHedgeFlagType hedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, int maxVolume = 0, string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQueryMaxOrderVolumeField struc = new CThostFtdcQueryMaxOrderVolumeField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				Direction = direction,
				OffsetFlag = offsetFlag,
				HedgeFlag = hedgeFlag,
				MaxVolume = maxVolume,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQueryMaxOrderVolume)loader.Invoke("ReqQueryMaxOrderVolume", typeof(DelegateReqQueryMaxOrderVolume)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqSettlementInfoConfirm(string brokerId = "", string investorId = "", string confirmDate = "", string confirmTime = "", int settlementId = 0, string accountId = "", string currencyId = "")
		{
            
			CThostFtdcSettlementInfoConfirmField struc = new CThostFtdcSettlementInfoConfirmField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				ConfirmDate = confirmDate,
				ConfirmTime = confirmTime,
				SettlementID = settlementId,
				AccountID = accountId,
				CurrencyID = currencyId,
			};
			return ((DelegateReqSettlementInfoConfirm)loader.Invoke("ReqSettlementInfoConfirm", typeof(DelegateReqSettlementInfoConfirm)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqRemoveParkedOrder(string brokerId = "", string investorId = "", string parkedOrderId = "", string investUnitId = "")
		{
            
			CThostFtdcRemoveParkedOrderField struc = new CThostFtdcRemoveParkedOrderField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				ParkedOrderID = parkedOrderId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqRemoveParkedOrder)loader.Invoke("ReqRemoveParkedOrder", typeof(DelegateReqRemoveParkedOrder)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqRemoveParkedOrderAction(string brokerId = "", string investorId = "", string parkedOrderActionId = "", string investUnitId = "")
		{
            
			CThostFtdcRemoveParkedOrderActionField struc = new CThostFtdcRemoveParkedOrderActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				ParkedOrderActionID = parkedOrderActionId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqRemoveParkedOrderAction)loader.Invoke("ReqRemoveParkedOrderAction", typeof(DelegateReqRemoveParkedOrderAction)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqExecOrderInsert(string brokerId = "", string investorId = "", string instrumentId = "", string execOrderRef = "", string userId = "", int volume = 0, int requestId = 0, string businessUnit = "", TThostFtdcOffsetFlagType offsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open, TThostFtdcHedgeFlagType hedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, TThostFtdcActionTypeType actionType = TThostFtdcActionTypeType.THOST_FTDC_ACTP_Exec, TThostFtdcPosiDirectionType posiDirection = TThostFtdcPosiDirectionType.THOST_FTDC_PD_Net, TThostFtdcExecOrderPositionFlagType reservePositionFlag = TThostFtdcExecOrderPositionFlagType.THOST_FTDC_EOPF_Reserve, TThostFtdcExecOrderCloseFlagType closeFlag = TThostFtdcExecOrderCloseFlagType.THOST_FTDC_EOCF_AutoClose, string exchangeId = "", string investUnitId = "", string accountId = "", string currencyId = "", string clientId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputExecOrderField struc = new CThostFtdcInputExecOrderField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExecOrderRef = execOrderRef,
				UserID = userId,
				Volume = volume,
				RequestID = requestId,
				BusinessUnit = businessUnit,
				OffsetFlag = offsetFlag,
				HedgeFlag = hedgeFlag,
				ActionType = actionType,
				PosiDirection = posiDirection,
				ReservePositionFlag = reservePositionFlag,
				CloseFlag = closeFlag,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
				AccountID = accountId,
				CurrencyID = currencyId,
				ClientID = clientId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqExecOrderInsert)loader.Invoke("ReqExecOrderInsert", typeof(DelegateReqExecOrderInsert)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqExecOrderAction(string brokerId = "", string investorId = "", int execOrderActionRef = 0, string execOrderRef = "", int requestId = 0, int frontId = 0, int sessionId = 0, string exchangeId = "", string execOrderSysId = "", TThostFtdcActionFlagType actionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, string userId = "", string instrumentId = "", string investUnitId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputExecOrderActionField struc = new CThostFtdcInputExecOrderActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				ExecOrderActionRef = execOrderActionRef,
				ExecOrderRef = execOrderRef,
				RequestID = requestId,
				FrontID = frontId,
				SessionID = sessionId,
				ExchangeID = exchangeId,
				ExecOrderSysID = execOrderSysId,
				ActionFlag = actionFlag,
				UserID = userId,
				InstrumentID = instrumentId,
				InvestUnitID = investUnitId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqExecOrderAction)loader.Invoke("ReqExecOrderAction", typeof(DelegateReqExecOrderAction)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqForQuoteInsert(string brokerId = "", string investorId = "", string instrumentId = "", string forQuoteRef = "", string userId = "", string exchangeId = "", string investUnitId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputForQuoteField struc = new CThostFtdcInputForQuoteField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ForQuoteRef = forQuoteRef,
				UserID = userId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqForQuoteInsert)loader.Invoke("ReqForQuoteInsert", typeof(DelegateReqForQuoteInsert)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQuoteInsert(string brokerId = "", string investorId = "", string instrumentId = "", string quoteRef = "", string userId = "", double askPrice = 0, double bidPrice = 0, int askVolume = 0, int bidVolume = 0, int requestId = 0, string businessUnit = "", TThostFtdcOffsetFlagType askOffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open, TThostFtdcOffsetFlagType bidOffsetFlag = TThostFtdcOffsetFlagType.THOST_FTDC_OF_Open, TThostFtdcHedgeFlagType askHedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, TThostFtdcHedgeFlagType bidHedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string askOrderRef = "", string bidOrderRef = "", string forQuoteSysId = "", string exchangeId = "", string investUnitId = "", string clientId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputQuoteField struc = new CThostFtdcInputQuoteField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				QuoteRef = quoteRef,
				UserID = userId,
				AskPrice = askPrice,
				BidPrice = bidPrice,
				AskVolume = askVolume,
				BidVolume = bidVolume,
				RequestID = requestId,
				BusinessUnit = businessUnit,
				AskOffsetFlag = askOffsetFlag,
				BidOffsetFlag = bidOffsetFlag,
				AskHedgeFlag = askHedgeFlag,
				BidHedgeFlag = bidHedgeFlag,
				AskOrderRef = askOrderRef,
				BidOrderRef = bidOrderRef,
				ForQuoteSysID = forQuoteSysId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
				ClientID = clientId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqQuoteInsert)loader.Invoke("ReqQuoteInsert", typeof(DelegateReqQuoteInsert)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQuoteAction(string brokerId = "", string investorId = "", int quoteActionRef = 0, string quoteRef = "", int requestId = 0, int frontId = 0, int sessionId = 0, string exchangeId = "", string quoteSysId = "", TThostFtdcActionFlagType actionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, string userId = "", string instrumentId = "", string investUnitId = "", string clientId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputQuoteActionField struc = new CThostFtdcInputQuoteActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				QuoteActionRef = quoteActionRef,
				QuoteRef = quoteRef,
				RequestID = requestId,
				FrontID = frontId,
				SessionID = sessionId,
				ExchangeID = exchangeId,
				QuoteSysID = quoteSysId,
				ActionFlag = actionFlag,
				UserID = userId,
				InstrumentID = instrumentId,
				InvestUnitID = investUnitId,
				ClientID = clientId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqQuoteAction)loader.Invoke("ReqQuoteAction", typeof(DelegateReqQuoteAction)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqBatchOrderAction(string brokerId = "", string investorId = "", int orderActionRef = 0, int requestId = 0, int frontId = 0, int sessionId = 0, string exchangeId = "", string userId = "", string investUnitId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputBatchOrderActionField struc = new CThostFtdcInputBatchOrderActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				OrderActionRef = orderActionRef,
				RequestID = requestId,
				FrontID = frontId,
				SessionID = sessionId,
				ExchangeID = exchangeId,
				UserID = userId,
				InvestUnitID = investUnitId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqBatchOrderAction)loader.Invoke("ReqBatchOrderAction", typeof(DelegateReqBatchOrderAction)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqOptionSelfCloseInsert(string brokerId = "", string investorId = "", string instrumentId = "", string optionSelfCloseRef = "", string userId = "", int volume = 0, int requestId = 0, string businessUnit = "", TThostFtdcHedgeFlagType hedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, TThostFtdcOptSelfCloseFlagType optSelfCloseFlag = TThostFtdcOptSelfCloseFlagType.THOST_FTDC_OSCF_CloseSelfOptionPosition, string exchangeId = "", string investUnitId = "", string accountId = "", string currencyId = "", string clientId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputOptionSelfCloseField struc = new CThostFtdcInputOptionSelfCloseField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				OptionSelfCloseRef = optionSelfCloseRef,
				UserID = userId,
				Volume = volume,
				RequestID = requestId,
				BusinessUnit = businessUnit,
				HedgeFlag = hedgeFlag,
				OptSelfCloseFlag = optSelfCloseFlag,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
				AccountID = accountId,
				CurrencyID = currencyId,
				ClientID = clientId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqOptionSelfCloseInsert)loader.Invoke("ReqOptionSelfCloseInsert", typeof(DelegateReqOptionSelfCloseInsert)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqOptionSelfCloseAction(string brokerId = "", string investorId = "", int optionSelfCloseActionRef = 0, string optionSelfCloseRef = "", int requestId = 0, int frontId = 0, int sessionId = 0, string exchangeId = "", string optionSelfCloseSysId = "", TThostFtdcActionFlagType actionFlag = TThostFtdcActionFlagType.THOST_FTDC_AF_Delete, string userId = "", string instrumentId = "", string investUnitId = "", string iPAddress = "", string macAddress = "")
		{
            
			CThostFtdcInputOptionSelfCloseActionField struc = new CThostFtdcInputOptionSelfCloseActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				OptionSelfCloseActionRef = optionSelfCloseActionRef,
				OptionSelfCloseRef = optionSelfCloseRef,
				RequestID = requestId,
				FrontID = frontId,
				SessionID = sessionId,
				ExchangeID = exchangeId,
				OptionSelfCloseSysID = optionSelfCloseSysId,
				ActionFlag = actionFlag,
				UserID = userId,
				InstrumentID = instrumentId,
				InvestUnitID = investUnitId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
			};
			return ((DelegateReqOptionSelfCloseAction)loader.Invoke("ReqOptionSelfCloseAction", typeof(DelegateReqOptionSelfCloseAction)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqCombActionInsert(string brokerId = "", string investorId = "", string instrumentId = "", string combActionRef = "", string userId = "", TThostFtdcDirectionType direction = TThostFtdcDirectionType.THOST_FTDC_D_Buy, int volume = 0, TThostFtdcCombDirectionType combDirection = TThostFtdcCombDirectionType.THOST_FTDC_CMDR_Comb, TThostFtdcHedgeFlagType hedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string exchangeId = "", string iPAddress = "", string macAddress = "", string investUnitId = "")
		{
            
			CThostFtdcInputCombActionField struc = new CThostFtdcInputCombActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				CombActionRef = combActionRef,
				UserID = userId,
				Direction = direction,
				Volume = volume,
				CombDirection = combDirection,
				HedgeFlag = hedgeFlag,
				ExchangeID = exchangeId,
				IPAddress = iPAddress,
				MacAddress = macAddress,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqCombActionInsert)loader.Invoke("ReqCombActionInsert", typeof(DelegateReqCombActionInsert)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryOrder(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string orderSysId = "", string insertTimeStart = "", string insertTimeEnd = "", string investUnitId = "")
		{
            
			CThostFtdcQryOrderField struc = new CThostFtdcQryOrderField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				OrderSysID = orderSysId,
				InsertTimeStart = insertTimeStart,
				InsertTimeEnd = insertTimeEnd,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryOrder)loader.Invoke("ReqQryOrder", typeof(DelegateReqQryOrder)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryTrade(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string tradeId = "", string tradeTimeStart = "", string tradeTimeEnd = "", string investUnitId = "")
		{
            
			CThostFtdcQryTradeField struc = new CThostFtdcQryTradeField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				TradeID = tradeId,
				TradeTimeStart = tradeTimeStart,
				TradeTimeEnd = tradeTimeEnd,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryTrade)loader.Invoke("ReqQryTrade", typeof(DelegateReqQryTrade)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInvestorPosition(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryInvestorPositionField struc = new CThostFtdcQryInvestorPositionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryInvestorPosition)loader.Invoke("ReqQryInvestorPosition", typeof(DelegateReqQryInvestorPosition)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryTradingAccount(string brokerId = "", string investorId = "", string currencyId = "", TThostFtdcBizTypeType bizType = TThostFtdcBizTypeType.THOST_FTDC_BZTP_Future, string accountId = "")
		{
            
			CThostFtdcQryTradingAccountField struc = new CThostFtdcQryTradingAccountField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				CurrencyID = currencyId,
				BizType = bizType,
				AccountID = accountId,
			};
			return ((DelegateReqQryTradingAccount)loader.Invoke("ReqQryTradingAccount", typeof(DelegateReqQryTradingAccount)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInvestor(string brokerId = "", string investorId = "")
		{
            
			CThostFtdcQryInvestorField struc = new CThostFtdcQryInvestorField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
			};
			return ((DelegateReqQryInvestor)loader.Invoke("ReqQryInvestor", typeof(DelegateReqQryInvestor)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryTradingCode(string brokerId = "", string investorId = "", string exchangeId = "", string clientId = "", TThostFtdcClientIDTypeType clientIdType = TThostFtdcClientIDTypeType.THOST_FTDC_CIDT_Speculation, string investUnitId = "")
		{
            
			CThostFtdcQryTradingCodeField struc = new CThostFtdcQryTradingCodeField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				ExchangeID = exchangeId,
				ClientID = clientId,
				ClientIDType = clientIdType,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryTradingCode)loader.Invoke("ReqQryTradingCode", typeof(DelegateReqQryTradingCode)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInstrumentMarginRate(string brokerId = "", string investorId = "", string instrumentId = "", TThostFtdcHedgeFlagType hedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryInstrumentMarginRateField struc = new CThostFtdcQryInstrumentMarginRateField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				HedgeFlag = hedgeFlag,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryInstrumentMarginRate)loader.Invoke("ReqQryInstrumentMarginRate", typeof(DelegateReqQryInstrumentMarginRate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInstrumentCommissionRate(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryInstrumentCommissionRateField struc = new CThostFtdcQryInstrumentCommissionRateField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryInstrumentCommissionRate)loader.Invoke("ReqQryInstrumentCommissionRate", typeof(DelegateReqQryInstrumentCommissionRate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryExchange(string exchangeId = "")
		{
            
			CThostFtdcQryExchangeField struc = new CThostFtdcQryExchangeField
			{
				ExchangeID = exchangeId,
			};
			return ((DelegateReqQryExchange)loader.Invoke("ReqQryExchange", typeof(DelegateReqQryExchange)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryProduct(string productId = "", TThostFtdcProductClassType productClass = TThostFtdcProductClassType.THOST_FTDC_PC_Futures, string exchangeId = "")
		{
            
			CThostFtdcQryProductField struc = new CThostFtdcQryProductField
			{
				ProductID = productId,
				ProductClass = productClass,
				ExchangeID = exchangeId,
			};
			return ((DelegateReqQryProduct)loader.Invoke("ReqQryProduct", typeof(DelegateReqQryProduct)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInstrument(string instrumentId = "", string exchangeId = "", string exchangeInstId = "", string productId = "")
		{
            
			CThostFtdcQryInstrumentField struc = new CThostFtdcQryInstrumentField
			{
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				ExchangeInstID = exchangeInstId,
				ProductID = productId,
			};
			return ((DelegateReqQryInstrument)loader.Invoke("ReqQryInstrument", typeof(DelegateReqQryInstrument)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryDepthMarketData(string instrumentId = "", string exchangeId = "")
		{
            
			CThostFtdcQryDepthMarketDataField struc = new CThostFtdcQryDepthMarketDataField
			{
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
			};
			return ((DelegateReqQryDepthMarketData)loader.Invoke("ReqQryDepthMarketData", typeof(DelegateReqQryDepthMarketData)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQrySettlementInfo(string brokerId = "", string investorId = "", string tradingDay = "", string accountId = "", string currencyId = "")
		{
            
			CThostFtdcQrySettlementInfoField struc = new CThostFtdcQrySettlementInfoField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				TradingDay = tradingDay,
				AccountID = accountId,
				CurrencyID = currencyId,
			};
			return ((DelegateReqQrySettlementInfo)loader.Invoke("ReqQrySettlementInfo", typeof(DelegateReqQrySettlementInfo)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryTransferBank(string bankId = "", string bankBrchId = "")
		{
            
			CThostFtdcQryTransferBankField struc = new CThostFtdcQryTransferBankField
			{
				BankID = bankId,
				BankBrchID = bankBrchId,
			};
			return ((DelegateReqQryTransferBank)loader.Invoke("ReqQryTransferBank", typeof(DelegateReqQryTransferBank)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInvestorPositionDetail(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryInvestorPositionDetailField struc = new CThostFtdcQryInvestorPositionDetailField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryInvestorPositionDetail)loader.Invoke("ReqQryInvestorPositionDetail", typeof(DelegateReqQryInvestorPositionDetail)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryNotice(string brokerId = "")
		{
            
			CThostFtdcQryNoticeField struc = new CThostFtdcQryNoticeField
			{
				BrokerID = brokerId,
			};
			return ((DelegateReqQryNotice)loader.Invoke("ReqQryNotice", typeof(DelegateReqQryNotice)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQrySettlementInfoConfirm(string brokerId = "", string investorId = "", string accountId = "", string currencyId = "")
		{
            
			CThostFtdcQrySettlementInfoConfirmField struc = new CThostFtdcQrySettlementInfoConfirmField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				AccountID = accountId,
				CurrencyID = currencyId,
			};
			return ((DelegateReqQrySettlementInfoConfirm)loader.Invoke("ReqQrySettlementInfoConfirm", typeof(DelegateReqQrySettlementInfoConfirm)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInvestorPositionCombineDetail(string brokerId = "", string investorId = "", string combInstrumentId = "", string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryInvestorPositionCombineDetailField struc = new CThostFtdcQryInvestorPositionCombineDetailField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				CombInstrumentID = combInstrumentId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryInvestorPositionCombineDetail)loader.Invoke("ReqQryInvestorPositionCombineDetail", typeof(DelegateReqQryInvestorPositionCombineDetail)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryCFMMCTradingAccountKey(string brokerId = "", string investorId = "")
		{
            
			CThostFtdcQryCFMMCTradingAccountKeyField struc = new CThostFtdcQryCFMMCTradingAccountKeyField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
			};
			return ((DelegateReqQryCFMMCTradingAccountKey)loader.Invoke("ReqQryCFMMCTradingAccountKey", typeof(DelegateReqQryCFMMCTradingAccountKey)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryEWarrantOffset(string brokerId = "", string investorId = "", string exchangeId = "", string instrumentId = "", string investUnitId = "")
		{
            
			CThostFtdcQryEWarrantOffsetField struc = new CThostFtdcQryEWarrantOffsetField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				ExchangeID = exchangeId,
				InstrumentID = instrumentId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryEWarrantOffset)loader.Invoke("ReqQryEWarrantOffset", typeof(DelegateReqQryEWarrantOffset)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInvestorProductGroupMargin(string brokerId = "", string investorId = "", string productGroupId = "", TThostFtdcHedgeFlagType hedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryInvestorProductGroupMarginField struc = new CThostFtdcQryInvestorProductGroupMarginField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				ProductGroupID = productGroupId,
				HedgeFlag = hedgeFlag,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryInvestorProductGroupMargin)loader.Invoke("ReqQryInvestorProductGroupMargin", typeof(DelegateReqQryInvestorProductGroupMargin)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryExchangeMarginRate(string brokerId = "", string instrumentId = "", TThostFtdcHedgeFlagType hedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, string exchangeId = "")
		{
            
			CThostFtdcQryExchangeMarginRateField struc = new CThostFtdcQryExchangeMarginRateField
			{
				BrokerID = brokerId,
				InstrumentID = instrumentId,
				HedgeFlag = hedgeFlag,
				ExchangeID = exchangeId,
			};
			return ((DelegateReqQryExchangeMarginRate)loader.Invoke("ReqQryExchangeMarginRate", typeof(DelegateReqQryExchangeMarginRate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryExchangeMarginRateAdjust(string brokerId = "", string instrumentId = "", TThostFtdcHedgeFlagType hedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation)
		{
            
			CThostFtdcQryExchangeMarginRateAdjustField struc = new CThostFtdcQryExchangeMarginRateAdjustField
			{
				BrokerID = brokerId,
				InstrumentID = instrumentId,
				HedgeFlag = hedgeFlag,
			};
			return ((DelegateReqQryExchangeMarginRateAdjust)loader.Invoke("ReqQryExchangeMarginRateAdjust", typeof(DelegateReqQryExchangeMarginRateAdjust)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryExchangeRate(string brokerId = "", string fromCurrencyId = "", string toCurrencyId = "")
		{
            
			CThostFtdcQryExchangeRateField struc = new CThostFtdcQryExchangeRateField
			{
				BrokerID = brokerId,
				FromCurrencyID = fromCurrencyId,
				ToCurrencyID = toCurrencyId,
			};
			return ((DelegateReqQryExchangeRate)loader.Invoke("ReqQryExchangeRate", typeof(DelegateReqQryExchangeRate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQrySecAgentACIDMap(string brokerId = "", string userId = "", string accountId = "", string currencyId = "")
		{
            
			CThostFtdcQrySecAgentACIDMapField struc = new CThostFtdcQrySecAgentACIDMapField
			{
				BrokerID = brokerId,
				UserID = userId,
				AccountID = accountId,
				CurrencyID = currencyId,
			};
			return ((DelegateReqQrySecAgentACIDMap)loader.Invoke("ReqQrySecAgentACIDMap", typeof(DelegateReqQrySecAgentACIDMap)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryProductExchRate(string productId = "", string exchangeId = "")
		{
            
			CThostFtdcQryProductExchRateField struc = new CThostFtdcQryProductExchRateField
			{
				ProductID = productId,
				ExchangeID = exchangeId,
			};
			return ((DelegateReqQryProductExchRate)loader.Invoke("ReqQryProductExchRate", typeof(DelegateReqQryProductExchRate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryProductGroup(string productId = "", string exchangeId = "")
		{
            
			CThostFtdcQryProductGroupField struc = new CThostFtdcQryProductGroupField
			{
				ProductID = productId,
				ExchangeID = exchangeId,
			};
			return ((DelegateReqQryProductGroup)loader.Invoke("ReqQryProductGroup", typeof(DelegateReqQryProductGroup)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryMMInstrumentCommissionRate(string brokerId = "", string investorId = "", string instrumentId = "")
		{
            
			CThostFtdcQryMMInstrumentCommissionRateField struc = new CThostFtdcQryMMInstrumentCommissionRateField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
			};
			return ((DelegateReqQryMMInstrumentCommissionRate)loader.Invoke("ReqQryMMInstrumentCommissionRate", typeof(DelegateReqQryMMInstrumentCommissionRate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryMMOptionInstrCommRate(string brokerId = "", string investorId = "", string instrumentId = "")
		{
            
			CThostFtdcQryMMOptionInstrCommRateField struc = new CThostFtdcQryMMOptionInstrCommRateField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
			};
			return ((DelegateReqQryMMOptionInstrCommRate)loader.Invoke("ReqQryMMOptionInstrCommRate", typeof(DelegateReqQryMMOptionInstrCommRate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInstrumentOrderCommRate(string brokerId = "", string investorId = "", string instrumentId = "")
		{
            
			CThostFtdcQryInstrumentOrderCommRateField struc = new CThostFtdcQryInstrumentOrderCommRateField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
			};
			return ((DelegateReqQryInstrumentOrderCommRate)loader.Invoke("ReqQryInstrumentOrderCommRate", typeof(DelegateReqQryInstrumentOrderCommRate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQrySecAgentTradingAccount(string brokerId = "", string investorId = "", string currencyId = "", TThostFtdcBizTypeType bizType = TThostFtdcBizTypeType.THOST_FTDC_BZTP_Future, string accountId = "")
		{
            
			CThostFtdcQryTradingAccountField struc = new CThostFtdcQryTradingAccountField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				CurrencyID = currencyId,
				BizType = bizType,
				AccountID = accountId,
			};
			return ((DelegateReqQrySecAgentTradingAccount)loader.Invoke("ReqQrySecAgentTradingAccount", typeof(DelegateReqQrySecAgentTradingAccount)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQrySecAgentCheckMode(string brokerId = "", string investorId = "")
		{
            
			CThostFtdcQrySecAgentCheckModeField struc = new CThostFtdcQrySecAgentCheckModeField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
			};
			return ((DelegateReqQrySecAgentCheckMode)loader.Invoke("ReqQrySecAgentCheckMode", typeof(DelegateReqQrySecAgentCheckMode)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryOptionInstrTradeCost(string brokerId = "", string investorId = "", string instrumentId = "", TThostFtdcHedgeFlagType hedgeFlag = TThostFtdcHedgeFlagType.THOST_FTDC_HF_Speculation, double inputPrice = 0, double underlyingPrice = 0, string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryOptionInstrTradeCostField struc = new CThostFtdcQryOptionInstrTradeCostField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				HedgeFlag = hedgeFlag,
				InputPrice = inputPrice,
				UnderlyingPrice = underlyingPrice,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryOptionInstrTradeCost)loader.Invoke("ReqQryOptionInstrTradeCost", typeof(DelegateReqQryOptionInstrTradeCost)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryOptionInstrCommRate(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryOptionInstrCommRateField struc = new CThostFtdcQryOptionInstrCommRateField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryOptionInstrCommRate)loader.Invoke("ReqQryOptionInstrCommRate", typeof(DelegateReqQryOptionInstrCommRate)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryExecOrder(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string execOrderSysId = "", string insertTimeStart = "", string insertTimeEnd = "")
		{
            
			CThostFtdcQryExecOrderField struc = new CThostFtdcQryExecOrderField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				ExecOrderSysID = execOrderSysId,
				InsertTimeStart = insertTimeStart,
				InsertTimeEnd = insertTimeEnd,
			};
			return ((DelegateReqQryExecOrder)loader.Invoke("ReqQryExecOrder", typeof(DelegateReqQryExecOrder)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryForQuote(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string insertTimeStart = "", string insertTimeEnd = "", string investUnitId = "")
		{
            
			CThostFtdcQryForQuoteField struc = new CThostFtdcQryForQuoteField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				InsertTimeStart = insertTimeStart,
				InsertTimeEnd = insertTimeEnd,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryForQuote)loader.Invoke("ReqQryForQuote", typeof(DelegateReqQryForQuote)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryQuote(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string quoteSysId = "", string insertTimeStart = "", string insertTimeEnd = "", string investUnitId = "")
		{
            
			CThostFtdcQryQuoteField struc = new CThostFtdcQryQuoteField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				QuoteSysID = quoteSysId,
				InsertTimeStart = insertTimeStart,
				InsertTimeEnd = insertTimeEnd,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryQuote)loader.Invoke("ReqQryQuote", typeof(DelegateReqQryQuote)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryOptionSelfClose(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string optionSelfCloseSysId = "", string insertTimeStart = "", string insertTimeEnd = "")
		{
            
			CThostFtdcQryOptionSelfCloseField struc = new CThostFtdcQryOptionSelfCloseField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				OptionSelfCloseSysID = optionSelfCloseSysId,
				InsertTimeStart = insertTimeStart,
				InsertTimeEnd = insertTimeEnd,
			};
			return ((DelegateReqQryOptionSelfClose)loader.Invoke("ReqQryOptionSelfClose", typeof(DelegateReqQryOptionSelfClose)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryInvestUnit(string brokerId = "", string investorId = "", string investUnitId = "")
		{
            
			CThostFtdcQryInvestUnitField struc = new CThostFtdcQryInvestUnitField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryInvestUnit)loader.Invoke("ReqQryInvestUnit", typeof(DelegateReqQryInvestUnit)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryCombInstrumentGuard(string brokerId = "", string instrumentId = "", string exchangeId = "")
		{
            
			CThostFtdcQryCombInstrumentGuardField struc = new CThostFtdcQryCombInstrumentGuardField
			{
				BrokerID = brokerId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
			};
			return ((DelegateReqQryCombInstrumentGuard)loader.Invoke("ReqQryCombInstrumentGuard", typeof(DelegateReqQryCombInstrumentGuard)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryCombAction(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryCombActionField struc = new CThostFtdcQryCombActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryCombAction)loader.Invoke("ReqQryCombAction", typeof(DelegateReqQryCombAction)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryTransferSerial(string brokerId = "", string accountId = "", string bankId = "", string currencyId = "")
		{
            
			CThostFtdcQryTransferSerialField struc = new CThostFtdcQryTransferSerialField
			{
				BrokerID = brokerId,
				AccountID = accountId,
				BankID = bankId,
				CurrencyID = currencyId,
			};
			return ((DelegateReqQryTransferSerial)loader.Invoke("ReqQryTransferSerial", typeof(DelegateReqQryTransferSerial)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryAccountregister(string brokerId = "", string accountId = "", string bankId = "", string bankBranchId = "", string currencyId = "")
		{
            
			CThostFtdcQryAccountregisterField struc = new CThostFtdcQryAccountregisterField
			{
				BrokerID = brokerId,
				AccountID = accountId,
				BankID = bankId,
				BankBranchID = bankBranchId,
				CurrencyID = currencyId,
			};
			return ((DelegateReqQryAccountregister)loader.Invoke("ReqQryAccountregister", typeof(DelegateReqQryAccountregister)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryContractBank(string brokerId = "", string bankId = "", string bankBrchId = "")
		{
            
			CThostFtdcQryContractBankField struc = new CThostFtdcQryContractBankField
			{
				BrokerID = brokerId,
				BankID = bankId,
				BankBrchID = bankBrchId,
			};
			return ((DelegateReqQryContractBank)loader.Invoke("ReqQryContractBank", typeof(DelegateReqQryContractBank)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryParkedOrder(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryParkedOrderField struc = new CThostFtdcQryParkedOrderField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryParkedOrder)loader.Invoke("ReqQryParkedOrder", typeof(DelegateReqQryParkedOrder)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryParkedOrderAction(string brokerId = "", string investorId = "", string instrumentId = "", string exchangeId = "", string investUnitId = "")
		{
            
			CThostFtdcQryParkedOrderActionField struc = new CThostFtdcQryParkedOrderActionField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InstrumentID = instrumentId,
				ExchangeID = exchangeId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryParkedOrderAction)loader.Invoke("ReqQryParkedOrderAction", typeof(DelegateReqQryParkedOrderAction)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryTradingNotice(string brokerId = "", string investorId = "", string investUnitId = "")
		{
            
			CThostFtdcQryTradingNoticeField struc = new CThostFtdcQryTradingNoticeField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQryTradingNotice)loader.Invoke("ReqQryTradingNotice", typeof(DelegateReqQryTradingNotice)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryBrokerTradingParams(string brokerId = "", string investorId = "", string currencyId = "", string accountId = "")
		{
            
			CThostFtdcQryBrokerTradingParamsField struc = new CThostFtdcQryBrokerTradingParamsField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				CurrencyID = currencyId,
				AccountID = accountId,
			};
			return ((DelegateReqQryBrokerTradingParams)loader.Invoke("ReqQryBrokerTradingParams", typeof(DelegateReqQryBrokerTradingParams)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQryBrokerTradingAlgos(string brokerId = "", string exchangeId = "", string instrumentId = "")
		{
            
			CThostFtdcQryBrokerTradingAlgosField struc = new CThostFtdcQryBrokerTradingAlgosField
			{
				BrokerID = brokerId,
				ExchangeID = exchangeId,
				InstrumentID = instrumentId,
			};
			return ((DelegateReqQryBrokerTradingAlgos)loader.Invoke("ReqQryBrokerTradingAlgos", typeof(DelegateReqQryBrokerTradingAlgos)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQueryCFMMCTradingAccountToken(string brokerId = "", string investorId = "", string investUnitId = "")
		{
            
			CThostFtdcQueryCFMMCTradingAccountTokenField struc = new CThostFtdcQueryCFMMCTradingAccountTokenField
			{
				BrokerID = brokerId,
				InvestorID = investorId,
				InvestUnitID = investUnitId,
			};
			return ((DelegateReqQueryCFMMCTradingAccountToken)loader.Invoke("ReqQueryCFMMCTradingAccountToken", typeof(DelegateReqQueryCFMMCTradingAccountToken)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqFromBankToFutureByFuture(string tradeCode = "", string bankId = "", string bankBranchId = "", string brokerId = "", string brokerBranchId = "", string tradeDate = "", string tradeTime = "", string bankSerial = "", string tradingDay = "", int plateSerial = 0, TThostFtdcLastFragmentType lastFragment = TThostFtdcLastFragmentType.THOST_FTDC_LF_Yes, int sessionId = 0, string customerName = "", TThostFtdcIdCardTypeType idCardType = TThostFtdcIdCardTypeType.THOST_FTDC_ICT_EID, string identifiedCardNo = "", TThostFtdcCustTypeType custType = TThostFtdcCustTypeType.THOST_FTDC_CUSTT_Person, string bankAccount = "", string bankPassWord = "", string accountId = "", string password = "", int installId = 0, int futureSerial = 0, string userId = "", TThostFtdcYesNoIndicatorType verifyCertNoFlag = TThostFtdcYesNoIndicatorType.THOST_FTDC_YNI_Yes, string currencyId = "", double tradeAmount = 0, double futureFetchAmount = 0, TThostFtdcFeePayFlagType feePayFlag = TThostFtdcFeePayFlagType.THOST_FTDC_FPF_BEN, double custFee = 0, double brokerFee = 0, string message = "", string digest = "", TThostFtdcBankAccTypeType bankAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string deviceId = "", TThostFtdcBankAccTypeType bankSecuAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string brokerIdByBank = "", string bankSecuAcc = "", TThostFtdcPwdFlagType bankPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, TThostFtdcPwdFlagType secuPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, string operNo = "", int requestId = 0, int tId = 0, TThostFtdcTransferStatusType transferStatus = TThostFtdcTransferStatusType.THOST_FTDC_TRFS_Normal, string longCustomerName = "")
		{
            
			CThostFtdcReqTransferField struc = new CThostFtdcReqTransferField
			{
				TradeCode = tradeCode,
				BankID = bankId,
				BankBranchID = bankBranchId,
				BrokerID = brokerId,
				BrokerBranchID = brokerBranchId,
				TradeDate = tradeDate,
				TradeTime = tradeTime,
				BankSerial = bankSerial,
				TradingDay = tradingDay,
				PlateSerial = plateSerial,
				LastFragment = lastFragment,
				SessionID = sessionId,
				CustomerName = customerName,
				IdCardType = idCardType,
				IdentifiedCardNo = identifiedCardNo,
				CustType = custType,
				BankAccount = bankAccount,
				BankPassWord = bankPassWord,
				AccountID = accountId,
				Password = password,
				InstallID = installId,
				FutureSerial = futureSerial,
				UserID = userId,
				VerifyCertNoFlag = verifyCertNoFlag,
				CurrencyID = currencyId,
				TradeAmount = tradeAmount,
				FutureFetchAmount = futureFetchAmount,
				FeePayFlag = feePayFlag,
				CustFee = custFee,
				BrokerFee = brokerFee,
				Message = message,
				Digest = digest,
				BankAccType = bankAccType,
				DeviceID = deviceId,
				BankSecuAccType = bankSecuAccType,
				BrokerIDByBank = brokerIdByBank,
				BankSecuAcc = bankSecuAcc,
				BankPwdFlag = bankPwdFlag,
				SecuPwdFlag = secuPwdFlag,
				OperNo = operNo,
				RequestID = requestId,
				TID = tId,
				TransferStatus = transferStatus,
				LongCustomerName = longCustomerName,
			};
			return ((DelegateReqFromBankToFutureByFuture)loader.Invoke("ReqFromBankToFutureByFuture", typeof(DelegateReqFromBankToFutureByFuture)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqFromFutureToBankByFuture(string tradeCode = "", string bankId = "", string bankBranchId = "", string brokerId = "", string brokerBranchId = "", string tradeDate = "", string tradeTime = "", string bankSerial = "", string tradingDay = "", int plateSerial = 0, TThostFtdcLastFragmentType lastFragment = TThostFtdcLastFragmentType.THOST_FTDC_LF_Yes, int sessionId = 0, string customerName = "", TThostFtdcIdCardTypeType idCardType = TThostFtdcIdCardTypeType.THOST_FTDC_ICT_EID, string identifiedCardNo = "", TThostFtdcCustTypeType custType = TThostFtdcCustTypeType.THOST_FTDC_CUSTT_Person, string bankAccount = "", string bankPassWord = "", string accountId = "", string password = "", int installId = 0, int futureSerial = 0, string userId = "", TThostFtdcYesNoIndicatorType verifyCertNoFlag = TThostFtdcYesNoIndicatorType.THOST_FTDC_YNI_Yes, string currencyId = "", double tradeAmount = 0, double futureFetchAmount = 0, TThostFtdcFeePayFlagType feePayFlag = TThostFtdcFeePayFlagType.THOST_FTDC_FPF_BEN, double custFee = 0, double brokerFee = 0, string message = "", string digest = "", TThostFtdcBankAccTypeType bankAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string deviceId = "", TThostFtdcBankAccTypeType bankSecuAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string brokerIdByBank = "", string bankSecuAcc = "", TThostFtdcPwdFlagType bankPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, TThostFtdcPwdFlagType secuPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, string operNo = "", int requestId = 0, int tId = 0, TThostFtdcTransferStatusType transferStatus = TThostFtdcTransferStatusType.THOST_FTDC_TRFS_Normal, string longCustomerName = "")
		{
            
			CThostFtdcReqTransferField struc = new CThostFtdcReqTransferField
			{
				TradeCode = tradeCode,
				BankID = bankId,
				BankBranchID = bankBranchId,
				BrokerID = brokerId,
				BrokerBranchID = brokerBranchId,
				TradeDate = tradeDate,
				TradeTime = tradeTime,
				BankSerial = bankSerial,
				TradingDay = tradingDay,
				PlateSerial = plateSerial,
				LastFragment = lastFragment,
				SessionID = sessionId,
				CustomerName = customerName,
				IdCardType = idCardType,
				IdentifiedCardNo = identifiedCardNo,
				CustType = custType,
				BankAccount = bankAccount,
				BankPassWord = bankPassWord,
				AccountID = accountId,
				Password = password,
				InstallID = installId,
				FutureSerial = futureSerial,
				UserID = userId,
				VerifyCertNoFlag = verifyCertNoFlag,
				CurrencyID = currencyId,
				TradeAmount = tradeAmount,
				FutureFetchAmount = futureFetchAmount,
				FeePayFlag = feePayFlag,
				CustFee = custFee,
				BrokerFee = brokerFee,
				Message = message,
				Digest = digest,
				BankAccType = bankAccType,
				DeviceID = deviceId,
				BankSecuAccType = bankSecuAccType,
				BrokerIDByBank = brokerIdByBank,
				BankSecuAcc = bankSecuAcc,
				BankPwdFlag = bankPwdFlag,
				SecuPwdFlag = secuPwdFlag,
				OperNo = operNo,
				RequestID = requestId,
				TID = tId,
				TransferStatus = transferStatus,
				LongCustomerName = longCustomerName,
			};
			return ((DelegateReqFromFutureToBankByFuture)loader.Invoke("ReqFromFutureToBankByFuture", typeof(DelegateReqFromFutureToBankByFuture)))(_api, ref struc, nRequestId++);
		}

		public IntPtr ReqQueryBankAccountMoneyByFuture(string tradeCode = "", string bankId = "", string bankBranchId = "", string brokerId = "", string brokerBranchId = "", string tradeDate = "", string tradeTime = "", string bankSerial = "", string tradingDay = "", int plateSerial = 0, TThostFtdcLastFragmentType lastFragment = TThostFtdcLastFragmentType.THOST_FTDC_LF_Yes, int sessionId = 0, string customerName = "", TThostFtdcIdCardTypeType idCardType = TThostFtdcIdCardTypeType.THOST_FTDC_ICT_EID, string identifiedCardNo = "", TThostFtdcCustTypeType custType = TThostFtdcCustTypeType.THOST_FTDC_CUSTT_Person, string bankAccount = "", string bankPassWord = "", string accountId = "", string password = "", int futureSerial = 0, int installId = 0, string userId = "", TThostFtdcYesNoIndicatorType verifyCertNoFlag = TThostFtdcYesNoIndicatorType.THOST_FTDC_YNI_Yes, string currencyId = "", string digest = "", TThostFtdcBankAccTypeType bankAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string deviceId = "", TThostFtdcBankAccTypeType bankSecuAccType = TThostFtdcBankAccTypeType.THOST_FTDC_BAT_BankBook, string brokerIdByBank = "", string bankSecuAcc = "", TThostFtdcPwdFlagType bankPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, TThostFtdcPwdFlagType secuPwdFlag = TThostFtdcPwdFlagType.THOST_FTDC_BPWDF_NoCheck, string operNo = "", int requestId = 0, int tId = 0, string longCustomerName = "")
		{
            
			CThostFtdcReqQueryAccountField struc = new CThostFtdcReqQueryAccountField
			{
				TradeCode = tradeCode,
				BankID = bankId,
				BankBranchID = bankBranchId,
				BrokerID = brokerId,
				BrokerBranchID = brokerBranchId,
				TradeDate = tradeDate,
				TradeTime = tradeTime,
				BankSerial = bankSerial,
				TradingDay = tradingDay,
				PlateSerial = plateSerial,
				LastFragment = lastFragment,
				SessionID = sessionId,
				CustomerName = customerName,
				IdCardType = idCardType,
				IdentifiedCardNo = identifiedCardNo,
				CustType = custType,
				BankAccount = bankAccount,
				BankPassWord = bankPassWord,
				AccountID = accountId,
				Password = password,
				FutureSerial = futureSerial,
				InstallID = installId,
				UserID = userId,
				VerifyCertNoFlag = verifyCertNoFlag,
				CurrencyID = currencyId,
				Digest = digest,
				BankAccType = bankAccType,
				DeviceID = deviceId,
				BankSecuAccType = bankSecuAccType,
				BrokerIDByBank = brokerIdByBank,
				BankSecuAcc = bankSecuAcc,
				BankPwdFlag = bankPwdFlag,
				SecuPwdFlag = secuPwdFlag,
				OperNo = operNo,
				RequestID = requestId,
				TID = tId,
				LongCustomerName = longCustomerName,
			};
			return ((DelegateReqQueryBankAccountMoneyByFuture)loader.Invoke("ReqQueryBankAccountMoneyByFuture", typeof(DelegateReqQueryBankAccountMoneyByFuture)))(_api, ref struc, nRequestId++);
		}

		#endregion

		delegate void DelegateSet(IntPtr spi, Delegate func);

		public delegate void DelegateOnFrontConnected();
		public void SetOnFrontConnected(DelegateOnFrontConnected func) { ((DelegateSet)loader.Invoke("SetOnFrontConnected", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnFrontDisconnected(int nReason);
		public void SetOnFrontDisconnected(DelegateOnFrontDisconnected func) { ((DelegateSet)loader.Invoke("SetOnFrontDisconnected", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnHeartBeatWarning(int nTimeLapse);
		public void SetOnHeartBeatWarning(DelegateOnHeartBeatWarning func) { ((DelegateSet)loader.Invoke("SetOnHeartBeatWarning", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspAuthenticate(ref CThostFtdcRspAuthenticateField pRspAuthenticateField, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspAuthenticate(DelegateOnRspAuthenticate func) { ((DelegateSet)loader.Invoke("SetOnRspAuthenticate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspUserLogin(ref CThostFtdcRspUserLoginField pRspUserLogin, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspUserLogin(DelegateOnRspUserLogin func) { ((DelegateSet)loader.Invoke("SetOnRspUserLogin", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspUserLogout(ref CThostFtdcUserLogoutField pUserLogout, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspUserLogout(DelegateOnRspUserLogout func) { ((DelegateSet)loader.Invoke("SetOnRspUserLogout", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspUserPasswordUpdate(ref CThostFtdcUserPasswordUpdateField pUserPasswordUpdate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspUserPasswordUpdate(DelegateOnRspUserPasswordUpdate func) { ((DelegateSet)loader.Invoke("SetOnRspUserPasswordUpdate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspTradingAccountPasswordUpdate(ref CThostFtdcTradingAccountPasswordUpdateField pTradingAccountPasswordUpdate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspTradingAccountPasswordUpdate(DelegateOnRspTradingAccountPasswordUpdate func) { ((DelegateSet)loader.Invoke("SetOnRspTradingAccountPasswordUpdate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspOrderInsert(ref CThostFtdcInputOrderField pInputOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspOrderInsert(DelegateOnRspOrderInsert func) { ((DelegateSet)loader.Invoke("SetOnRspOrderInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspParkedOrderInsert(ref CThostFtdcParkedOrderField pParkedOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspParkedOrderInsert(DelegateOnRspParkedOrderInsert func) { ((DelegateSet)loader.Invoke("SetOnRspParkedOrderInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspParkedOrderAction(ref CThostFtdcParkedOrderActionField pParkedOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspParkedOrderAction(DelegateOnRspParkedOrderAction func) { ((DelegateSet)loader.Invoke("SetOnRspParkedOrderAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspOrderAction(ref CThostFtdcInputOrderActionField pInputOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspOrderAction(DelegateOnRspOrderAction func) { ((DelegateSet)loader.Invoke("SetOnRspOrderAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQueryMaxOrderVolume(ref CThostFtdcQueryMaxOrderVolumeField pQueryMaxOrderVolume, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQueryMaxOrderVolume(DelegateOnRspQueryMaxOrderVolume func) { ((DelegateSet)loader.Invoke("SetOnRspQueryMaxOrderVolume", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspSettlementInfoConfirm(ref CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspSettlementInfoConfirm(DelegateOnRspSettlementInfoConfirm func) { ((DelegateSet)loader.Invoke("SetOnRspSettlementInfoConfirm", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspRemoveParkedOrder(ref CThostFtdcRemoveParkedOrderField pRemoveParkedOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspRemoveParkedOrder(DelegateOnRspRemoveParkedOrder func) { ((DelegateSet)loader.Invoke("SetOnRspRemoveParkedOrder", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspRemoveParkedOrderAction(ref CThostFtdcRemoveParkedOrderActionField pRemoveParkedOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspRemoveParkedOrderAction(DelegateOnRspRemoveParkedOrderAction func) { ((DelegateSet)loader.Invoke("SetOnRspRemoveParkedOrderAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspExecOrderInsert(ref CThostFtdcInputExecOrderField pInputExecOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspExecOrderInsert(DelegateOnRspExecOrderInsert func) { ((DelegateSet)loader.Invoke("SetOnRspExecOrderInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspExecOrderAction(ref CThostFtdcInputExecOrderActionField pInputExecOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspExecOrderAction(DelegateOnRspExecOrderAction func) { ((DelegateSet)loader.Invoke("SetOnRspExecOrderAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspForQuoteInsert(ref CThostFtdcInputForQuoteField pInputForQuote, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspForQuoteInsert(DelegateOnRspForQuoteInsert func) { ((DelegateSet)loader.Invoke("SetOnRspForQuoteInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQuoteInsert(ref CThostFtdcInputQuoteField pInputQuote, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQuoteInsert(DelegateOnRspQuoteInsert func) { ((DelegateSet)loader.Invoke("SetOnRspQuoteInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQuoteAction(ref CThostFtdcInputQuoteActionField pInputQuoteAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQuoteAction(DelegateOnRspQuoteAction func) { ((DelegateSet)loader.Invoke("SetOnRspQuoteAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspBatchOrderAction(ref CThostFtdcInputBatchOrderActionField pInputBatchOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspBatchOrderAction(DelegateOnRspBatchOrderAction func) { ((DelegateSet)loader.Invoke("SetOnRspBatchOrderAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspOptionSelfCloseInsert(ref CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspOptionSelfCloseInsert(DelegateOnRspOptionSelfCloseInsert func) { ((DelegateSet)loader.Invoke("SetOnRspOptionSelfCloseInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspOptionSelfCloseAction(ref CThostFtdcInputOptionSelfCloseActionField pInputOptionSelfCloseAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspOptionSelfCloseAction(DelegateOnRspOptionSelfCloseAction func) { ((DelegateSet)loader.Invoke("SetOnRspOptionSelfCloseAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspCombActionInsert(ref CThostFtdcInputCombActionField pInputCombAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspCombActionInsert(DelegateOnRspCombActionInsert func) { ((DelegateSet)loader.Invoke("SetOnRspCombActionInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryOrder(ref CThostFtdcOrderField pOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryOrder(DelegateOnRspQryOrder func) { ((DelegateSet)loader.Invoke("SetOnRspQryOrder", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryTrade(ref CThostFtdcTradeField pTrade, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryTrade(DelegateOnRspQryTrade func) { ((DelegateSet)loader.Invoke("SetOnRspQryTrade", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInvestorPosition(ref CThostFtdcInvestorPositionField pInvestorPosition, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInvestorPosition(DelegateOnRspQryInvestorPosition func) { ((DelegateSet)loader.Invoke("SetOnRspQryInvestorPosition", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryTradingAccount(ref CThostFtdcTradingAccountField pTradingAccount, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryTradingAccount(DelegateOnRspQryTradingAccount func) { ((DelegateSet)loader.Invoke("SetOnRspQryTradingAccount", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInvestor(ref CThostFtdcInvestorField pInvestor, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInvestor(DelegateOnRspQryInvestor func) { ((DelegateSet)loader.Invoke("SetOnRspQryInvestor", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryTradingCode(ref CThostFtdcTradingCodeField pTradingCode, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryTradingCode(DelegateOnRspQryTradingCode func) { ((DelegateSet)loader.Invoke("SetOnRspQryTradingCode", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInstrumentMarginRate(ref CThostFtdcInstrumentMarginRateField pInstrumentMarginRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInstrumentMarginRate(DelegateOnRspQryInstrumentMarginRate func) { ((DelegateSet)loader.Invoke("SetOnRspQryInstrumentMarginRate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInstrumentCommissionRate(ref CThostFtdcInstrumentCommissionRateField pInstrumentCommissionRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInstrumentCommissionRate(DelegateOnRspQryInstrumentCommissionRate func) { ((DelegateSet)loader.Invoke("SetOnRspQryInstrumentCommissionRate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryExchange(ref CThostFtdcExchangeField pExchange, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryExchange(DelegateOnRspQryExchange func) { ((DelegateSet)loader.Invoke("SetOnRspQryExchange", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryProduct(ref CThostFtdcProductField pProduct, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryProduct(DelegateOnRspQryProduct func) { ((DelegateSet)loader.Invoke("SetOnRspQryProduct", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInstrument(ref CThostFtdcInstrumentField pInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInstrument(DelegateOnRspQryInstrument func) { ((DelegateSet)loader.Invoke("SetOnRspQryInstrument", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryDepthMarketData(DelegateOnRspQryDepthMarketData func) { ((DelegateSet)loader.Invoke("SetOnRspQryDepthMarketData", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQrySettlementInfo(ref CThostFtdcSettlementInfoField pSettlementInfo, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQrySettlementInfo(DelegateOnRspQrySettlementInfo func) { ((DelegateSet)loader.Invoke("SetOnRspQrySettlementInfo", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryTransferBank(ref CThostFtdcTransferBankField pTransferBank, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryTransferBank(DelegateOnRspQryTransferBank func) { ((DelegateSet)loader.Invoke("SetOnRspQryTransferBank", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInvestorPositionDetail(ref CThostFtdcInvestorPositionDetailField pInvestorPositionDetail, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInvestorPositionDetail(DelegateOnRspQryInvestorPositionDetail func) { ((DelegateSet)loader.Invoke("SetOnRspQryInvestorPositionDetail", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryNotice(ref CThostFtdcNoticeField pNotice, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryNotice(DelegateOnRspQryNotice func) { ((DelegateSet)loader.Invoke("SetOnRspQryNotice", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQrySettlementInfoConfirm(ref CThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQrySettlementInfoConfirm(DelegateOnRspQrySettlementInfoConfirm func) { ((DelegateSet)loader.Invoke("SetOnRspQrySettlementInfoConfirm", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInvestorPositionCombineDetail(ref CThostFtdcInvestorPositionCombineDetailField pInvestorPositionCombineDetail, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInvestorPositionCombineDetail(DelegateOnRspQryInvestorPositionCombineDetail func) { ((DelegateSet)loader.Invoke("SetOnRspQryInvestorPositionCombineDetail", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryCFMMCTradingAccountKey(ref CThostFtdcCFMMCTradingAccountKeyField pCFMMCTradingAccountKey, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryCFMMCTradingAccountKey(DelegateOnRspQryCFMMCTradingAccountKey func) { ((DelegateSet)loader.Invoke("SetOnRspQryCFMMCTradingAccountKey", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryEWarrantOffset(ref CThostFtdcEWarrantOffsetField pEWarrantOffset, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryEWarrantOffset(DelegateOnRspQryEWarrantOffset func) { ((DelegateSet)loader.Invoke("SetOnRspQryEWarrantOffset", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInvestorProductGroupMargin(ref CThostFtdcInvestorProductGroupMarginField pInvestorProductGroupMargin, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInvestorProductGroupMargin(DelegateOnRspQryInvestorProductGroupMargin func) { ((DelegateSet)loader.Invoke("SetOnRspQryInvestorProductGroupMargin", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryExchangeMarginRate(ref CThostFtdcExchangeMarginRateField pExchangeMarginRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryExchangeMarginRate(DelegateOnRspQryExchangeMarginRate func) { ((DelegateSet)loader.Invoke("SetOnRspQryExchangeMarginRate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryExchangeMarginRateAdjust(ref CThostFtdcExchangeMarginRateAdjustField pExchangeMarginRateAdjust, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryExchangeMarginRateAdjust(DelegateOnRspQryExchangeMarginRateAdjust func) { ((DelegateSet)loader.Invoke("SetOnRspQryExchangeMarginRateAdjust", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryExchangeRate(ref CThostFtdcExchangeRateField pExchangeRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryExchangeRate(DelegateOnRspQryExchangeRate func) { ((DelegateSet)loader.Invoke("SetOnRspQryExchangeRate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQrySecAgentACIDMap(ref CThostFtdcSecAgentACIDMapField pSecAgentACIdMap, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQrySecAgentACIDMap(DelegateOnRspQrySecAgentACIDMap func) { ((DelegateSet)loader.Invoke("SetOnRspQrySecAgentACIDMap", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryProductExchRate(ref CThostFtdcProductExchRateField pProductExchRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryProductExchRate(DelegateOnRspQryProductExchRate func) { ((DelegateSet)loader.Invoke("SetOnRspQryProductExchRate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryProductGroup(ref CThostFtdcProductGroupField pProductGroup, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryProductGroup(DelegateOnRspQryProductGroup func) { ((DelegateSet)loader.Invoke("SetOnRspQryProductGroup", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryMMInstrumentCommissionRate(ref CThostFtdcMMInstrumentCommissionRateField pMMInstrumentCommissionRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryMMInstrumentCommissionRate(DelegateOnRspQryMMInstrumentCommissionRate func) { ((DelegateSet)loader.Invoke("SetOnRspQryMMInstrumentCommissionRate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryMMOptionInstrCommRate(ref CThostFtdcMMOptionInstrCommRateField pMMOptionInstrCommRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryMMOptionInstrCommRate(DelegateOnRspQryMMOptionInstrCommRate func) { ((DelegateSet)loader.Invoke("SetOnRspQryMMOptionInstrCommRate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInstrumentOrderCommRate(ref CThostFtdcInstrumentOrderCommRateField pInstrumentOrderCommRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInstrumentOrderCommRate(DelegateOnRspQryInstrumentOrderCommRate func) { ((DelegateSet)loader.Invoke("SetOnRspQryInstrumentOrderCommRate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQrySecAgentTradingAccount(ref CThostFtdcTradingAccountField pTradingAccount, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQrySecAgentTradingAccount(DelegateOnRspQrySecAgentTradingAccount func) { ((DelegateSet)loader.Invoke("SetOnRspQrySecAgentTradingAccount", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQrySecAgentCheckMode(ref CThostFtdcSecAgentCheckModeField pSecAgentCheckMode, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQrySecAgentCheckMode(DelegateOnRspQrySecAgentCheckMode func) { ((DelegateSet)loader.Invoke("SetOnRspQrySecAgentCheckMode", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryOptionInstrTradeCost(ref CThostFtdcOptionInstrTradeCostField pOptionInstrTradeCost, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryOptionInstrTradeCost(DelegateOnRspQryOptionInstrTradeCost func) { ((DelegateSet)loader.Invoke("SetOnRspQryOptionInstrTradeCost", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryOptionInstrCommRate(ref CThostFtdcOptionInstrCommRateField pOptionInstrCommRate, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryOptionInstrCommRate(DelegateOnRspQryOptionInstrCommRate func) { ((DelegateSet)loader.Invoke("SetOnRspQryOptionInstrCommRate", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryExecOrder(ref CThostFtdcExecOrderField pExecOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryExecOrder(DelegateOnRspQryExecOrder func) { ((DelegateSet)loader.Invoke("SetOnRspQryExecOrder", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryForQuote(ref CThostFtdcForQuoteField pForQuote, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryForQuote(DelegateOnRspQryForQuote func) { ((DelegateSet)loader.Invoke("SetOnRspQryForQuote", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryQuote(ref CThostFtdcQuoteField pQuote, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryQuote(DelegateOnRspQryQuote func) { ((DelegateSet)loader.Invoke("SetOnRspQryQuote", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryOptionSelfClose(ref CThostFtdcOptionSelfCloseField pOptionSelfClose, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryOptionSelfClose(DelegateOnRspQryOptionSelfClose func) { ((DelegateSet)loader.Invoke("SetOnRspQryOptionSelfClose", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryInvestUnit(ref CThostFtdcInvestUnitField pInvestUnit, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryInvestUnit(DelegateOnRspQryInvestUnit func) { ((DelegateSet)loader.Invoke("SetOnRspQryInvestUnit", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryCombInstrumentGuard(ref CThostFtdcCombInstrumentGuardField pCombInstrumentGuard, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryCombInstrumentGuard(DelegateOnRspQryCombInstrumentGuard func) { ((DelegateSet)loader.Invoke("SetOnRspQryCombInstrumentGuard", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryCombAction(ref CThostFtdcCombActionField pCombAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryCombAction(DelegateOnRspQryCombAction func) { ((DelegateSet)loader.Invoke("SetOnRspQryCombAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryTransferSerial(ref CThostFtdcTransferSerialField pTransferSerial, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryTransferSerial(DelegateOnRspQryTransferSerial func) { ((DelegateSet)loader.Invoke("SetOnRspQryTransferSerial", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryAccountregister(ref CThostFtdcAccountregisterField pAccountregister, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryAccountregister(DelegateOnRspQryAccountregister func) { ((DelegateSet)loader.Invoke("SetOnRspQryAccountregister", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspError(ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspError(DelegateOnRspError func) { ((DelegateSet)loader.Invoke("SetOnRspError", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnOrder(ref CThostFtdcOrderField pOrder);
		public void SetOnRtnOrder(DelegateOnRtnOrder func) { ((DelegateSet)loader.Invoke("SetOnRtnOrder", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnTrade(ref CThostFtdcTradeField pTrade);
		public void SetOnRtnTrade(DelegateOnRtnTrade func) { ((DelegateSet)loader.Invoke("SetOnRtnTrade", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnOrderInsert(ref CThostFtdcInputOrderField pInputOrder, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnOrderInsert(DelegateOnErrRtnOrderInsert func) { ((DelegateSet)loader.Invoke("SetOnErrRtnOrderInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnOrderAction(ref CThostFtdcOrderActionField pOrderAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnOrderAction(DelegateOnErrRtnOrderAction func) { ((DelegateSet)loader.Invoke("SetOnErrRtnOrderAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnInstrumentStatus(ref CThostFtdcInstrumentStatusField pInstrumentStatus);
		public void SetOnRtnInstrumentStatus(DelegateOnRtnInstrumentStatus func) { ((DelegateSet)loader.Invoke("SetOnRtnInstrumentStatus", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnBulletin(ref CThostFtdcBulletinField pBulletin);
		public void SetOnRtnBulletin(DelegateOnRtnBulletin func) { ((DelegateSet)loader.Invoke("SetOnRtnBulletin", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnTradingNotice(ref CThostFtdcTradingNoticeInfoField pTradingNoticeInfo);
		public void SetOnRtnTradingNotice(DelegateOnRtnTradingNotice func) { ((DelegateSet)loader.Invoke("SetOnRtnTradingNotice", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnErrorConditionalOrder(ref CThostFtdcErrorConditionalOrderField pErrorConditionalOrder);
		public void SetOnRtnErrorConditionalOrder(DelegateOnRtnErrorConditionalOrder func) { ((DelegateSet)loader.Invoke("SetOnRtnErrorConditionalOrder", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnExecOrder(ref CThostFtdcExecOrderField pExecOrder);
		public void SetOnRtnExecOrder(DelegateOnRtnExecOrder func) { ((DelegateSet)loader.Invoke("SetOnRtnExecOrder", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnExecOrderInsert(ref CThostFtdcInputExecOrderField pInputExecOrder, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnExecOrderInsert(DelegateOnErrRtnExecOrderInsert func) { ((DelegateSet)loader.Invoke("SetOnErrRtnExecOrderInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnExecOrderAction(ref CThostFtdcExecOrderActionField pExecOrderAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnExecOrderAction(DelegateOnErrRtnExecOrderAction func) { ((DelegateSet)loader.Invoke("SetOnErrRtnExecOrderAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnForQuoteInsert(ref CThostFtdcInputForQuoteField pInputForQuote, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnForQuoteInsert(DelegateOnErrRtnForQuoteInsert func) { ((DelegateSet)loader.Invoke("SetOnErrRtnForQuoteInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnQuote(ref CThostFtdcQuoteField pQuote);
		public void SetOnRtnQuote(DelegateOnRtnQuote func) { ((DelegateSet)loader.Invoke("SetOnRtnQuote", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnQuoteInsert(ref CThostFtdcInputQuoteField pInputQuote, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnQuoteInsert(DelegateOnErrRtnQuoteInsert func) { ((DelegateSet)loader.Invoke("SetOnErrRtnQuoteInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnQuoteAction(ref CThostFtdcQuoteActionField pQuoteAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnQuoteAction(DelegateOnErrRtnQuoteAction func) { ((DelegateSet)loader.Invoke("SetOnErrRtnQuoteAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnForQuoteRsp(ref CThostFtdcForQuoteRspField pForQuoteRsp);
		public void SetOnRtnForQuoteRsp(DelegateOnRtnForQuoteRsp func) { ((DelegateSet)loader.Invoke("SetOnRtnForQuoteRsp", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnCFMMCTradingAccountToken(ref CThostFtdcCFMMCTradingAccountTokenField pCFMMCTradingAccountToken);
		public void SetOnRtnCFMMCTradingAccountToken(DelegateOnRtnCFMMCTradingAccountToken func) { ((DelegateSet)loader.Invoke("SetOnRtnCFMMCTradingAccountToken", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnBatchOrderAction(ref CThostFtdcBatchOrderActionField pBatchOrderAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnBatchOrderAction(DelegateOnErrRtnBatchOrderAction func) { ((DelegateSet)loader.Invoke("SetOnErrRtnBatchOrderAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnOptionSelfClose(ref CThostFtdcOptionSelfCloseField pOptionSelfClose);
		public void SetOnRtnOptionSelfClose(DelegateOnRtnOptionSelfClose func) { ((DelegateSet)loader.Invoke("SetOnRtnOptionSelfClose", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnOptionSelfCloseInsert(ref CThostFtdcInputOptionSelfCloseField pInputOptionSelfClose, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnOptionSelfCloseInsert(DelegateOnErrRtnOptionSelfCloseInsert func) { ((DelegateSet)loader.Invoke("SetOnErrRtnOptionSelfCloseInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnOptionSelfCloseAction(ref CThostFtdcOptionSelfCloseActionField pOptionSelfCloseAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnOptionSelfCloseAction(DelegateOnErrRtnOptionSelfCloseAction func) { ((DelegateSet)loader.Invoke("SetOnErrRtnOptionSelfCloseAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnCombAction(ref CThostFtdcCombActionField pCombAction);
		public void SetOnRtnCombAction(DelegateOnRtnCombAction func) { ((DelegateSet)loader.Invoke("SetOnRtnCombAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnCombActionInsert(ref CThostFtdcInputCombActionField pInputCombAction, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnCombActionInsert(DelegateOnErrRtnCombActionInsert func) { ((DelegateSet)loader.Invoke("SetOnErrRtnCombActionInsert", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryContractBank(ref CThostFtdcContractBankField pContractBank, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryContractBank(DelegateOnRspQryContractBank func) { ((DelegateSet)loader.Invoke("SetOnRspQryContractBank", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryParkedOrder(ref CThostFtdcParkedOrderField pParkedOrder, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryParkedOrder(DelegateOnRspQryParkedOrder func) { ((DelegateSet)loader.Invoke("SetOnRspQryParkedOrder", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryParkedOrderAction(ref CThostFtdcParkedOrderActionField pParkedOrderAction, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryParkedOrderAction(DelegateOnRspQryParkedOrderAction func) { ((DelegateSet)loader.Invoke("SetOnRspQryParkedOrderAction", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryTradingNotice(ref CThostFtdcTradingNoticeField pTradingNotice, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryTradingNotice(DelegateOnRspQryTradingNotice func) { ((DelegateSet)loader.Invoke("SetOnRspQryTradingNotice", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryBrokerTradingParams(ref CThostFtdcBrokerTradingParamsField pBrokerTradingParams, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryBrokerTradingParams(DelegateOnRspQryBrokerTradingParams func) { ((DelegateSet)loader.Invoke("SetOnRspQryBrokerTradingParams", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQryBrokerTradingAlgos(ref CThostFtdcBrokerTradingAlgosField pBrokerTradingAlgos, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQryBrokerTradingAlgos(DelegateOnRspQryBrokerTradingAlgos func) { ((DelegateSet)loader.Invoke("SetOnRspQryBrokerTradingAlgos", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQueryCFMMCTradingAccountToken(ref CThostFtdcQueryCFMMCTradingAccountTokenField pQueryCFMMCTradingAccountToken, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQueryCFMMCTradingAccountToken(DelegateOnRspQueryCFMMCTradingAccountToken func) { ((DelegateSet)loader.Invoke("SetOnRspQueryCFMMCTradingAccountToken", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnFromBankToFutureByBank(ref CThostFtdcRspTransferField pRspTransfer);
		public void SetOnRtnFromBankToFutureByBank(DelegateOnRtnFromBankToFutureByBank func) { ((DelegateSet)loader.Invoke("SetOnRtnFromBankToFutureByBank", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnFromFutureToBankByBank(ref CThostFtdcRspTransferField pRspTransfer);
		public void SetOnRtnFromFutureToBankByBank(DelegateOnRtnFromFutureToBankByBank func) { ((DelegateSet)loader.Invoke("SetOnRtnFromFutureToBankByBank", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnRepealFromBankToFutureByBank(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromBankToFutureByBank(DelegateOnRtnRepealFromBankToFutureByBank func) { ((DelegateSet)loader.Invoke("SetOnRtnRepealFromBankToFutureByBank", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnRepealFromFutureToBankByBank(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromFutureToBankByBank(DelegateOnRtnRepealFromFutureToBankByBank func) { ((DelegateSet)loader.Invoke("SetOnRtnRepealFromFutureToBankByBank", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnFromBankToFutureByFuture(ref CThostFtdcRspTransferField pRspTransfer);
		public void SetOnRtnFromBankToFutureByFuture(DelegateOnRtnFromBankToFutureByFuture func) { ((DelegateSet)loader.Invoke("SetOnRtnFromBankToFutureByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnFromFutureToBankByFuture(ref CThostFtdcRspTransferField pRspTransfer);
		public void SetOnRtnFromFutureToBankByFuture(DelegateOnRtnFromFutureToBankByFuture func) { ((DelegateSet)loader.Invoke("SetOnRtnFromFutureToBankByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnRepealFromBankToFutureByFutureManual(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromBankToFutureByFutureManual(DelegateOnRtnRepealFromBankToFutureByFutureManual func) { ((DelegateSet)loader.Invoke("SetOnRtnRepealFromBankToFutureByFutureManual", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnRepealFromFutureToBankByFutureManual(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromFutureToBankByFutureManual(DelegateOnRtnRepealFromFutureToBankByFutureManual func) { ((DelegateSet)loader.Invoke("SetOnRtnRepealFromFutureToBankByFutureManual", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnQueryBankBalanceByFuture(ref CThostFtdcNotifyQueryAccountField pNotifyQueryAccount);
		public void SetOnRtnQueryBankBalanceByFuture(DelegateOnRtnQueryBankBalanceByFuture func) { ((DelegateSet)loader.Invoke("SetOnRtnQueryBankBalanceByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnBankToFutureByFuture(ref CThostFtdcReqTransferField pReqTransfer, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnBankToFutureByFuture(DelegateOnErrRtnBankToFutureByFuture func) { ((DelegateSet)loader.Invoke("SetOnErrRtnBankToFutureByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnFutureToBankByFuture(ref CThostFtdcReqTransferField pReqTransfer, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnFutureToBankByFuture(DelegateOnErrRtnFutureToBankByFuture func) { ((DelegateSet)loader.Invoke("SetOnErrRtnFutureToBankByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnRepealBankToFutureByFutureManual(ref CThostFtdcReqRepealField pReqRepeal, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnRepealBankToFutureByFutureManual(DelegateOnErrRtnRepealBankToFutureByFutureManual func) { ((DelegateSet)loader.Invoke("SetOnErrRtnRepealBankToFutureByFutureManual", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnRepealFutureToBankByFutureManual(ref CThostFtdcReqRepealField pReqRepeal, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnRepealFutureToBankByFutureManual(DelegateOnErrRtnRepealFutureToBankByFutureManual func) { ((DelegateSet)loader.Invoke("SetOnErrRtnRepealFutureToBankByFutureManual", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnErrRtnQueryBankBalanceByFuture(ref CThostFtdcReqQueryAccountField pReqQueryAccount, ref CThostFtdcRspInfoField pRspInfo);
		public void SetOnErrRtnQueryBankBalanceByFuture(DelegateOnErrRtnQueryBankBalanceByFuture func) { ((DelegateSet)loader.Invoke("SetOnErrRtnQueryBankBalanceByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnRepealFromBankToFutureByFuture(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromBankToFutureByFuture(DelegateOnRtnRepealFromBankToFutureByFuture func) { ((DelegateSet)loader.Invoke("SetOnRtnRepealFromBankToFutureByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnRepealFromFutureToBankByFuture(ref CThostFtdcRspRepealField pRspRepeal);
		public void SetOnRtnRepealFromFutureToBankByFuture(DelegateOnRtnRepealFromFutureToBankByFuture func) { ((DelegateSet)loader.Invoke("SetOnRtnRepealFromFutureToBankByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspFromBankToFutureByFuture(ref CThostFtdcReqTransferField pReqTransfer, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspFromBankToFutureByFuture(DelegateOnRspFromBankToFutureByFuture func) { ((DelegateSet)loader.Invoke("SetOnRspFromBankToFutureByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspFromFutureToBankByFuture(ref CThostFtdcReqTransferField pReqTransfer, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspFromFutureToBankByFuture(DelegateOnRspFromFutureToBankByFuture func) { ((DelegateSet)loader.Invoke("SetOnRspFromFutureToBankByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRspQueryBankAccountMoneyByFuture(ref CThostFtdcReqQueryAccountField pReqQueryAccount, ref CThostFtdcRspInfoField pRspInfo, int nRequestId, bool bIsLast);
		public void SetOnRspQueryBankAccountMoneyByFuture(DelegateOnRspQueryBankAccountMoneyByFuture func) { ((DelegateSet)loader.Invoke("SetOnRspQueryBankAccountMoneyByFuture", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnOpenAccountByBank(ref CThostFtdcOpenAccountField pOpenAccount);
		public void SetOnRtnOpenAccountByBank(DelegateOnRtnOpenAccountByBank func) { ((DelegateSet)loader.Invoke("SetOnRtnOpenAccountByBank", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnCancelAccountByBank(ref CThostFtdcCancelAccountField pCancelAccount);
		public void SetOnRtnCancelAccountByBank(DelegateOnRtnCancelAccountByBank func) { ((DelegateSet)loader.Invoke("SetOnRtnCancelAccountByBank", typeof(DelegateSet)))(_spi, func); }
		public delegate void DelegateOnRtnChangeAccountByBank(ref CThostFtdcChangeAccountField pChangeAccount);
		public void SetOnRtnChangeAccountByBank(DelegateOnRtnChangeAccountByBank func) { ((DelegateSet)loader.Invoke("SetOnRtnChangeAccountByBank", typeof(DelegateSet)))(_spi, func); }
	}
}