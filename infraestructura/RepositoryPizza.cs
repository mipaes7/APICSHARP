using webapi.core.ioc;
using webapi.core.repository;
using Domain.Pizzas;
using Microsoft.EntityFrameworkCore;


namespace webapi.infraestructura
{

    [Injectable]
    public class RepositoryPizza : IRepository<Pizza, Guid>
    {
        private readonly PizzaDbContext _DataBase;
        public RepositoryPizza(PizzaDbContext DataBase)
        {
            _DataBase = DataBase;
        }
        DbSet<Pizza> IDatabase<Pizza>.Data => _DataBase.Pizzas;
        public void Commit()
        {
            _DataBase.SaveChanges();
        }
    }
}