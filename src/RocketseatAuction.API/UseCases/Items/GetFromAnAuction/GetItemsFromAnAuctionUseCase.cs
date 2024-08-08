using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Items.GetFromAnAuction
{
    public class GetItemsFromAnAuctionUseCase
    {
        private readonly IItemRepository _Repository;
        public GetItemsFromAnAuctionUseCase(IItemRepository repository) => _Repository = repository;

        public List<Item>? Execute(int auctionId) => _Repository.GetItemsFromAnAuction(auctionId);
    }
}
