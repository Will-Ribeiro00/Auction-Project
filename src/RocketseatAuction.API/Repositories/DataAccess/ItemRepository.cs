using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Communication.Requests.Item;

namespace RocketseatAuction.API.Repositories.DataAccess
{
    public class ItemRepository : IItemRepository
    {
        private readonly RocketseatAuctionDbContext _dbContext;
        public ItemRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

        public Item? GetItemById(int itemId, int auctionId) => _dbContext.Items.FirstOrDefault(item => item.Id == itemId && item.AuctionId == auctionId);

        public List<Item>? GetItemsFromAnAuction(int auctionId) => [.. _dbContext.Items.Where(item => item.AuctionId.Equals(auctionId))];

        public Item Create(Item item)
        {
            _dbContext.Items.Add(item);

            _dbContext.SaveChanges();

            return item;
        }

        public Item Update(int id, RequestBodyItemJson request)
        {
            var item = _dbContext.Items.FirstOrDefault(a => a.Id.Equals(id));

            if (item == null) return null;

            item.Name = request.Name;
            item.Brand = request.Brand;
            item.BasePrice = request.BasePrice;
            item.Condition = request.Condition;

            _dbContext.SaveChanges();

            return item;
        }

        public bool Delete(int id)
        {
            var item = _dbContext.Items.FirstOrDefault(item => item.Id.Equals(id));

            if (item is null) return false;

            _dbContext.Items.Remove(item);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
