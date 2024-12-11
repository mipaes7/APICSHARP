using webapi.core.ioc;
using webapi.core.repository;
using Domain.Pizzas;


namespace webapi.infraestructura
{
    
    [Injectable]
    public class RepositoryPizza : IRepository<Pizza, Guid>
    {
        private static readonly ISet<Pizza> data = new HashSet<Pizza>();
        ICollection<Pizza> IDatabase<Pizza>.Data => data;
    }
}