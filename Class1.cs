using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

public class Class1 : Connection
{
    public static void AgregarProductos()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("ID del producto: ");
        var id = int.Parse(Console.ReadLine());

        Console.Write("Nombre del producto: ");
        var nombre = Console.ReadLine();

        Console.Write("Categoría: ");
        var cat = Console.ReadLine();

        Console.Write("Precio del producto: $");
        var precio = double.Parse(Console.ReadLine());  // Usar double para manejar decimales

        var documento = new BsonDocument
            {
                { "id", id },
                { "nombre", nombre },
                { "categoria", cat },
                { "precio", precio }
            };

        _collection.InsertOne(documento);
        Console.WriteLine("\nProducto agregado exitosamente.");
        Console.ReadKey();
    }

    public static void ConsultarProductos()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        var productos = _collection.Find(new BsonDocument()).ToList();

        if (productos.Count > 0)
        {
            Console.WriteLine("\nProductos en stock:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.ToJson());
            }
        }
        else
        {
            Console.WriteLine("No hay productos en Stock.");
        }

        Console.ReadKey();
    }

    public static void ActualizarProducto()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Ingrese el ID del producto a actualizar: ");
        var id = int.Parse(Console.ReadLine());

        var producto = _collection.Find(Builders<BsonDocument>.Filter.Eq("id", id)).FirstOrDefault();

        if (producto != null)
        {
            Console.Write("\nIngrese el nuevo nombre: ");
            var nuevoNombre = Console.ReadLine();

            Console.Write("\nIngrese la nueva categoría: ");
            var nuevaCategoria = Console.ReadLine();

            Console.Write("\nIngrese el nuevo precio: $");
            var nuevoPrecio = double.Parse(Console.ReadLine());
            var actualizacion = Builders<BsonDocument>.Update
            .Set("nombre", nuevoNombre)
            .Set("categoria", nuevaCategoria)
            .Set("precio", nuevoPrecio);

            var filtro = Builders<BsonDocument>.Filter.Eq("id", id);
            var resultado = _collection.UpdateOne(filtro, actualizacion);
            if (resultado.ModifiedCount > 0)
                Console.WriteLine("\nProducto actualizado exitosamente.");
           
        }
        else
            Console.WriteLine("\nNo se encontró un producto con ese ID.");

        Console.ReadKey();
    }

    public static void EliminarProducto()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Ingrese el ID del producto a eliminar: ");
        var id = int.Parse(Console.ReadLine());

        var filtro = Builders<BsonDocument>.Filter.Eq("id", id);  
        var resultado = _collection.DeleteOne(filtro);

        if (resultado.DeletedCount > 0)
            Console.WriteLine("\nProducto eliminado exitosamente.");
        else
            Console.WriteLine("\nNo se encontró un producto con ese ID.");

        Console.ReadKey();
    }
}