using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using static FSharpCalc.Calculator;
using CalculatorSeriallization;

namespace ASPCalculator
{
    public class CalculatorMiddleware
    {
        private readonly RequestDelegate next;
        public CalculatorMiddleware(RequestDelegate _next)
        {
            next = _next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            using (var sr = new StreamReader(context.Request.Body))
            {
                var str = await sr.ReadToEndAsync();
                var data = JsonSerializer.Deserialize<InputData>(str);
                var answerString = showValue(activate(data.FirstNumber, data.Operation, data.SecondNumber));
                var bytes = System.Text.Encoding.UTF8.GetBytes(answerString);
                await context.Response.Body.WriteAsync(bytes,0,bytes.Length);
            }
            
        }
    }
}