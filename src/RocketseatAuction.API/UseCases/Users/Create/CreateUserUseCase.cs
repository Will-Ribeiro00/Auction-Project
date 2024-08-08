using RocketseatAuction.API.Communication.Requests.User;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Users.Create
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _repository;
        public CreateUserUseCase(IUserRepository repository) => _repository = repository;

        public User Execute(RequestBodyUserJson request)
        {
            var user = new User()
            {
                Name = request.Name,
                Email = request.Email
            };

            _repository.Create(user);
            return user;
        }
    }
}
