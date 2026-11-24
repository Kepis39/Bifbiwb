using Bibliotekaapi.Abstractions;
using Bibliotekaapi.Models;
using Bibliotekaapi.Models.Data;
using Bibliotekaapi.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,

            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,

            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IMemoryCache>(new MemoryCache(new MemoryCacheOptions
{
    TrackStatistics = true,
    SizeLimit = 50,
}));

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICommonService<Book, int>, BooksService>();
builder.Services.AddScoped<BooksService>();

builder.Services.AddScoped<ICommonService<Reader, int>, ReadersService>();
builder.Services.AddScoped<ReadersService>();

builder.Services.AddScoped<ICommonService<Issue, int>, IssuesService>();
builder.Services.AddScoped<IssuesService>();

builder.Services.AddScoped<ICommonService<Copy, string>, CopiesService>();
builder.Services.AddScoped<CopiesService>();

builder.Services.AddScoped<ICommonService<ThematicCatalog, int>, ThematicCatalogsService>();
builder.Services.AddScoped<ThematicCatalogsService>();

builder.Services.AddScoped<ICommonService<BookCatalog, int>, BookCatalogsService>();
builder.Services.AddScoped<BookCatalogsService>();

builder.Services.AddScoped<AuthService, AuthService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddResponseCaching();

var app = builder.Build();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.UseResponseCaching();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
