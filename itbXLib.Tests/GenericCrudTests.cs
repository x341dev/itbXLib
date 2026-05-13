using itbXLib.MongoDb;
using MongoDB.Driver;
using Xunit;

namespace itbXLib.Tests;

// Clase modelo dummy para realizar los tests
public class DummyDocument
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public int Value { get; set; }
}

public class GenericCrudTests : IDisposable
{
    private readonly IMongoDatabase _database;
    private readonly GenericCrud<DummyDocument> _crud;
    private readonly string _collectionName;

    public GenericCrudTests()
    {
        _database = MongoLocalConnection.GetDatabase("TestDatabase");

        _collectionName = $"TestCollection_{Guid.NewGuid()}";
        _crud = new GenericCrud<DummyDocument>(_database, _collectionName);
    }

    [Fact]
    public void Create_ShouldInsertItem()
    {
        // Arrange
        var item = new DummyDocument { Name = "TestItem", Value = 10 };

        // Act
        _crud.Create(item);

        // Assert
        var result = _crud.GetById(item.Id);
        Assert.NotNull(result);
        Assert.Equal("TestItem", result.Name);
    }

    [Fact]
    public void CreateMany_ShouldInsertMultipleItems()
    {
        // Arrange
        var items = new List<DummyDocument>
        {
            new() { Name = "Item1", Value = 1 },
            new() { Name = "Item2", Value = 2 }
        };

        // Act
        _crud.CreateMany(items);

        // Assert
        var result = _crud.GetAll();
        Assert.Equal(2, result.Count);
        Assert.Contains(result, i => i.Name == "Item1");
        Assert.Contains(result, i => i.Name == "Item2");
    }

    [Fact]
    public void GetAll_ShouldReturnEmptyList_WhenNoItemsExist()
    {
        // Act
        var result = _crud.GetAll();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetByParam_ShouldReturnCorrectItem()
    {
        // Arrange
        var targetItem = new DummyDocument { Name = "Target", Value = 50 };
        var otherItem = new DummyDocument { Name = "Other", Value = 100 };
        _crud.CreateMany(new[] { targetItem, otherItem });

        // Act
        var result = _crud.GetByParam("Name", "Target");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(targetItem.Id, result.Id);
    }

    [Fact]
    public void GetById_ShouldReturnNull_WhenItemDoesNotExist()
    {
        // Act
        var result = _crud.GetById("non-existent-id");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Update_ShouldModifyExistingItem()
    {
        // Arrange
        var item = new DummyDocument { Name = "OldName", Value = 0 };
        _crud.Create(item);

        // Act
        item.Name = "NewName";
        item.Value = 99;
        _crud.Update(item.Id, item);

        // Assert
        var updatedItem = _crud.GetById(item.Id);
        Assert.NotNull(updatedItem);
        Assert.Equal("NewName", updatedItem.Name);
        Assert.Equal(99, updatedItem.Value);
    }

    [Fact]
    public void Delete_ShouldRemoveItem()
    {
        // Arrange
        var item = new DummyDocument { Name = "ToDelete", Value = 0 };
        _crud.Create(item);

        // Verificamos que se insertó correctamente
        Assert.NotNull(_crud.GetById(item.Id));

        // Act
        _crud.Delete(item.Id);

        // Assert
        var deletedItem = _crud.GetById(item.Id);
        Assert.Null(deletedItem);
    }

    [Fact]
    public void Drop_ShouldRemoveEntireCollection()
    {
        // Arrange
        _crud.Create(new DummyDocument { Name = "Item1" });
        _crud.Create(new DummyDocument { Name = "Item2" });

        // Act
        _crud.Drop();

        // Assert
        var collections = _database.ListCollectionNames().ToList();
        Assert.DoesNotContain(_collectionName, collections);
    }

    public void Dispose()
    {
        _crud.Drop();
    }
}
