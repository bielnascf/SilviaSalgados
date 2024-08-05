using Business;
using Business.Interface;
using DAO;
using DAO.Interface;
using Infra.Context;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddScoped<ICarrinhoBusiness, CarrinhoBusiness>();
builder.Services.AddScoped<IPedidoBusiness, PedidoBusiness>();
builder.Services.AddScoped<ISalgadoBusiness, SalgadoBusiness>();
builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
builder.Services.AddScoped<IUsuarioDAO, UsuarioDAO>();
builder.Services.AddScoped<ISalgadoDAO, SalgadoDAO>();
builder.Services.AddScoped<ICarrinhoDAO, CarrinhoDAO>();
builder.Services.AddScoped<IPedidoDAO, PedidoDAO>();

builder.Services.AddDbContext<SilviaSalgadosDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
            options.SlidingExpiration = true;
            options.LogoutPath = "/Account/Logout";
            options.Cookie.Name = "SilviaSalgadosCookie";
        });

builder.Services.AddAuthorization();
builder.Services.AddMvc();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
