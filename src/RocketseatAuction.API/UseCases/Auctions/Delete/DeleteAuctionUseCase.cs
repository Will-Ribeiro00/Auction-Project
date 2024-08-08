using RocketseatAuction.API.Contracts;

namespace RocketseatAuction.API.UseCases.Auctions.Delete
{
    public class DeleteAuctionUseCase
    {
        private readonly IAuctionRepository _repository;
        public DeleteAuctionUseCase(IAuctionRepository repository) => _repository = repository;

        public bool Execute(int id) => _repository.Delete(id);
    }
}
