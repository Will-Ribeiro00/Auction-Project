using RocketseatAuction.API.Communication.Requests.User;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Users.Update
{
    public class UpdateUserUseCase
    {
        private readonly IUserRepository _repository;
        public UpdateUserUseCase(IUserRepository repository) => _repository = repository;

        public User? Execute(int id, RequestBodyUserJson request) => _repository.Update(id, request);
    }
}
