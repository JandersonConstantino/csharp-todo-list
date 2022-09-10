
using System.Security.Authentication;
using MongoDB.Driver;

namespace Todo.WebApi.Models;

public class DatabaseContext
{
     public static string ConnectionString { get; set; }
     public static string DatabaseName { get; set; }
     public static bool IsSSL { get; set; }
     
     public IMongoDatabase Database { get; init; }

     public DatabaseContext()
     {
          try
          {
               var settings = MongoClientSettings.FromUrl((new MongoUrl(ConnectionString)));

               if (IsSSL)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

               var client = new MongoClient(settings);
               Database = client.GetDatabase((DatabaseName));
          }
          catch (Exception e)
          {
               throw new Exception("We cannot connect to database.", e);
          }
     }

     public IMongoCollection<Item> Item => Database.GetCollection<Item>("Item");
}