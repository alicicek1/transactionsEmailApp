using BankingApplication.Application.Services.Transaction;
using BankingApplication.Application.Services.Email;
using BankingApplication.Application.Services.PdfGeneration;
using BankingApplication.Transactions.Database.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDatabase, Database>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IPdfGenerationService, PdfGenerationService>();

builder.Services.AddScoped<ITransactionsService, TransactionsService>();

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