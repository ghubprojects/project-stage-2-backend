using Microsoft.AspNetCore.Mvc;
using MISA.SME2023.API;
using MISA.SME2023.BL;
using MISA.SME2023.Common;
using MISA.SME2023.DL;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;

    // configure database settings
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    // Add dependency injection
    services.AddBusinessLayer();

    services.AddMvc().ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            return new BadRequestObjectResult(new BaseException()
            {
                ErrorCode = StatusCodes.Status400BadRequest,
                UserMessage = "Yêu cầu không hợp lệ",
                DevMessage = "Bad request",
                TraceId = context.HttpContext.TraceIdentifier,
                Errors = context.ModelState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(error => error.ErrorMessage).ToArray())
            });
            ;
        };
    });

    services.AddCors();
    services.AddControllers().AddJsonOptions((options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; }));

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.UseMiddleware<ErrorHandlerMiddleware>();

    // global cors policy
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    app.Run();
}