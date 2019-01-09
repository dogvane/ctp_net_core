using System;
using System.Runtime.InteropServices;

namespace test_call_c
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
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
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=31)]
            public string username;
            
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=31)]
            public string password;
            
            public int logintype;
        }
    }
}
