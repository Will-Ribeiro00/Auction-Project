using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests.User;
using RocketseatAuction.API.UseCases.Users.Create;
using RocketseatAuction.API.UseCases.Users.Delete;
using RocketseatAuction.API.UseCases.Users.GetById;
using RocketseatAuction.API.UseCases.Users.Update;

namespace RocketseatAuction.API.Controllers
{
    public class UserController : RocketseatAuctionBaseController
    {

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserById([FromRoute] int userId,
                                         [FromServices] GetUserById useCase)
        {
            var user = useCase.Execute(userId);

            if (user is null)
                return NoContent();

            return Ok(user);
        }

        [HttpGet]
        [Route("Get All")]
        public IActionResult GetAllUsers([FromServices] GetAllUsersUseCase useCase)
        {
            return Ok(useCase.Execute());
        }

        [HttpPost]
        public IActionResult Create([FromBody] RequestBodyUserJson request,
                                    [FromServices] CreateUserUseCase useCase)
        {
            var user = useCase.Execute(request);
            if (user is null)
                return NoContent();

            return Created(string.Empty, user);
        }

        [HttpPut]
        [Route("{userId}")]
        public IActionResult UpdateAuction([FromRoute] int userId,
                                       [FromBody] RequestBodyUserJson request,
                                       [FromServices] UpdateUserUseCase useCase)
        {

            var user = useCase.Execute(userId, request);

            if (user is null)
                return NoContent();

            return Ok(user);
        }

        [HttpDelete]
        [Route("{userId}")]
        public IActionResult DeleteAuction([FromRoute] int userId,
                                        [FromServices] DeleteUserUseCase useCase)
        {

            var result = useCase.Execute(userId);

            if (!result)
                return NoContent();

            return Ok("User successfully deleted");
        }
    }
}
