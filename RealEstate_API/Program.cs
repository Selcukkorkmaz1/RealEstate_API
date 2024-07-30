using RealEstate_API.Models.DapperContext;
using RealEstate_API.Repositories.BottomGridRepositories;
using RealEstate_API.Repositories.CategoryRepositories;
using RealEstate_API.Repositories.ProductRepositories;
using RealEstate_API.Repositories.ServiceRepositories;
using RealEstate_API.Repositories.WhoWeAreRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreRepository, WhoWeAreRepository>();
builder.Services.AddTransient<IServicesRepository, ServicesRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
