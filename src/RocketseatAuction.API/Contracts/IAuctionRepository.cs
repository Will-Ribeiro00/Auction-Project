using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests.Auction;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
    void Create(Auction auction);
    List<Auction> GetAll();
    Auction? Update(int id, RequestBodyAuctionJson request);
    bool Delete(int id);
}
