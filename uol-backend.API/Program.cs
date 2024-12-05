using uol_backend.API.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();
builder.Services.AddDatabase();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddGlobalWebApplicationConfig();
