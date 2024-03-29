using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CellSystem.Client;
using CellSystem.Client.Manager;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUsuarioRolManager,UsuarioRolManager>();
builder.Services.AddScoped<IClienteManager,ClienteManager>();
builder.Services.AddScoped<IFacturarManager,FacturarManager>();
builder.Services.AddScoped<IProductosManager,ProductosManager>();
await builder.Build().RunAsync();
