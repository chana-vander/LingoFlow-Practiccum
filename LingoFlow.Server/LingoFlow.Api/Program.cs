using LingoFlow.Core.Services;
using LingoFlow.Service;
using LingoFlow.Core.Repositories;
using LingoFlow.Data.Repositories;
using LingoFlow.Data;
using LingoFlow.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// הוספת `IUserService` ל-DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<ISubjectService,SubjectService>();
builder.Services.AddScoped<IWordService, WordService>();

// הוספת `IUserRepository` ל-DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IWordRepository,WordRepository>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
