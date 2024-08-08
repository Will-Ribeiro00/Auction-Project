using RocketseatAuction.API.Communication.Requests.Item;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Items.Update
{
    public class UpdateItemUseCase
    {
        private readonly IItemRepository _repository;
        public UpdateItemUseCase(IItemRepository repository) => _repository = repository;

        public Item? Execute(int id, RequestBodyItemJson json) => _repository.Update(id, json);
    }
}
