using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB
{
    public class Connection
    {
        public static IMongoCollection<BsonDocument> _collection;

        public static void Conn()
        {
            // Configuración de la conexión con MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Tienda-Online"); // Nombre de la base de datos
            _collection = database.GetCollection<BsonDocument>("productscollection"); // Nombre de la colección
        }
    }
}