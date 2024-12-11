using Domain.Pizzas;
using Microsoft.AspNetCore.Mvc;
using webapi.core.IFeatureModule;
using webapi.core.repository;
namespace webapi.Features.Ingredients
{

    public readonly record struct IngredientRequest(string Name, decimal Cost)
    {

    }

    public readonly record struct IngredientResponse(Guid Id, string Name, decimal Cost)
    {

    }
    public class IngredientCreate : IFeatureModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {            
            app.MapPost("/ingredients", (IAdd<Ingredient> repository,
            [FromBody] IngredientRequest request)=>{
                var ingredient = Ingredient.Create(request.Name, request.Cost);
                repository.Add(ingredient);
                var response = new IngredientResponse(ingredient.Id, ingredient.Name, ingredient.Cost);
                return Results.Created("",response);                
            });
        }
    }
}