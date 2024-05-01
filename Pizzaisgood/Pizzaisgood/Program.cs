
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Pizzaisgood;
using Pizzaisgood.Components;
using Pizzaisgood.Data;
using Pizzaisgood.Data.BlazorViewDataModel;
using Pizzaisgood.Data.Databasecrud;
using Pizzaisgood.InmemoryDatasingleton;
using Pizzaisgood.Data.Loginlogic;
using Microsoft.AspNetCore.HttpOverrides;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.Name = "pizza_is_good";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(10);
        options.Validate();
       // options.AccessDeniedPath = "/deci"; 
        

    });


builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddBlazorBootstrap();


var connectionString = builder.Configuration.GetConnectionString("mysqldatabase") ?? throw new InvalidOperationException("Connection string 'mysqldatabase' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
     options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));


builder.Services.AddSingleton<IAdminpagedatasingleton, Adminpagedatasingleton>();
builder.Services.AddScoped<ICrudController,CrudApplication>();
builder.Services.AddSingleton<ILogindata,Logindata>();


builder.Services.AddHttpClient<Generatefakedata>();
builder.Services.AddScoped<blazorviewPaymentForm>();



builder.Services.AddScoped<Orderlist>();


var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

await app.UseMemoryFill();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Pizzaisgood.Client._Imports).Assembly);

app.Run();
