using System;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a number");
            var inputx = Console.ReadLine();
            var inputy = Console.ReadLine();

            if (Double.TryParse(inputx, out double x) && Double.TryParse(inputy, out double y))
                //DelegatesCalculator.Operate(x,y);
                //FunctionCalculator.Lambda(x , y);
                ActionCalculator.Lambda(x, y);  
            else
                Console.WriteLine("Please insert a valid number");
            
            
        }
    }

    public class DelegatesCalculator
    {
        public delegate double SelfOperator(double x);
        public delegate double Operator(double x, double y);
        public delegate double Minus(double x, double y);
        public delegate double Division(double x, double y);
        public delegate double Sin(double g);
        public delegate double Cos(double g);

        public static void Operate(double num1, double num2)
        {
            SelfOperator square = new SelfOperator(x => x * x);
            Console.WriteLine($"Firs square operation equals {square(num1)}, Second square operation equals {square(num2)}");

            Operator addition = new Operator((x,y) => x + y);
            Console.WriteLine("ADDITION :: " + addition(num1, num2));

            Minus less = new Minus((x, y) => x - y);
            Console.WriteLine($"Substraction equals to {less(num1, num2)}");

            Division divide = new Division((x,y) => x/y);
            Console.WriteLine($"Division equals to {divide(num1, num2)}");

            Sin sin = new Sin(x =>
            {
                var radianes = x * (Math.PI / 180);
                return Math.Sin(radianes);
            });
            Console.WriteLine($"Sin of the angle is {sin(num1)}");

            Cos cos = new Cos(x => {
                var radianes = x * (Math.PI / 180);
                return Math.Cos(radianes);
            });
            Console.WriteLine($"Cos of the angle is {cos(num1)}");
        }
    }

    public class FunctionCalculator
    {
        public static void Lambda(double x, double y)
        {
            Func<double, double> Square = (x) => x * x;
            Console.WriteLine($"SQUARE 1 :: {Square(x)}, SQUARE 2:: {Square(y)}");

            Func<double, double, double> Addition = (x, y) => x + y;
            Console.WriteLine($"ADDITION :: {Addition(x,y)}");

            Func<double, double, double> Subtraction = (x, y) => x - y;
            Console.WriteLine($"SUBTRACTION :: {Subtraction(x, y)}");

            Func<double, double, double> Divide = (x, y) => x / y;
            Console.WriteLine($"DIVISION :: {Divide(x, y)}");

            Func<double, double> Sin = (x) => Math.Sin(x * (Math.PI / 180));
            Console.WriteLine($"SIN :: {Sin(x)}");

            Func<double, double> Cos = (x) => Math.Cos(x * (Math.PI / 180));
            Console.WriteLine($"COS :: {Cos(x)}");
        }
    }

    class ActionCalculator
    {
        public static void Lambda(double x, double y)
        {
            // El Action es un void, por lo tanto no regresa nada
            Action<double, double> addition = (x, y) =>
            {
                Console.WriteLine(x + y);
            };
            addition(x, y);
        }
    }
}
