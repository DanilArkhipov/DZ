using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSharpProxy
{
    public interface ICalculate
    {
        public Task<double> CalculateAsync(double num1,char ch,double num2);
    }
}