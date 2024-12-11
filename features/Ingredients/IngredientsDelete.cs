using Domain.Pizzas;
using Microsoft.AspNetCore.Mvc;
using webapi.core.IFeatureModule;
using webapi.core.repository;

namespace webapi.Features.Ingredients
{
    public class IngredientDelete : IFeatureModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/ingredients/{id}", (
                IRemove<Ingredient, Guid> repository,
                [FromRoute] Guid id
            ) =>
            {
                var ingredient = repository.Get(id);
                repository.Remove(ingredient);
                return Results.NoContent();
            });
        }
    }
}
