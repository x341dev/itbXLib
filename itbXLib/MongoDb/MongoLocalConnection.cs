using MongoDB.Driver;

namespace itbXlib.MongoDb;

public static class MongoLocalConnection
{
    private static string Url = "mongodb://127.0.0.1:27017/";

    private static MongoClient? _mongoClient;


    public static IMongoDatabase GetDatabase(string database)
    {
        if (_mongoClient == null) GetMongoClient();

        return _mongoClient!.GetDatabase(database) ??
               throw new InvalidOperationException($"Failed to get database: {database}");
    }

    public static MongoClient GetMongoClient()
    {
        if (_mongoClient == null)
        {
            CreateMongoClient();
        }
        return _mongoClient ?? new MongoClient(Url);
    }

    private static void CreateMongoClient()
    {
        _mongoClient = new MongoClient(Url);
    }
}
