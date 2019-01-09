# hf_ctp_py_proxy
上期技术期货交易api之python封装，实现接口调用。支持windows linux.

## 环境需求
* VS2017
* python 3.6+
* 64位

## .net core 下使用说明
* 当前版本版本基于海风版本修改(fork 2018年11月)，修改了对dll的引用方式，时期能在.net core下编译并运行。
* 当前的版本已经能在linux运行（centos 7.3环境 .net core 2.13)。
* 接口未全面测试，请小心使用。

### 用前须知
* 未来的修改将主要集中在 netcore_ctp 目录下。
* netcore_ctp 目录下的代码和海风的代码相比，会有很大的不一样，所以如果现有代码升级话，请使用 cs_ctp 目录下的文件。
* 如果海风ctp未来版本升级的话，请阅读 [如何让海风CTP的c#版本能跑在 Linux (.net core)](http://www.csharptools.cn/post/25.html) 自己升级海风代码。

## 测试demo执行
* 在centos7.3 下安装好 .net core
* git clone 项目
* 先编译测试demo
    * dotnet build cs_ctp/quote_save/
* 复制 *.so 到执行目录
    * cp dll/*.so cs_ctp/quote_save/bin/Debug/netcoreapp2.1
* 执行测试demo
    * cd cs_ctp/quote_save/
    * dotnet run
* 测试demo会接入上期所的模拟环境，获得当前交易的tick，demo只有在有效的交易时间段才会有数据返回。

## 使用说明
* 运行 `pyton generate\\run.py` 生成所有文件
* C++编译
    * Windows
        * 环境要求 `vs2017` `64位`
        * 设置项目为x64,否则会提示找不到windows.h
        * 打开ctp_c\\ctp.sln
        * 编译ctp_quote 和 ctp_trade项目
        * 编译后生成的dll放在dll目录下
    * Linux
        * 设置系统语言为：zh_CN.UTF-8
        * 复制文件到linux ctp_c\\*.h *.cpp 到ctp_c目录下
        * 复制 ctp_20180109\\*.so到dll目录下
        * 复制 py_ctp\\*.py到py_ctp目录下
        * 进入dll目录，执行以下指令
            * g++ -shared -fPIC ../ctp_c/trade.cpp -o ./ctp_trade.so ./thosttraderapi.so
            * g++ -shared -fPIC ../ctp_c/quote.cpp -o ./ctp_quote.so ./thostmduserapi.so
* 测试
    * 执行 `copy ctp_20180109\\*.dll dll\`
    * Python
        * 运行 `python py_ctp\test_api.py`
    * C#
        * `copy cs_ctp\*.cs cs_ctp\ctp_test\`
        * 打开cs_ctp\ctp_test 项目进行调试
        * `copy cs_ctp\*.cs cs_ctp\proxy\`
        * 打开cs_ctp\proxy 项目编译.net封装
        * 打开cs_ctp\proxytest 项目测试.net封装



