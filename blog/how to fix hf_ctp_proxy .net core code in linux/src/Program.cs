using System;
using System.Runtime.InteropServices;
using System.Text;

namespace test_call_c
{
    class Program
    {
        static Encoding encoding = CodePagesEncodingProvider.Instance.GetEncoding("GB2312");

        static void OnErrorRetFun(ref struct_error_ret ret)
        {
            Console.WriteLine("OnErrorRetFun !");
            Console.WriteLine(ret.ErrorId);

            // PrintByte(ret.ErrorMsg);
            Console.WriteLine(ret.ErrorMsg);
            // Console.WriteLine(ret.GetErrorMsg());

            Console.WriteLine("OnErrorRetFun end!");
        }

        static unsafe void PrintByte(byte[] bytes)
        {
            int len = 0;
            for (var i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0)
                {
                    len = i;
                    break;
                }

                Console.Write(bytes[i]);
                Console.Write(" ");
            }

            fixed (byte* p = bytes)
            {
                var s = encoding.GetString(p, len);
                Console.WriteLine(s);
            }
        }

        static unsafe void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            var del = new OnErrorRet(OnErrorRetFun);
            set_call_back_fun(del);

            var msg = "CTP:登录成功。您的密码为弱密码，密码长度不可少于6位";
            var utf8bytes = Encoding.UTF8.GetBytes(msg);

            Console.WriteLine("CTP:登录成功。您的密码为弱密码，密码长度不可少于6位".Length);
            Console.WriteLine(utf8bytes.Length);

            // var encoding = Encoding.GetEncoding("gb2312");
            var gbBytes = encoding.GetBytes(msg);

            Console.WriteLine("gb" + gbBytes.Length);
            PrintByte(gbBytes);
            fixed (byte* p = gbBytes)
            {
                Console.WriteLine("net pointer = " + (int)p);
                test_call_back_fun(gbBytes.Length, p);
            }

            return;

            // test_base_valuetype.test();

            fun_input_char_username("username:dogvane");

            // 超过定义的长度
            fun_input_char_username("username:dogvane_123456789123456789123456789");
            fun_input_char_username("username:dogvane_dogvane");

            // 两个字符串输入
            fun_input_char_username2("username:dogvane_123456789123456789123456789", "username:dogvane_dogvane");

            // 测试结构体的登录信息
            var s1 = new struct_login_1();
            s1.username = "dogvane";
            s1.password = "123@321";
            s1.logintype = 10086;

            Console.WriteLine("test login!");

            fun_input_char_login1(s1);
            fun_input_char_login1_ref(ref s1);

            var s2 = new struct_login_2();
            s2.username = "dogvane";
            s2.password = "123@321";
            s2.logintype = 10086;

            Console.WriteLine("test login 2!");

            fun_input_char_login2(s2);
            fun_input_char_login2_ref(ref s2);
        }

        [DllImport("test.so", EntryPoint = "fun_input_char_username")]
        public static extern IntPtr fun_input_char_username(string i);

        [DllImport("test.so", EntryPoint = "fun_input_char_username2")]
        public static extern IntPtr fun_input_char_username2(string s1, string s2);

        [DllImport("test.so", EntryPoint = "fun_input_char_login")]
        public static extern IntPtr fun_input_char_login1(struct_login_1 s1);

        [DllImport("test.so", EntryPoint = "fun_input_char_login")]
        public static extern IntPtr fun_input_char_login1_ref(ref struct_login_1 s1);

        [DllImport("test.so", EntryPoint = "fun_input_char_login")]
        public static extern IntPtr fun_input_char_login2(struct_login_2 s1);

        [DllImport("test.so", EntryPoint = "fun_input_char_login")]
        public static extern IntPtr fun_input_char_login2_ref(ref struct_login_2 s1);

        [DllImport("test.so", EntryPoint = "set_call_back_fun")]
        public static extern IntPtr set_call_back_fun(OnErrorRet fun);

        public delegate void OnErrorRet(ref struct_error_ret errorData);

        [DllImport("test.so", EntryPoint = "test_call_back_fun")]
        public unsafe static extern IntPtr test_call_back_fun(int len, byte* stringBytes);


        [StructLayout(LayoutKind.Sequential)]
        public struct struct_login_1
        {
            public string username;

            public string password;

            public int logintype;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct struct_login_2
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
            public string username;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
            public string password;

            public int logintype;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct struct_error_ret
        {
            public int ErrorId;

            // [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(GB2312CustomMarshaler), MarshalCookie ="81")]
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
            public string ErrorMsg;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct struct_error_ret2
        {
            public int ErrorId;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 81)]
            public byte[] ErrorMsg;

            public unsafe string GetErrorMsg()
            {
                int len = 0;
                for (var i = 0; i < ErrorMsg.Length; i++)
                {
                    if (ErrorMsg[i] == 0)
                    {
                        len = i;
                        break;
                    }
                }

                fixed (byte* p = ErrorMsg)
                {
                    var s = encoding.GetString(p, len);
                    return s;
                }
            }
        }
    }

    public class GB2312CustomMarshaler : ICustomMarshaler
    {
        static Encoding encoding;
        private int len = 0;


        static GB2312CustomMarshaler()
        {
            Console.WriteLine("GB2312CustomMarshaler static");
            encoding = CodePagesEncodingProvider.Instance.GetEncoding("GB2312");
        }

        public GB2312CustomMarshaler(string cookie)
        {
            Console.WriteLine("GB2312CustomMarshaler" + cookie);
            if (string.IsNullOrEmpty(cookie))
            {
                throw new Exception("需要定义数组最大长度在 MarshalCookie 上");
            }

            if (!int.TryParse(cookie, out len))
            {
                throw new Exception("MarshalCookie 不是数字  " + cookie);
            }

            if (len < 1)
            {
                throw new Exception("字符串长度必须大于1");
            }
        }

        public void CleanUpManagedData(object ManagedObj)
        {
            Console.WriteLine("CleanUpManagedData");
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            Console.WriteLine("CleanUpNativeData");
            Marshal.FreeHGlobal(pNativeData);
        }

        public int GetNativeDataSize()
        {
            return len;
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            Console.WriteLine("MarshalManagedToNative");

            var s = ManagedObj as string;
            if (s == null)
                return IntPtr.Zero;

            var bytes = encoding.GetBytes(s);

            var ret = Marshal.AllocHGlobal(GetNativeDataSize());
            Marshal.Copy(bytes, 0, ret, bytes.Length);
            return ret;
        }

        public unsafe object MarshalNativeToManaged(IntPtr pNativeData)
        {
            Console.WriteLine("MarshalNativeToManaged");

            void* p = pNativeData.ToPointer();
            var x = (byte*) p;
            var i = 0;
            while (x[i] != 0)
            {
                i++;
            }

            return encoding.GetString(x, i);
        }

        public static ICustomMarshaler GetInstance(string cookie)
        {
            return new GB2312CustomMarshaler(cookie);
        }
    }
}
