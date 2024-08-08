using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests.Item;
using RocketseatAuction.API.UseCases.Items.Create;
using RocketseatAuction.API.UseCases.Items.Delete;
using RocketseatAuction.API.UseCases.Items.GetById;
using RocketseatAuction.API.UseCases.Items.GetFromAnAuction;
using RocketseatAuction.API.UseCases.Items.Update;

namespace RocketseatAuction.API.Controllers
{
    public class ItemController : RocketseatAuctionBaseController
    {
        [HttpGet]
        [Route("{itemId}/{auctionId}")]
        public IActionResult GetItemById([FromRoute] int itemId,
                                         [FromRoute] int auctionId,
                                         [FromServices] GetItemByIdUseCase useCase)
        {
            var item = useCase.Execute(itemId, auctionId);

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpGet]
        [Route("{auctionId}")]
        public IActionResult GetItemsFromAnAuction([FromRoute] int auctionId,
                                                   [FromServices] GetItemsFromAnAuctionUseCase useCase)
        {
            var items = useCase.Execute(auctionId);

            return items.Count == 0 ? NoContent() : Ok(items);
        }

        [HttpPost]
        [Route("{auctionId}")]
        public IActionResult CreateItem([FromRoute] int auctionId,
                                        [FromBody] RequestBodyItemJson json,
                                        [FromServices] CreateItemUseCase useCase)
        {
            var item = useCase.Execute(auctionId, json);

            if (item is null) 
                return NoContent();

            return Created(string.Empty, item);
        }

        [HttpPut]
        [Route("{itemId}")]
        public IActionResult UpdateItem([FromRoute] int itemId,
                                        [FromBody] RequestBodyItemJson json,
                                        [FromServices] UpdateItemUseCase useCase)
        {
            var item = useCase.Execute(itemId, json);

            if (item is null)
                return NoContent();

            return Ok(item);
        }

        [HttpDelete]
        [Route("{itemId}")]
        public IActionResult DeleteItem([FromRoute] int itemId,
                                        [FromServices] DeleteItemUseCase useCase)
        {
            var result = useCase.Execute(itemId);

            if(!result)
                return NoContent();

            return Ok("Item successfully deleted");
        }

    }
}
