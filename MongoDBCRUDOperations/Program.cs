using Microsoft.Extensions.Options;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDBCRUDOperations.Models;
using MongoDBCRUDOperations.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton<IMongoClient,MongoClient>(op =>
{
    var mongoSettings = op.GetRequiredService<MongoSettings>();
    return new MongoClient(mongoSettings.ConnectionString);
});
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddSingleton<MongoSettings>(sp =>
    sp.GetRequiredService<IOptions<MongoSettings>>().Value);

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
