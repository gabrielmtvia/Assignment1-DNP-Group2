using Application;
using Assigntment1.models;
using Blazor.Authentication;
using BlazorUI;
using BlazorUI.Pages;
using ClassLibrary1;
using Contracts;
using Contracts.ImpContracts;
using Entities.Models;

using JsonDataAccess;
// using JsonDataAccess;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<User>();
builder.Services.AddScoped<UserServiceImpl>();
builder.Services.AddScoped<JsonContext>();
builder.Services.AddScoped<IUserDao, JsonUserDao>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
// builder.Services.AddScoped<ForumContainer>();
 //builder.Services.AddScoped<JsonForumContext>();
//builder.Services.AddScoped<SubForumDao, JsonSubForumDao>();
builder.Services.AddScoped<SubForumDao, HttS>();
builder.Services.AddScoped<ISubForum, ISubForumImp>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthenticationStateProvider>();

builder.Services.AddScoped<SubForum>();

// builder.Services.AddScoped<ISubForum, HttS>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();