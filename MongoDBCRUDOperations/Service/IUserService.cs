using MongoDBCRUDOperations.Enitites;

namespace MongoDBCRUDOperations.Service;

public interface IUserService
{
    Task Insert(User user);
    Task Delete(Guid userId);
    Task<User> GetBy(Guid userId);
    Task<List<User>> GetUsers();
    Task Update(User user);
}