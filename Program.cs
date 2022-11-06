using LMSProject.Models;
using LMSProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors", opts =>
        {
            opts.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddDbContext<LmsContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Loandb"));
});
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRepo<int, UserDetails>, UserDetailsRepo>();
builder.Services.AddScoped<IRepo<string, Documents>, DocumentsRepo>();
builder.Services.AddScoped<ILoan<int, LoanDetails>, LoanDetailsRepo>();
builder.Services.AddScoped<IRepo<string, Login>, LoginRepo>();
builder.Services.AddScoped<ITokenService, TokenService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseCors("MyCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
