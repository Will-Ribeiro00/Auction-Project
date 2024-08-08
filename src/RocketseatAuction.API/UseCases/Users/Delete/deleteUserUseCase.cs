using RocketseatAuction.API.Contracts;

namespace RocketseatAuction.API.UseCases.Users.Delete
{
    public class DeleteUserUseCase
    {
        private readonly IUserRepository _repository;
        public DeleteUserUseCase(IUserRepository repository) => _repository = repository;

        public bool Execute(int id) => _repository.Delete(id);
    }
}
