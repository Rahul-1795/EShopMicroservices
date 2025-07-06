var builder = WebApplication.CreateBuilder(args);

// add services to the container

builder.Services.AddCarter();
builder.Services.AddMediatR(confg =>
{
    confg.RegisterServicesFromAssembly(typeof(Program).Assembly);    
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<Product>().Identity(x => x.Id);
})
.UseLightweightSessions();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var store = scope.ServiceProvider.GetRequiredService<IDocumentStore>();
    await store.Storage.ApplyAllConfiguredChangesToDatabaseAsync();
    // This applies tables, indexes, etc. that you've configured.
}


// confg pipeline

app.MapCarter();

app.Run();
