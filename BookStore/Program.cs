using BookStore.Context;
using BookStore.Filters;
using BookStore.RouteConstraints;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => 
{
    //adicionando um filtro global na aplica��o, filtro da pasta Filters
    options.Filters.Add<LogActionFilter>();

});

// Add Restri��es de rota para a aplica��o
builder.Services.AddRouting(options =>
    options.ConstraintMap.Add("values", typeof(ValuesConstraint)));


builder.Services.AddDbContext<BookStoreDataContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreConnectionString")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

