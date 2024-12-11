using webapi.core.exceptions;
using webapi.core.IFeatureModule;
using webapi.core.ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddInjectables();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// builder.Services.AddScoped<IRepository<Ingredient, Guid>, RepositoryIngredient>();
// builder.Services.AddScoped<IGet<Ingredient, Guid>, RepositoryIngredient>();
// builder.Services.AddScoped<IUpdate<Ingredient, Guid>, RepositoryIngredient>();
// builder.Services.AddScoped<IAdd<Ingredient>, RepositoryIngredient>();
// builder.Services.AddScoped<IRemove<Ingredient, Guid>, RepositoryIngredient>();

var app = builder.Build();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }


app.UseExceptionHandler();
app.MapFeatures();
app.MapControllers();
app.Run();