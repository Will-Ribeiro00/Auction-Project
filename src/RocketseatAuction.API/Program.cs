using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Repositories.DataAccess;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Auctions.Create;
using RocketseatAuction.API.UseCases.Auctions.Delete;
using RocketseatAuction.API.UseCases.Auctions.GetAll;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Auctions.Update;
using RocketseatAuction.API.UseCases.Items.Create;
using RocketseatAuction.API.UseCases.Items.Delete;
using RocketseatAuction.API.UseCases.Items.GetById;
using RocketseatAuction.API.UseCases.Items.GetFromAnAuction;
using RocketseatAuction.API.UseCases.Items.Update;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using RocketseatAuction.API.UseCases.Users.Create;
using RocketseatAuction.API.UseCases.Users.Delete;
using RocketseatAuction.API.UseCases.Users.GetById;
using RocketseatAuction.API.UseCases.Users.Update;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below;
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<AuthenticationUserAttibute>();
builder.Services.AddScoped<ILoggedUser, LoggedUser>();

builder.Services.AddScoped<CreateOfferUseCase>();

builder.Services.AddScoped<CreateAuctionUseCase>();
builder.Services.AddScoped<GetCurrentAuctionUseCase>();
builder.Services.AddScoped<GetAllAuctionUseCase>();
builder.Services.AddScoped<UpdateAuctionUseCase>();
builder.Services.AddScoped<DeleteAuctionUseCase>();

builder.Services.AddScoped<GetItemByIdUseCase>();
builder.Services.AddScoped<GetItemsFromAnAuctionUseCase>();
builder.Services.AddScoped<CreateItemUseCase>();
builder.Services.AddScoped<UpdateItemUseCase>();
builder.Services.AddScoped<DeleteItemUseCase>();

builder.Services.AddScoped<GetUserById>();
builder.Services.AddScoped<GetAllUsersUseCase>();
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<UpdateUserUseCase>();
builder.Services.AddScoped<DeleteUserUseCase>();




builder.Services.AddDbContext<RocketseatAuctionDbContext>(options =>
{
    options.UseSqlite(@"Data Source=C:\Users\willi\OneDrive\Ambiente de Trabalho\Back End\Auction Project\leilaoDbNLW.db");
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
