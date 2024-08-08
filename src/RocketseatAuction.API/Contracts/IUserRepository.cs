using RocketseatAuction.API.Communication.Requests.User;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
    User Create(User user);
    User? GetUserById(int id);
    List<User>? GetAllUsers();
    User? Update(int id, RequestBodyUserJson request);
    bool Delete(int id);
}
