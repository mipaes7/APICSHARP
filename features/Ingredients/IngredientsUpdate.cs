using Domain.Pizzas;
using Microsoft.AspNetCore.Mvc;
using webapi.core.IFeatureModule;
using webapi.core.repository;


namespace webapi.Features.Ingredients
{
    public class IngredientUpdate : IFeatureModule
    {
        public readonly record struct IngredientRequest(string Name, decimal Cost);

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/ingredients/{id}", (
                IUpdate<Ingredient, Guid> repository,
                [FromRoute] Guid id,
                [FromBody] IngredientRequest request
            ) =>
            {
                var ingredient = repository.Get(id);
                ingredient.Update(request.Name, request.Cost);
                repository.Update(ingredient);
                return Results.NoContent();
            });
        }
    }
}