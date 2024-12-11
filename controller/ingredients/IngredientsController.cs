// using Domain.Pizzas;
// using Microsoft.AspNetCore.Mvc;


// [ApiController]
// [Route("[controller]")]
// public class IngredientsController : ControllerBase
// {
//     public readonly record struct IngredientRequest(string Name, decimal Cost);

//     public record struct IngredientResponse(string Name, decimal Cost, Guid Id);

//     [HttpPost]
//     public ActionResult<Ingredient> Create([FromBody] IngredientRequest ingredientRequest)
//     {
//         var ingredient = Ingredient.Create(ingredientRequest.Name, ingredientRequest.Cost);

//         var response = new IngredientResponse(ingredient.Name, ingredient.Cost, ingredient.Id);

//         return StatusCode(201, response);
//     }
// }