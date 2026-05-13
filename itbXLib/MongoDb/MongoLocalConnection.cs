using MongoDB.Driver;

namespace itbXLib.MongoDb;

/// <summary>
/// Helper for creating and reusing a local <see cref="MongoClient"/> instance
/// and retrieving <see cref="IMongoDatabase"/> objects from it.
/// </summary>
public static class MongoLocalConnection
{
    /// <summary>
    /// Connection URL used to connect to the local MongoDB instance.
    /// Default: "mongodb://127.0.0.1:27017/".
    /// </summary>
    private static readonly string Url = "mongodb://127.0.0.1:27017/";

    /// <summary>
    /// Cached <see cref="MongoClient"/> instance used for all operations.
    /// Lazily created by <see cref="GetMongoClient"/>.
    /// </summary>
    private static MongoClient? _mongoClient;

    /// <summary>
    /// Gets a database with the specified name from the local MongoDB server.
    /// </summary>
    /// <param name="database">The name of the database to retrieve.</param>
    /// <returns>An <see cref="IMongoDatabase"/> instance for the given database name.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the database could not be obtained from the client.
    /// This should not normally happen unless the client is misconfigured.
    /// </exception>
    public static IMongoDatabase GetDatabase(string database)
    {
        if (_mongoClient == null) GetMongoClient();

        return _mongoClient!.GetDatabase(database) ??
               throw new InvalidOperationException($"Failed to get database: {database}");
    }

    /// <summary>
    /// Returns the singleton <see cref="MongoClient"/> instance used by this helper.
    /// If no client exists yet, a new one is created.
    /// </summary>
    /// <returns>The singleton <see cref="MongoClient"/> used for connections.</returns>
    public static MongoClient GetMongoClient()
    {
        if (_mongoClient == null)
        {
            CreateMongoClient();
        }
        return _mongoClient ?? new MongoClient(Url);
    }

    /// <summary>
    /// Creates and caches a new <see cref="MongoClient"/> using <see cref="Url"/>.
    /// </summary>
    private static void CreateMongoClient()
    {
        _mongoClient = new MongoClient(Url);
    }
}
