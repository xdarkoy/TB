using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Repositories;
using Server.Services;
using AutoMapper;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Serilog configuration
builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var contacts = app.MapGroup("/api/contacts");

contacts.MapGet("/", (IContactService service) => service.GetContactsAsync());
contacts.MapGet("/{id:int}", (int id, IContactService service) => service.GetByIdAsync(id));
contacts.MapPost("/", (ContactDto dto, IContactService service) => service.CreateAsync(dto));
contacts.MapPut("/{id:int}", (int id, ContactDto dto, IContactService service) => service.UpdateAsync(id, dto));
contacts.MapDelete("/{id:int}", (int id, IContactService service) => service.DeleteAsync(id));

app.Run();

