using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var clas = new bench();
            BenchmarkRunner.Run(new[]
            {
                clas.PublicMethod(),
                bench.PublicStaticGeneric<int>(),
                clas.PublicGeneric<int>(),
                clas.PublicVitrualMethod(),
                clas.PublicDinamyc(),
            };

        }

        private class bench
        {
            
            private static int PrivateMethod()
            {
                var str = "+";
                for (var i = 0; i < 100000; i++) str += "+";

                return 1;
            }
            [Benchmark(Description = "Summ100")]
            public int PublicMethod()
            {
                return PrivateMethod();
            }
            [Benchmark(Description = "Summ100")]
            public static int PublicStaticMethod()
            {
                return PrivateMethod();
            }
            [Benchmark(Description = "Summ100")]
            public virtual int PublicVitrualMethod()
            {
                return PrivateMethod();
            }
            [Benchmark(Description = "Summ100")]
            public static int PublicStaticGeneric<T>()
            {
                return PrivateMethod();
            }
            [Benchmark(Description = "Summ100")]
            public int PublicGeneric<T>()
            {
                return PrivateMethod();
            }
            [Benchmark(Description = "Summ100")]
            public dynamic PublicDinamyc()
            {
                return PrivateMethod();
            }
        }
    }
}