using System;
using System.Text.Json;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

class Program : Class1
{
    static void Main(string[] args)
    {
        Connection.Conn(); //Conexión a la base de datos 
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Tienda ONLINE.\n");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Consultar productos");
            Console.WriteLine("3. Actualizar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AgregarProductos();
                    break;
                case "2":
                    ConsultarProductos();
                    break;
                case "3":
                    ActualizarProducto();
                    break;
                case "4":
                    EliminarProducto();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}