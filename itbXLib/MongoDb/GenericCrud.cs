using itbXLib.TerminalUtils;
using MongoDB.Driver;

namespace itbXlib.MongoDb;

/// <summary>
/// Generic CRUD helper for a MongoDB collection.
/// Provides basic Create, Read, Update and Delete operations for type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The document type stored in the MongoDB collection.</typeparam>
public class GenericCrud<T>
{
    /// <summary>
    /// The MongoDB collection used to persist instances of <typeparamref name="T"/>.
    /// </summary>
    private readonly IMongoCollection<T> _collection;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericCrud{T}"/> class using the
    /// provided MongoDB database and collection name.
    /// </summary>
    /// <param name="database">The MongoDB database instance to use.</param>
    /// <param name="collectionName">The name of the collection for <typeparamref name="T"/>.</param>
    public GenericCrud(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }

    /// <summary>
    /// Inserts the specified item into the collection.
    /// </summary>
    /// <param name="item">The item to insert.</param>
    public void Create(T item)
    {
        _collection.InsertOne(item);
        ConsoleHelper.ColorWriteLine($"Inserted item into collection: {item}", ConsoleColor.Green);
    }

    /// <summary>
    /// Inserts multiple items into the collection in a single operation.
    /// </summary>
    /// <param name="items">The list of items to insert.</param>
    public void CreateMany(IEnumerable<T> items)
    {
        _collection.InsertMany(items);
        ConsoleHelper.ColorWriteLine($"Inserted {items.Count()} items into collection", ConsoleColor.Green);
    }

    /// <summary>
    /// Retrieves all documents from the collection.
    /// </summary>
    /// <returns>A list containing all documents of type <typeparamref name="T"/> in the collection.</returns>
    public List<T> GetAll()
    {
        var items = _collection.Find(_ => true).ToList();
        if (items.Count == 0)
        {
            ConsoleHelper.ColorWriteLine("No items found in collection", ConsoleColor.Yellow);
        }
        else
        {
            ConsoleHelper.ColorWriteLine($"Retrieved all items from collection: {items.Count} items found", ConsoleColor.Green);
        }
        return items;
    }

    /// <summary>
    /// Finds a document by its Id field.
    /// </summary>
    /// <param name="id">The id value to search for (as a string).</param>
    /// <returns>The matching document, or <c>null</c> if not found.</returns>
    public T GetById(string id)
    {
        var item = _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefault();
        if (item == null)
        {
            ConsoleHelper.ColorWriteLine($"No item found with ID: {id}", ConsoleColor.Yellow);
        }
        else
        {
            ConsoleHelper.ColorWriteLine($"Retrieved item by ID: {id} - Found: {item != null}", ConsoleColor.Green);
        }
        return item;
    }

    /// <summary>
    /// Finds a document by an arbitrary parameter name and value.
    /// </summary>
    /// <param name="paramName">The field name to query.</param>
    /// <param name="paramValue">The value to match for the specified field.</param>
    /// <returns>The matching document, or <c>null</c> if not found.</returns>
    public T GetByParam(string paramName, string paramValue)
    {
        var item = _collection.Find(Builders<T>.Filter.Eq(paramName, paramValue)).FirstOrDefault();
        if (item == null)
        {
            ConsoleHelper.ColorWriteLine($"No item found with {paramName}={paramValue}", ConsoleColor.Yellow);
        }
        else
        {
            ConsoleHelper.ColorWriteLine($"Item found with {paramName}={paramValue}: {item}", ConsoleColor.Green);
        }
        return item;
    }

    /// <summary>
    /// Replaces the document with the specified id with the provided updated item.
    /// </summary>
    /// <param name="id">The id of the document to replace.</param>
    /// <param name="updatedItem">The new document value to store.</param>
    public void Update(string id, T updatedItem)
    {
        var result = _collection.ReplaceOne(Builders<T>.Filter.Eq("Id", id), updatedItem);
        if (result.MatchedCount == 0)
        {
            ConsoleHelper.ColorWriteLine($"No item found with ID: {id} to update", ConsoleColor.Yellow);
        } else
        {
            ConsoleHelper.ColorWriteLine(
                $"Updated item with ID: {id} - Matched: {result.MatchedCount}, Modified: {result.ModifiedCount}", ConsoleColor.Green);
        }
    }

    /// <summary>
    /// Deletes the document with the specified id from the collection.
    /// </summary>
    /// <param name="id">The id of the document to delete.</param>
    public void Delete(string id)
    {
        var result = _collection.DeleteOne(Builders<T>.Filter.Eq("Id", id));
        if (result.DeletedCount == 0)
        {
            ConsoleHelper.ColorWriteLine($"No item found with ID: {id} to delete", ConsoleColor.Yellow);
        } else
        {
            ConsoleHelper.ColorWriteLine($"Deleted item with ID: {id} - Deleted Count: {result.DeletedCount}", ConsoleColor.Green);
        }
    }

    /// <summary>
    /// Drops the entire collection from the database.
    /// </summary>
    public void Drop()
    {
        var name = _collection.CollectionNamespace.CollectionName;
        _collection.Database.DropCollection(name);
        ConsoleHelper.ColorWriteLine($"Dropped collection: {name}", ConsoleColor.Green);
    }


}
