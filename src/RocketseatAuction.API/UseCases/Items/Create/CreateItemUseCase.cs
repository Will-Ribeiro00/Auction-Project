using RocketseatAuction.API.Communication.Requests.Item;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;

namespace RocketseatAuction.API.UseCases.Items.Create
{
    public class CreateItemUseCase
    {
        private readonly IItemRepository _repository;
        public CreateItemUseCase(IItemRepository repository) => _repository = repository;

        public Item? Execute(int id, RequestBodyItemJson request)
        {
            var item = new Item
            {
                Name = request.Name,
                Brand = request.Brand,
                BasePrice = request.BasePrice,
                Condition = request.Condition,
                AuctionId = id
            };

            return _repository.Create(item);

        }
    }
}
