using Microsoft.EntityFrameworkCore;
using WebConsumoApi.Interfaces;
using WebConsumoApi.Models;
using WebConsumoApi.Models.ViewModels;
using WebConsumoApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbProdutosContext>
    (options => options.UseSqlServer("Server=LAPTOP-SN3G0PN2\\SQLEXPRESS; DataBase=DbProdutos;Integrated Security=true"));
builder.Services.AddScoped<IProduto, RepositoryProduto>();
builder.Services.AddSingleton<IProductDB, RepositoryProductDB>();

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
