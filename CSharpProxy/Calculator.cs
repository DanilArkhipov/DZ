using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CalculatorSeriallization;

namespace CSharpProxy
{
    public class Calculator : ICalculate
    {
        public async Task<double> CalculateAsync(double num1, char operation, double num2)
        {
            var convertData = new InputData
            {
                FirstNumber = num1.ToString(CultureInfo.InvariantCulture),
                Operation = operation.ToString(),
                SecondNumber = num2.ToString(CultureInfo.InvariantCulture)
            };
            var jsonString = JsonSerializer.Serialize(convertData);
            using (var client = new HttpClient())
            {
                var content = new StringContent(jsonString);
                var response = await client.PostAsync("https://localhost:5001/", content);
                var resSting = await response.Content.ReadAsStringAsync();
                return Convert.ToDouble(resSting);
            }
        }
    }
}