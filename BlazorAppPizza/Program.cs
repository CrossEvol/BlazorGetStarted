using BlazorAppPizza.Components;
using BlazorAppPizza.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add the AppState class
builder.Services.AddScoped<PizzaSalesState>();

// Register the pizzas service
builder.Services.AddSingleton<PizzaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorPages();
app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
	if (db.Database.EnsureCreated())
	{
		SeedData.Initialize(db);
	}
}

app.Run();
