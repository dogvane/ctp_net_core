# 如何自己让海风的c#版本能跑在Linux下

## 版本信息

目前.net core版本使用的 6.3.11_20180109, 项目在2018年11月从[海风ctp封装](https://github.com/haifengat/hf_ctp_py_proxy)里fork出来。

## 预备知识 -- 海风CTP是如何运行的

上期所提供的API是基于c++开发的，[最新的版本下载](http://www.sfit.com.cn/5_2_DocumentDown.htm)。

我们可以打开一个 .h 的头文件来看看 [ThostFtdcTraderApi.h](https://github.com/dogvane/hf_ctp_py_proxy/blob/master/ctp_20180109/ThostFtdcTraderApi.h)

它是使用c++封装的，CThostFtdcTraderApi 用来向服务器发送命令，CThostFtdcTraderSpi 则是接收返回的数据。在c++下开发，则需要继承 CThostFtdcTraderSpi 这个类。

而 .net 只支持对 C 的调用，.net core 下 暂时还没 c++ cli，所以 .net 下如果要调用 ctp 的 api，只能通过一些模式来进行桥接了。

我们可以看看海风之前写的一个桥接用的 [quote.cpp](https://github.com/haifengat/hf_ctp_c_proxy/blob/master/ctp_quote/quote.cpp) 文件。

我们就看这几行代码好了：

··· c

DLL_EXPORT_C_DECL void WINAPI SetOnRspUnSubForQuoteRsp(Quote* spi, void* func) { spi->_RspUnSubForQuoteRsp = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRtnDepthMarketData(Quote* spi, void* func) { spi->_RtnDepthMarketData = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRtnForQuoteRsp(Quote* spi, void* func) { spi->_RtnForQuoteRsp = func; }

DLL_EXPORT_C_DECL void* WINAPI CreateApi() { return CThostFtdcMdApi::CreateFtdcMdApi("./log/"); }
DLL_EXPORT_C_DECL void* WINAPI CreateSpi() { return new Quote(); }

DLL_EXPORT_C_DECL void* WINAPI Release(CThostFtdcMdApi *api) { api->Release(); return 0; }
DLL_EXPORT_C_DECL void* WINAPI Init(CThostFtdcMdApi *api) { api->Init(); return 0; }
DLL_EXPORT_C_DECL void* WINAPI Join(CThostFtdcMdApi *api) { api->Join(); return 0; }

···

上面的3个方法用于设置行情的回调函数，中间的2个方法则是创建发送指令和接收数据的c++对象，下面的三个方法则是对行情api的调用。

我们来看一下，上面的c++的代码会对应到的 .net 代码（代码有删减，只展示最必要的内容，[完整内容见github](https://github.com/haifengat/hf_ctp_cs_proxy/blob/master/Proxy/ctp_quote.cs))

``` csharp

		IntPtr _handle = IntPtr.Zero, _api = IntPtr.Zero, _spi = IntPtr.Zero;

    	public CTP_quote(string pFile)
		{
			_api = (Invoke(_handle, "CreateApi", typeof(Create)) as Create)();
			_spi = (Invoke(_handle, "CreateSpi", typeof(Create)) as Create)();
			(Invoke(_handle, "RegisterSpi", typeof(DeleRegisterSpi)) as DeleRegisterSpi)(_api, _spi);
		}

		public IntPtr Release()
		{
			(Invoke(_handle, "RegisterSpi", typeof(DeleRegisterSpi)) as DeleRegisterSpi)(_api, IntPtr.Zero);
			return (Invoke(_handle, "Release", typeof(DeleRelease)) as DeleRelease)(_api);
		}

		public IntPtr Init()
		{
			return (Invoke(_handle, "Init", typeof(DeleInit)) as DeleInit)(_api);
		}

		public IntPtr Join()
		{
			return (Invoke(_handle, "Join", typeof(DeleJoin)) as DeleJoin)(_api);
		}

        public delegate void DeleOnRspUnSubForQuoteRsp(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool IsLast);
        public void SetOnRspUnSubForQuoteRsp(DeleOnRspUnSubForQuoteRsp func) { (Invoke(_handle, "SetOnRspUnSubForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func); }

		public delegate void DeleOnRtnDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData);
        public void SetOnRtnDepthMarketData(DeleOnRtnDepthMarketData func) { (Invoke(_handle, "SetOnRtnDepthMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }

		public delegate void DeleOnRtnForQuoteRsp(ref CThostFtdcForQuoteRspField pForQuoteRsp);
		public void SetOnRtnForQuoteRsp(DeleOnRtnForQuoteRsp func) { (Invoke(_handle, "SetOnRtnForQuoteRsp", typeof(DeleSet)) as DeleSet)(_spi, func); }

```

## .net core 的迁移

在 github 上是有一个 .net core [CtpNetCore][https://github.com/slobber/CtpNetCore] 的ctp版本，也是基于海风的版本做的修改，但修改的时间比较早，使用的不是最新的上期所sdk，所以只拿来做参考。

借鉴它的代码，将[AssemblyLoader.cs][https://github.com/slobber/CtpNetCore/blob/master/CtpNetCore/AssemblyLoader.cs]合并到海风的代码里，就能在windows下正常的运行了。

恩，你没看错，是windows下运行，在linux下无法运行。

经过测试，出现以下情况：

. 程序可以编译
. 能运行，调用 connect 函数没出异常
. 在 connect 后，能收到正确的回调
. 在回调函数里，调用 login 会失败，直接导致应用程序崩溃
. .net core 无法捕捉到 login 失败的异常

基于以上判断，得到以下结论

. .net core 本身没问题(windows能正常运行)
. [AssemblyLoader.cs][https://github.com/slobber/CtpNetCore/blob/master/CtpNetCore/AssemblyLoader.cs] 在 linux 下调用机制没问题（调用connect成功，并回调没问题）
. 出问题可能在 c++ 部分，和 .net core 本身无关
. 最大可能是传参出问题了（因为connect是空函数，没传参）

那么，问题出处知道了，原因呢？

### 用测试代码说话

开始的时候，考虑的是 windows 和 linux 在大小端上的问题导致到，有猜测后，自然得想办法验证的想法了。

直接在云服务器linux上，创建一个 .c 文件，一个.net core 项目开测。

从简单的int值传参开始，到long, 到double，然后是字符串，最后是结构体。


## 结论

<b>传参时，给结构体加ref<b>



