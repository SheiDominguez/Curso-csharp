using System;

namespace CalculadoraGeometrica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selecciona la figura de la que deseas conocer el perímetro y área:");
            Console.WriteLine("1 - Cuadrado, 2 - Rectángulo, 3 - Triángulo, 4 - Círculo");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out int opcion);
            if (isNumber)
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Por favor intruduce la longitud de la base");
                        var isNum = Double.TryParse(Console.ReadLine(), out double lado);
                        if (isNum)
                        {
                            Console.WriteLine("*** DELEGATE ***");
                            Delegados.ProcesaCuadrado(lado);
                            Console.WriteLine("*** FUNC ***");
                            Funciones.ProcesaCuadrado(lado);  
                        }
                        else {
                            Console.WriteLine("Por favor introduce un número válido");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Por favor intruduce la longitud de la base");
                        var isNumLado1 = Double.TryParse(Console.ReadLine(), out double lado1);
                        Console.WriteLine("Por favor intruduce la altura");
                        var isNumLado2 = Double.TryParse(Console.ReadLine(), out double lado2);
                        if (isNumLado1 && isNumLado2)
                        {
                            Console.WriteLine("*** DELEGATE ***");
                            Delegados.ProcesaRectangulo(lado1, lado2);
                            Console.WriteLine("*** FUNC ***");
                            Funciones.ProcesaRectangulo(lado1, lado2);
                        }
                        else
                        {
                            Console.WriteLine("Por favor introduce un número válido");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Por favor intruduce la longitud de la base");
                        isNumLado1 = Double.TryParse(Console.ReadLine(), out lado1);
                        Console.WriteLine("Por favor intruduce la altura");
                        var isNumAltura = Double.TryParse(Console.ReadLine(), out double altura);
                        if (isNumLado1 && isNumAltura)
                        {
                            Console.WriteLine("*** DELEGATE ***");
                            Delegados.ProcesaTriangulo(lado1, altura);
                            Console.WriteLine("*** FUNC ***");
                            Funciones.ProcesaTriangulo(lado1, altura);
                        }
                        else
                        {
                            Console.WriteLine("Por favor introduce un número válido");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Por favor intruduce la longitud del radio");
                        var isNumRadio = Double.TryParse(Console.ReadLine(), out double radio);
                        Console.WriteLine("Por favor intruduce la longitud del diámetro");
                        var isNumDiametro = Double.TryParse(Console.ReadLine(), out double diametro);
                        if (isNumRadio && isNumDiametro)
                        {
                            Console.WriteLine("*** DELEGATE ***");
                            Delegados.ProcesaCirculo(radio, diametro);
                            Console.WriteLine("*** FUNC ***");
                            Funciones.ProcesaCirculo(radio, diametro);
                        }
                        else
                        {
                            Console.WriteLine("Por favor introduce un número válido");
                        }
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor proporcione un número válido");
            }
        }
    }

    class Delegados
    {
        public delegate double CalculaAreaCuadrado(double lado);
        public delegate double CalculaPerimetroCuadrado(double lado);
        public delegate double CalculaAreaRectangulo(double lado1, double lado2);
        public delegate double CalculaPerimetroRectangulo(double lado1, double lado2);
        public delegate double CalculaAreaTriangulo(double lado1, double altura);
        public delegate double CalculaPerimetroTriangulo(double lado1, double altura);
        public delegate double CalculaAreaCirculo(double radio);
        public delegate double CalculaPerimetroCirculo(double diametro);

        public static void ProcesaCuadrado(double lado)
        {
            CalculaAreaCuadrado areaCuadrado = new CalculaAreaCuadrado(x => x * x);
            CalculaPerimetroCuadrado perimetroCuadrado = new CalculaPerimetroCuadrado(x => x * 4);
            Console.WriteLine($"El área del cuadrado es {areaCuadrado(lado)}");
            Console.WriteLine($"El perímetro del cuadrado es {perimetroCuadrado(lado)}");
        }

        public static void ProcesaRectangulo(double lado1, double lado2)
        {
            CalculaAreaRectangulo areaRectangulo = new CalculaAreaRectangulo((x, y) => x * y);
            CalculaPerimetroRectangulo perimetroRectangulo = new CalculaPerimetroRectangulo((x, y) => (x * 2) + (y * 2));
            Console.WriteLine($"El área del rectángulo es {areaRectangulo(lado1, lado2)}");
            Console.WriteLine($"El perímetro del rectángulo es {perimetroRectangulo(lado1, lado2)}");
        }
        // x + 2 * (y / Math.Sin(Math.Atan(y / (x/2))))
        public static void ProcesaTriangulo(double lado1, double altura)
        {
            CalculaAreaTriangulo areaTriangulo = new CalculaAreaTriangulo((x, y) => (x * y)/2);
            CalculaPerimetroTriangulo perimetroTriangulo = new CalculaPerimetroTriangulo((x, y) => x + 2 * (y / Math.Sin(Math.Atan(y / (x / 2)))));
            Console.WriteLine($"El área del triángulo es {areaTriangulo(lado1, altura)}");
            Console.WriteLine($"El perímetro del triángulo es {perimetroTriangulo(lado1, altura)}");
        }

        public static void ProcesaCirculo(double radio, double diametro)
        {
            CalculaAreaCirculo areaCirculo = new CalculaAreaCirculo((x) => Math.PI * (Math.Sqrt(x)));
            CalculaPerimetroCirculo perimetroCirculo = new CalculaPerimetroCirculo(x => Math.PI * x);
            Console.WriteLine($"El área del círculo es {areaCirculo(radio)}");
            Console.WriteLine($"El perímetro del círculo es {perimetroCirculo(diametro)}");
        }


    }

    class Funciones
    {
        public static void ProcesaCuadrado(double lado)
        {
            Func<double, double> areaCuadrado = (x) => x * x;
            Func<double, double> perimetroCuadrado = (x) => x * 4;
            Console.WriteLine($"El área del cuadrado es {areaCuadrado(lado)}");
            Console.WriteLine($"El perímetro del cuadrado es {perimetroCuadrado(lado)}");
        }

        public static void ProcesaRectangulo(double lado1, double lado2)
        {
            Func<double, double, double> areaRectangulo = (x, y) => x * y;
            Func<double, double, double> perimetroRectangulo = (x, y) => (x * 2) + (y * 2);
            Console.WriteLine($"El área del rectángulo es {areaRectangulo(lado1, lado2)}");
            Console.WriteLine($"El perímetro del rectángulo es {perimetroRectangulo(lado1, lado2)}");
        }

        public static void ProcesaTriangulo(double lado1, double altura)
        {
            Func<double, double, double> areaTriangulo = (x, y) => (x * y) / 2;
            Func<double, double, double> perimetroTriangulo = (x, y) => x + 2 * (y / Math.Sin(Math.Atan(y / (x / 2))));
            Console.WriteLine($"El área del triángulo es {areaTriangulo(lado1, altura)}");
            Console.WriteLine($"El perímetro del triángulo es {perimetroTriangulo(lado1, altura)}");
        }

        public static void ProcesaCirculo(double radio, double diametro)
        {
            Func<double, double> areaCirculo = (x) => Math.PI * (Math.Sqrt(x));
            Func<double, double> perimetroCirculo = (x) => Math.PI * x;
            Console.WriteLine($"El área del círculo es {areaCirculo(radio)}");
            Console.WriteLine($"El perímetro del círculo es {perimetroCirculo(diametro)}");
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
