using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CalculatorSeriallization;
using Microsoft.AspNetCore.Http;

namespace ASPCalculator
{
    public class CalculatorMiddleware
    {
        private readonly ICalculator calculator;
        private readonly RequestDelegate next;

        public CalculatorMiddleware(RequestDelegate next, ICalculator calculator)
        {
            this.next = next;
            this.calculator = calculator;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var sr = new StreamReader(context.Request.Body))
            {
                var str = await sr.ReadToEndAsync();
                var data = JsonSerializer.Deserialize<InputData>(str);
                var answerString = calculator.Calculate(data.FirstNumber, data.Operation, data.SecondNumber);
                var bytes = Encoding.UTF8.GetBytes(answerString);
                await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}