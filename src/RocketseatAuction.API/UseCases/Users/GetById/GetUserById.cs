using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Users.GetById
{
    public class GetUserById
    {
        private readonly IUserRepository _repository;
        public GetUserById(IUserRepository repository) => _repository = repository;

        public User? Execute(int id) => _repository.GetUserById(id);
    }
}
