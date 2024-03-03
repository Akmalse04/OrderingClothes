var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapControllers();
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

////Routing

//// "shirts"
//app.MapGet("/shirts", () =>
//{
//    return "Reading all the shirts";
//});
//app.MapGet("/shirts/{id}", (int id) =>
//{
//    return $"Return shirt with Id: {id}";
//});
//app.MapPost("/shirts", () =>
//{
//    return "Creating shirt.";
//});
//app.MapPut("/shirts/{id}", (int id) =>
//{
//    return $"Updating shirt with Id:{id}";
//});
//app.MapDelete("/shirts/{id}", (int id) =>
//{
//    return $"Deleting shirt with Id:{id}";
//});
app.Run();

