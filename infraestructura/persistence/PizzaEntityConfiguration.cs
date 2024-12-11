using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Pizzas;

namespace webapi.infraestructura.persistence;

public class PizzaEntityfiguration : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.ToTable("Pizza");

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Ingredients)
            .WithMany();

    }
}