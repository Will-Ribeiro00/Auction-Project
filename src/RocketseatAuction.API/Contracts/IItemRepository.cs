using RocketseatAuction.API.Communication.Requests.Item;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts
{
    public interface IItemRepository
    {
        Item? Create(Item item);
        Item? GetItemById(int itemId, int auctionId);
        List<Item>? GetItemsFromAnAuction(int auctionId);
        Item Update(int id, RequestBodyItemJson request);
        bool Delete(int id);
    }
}
