using RocketseatAuction.API.Communication.Requests.Auction;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Auctions.Create
{
    public class CreateAuctionUseCase
    {
        private readonly IAuctionRepository _repository;
        public CreateAuctionUseCase(IAuctionRepository repository) => _repository = repository;

        public Auction Execute(RequestBodyAuctionJson request)
        {
            var auction = new Auction()
            {
                Name = request.Name,
                Starts = request.Start,
                Ends = request.End
            };

            _repository.Create(auction);

            return auction;
        }
    }
}
