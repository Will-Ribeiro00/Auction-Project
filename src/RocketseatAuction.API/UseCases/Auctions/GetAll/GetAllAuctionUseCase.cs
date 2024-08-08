using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Auctions.GetAll
{
    public class GetAllAuctionUseCase
    {
        private readonly IAuctionRepository _repository;
        public GetAllAuctionUseCase(IAuctionRepository repository) => _repository = repository;

        public List<Auction> Execute() => _repository.GetAll();
    }
}
