using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAnother
{
    class Program
    {
        public class Average<T>
        {
            private dynamic sum;
            public int i;
            public int j = 0; //Создана для флага ошибок (различие деления на ноль и ввода строки)
            public Average() { 
                if (this.GetType() == typeof (Average<int>))
                {
                    sum = 0;
                } else if (this.GetType() == typeof(Average<double>))
                {
                    sum = 0.0;
                } else
                {
                    Console.WriteLine("Скорее ваш тип не число. Проверьте.");
                }
            }
            public ValueType Add(string number)
            {
                if (Int32.TryParse(number, out int numberInt))
                {
                    if (this.GetType() == typeof(Average<int>))
                    {
                        this.sum += numberInt;
                        this.i++;
                    } else
                    {
                        this.j++;
                        this.i++;
                    }
                } else if (Double.TryParse(number, out double numberDouble))
                {
                    if (this.GetType() == typeof(Average<double>))
                    {
                        this.sum += numberDouble;
                        this.i++;
                    } else
                    {
                        this.j++;
                        this.i++;
                    }
                } else
                {
                    this.j--;
                }
                return this.sum;
            }
            public double Result(ValueType summ)
            {
                if (summ is Int32)
                    return (int)summ / this.i;
                else
                    return (double)summ / this.i;
            }
            public bool Reset()
            {
                if (this.GetType() == typeof(Average<int>))
                    this.sum = 0;
                if (this.GetType() == typeof(Average<double>))
                    this.sum = 0.0;
                this.i = 0;
                this.j = 0;
                return true;
            }
        }
       
        static void Main(string[] args)
        {
            Average<double> firstOne;
            firstOne = new Average<double>();
            Average<int> fOne = new Average<int>();
            ForUser<double>(firstOne);
            ForUser<int>(fOne);
            Console.ReadLine();
        }

        static void ForUser<T> (Average<T> example) 
        {
            string answer;
            dynamic sum1;
            do
            {
                if (example.GetType() == typeof(Average<double>))
                    Console.WriteLine("Введите переменные типа double. Пример: 25,01");
                else if (example.GetType() == typeof(Average<int>))
                    Console.WriteLine("Введите переменную типа int");
                Console.Write("Введите число: ");
                string number = Console.ReadLine();
                sum1 = example.Add(number);
                Console.Write("Вы намерены продолжить? [y/n]: ");
                answer = Console.ReadLine();
                if ((example.i == 0))
                {
                    Console.WriteLine("Произошло деление на ноль!");
                    example.j = 0;
                    continue;
                }
                else if (example.j < 0)
                {
                    Console.WriteLine("Была введена строка");
                    example.j = 0;
                    continue;
                } else if (example.j > 0)
                {
                    Console.WriteLine("Произошло несоответствие типов");
                    Console.WriteLine("Придется ввести все заново!");
                    example.Reset();
                    continue;
                }
            } while (answer.ToLower().Equals("y"));
            Console.WriteLine(Convert.ToString(example.Result(sum1)));
        }
    }
}
