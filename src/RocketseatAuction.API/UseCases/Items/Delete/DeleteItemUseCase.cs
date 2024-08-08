using RocketseatAuction.API.Contracts;

namespace RocketseatAuction.API.UseCases.Items.Delete
{
    public class DeleteItemUseCase
    {
        private readonly IItemRepository _repository;
        public DeleteItemUseCase(IItemRepository repository) => _repository = repository;

        public bool Execute(int id) => _repository.Delete(id);
    }
}
