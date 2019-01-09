using System;
using System.Runtime.InteropServices;

namespace test_call_c
{
    class test_base_valuetype
    {
        public static void test()
        {
            Console.WriteLine("test_base_valuetype");
            
            call1();

            fun_input_int(1234);
            fun_input_int(int.MaxValue);
            
            fun_input_long(3214);
            fun_input_long(long.MaxValue);
            
            fun_input_float((float)3.14159265358979);
            fun_input_float(float.MaxValue);
            
            fun_input_double(3.14159265358979);
            fun_input_double(double.MinValue);
            
            
            
            var s2 = new Struct_s2();
            s2.i = 10086;
            s2.l = 1008600010068;
            s2.f = (float)10.086;
            s2.d = 100.86;
            
            Console.WriteLine("Struct_s2");
            fun_input_struct_s2(s2);
            
            Console.WriteLine("Struct_s2_ref");
            fun_input_struct_s2_ref(ref s2);
            
            
            var s1 = new Struct_s1();
            s1.i = 10086;
            s1.l = 1008600010068;
            s1.f = (float)10.086;
            s1.d = 100.86;
            
            Console.WriteLine("Struct_s1");
            fun_input_struct_s1(s1);
            
            Console.WriteLine("Struct_s1_ref");
            fun_input_struct_s1_ref(ref s1);
        }
        
        // 本地函数名与c函数名不一致的情况
        [DllImport("test.so", EntryPoint = "fun1")]
        public static extern IntPtr call1();
        
        [DllImport("test.so", EntryPoint = "fun_input_int")]
        public static extern IntPtr fun_input_int(int i);
        
        [DllImport("test.so", EntryPoint = "fun_input_long")]
        public static extern IntPtr fun_input_long(long i);

        [DllImport("test.so", EntryPoint = "fun_input_float")]
        public static extern IntPtr fun_input_float(float i);
        
        [DllImport("test.so", EntryPoint = "fun_input_double")]
        public static extern IntPtr fun_input_double(double i);
        
        // 测试自定义结构体（默认顺序）
        [DllImport("test.so", EntryPoint = "fun_input_struct_s1")]
        public static extern IntPtr fun_input_struct_s1(Struct_s1 i);
        
                // 测试自定义结构体（默认顺序）
        [DllImport("test.so", EntryPoint = "fun_input_struct_s1")]
        public static extern IntPtr fun_input_struct_s1_ref(ref Struct_s1 i);
        
        // 测试自定义结构体（自定义顺序）
        [DllImport("test.so", EntryPoint = "fun_input_struct_s1")]
        public static extern IntPtr fun_input_struct_s2(Struct_s2 i);
        
                // 测试自定义结构体（自定义顺序）
        [DllImport("test.so", EntryPoint = "fun_input_struct_s1")]
        public static extern IntPtr fun_input_struct_s2_ref(ref Struct_s2 i);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct Struct_s1
    {
        public int i;
        
        public long l;
        
        public float f;
        
        public double d;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct Struct_s2
    {
        [FieldOffset(0)]
        public int i;
        
        [FieldOffset(8)]
        public long l;
        
        [FieldOffset(16)]
        public float f;
        
        [FieldOffset(24)]
        public double d;
    }
}