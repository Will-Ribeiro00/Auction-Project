using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Users.GetById
{
    public class GetAllUsersUseCase
    {
        private readonly IUserRepository _repository;
        public GetAllUsersUseCase(IUserRepository repository) => _repository = repository;

        public List<User>? Execute() => _repository.GetAllUsers();
    }
}
