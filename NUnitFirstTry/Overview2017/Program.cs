using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SumAdjacentEqualNumbers
{
    public static void Main()
    {
        var separators = new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' };
        var input = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        
    }

    private static void SumTwoEqualAjustNums()
    {
        List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
        int index = 0;

        while (index < numbers.Count - 1)
        {
            if (numbers[index] == numbers[index + 1])
            {
                numbers[index] = numbers[index] + numbers[index + 1];
                numbers.RemoveAt(index + 1);
                if (index > 0)
                {
                    index--;
                }
            }
            else
            {
                index++;
            }

        }


        Console.WriteLine(string.Join(" ", numbers));
    }

    private static void ListReverse()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).Where(x => x > 0).Reverse();

            if (input.Count() > 0)
            {
                Console.WriteLine(string.Join(" ", input));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }

        private static void ReverceArray()
        {
            int number = int.Parse(Console.ReadLine());
            int[] myarr = new int[number];
            for (int i = 0; i < number; i++)
            {
                int currentnum = int.Parse(Console.ReadLine());
                myarr[i] = currentnum;
            }
            for (int i = number - 1; i >= 0; i--)
            {
                Console.Write(myarr[i] + " ");
            }
            Console.WriteLine();
        }

        private static void PrintWeekdays()
        {
            int number = int.Parse(Console.ReadLine());
            string[] weekdays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            if (number > 7 || number <= 0)
            {
                Console.WriteLine("Invalid day!");

            }
            else
            {
                Console.WriteLine(weekdays[number - 1]);
            }
        }

        private static void PrintFilledSqare()
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', number * 2));
            for (int i = 0; i < (number - 2); i++)
            {

                Console.Write('-');
                for (int j = 1; j < number; j++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine('-');
            }
            Console.WriteLine(new string('-', number * 2));
        }

        private static void PrintTriangle()
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            for (int i = number - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintSign()
        {
            int number = int.Parse(Console.ReadLine());
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }

        private static void PrintReceipe()
        {
            PrintHeader();
            PrintMainContent();
            PrintFooter();
        }

        private static void PrintFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }

        private static void PrintMainContent()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        private static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }

        public void CenturiesConverter()
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minuties = hours * 60;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minuties} minutes");
        }

        public void CircleAria()
        {
            double radius = double.Parse(Console.ReadLine());
            double circle_aria = Math.PI * radius * radius;

            Console.WriteLine($"{circle_aria:f12}");
        }
        
        public void SumofRealNums()
        {
            int numbers = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < numbers; i++)
            {
                decimal currentNumber = decimal.Parse(Console.ReadLine());
                sum += currentNumber;
            }
            Console.WriteLine(sum);
        }
    
}
