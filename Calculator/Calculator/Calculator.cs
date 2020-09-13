﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {
        const string startStr = "Введите простое выражение вида число оператор число\nНа следующей строке калькулятор выведет ответ";
        public void CalculatorActivate()
        {
            Console.WriteLine(startStr);
            while (true)
            {
                Calculate(Console.ReadLine());
            }
        }

        private void Calculate(string input)
        {
            var tmpArray = input.Split(' ');
            double res = 0;
            switch (tmpArray[1])
            {
                case "+":
                    {
                        res = Double.Parse(tmpArray[0]) + Double.Parse(tmpArray[2]);
                        break;
                    }
                case "-":
                    {
                        res = Double.Parse(tmpArray[0]) - Double.Parse(tmpArray[2]);
                        break;
                    }
                case "*":
                    {
                        res = Double.Parse(tmpArray[0]) * Double.Parse(tmpArray[2]);
                        break;
                    }
                case "/":
                    {
                        if (tmpArray[1] != "0")
                        {
                            res = Double.Parse(tmpArray[0]) / Double.Parse(tmpArray[2]);
                        }
                        else Print(tmpArray[0], tmpArray[1], tmpArray[2], "На ноль делить нельзя");
                        break;
                    }
                default:
                    {
                        Print(tmpArray[0], tmpArray[1], tmpArray[2], "Неправильный ввод");
                        return;
                    }
            }
            Print(tmpArray[0], tmpArray[1], tmpArray[2], res);
            
        }
        private void Print(string first, string @operator, string second, Object o)
        {
            if(o is Double)
            {
                Console.WriteLine("{0} {1} {2} = {3}", first, @operator, second, o);
            }
            else if( o is string)
            {
                Console.WriteLine(o);
            }
        }
    }
}
