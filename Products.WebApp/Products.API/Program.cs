using Microsoft.EntityFrameworkCore;
using Products.Bll;
using Products.Bll.Interfaces;
using Products.Bll.Services;
using Products.Dal;
using Products.Dal.Interfaces;
using Products.Dal.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(BllAssemblyMarker));
builder.Services.AddDbContext<ProductsDbContext>(optionBuilder =>
{
    optionBuilder.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
