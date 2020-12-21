namespace Benchmarks
{
    public class Methods
    {
        public static void StaticMethod()
        {
            string s = "";
            for (int i = 0; i < 10; i++)
            {
                s += "a";
            }
        }
        public static void StaticDynamicMethod()
        {
            dynamic s = "";
            for (int i = 0; i < 10; i++)
            {
                s += "a";
            }
        }
        
        public void GenericMethod<T>(T x)
        {
            string s = "";
            for (int i = 0; i < 10; i++)
            {
                s += x;
            }
        }
        public void DynamicGenericMethod<T>(T x)
        {
            dynamic s = "";
            for (int i = 0; i < 10; i++)
            {
                s += x;
            }
        }

    }
}