using Domain.Pizzas;
using Microsoft.AspNetCore.Mvc;
using webapi.core.IFeatureModule;
using webapi.core.repository;

namespace webapi.Features.Ingredients
{
    public class IngredientGet : IFeatureModule
    {
        public readonly record struct IngredientResponse(Guid Id, string Name, decimal Cost)
        {

        }
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/ingredients/{id}", (
                IGet<Ingredient, Guid> repository,
                [FromRoute] Guid id
            ) =>
            {
                var ingredient = repository.Get(id);
                var response = new IngredientResponse(ingredient.Id, ingredient.Name, ingredient.Cost);
                return Results.Ok(response);
            });

            app.MapGet("/ingredients", (
                IQuery<Ingredient> repository,
                [FromQuery] string? name,
                [FromQuery] int page = 1,
                [FromQuery] int size = 10
            ) =>
            {
                var res = repository.Query;
                if(name != null || name != "") res = res.Where(i =>(name == null) || i.Name.ToLower().Contains(name.ToLower())).ToList();
                var pagination = res.Skip((page - 1) * size).Take(size);
                return Results.Ok(pagination);
            });
        }
    }
}