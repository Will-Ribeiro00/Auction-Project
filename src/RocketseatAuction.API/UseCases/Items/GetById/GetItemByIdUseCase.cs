using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Items.GetById
{
    public class GetItemByIdUseCase
    {
        private readonly IItemRepository _repository;
        public GetItemByIdUseCase(IItemRepository repository) => _repository = repository;

        public Item? Execute(int itemId, int auctionId) => _repository.GetItemById(itemId, auctionId);
    }
}
