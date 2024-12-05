using Autofac;
using GicBackend.DataObjects;
using GicBackend.Services.AutofacServices;
using GicBackend.Services.DbServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsPolicy = "Dammit CORS!";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://localhost:3000");
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(corsPolicy);

// Stuck this here to init the DB. Would not do this in production >_<
using (var scope = DbSeederRegistrar.GetModules(typeof(Cafe)))
{
    var dbSeeder = scope.Resolve<IDbSeeder>();
    dbSeeder.SetupTable();
    dbSeeder.SeedTable();
    var result = dbSeeder.TestSeedData();
}

using (var scope = DbSeederRegistrar.GetModules(typeof(Employee)))
{
    var dbSeeder = scope.Resolve<IDbSeeder>();
    dbSeeder.SetupTable();
    dbSeeder.SeedTable();
    var result = dbSeeder.TestSeedData();
}

using (var scope = DbSeederRegistrar.GetModules(typeof(EmployeeCafeLink)))
{
    var dbSeeder = scope.Resolve<IDbSeeder>();
    dbSeeder.SetupTable();
    dbSeeder.SeedTable();
    var result = dbSeeder.TestSeedData();
}

app.Run();