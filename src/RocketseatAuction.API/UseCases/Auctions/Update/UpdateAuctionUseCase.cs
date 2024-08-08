using RocketseatAuction.API.Communication.Requests.Auction;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Auctions.Update
{
    public class UpdateAuctionUseCase
    {
        private readonly IAuctionRepository _repository;
        public UpdateAuctionUseCase(IAuctionRepository repository) => _repository = repository;

        public Auction Execute(int id, RequestBodyAuctionJson request) => _repository.Update(id, request);
    }
}
