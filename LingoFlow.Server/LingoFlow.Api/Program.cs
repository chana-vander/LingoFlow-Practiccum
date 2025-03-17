using LingoFlow.Core.Services;
using LingoFlow.Service;
using LingoFlow.Core.Repositories;
using LingoFlow.Data.Repositories;
using LingoFlow.Data;
using LingoFlow.Core.Models;
using LingoFlow.Core;
using AutoMapper;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
//using AutoMapper.Extensions.Microsoft.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// הוספת `IUserService` ל-DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IWordService, WordService>();

// הוספת `IUserRepository` ל-DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IWordRepository, WordRepository>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//dto&aoto mapper
//builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfile));

//jwt:
//var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var key2 = builder.Configuration["Jwt:Key"];
Console.WriteLine($"Loaded JWT Key: {key2}");
//swagger:
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
