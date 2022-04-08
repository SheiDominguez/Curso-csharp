using System;

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            //var polygon = new Polygon(20, 50);
            //Console.WriteLine(polygon.GetArea());
            //Polygon.Show();

            var squre = new Square(20);
            Console.WriteLine(squre.GetArea());

            var triangule = new Triangule(20,30);
            Console.WriteLine(triangule.GetArea());
        }
    }

    class Polygon
    {
        public decimal Base { get; set; }
        public decimal Height { get; set; }

        //public Polygon(decimal baseDim, decimal heightDim)
        //{
        //    Base = baseDim;
        //    Height = heightDim;
        //}

        //public Polygon() { }

        public virtual decimal GetArea()
        {
            return Base * Height;
        }

        //public static void show()
        //{
        //    console.writeline("show time!");
        //}
    }


    class Square : Polygon
    {
        public Square(decimal baseDim)
        {
            Base = baseDim;
            Height = baseDim;
        }
    }

    class Rectangule : Polygon
    {
        public Rectangule(decimal baseDim, decimal heightDim)
        {
            Base = baseDim;
            Height = heightDim;
        }
    }

    class Triangule : Polygon
    {
        public Triangule(decimal baseDim, decimal heightDim)
        {
            Base = baseDim;
            Height = heightDim;
        }

        public override decimal GetArea()
        {
            return (Base * Height) / 2;
        }
    }


}
