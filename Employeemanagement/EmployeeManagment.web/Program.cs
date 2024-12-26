using BlazorApp_EmployeeList.services;
using EmployeeManagment.web;
using EmployeeManagment.web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7222/");
});
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>

{

    client.BaseAddress = new Uri("https://localhost:7222/");

});


await builder.Build().RunAsync();
