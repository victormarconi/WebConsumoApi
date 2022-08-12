using Microsoft.EntityFrameworkCore;
using WebConsumoApi.DBContext;
using WebConsumoApi.Interfaces;
using WebConsumoApi.Models;
using WebConsumoApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbProdutosContext>
    (options => options.UseMySql("Server=sql10.freemysqlhosting.net; AllowLoadLocalInfile=true; DataBase=sql10511870; Uid=sql10511870;Pwd=1udxXsDDv6", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.62-0ubuntu0.14.04.1")));
//(options => options.UseMySql("Server=db4free.net; AllowLoadLocalInfile=true; DataBase=produtos; Uid=rooteradmin;Pwd=rootadmin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30")));
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
