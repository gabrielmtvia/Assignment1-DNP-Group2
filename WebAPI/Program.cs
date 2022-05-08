using Application;
using Contracts;
using Contracts.ImpContracts;
using EfcData;
using JsonDataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISubForum, ISubForumImp>();
//builder.Services.AddScoped<SubForumDao, JsonSubForumDao>();
builder.Services.AddScoped<SubForumDao, SubForumDAO>();
builder.Services.AddDbContext<Context>();
var app = builder.Build();

//Here, we use a "using block", meaning that the ctx variable is disposed at the last " } ".

//The first time we run the Web API, the database will be seeding. On subsequent runs, there is already data present, so nothing happens.
using (Context ctx = new())
{
    ctx.Seed();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();