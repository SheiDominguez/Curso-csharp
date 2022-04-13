using System;
using System.Linq;
using System.Collections.Generic;
using LinqExercises.Clases;

namespace LinqExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("primer elemento de la categoria Seafood");
            Console.WriteLine(Products.GetFirstSeafood());
            Console.WriteLine("\nPrecio promedio de productos por categoria\n");
            Console.WriteLine(Products.AveragePricePerCategory());
            Console.WriteLine("\ncantidad de productos\n");
            Console.WriteLine(Products.ProductsAmount());
            Console.WriteLine("\nproductos que cuestan menos de 12 ordenados por el mas barato\n");
            Console.WriteLine(Products.ProductsPriceLower12AverageOrdered());
            Console.WriteLine("\ntop 3 de productos más caros\n");
            Console.WriteLine(Products.Top3ExpensiveProducts());
            Console.WriteLine("\ntop 3 de productos más baratos\n");
            Console.WriteLine(Products.Top3CheaperProducts());
            Console.WriteLine("\nel producto con el nombre mas largo\n");
            Console.WriteLine(Products.ProductWithLargestName());
            Console.WriteLine("\nsuma de stock general\n");
            Console.WriteLine(Products.GeneralStock());
            Console.WriteLine("\ntraer el nombre del producto con el id 80\n");
            Console.WriteLine(Products.ProductWithId80());
            Console.WriteLine("\nlistado ordenado por la categoria y luego por el precio\n");
            Console.WriteLine(Products.ListOrderedByCategoryThenPrice());
            Console.WriteLine("\nel producto con mayor cantidad de palabras\n");
            Console.WriteLine(Products.ProductWithMoreWords());
            Console.WriteLine("\nel producto que su precio total sea el mayor multiplicando su precio unitario por la cantidad en stock\n");
            Console.WriteLine(Products.ProductWithHigherTotalPrice());
        }
    }
}
