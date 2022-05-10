using MongoDB.Driver;
using MongoDBCRUDOperations.Enitites;
using MongoDBCRUDOperations.Models;

namespace MongoDBCRUDOperations.Service;

public class UserService : IUserService
{


    private readonly IMongoCollection<User> _users;
    public UserService(MongoSettings settings,IMongoClient client)
    {
        var dataBase = client.GetDatabase(settings.DatabaseName);
        _users = dataBase.GetCollection<User>("Users");
    }

    public async Task Insert(User user)
    {
        await _users.InsertOneAsync(user);
    }

    public async Task Delete(Guid userId)
    {
        await _users.DeleteOneAsync(c=>c.Id == userId);
    }

    public async Task<User> GetBy(Guid userId)
    {
        return await _users.Find(c => c.Id == userId).FirstOrDefaultAsync();
    }

    public async Task<List<User>> GetUsers()
    {
        return await _users.Find(c=>true).ToListAsync();
    }

    public async Task Update(User user)
    {
        await _users.ReplaceOneAsync(c => c.Id == user.Id, user);
    }
}