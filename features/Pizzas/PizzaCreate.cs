using Domain.Pizzas;
using Microsoft.AspNetCore.Mvc;
using webapi.core.IFeatureModule;
using webapi.core.repository;

namespace webapi.Features.Pizzas
{
    public readonly record struct IngredientRequest(string Name, decimal Cost);

    public readonly record struct IngredientResponse(Guid Id, string Name);

    public readonly record struct PizzaRequest(
        string Name,
        string Description,
        string Url,
        IEnumerable<IngredientRequest> Ingredients
    );

    public readonly record struct PizzaResponse(
        Guid Id,
        string Name,
        string Description,
        string Url,
        decimal Price,
        IEnumerable<IngredientResponse> Ingredients
    );

    public class PizzaCreate : IFeatureModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/pizzas", (
                IAdd<Pizza> repositoryPizza,
                IRepository<Ingredient, Guid> repositoryIngredient,
                [FromBody] PizzaRequest request) =>
            {
                var ingredients = new List<Ingredient>();

                foreach (var req in request.Ingredients)
                {
                    var ingredient = Ingredient.Create(req.Name, req.Cost);
                    repositoryIngredient.Add(ingredient);
                    ingredients.Add(ingredient);
                }

                var pizza = Pizza.Create(request.Name, request.Description, request.Url, ingredients);
                repositoryPizza.Commit();
                repositoryPizza.Add(pizza);

                var response = new PizzaResponse(
                    pizza.Id,
                    pizza.Name,
                    pizza.Description,
                    pizza.Url,
                    pizza.Price,
                    pizza.Ingredients.Select(i => new IngredientResponse(i.Id, i.Name))
                );

                return Results.Created("pizza creada", response);
            });
        }
    }
}
