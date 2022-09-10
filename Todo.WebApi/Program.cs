using Todo.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Init Database
DatabaseContext.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
DatabaseContext.DatabaseName = builder.Configuration.GetSection("MongoConnection:Database").Value;
DatabaseContext.IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("MongoConnection:IsSSL").Value);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();