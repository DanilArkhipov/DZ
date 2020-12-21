using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace Benchmarks
{
    public class Benchmarks
    {
        
        [Benchmark(Description = "SimpleMethod")]
        public void SimpleMethod()
        {
            var s = "";
            for (int i = 0; i < 10; i++)
            {
                s += "a";
            }
        }
        
        [Benchmark(Description = "DynamicMethod")]
        public void DynamicMethod()
        {
            dynamic s = "";
            for (int i = 0; i < 10; i++)
            {
                s += "a";
            }
        }
        
        [Benchmark(Description = "StaticMethod")]
        public void func1()
        {
            Methods.StaticMethod();
        }
        
        [Benchmark(Description = "StaticDynamicMethod")]
        public void func2()
        {
            Methods.StaticDynamicMethod();
        }
        
        [Benchmark(Description = "VirtualMethod")]
        public virtual void VirtualMethod()
        {
            var s = "";
            for (int i = 0; i < 10; i++)
            {
                s += "a";
            }
        }
        
        [Benchmark(Description = "DynamicVirtualMethod")]
        public virtual void DynamicVirtualMethod()
        {
            dynamic s = "";
            for (int i = 0; i < 10; i++)
            {
                s += "a";
            }
        }
        
        [Benchmark(Description = "GenericMethod")]
        public void func3()
        {
            var methods = new Methods();
            methods.GenericMethod("a");
        }
        
        [Benchmark(Description = "DynamicGenericMethod")]
        public void func4()
        {
            var methods = new Methods();
            methods.DynamicGenericMethod("a");
        }

        [Benchmark(Description = "ReflectionMethod")]
        public void ReflectionMethod()
        {
            Type type = this.GetType();
            var methodInfo = type.GetMethod("SimpleMethod").Invoke(this, null);
        }

    }
}