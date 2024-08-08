using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests.Auction;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.Create;
using RocketseatAuction.API.UseCases.Auctions.Delete;
using RocketseatAuction.API.UseCases.Auctions.GetAll;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Auctions.Update;

namespace RocketseatAuction.API.Controllers;

public class AuctionController : RocketseatAuctionBaseController
{
    [HttpGet]
    [Route("Get Current")]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {

        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }

    [HttpGet]
    [Route("Get All")]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAllAuction([FromServices] GetAllAuctionUseCase useCase)
    {
        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateAuction([FromBody] RequestBodyAuctionJson request,
                                       [FromServices] CreateAuctionUseCase useCase)
    {
        var auction = useCase.Execute(request);

        return Created(string.Empty, auction);
    }

    [HttpPut]
    [Route("{auctionId}")]
    public IActionResult UpdateAuction([FromRoute] int auctionId,
                                       [FromBody] RequestBodyAuctionJson request,
                                        [FromServices] UpdateAuctionUseCase useCase)
    {
        var id = useCase.Execute(auctionId, request);
        
        if (id is null) 
            return NoContent();

        return Ok(id);
    }

    [HttpDelete]
    [Route("{auctionId}")]
    public IActionResult DeleteAuction([FromRoute] int auctionId,
                                        [FromServices] DeleteAuctionUseCase useCase)
    {
        
        var result = useCase.Execute(auctionId);

        if (!result)
            return NoContent();

        return Ok("auction successfully deleted");
    }
}
