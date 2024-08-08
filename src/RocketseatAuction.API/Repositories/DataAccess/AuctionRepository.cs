using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Communication.Requests.Auction;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
   private readonly RocketseatAuctionDbContext _dbContext;
   public AuctionRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _dbContext
           .Auctions
           .Include(auction => auction.Items)
           .Where(auction => auction.Starts <= today && auction.Ends >= today)
           .FirstOrDefault();
    }

    public List<Auction> GetAll()
    {
        return [.. _dbContext.Auctions.OrderBy(a => a.Id)];
    }

    public void Create(Auction auction)
    {
        _dbContext.Auctions.Add(auction);

        _dbContext.SaveChanges();
    }

    public Auction? Update(int id, RequestBodyAuctionJson request)
    {
        var auction = _dbContext.Auctions.FirstOrDefault(a => a.Id.Equals(id));

        if (auction == null) return null;

        auction.Name = request.Name;
        auction.Starts = request.Start;
        auction.Ends = request.End;

        _dbContext.SaveChanges();

        return auction;
    }

    public bool Delete(int id)
    {
        var auction = _dbContext.Auctions.FirstOrDefault(a => a.Id.Equals(id));

        if (auction is null) return false;

        _dbContext.Auctions.Remove(auction);
        _dbContext.SaveChanges();
        return true;
    }
}
