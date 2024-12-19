var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseMiddleware<UserManagementAPIDoneByCoPilot.Middleware.ExceptionHandlingMiddleware>();
app.UseMiddleware<UserManagementAPIDoneByCoPilot.Middleware.TokenValidationMiddleware>();
app.UseMiddleware<UserManagementAPIDoneByCoPilot.Middleware.RequestLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
