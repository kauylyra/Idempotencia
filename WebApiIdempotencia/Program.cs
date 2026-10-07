using IdempotentAPI.Cache.DistributedCache.Extensions.DependencyInjection;
using IdempotentAPI.Core;
using IdempotentAPI.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDistributedMemoryCache();

var idempotencyOptions = new IdempotencyOptions
{
    HeaderKeyName = "IdempotencyKey",
    ExpiresInMilliseconds = TimeSpan.FromHours(24).TotalMilliseconds,
    CacheOnlySuccessResponses = true,
    DistributedCacheKeysPrefix = "IdempAPI_"
};

builder.Services.AddIdempotentAPI(idempotencyOptions);
builder.Services.AddIdempotentAPIUsingDistributedCache();

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