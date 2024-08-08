using RocketseatAuction.API.Communication.Requests.Auction;
using RocketseatAuction.API.Communication.Requests.User;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;
    public UserRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));

    public User? GetUserById(int id) => _dbContext.Users.FirstOrDefault(user => user.Id.Equals(id));

    public List<User>? GetAllUsers() => [.. _dbContext.Users.OrderBy(user => user.Id)];

    public User Create(User user)
    {
        _dbContext.Users.Add(user);

        _dbContext.SaveChanges();

        return user;
    }

    public User? Update(int id, RequestBodyUserJson request)
    {
        var user = _dbContext.Users.FirstOrDefault(user => user.Id.Equals(id));

        if (user == null) return null;

        user.Name = request.Name;
        user.Email = request.Email;

        _dbContext.SaveChanges();

        return user;
    }
    public bool Delete(int id)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id.Equals(id));

        if (user is null) return false;

        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();
        return true;
    }
}
