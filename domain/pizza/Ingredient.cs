
namespace Domain.Pizzas;
using webapi.core.entitybase;

public class Ingredient: EntityBase{

    public string Name {get;set;}
    public decimal Cost {get;set;}
    protected Ingredient(Guid id,string name,decimal cost):base(id){
        Name = name;
        Cost = cost;
    }
    public void Update(string name,decimal cost){
        Name = name;
        Cost = cost;
    }
    public static Ingredient Create(string name,decimal cost){
        return new Ingredient(Guid.NewGuid(), name, cost);
    }

}